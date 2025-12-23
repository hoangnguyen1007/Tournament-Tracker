using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TeamListForm
{
    // Class phụ hỗ trợ lấy dữ liệu đội
    public class TeamStats
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class MatchGenerator
    {
        // =================================================================
        // PHẦN 1: TẠO VÒNG BẢNG (ROUND 1) - (Không đổi)
        // =================================================================
        public static void GenerateRound1(int tournamentId)
        {
            int numGroups = DatabaseHelper.GetTournamentGroupCount(tournamentId);
            var teams = DatabaseHelper.GetTeams(tournamentId);

            // Check logic: 2 bảng cần >= 4 đội, 4 bảng cần >= 8 đội...
            if (teams.Count < numGroups * 2)
            {
                MessageBox.Show($"Không đủ đội! Cần ít nhất {numGroups * 2} đội để chia {numGroups} bảng.");
                return;
            }

            bool success = DatabaseHelper.GenerateGroupStage(tournamentId, numGroups);
            if (success)
            {
                MessageBox.Show($"Đã chia ngẫu nhiên thành {numGroups} bảng đấu!", "Thành công");
            }
        }
        // =================================================================
        // PHẦN 2: TẠO VÒNG TIẾP THEO (NEXT ROUND)
        // =================================================================
        public static void GenerateNextRound(int tournamentId)
        {
            int currentRound = DatabaseHelper.GetMaxRound(tournamentId);
            if (currentRound == 0) return;

            // --- TRƯỜNG HỢP 1: TỪ VÒNG BẢNG (ROUND 1) -> KNOCKOUT (ROUND 2) ---
            if (currentRound == 1)
            {
                ProcessGroupStageToKnockout(tournamentId);
            }
            // --- TRƯỜNG HỢP 2: TỪ KNOCKOUT NÀY -> KNOCKOUT SAU (Bán kết -> Chung kết...) ---
            else
            {
                ProcessKnockoutToNext(tournamentId, currentRound);
            }
        }
        // -----------------------------------------------------------------
        // LOGIC XỬ LÝ: TỪ VÒNG BẢNG -> VÒNG 2 (Hỗ trợ 2, 4, 8 bảng)
        // -----------------------------------------------------------------
        private static void ProcessGroupStageToKnockout(int tId)
        {
            int groupCount = DatabaseHelper.GetTournamentGroupCount(tId);
            // Cứ 2 bảng liền kề (A-B, C-D, E-F...) sẽ ghép chéo Nhất-Nhì với nhau.
            int matchCreated = 0;
            // Duyệt từng cặp bảng: 0-1 (A-B), 2-3 (C-D), 4-5 (E-F)...
            for (int i = 0; i < groupCount; i += 2)
            {
                string groupName1 = ((char)('A' + i)).ToString();     // Ví dụ: A
                string groupName2 = ((char)('A' + i + 1)).ToString(); // Ví dụ: B

                // Lấy 2 đội đầu bảng mỗi bảng
                var top1_Group1 = GetTeamByRank(tId, groupName1, 0); // Nhất bảng 1
                var top2_Group1 = GetTeamByRank(tId, groupName1, 1); // Nhì bảng 1

                var top1_Group2 = GetTeamByRank(tId, groupName2, 0); // Nhất bảng 2
                var top2_Group2 = GetTeamByRank(tId, groupName2, 1); // Nhì bảng 2

                if (top1_Group1 == null || top2_Group1 == null || top1_Group2 == null || top2_Group2 == null)
                {
                    MessageBox.Show($"Bảng {groupName1} hoặc {groupName2} chưa xác định đủ 2 đội đứng đầu.");
                    return;
                }
                // TẠO TRẬN ĐẤU (Round 2)
                // Cặp 1: Nhất bảng 1 vs Nhì bảng 2
                DatabaseHelper.InsertMatch(tId, 2, 1, top1_Group1.ID, top2_Group2.ID, null);
                // Cặp 2: Nhất bảng 2 vs Nhì bảng 1
                DatabaseHelper.InsertMatch(tId, 2, 1, top1_Group2.ID, top2_Group1.ID, null);
                matchCreated += 2;
            }
            string roundName = "";
            if (matchCreated == 4) roundName = "Bán Kết ";
            else if (matchCreated == 8) roundName = "Tứ Kết";
            else if (matchCreated == 16) roundName = "Vòng 1/16";

            MessageBox.Show($"Đã tạo lịch thi đấu {roundName} thành công!\nGhép cặp theo nguyên tắc: Nhất bảng này gặp Nhì bảng kia.");
        }
        // -----------------------------------------------------------------
        // LOGIC XỬ LÝ: CÁC VÒNG KNOCKOUT TIẾP THEO
        // -----------------------------------------------------------------
        private static void ProcessKnockoutToNext(int tId, int currentRound)
        {
            // Lấy danh sách người thắng
            List<int> winners = DatabaseHelper.GetWinnersFromRound(tId, currentRound);

            if (winners.Count == 0)
            {
                MessageBox.Show("Chưa có kết quả của vòng hiện tại.");
                return;
            }
            if (winners.Count == 1)
            {
                var allTeams = DatabaseHelper.GetTeams(tId);
                var champion = allTeams.FirstOrDefault(t => t.ID == winners[0]);
                string championName = champion != null ? champion.TEAMNAME : $"Team ID {winners[0]}";
                MessageBox.Show($"🏆 CHÚC MỪNG NHÀ VÔ ĐỊCH {championName} 🏆", "KẾT THÚC");
                return;
            }
            int nextRound = currentRound + 1;
            // Để đơn giản hóa, ta ghép cặp tuần tự theo danh sách thắng
            for (int i = 0; i < winners.Count; i += 2)
            {
                if (i + 1 < winners.Count)
                {
                    DatabaseHelper.InsertMatch(tId, nextRound, 1, winners[i], winners[i + 1], null);
                }
            }
            string msg = (winners.Count == 2) ? "Chung Kết" : $"Vòng {nextRound}";
            MessageBox.Show($"Đã tạo lịch thi đấu {msg}!");
        }
        // Hàm lấy Team ID và Name từ SQL dựa trên Bảng và Thứ hạng
        private static TeamStats GetTeamByRank(int tId, string groupName, int rankIndex)
        {
            DataTable dt = DatabaseHelper.GetStandings(tId, groupName);
            if (dt.Rows.Count <= rankIndex) return null;

            DataRow row = dt.Rows[rankIndex];
            return new TeamStats
            {
                ID = Convert.ToInt32(row["TeamID"]),
                Name = row["Name"].ToString()
            };
        }
    }
}