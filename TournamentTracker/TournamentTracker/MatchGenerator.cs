using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamListForm
{
    public class MatchGenerator
    {
        public static void GenerateRound1(int tournamentId, List<int> allTeamIds)
        {
            if (allTeamIds.Count < 4) { MessageBox.Show("Cần ít nhất 4 đội."); return; }

            // Chia 2 bảng A và B
            int mid = allTeamIds.Count / 2;
            var groupA = allTeamIds.Take(mid).ToList();
            var groupB = allTeamIds.Skip(mid).ToList();

            // Hàm con tạo lịch vòng tròn
            CreateRoundRobin(tournamentId, groupA, "A");
            CreateRoundRobin(tournamentId, groupB, "B");

            MessageBox.Show("Đã tạo lịch thi đấu Vòng Bảng (Round 1)!");
        }

        private static void CreateRoundRobin(int tId, List<int> teams, string groupName)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = i + 1; j < teams.Count; j++)
                {
                    // Round 1, Type 0 (Vòng bảng)
                    DatabaseHelper.InsertMatch(tId, 1, 0, teams[i], teams[j], groupName);
                }
            }
        }

        // Tạo các vòng tiếp theo 
        public static void GenerateNextRound(int tournamentId)
        {
            int currentRound = DatabaseHelper.GetMaxRound(tournamentId);
            if (currentRound == 0) return;

            // --- KỊCH BẢN 1: TỪ VÒNG BẢNG (ROUND 1) -> KNOCKOUT (ROUND 2) ---
            if (currentRound == 1)
            {
                DataTable dtA = DatabaseHelper.GetStandingsTable(tournamentId, "A");
                DataTable dtB = DatabaseHelper.GetStandingsTable(tournamentId, "B");

                if (dtA.Rows.Count < 2 || dtB.Rows.Count < 2)
                {
                    MessageBox.Show("Các bảng đấu chưa xác định đủ Top 2.");
                    return;
                }
                // Rows[0] là Nhất bảng, Rows[1] là Nhì bảng (do SQL đã sort sẵn Rank)
                int a1 = Convert.ToInt32(dtA.Rows[0]["TeamID"]);
                int a2 = Convert.ToInt32(dtA.Rows[1]["TeamID"]);

                int b1 = Convert.ToInt32(dtB.Rows[0]["TeamID"]);
                int b2 = Convert.ToInt32(dtB.Rows[1]["TeamID"]);

                // Ghép chéo: Nhất A vs Nhì B, Nhất B vs Nhì A
                DatabaseHelper.InsertMatch(tournamentId, 2, 1, a1, b2, null);
                DatabaseHelper.InsertMatch(tournamentId, 2, 1, b1, a2, null);

                MessageBox.Show("Đã tạo lịch thi đấu Vòng 2 (Knockout)!");
                return;
            }

            // --- KỊCH BẢN 2: TỪ ROUND 2 TRỞ ĐI (KNOCKOUT -> KNOCKOUT) ---
            List<int> winners = DatabaseHelper.GetWinnersFromRound(tournamentId, currentRound);

            if (winners.Count == 0) { MessageBox.Show("Chưa có kết quả của vòng trước."); return; }
            if (winners.Count == 1) { MessageBox.Show($"Đã tìm ra VÔ ĐỊCH! Team ID: {winners[0]}"); return; }

            // Trộn ngẫu nhiên
            Random rng = new Random();
            winners = winners.OrderBy(x => rng.Next()).ToList();

            int nextRound = currentRound + 1;
            for (int i = 0; i < winners.Count; i += 2)
            {
                if (i + 1 < winners.Count)
                {
                    DatabaseHelper.InsertMatch(tournamentId, nextRound, 1, winners[i], winners[i + 1], null);
                }
            }
            MessageBox.Show($"Đã tạo lịch thi đấu Vòng {nextRound}!");
        }
    }
}
