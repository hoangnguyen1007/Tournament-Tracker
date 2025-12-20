using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TeamListForm
{
    public partial class MatchesScheduleForm : Form
    {
        // Biến lưu ID giải đấu nhận từ Form cha
        private int _tournamentId;

        // 1. SỬA CONSTRUCTOR ĐỂ NHẬN ID
        public MatchesScheduleForm(int tournamentId)
        {
            InitializeComponent();
            _tournamentId = tournamentId; // Lưu lại ID để dùng
        }

        // 2. FORM LOAD: Tải dữ liệu ngay lập tức
        private void MatchesScheduleForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Tải danh sách vòng đấu của giải này
                LoadRounds();

                // Tính toán bảng xếp hạng của giải này
                RecalculateStandings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadRounds()
        {
            // Gọi DatabaseHelper lấy các vòng đấu dựa trên ID giải (_tournamentId)
            var rounds = DatabaseHelper.GetRounds(_tournamentId);

            choiceRoundComboBox.DataSource = null;
            if (rounds.Count > 0)
            {
                choiceRoundComboBox.DataSource = rounds;
                // Khi gán DataSource, sự kiện SelectedIndexChanged sẽ tự chạy để load lưới trận đấu
            }
            else
            {
                matchesDataGridView.DataSource = null;
            }
        }

        private void choiceRoundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchesToGrid();
        }

        private void LoadMatchesToGrid()
        {
            if (choiceRoundComboBox.SelectedItem == null) return;

            string selectedRound = choiceRoundComboBox.SelectedItem.ToString();

            // Truyền ID giải đấu + Vòng đấu để lấy danh sách trận
            DataTable dt = DatabaseHelper.GetMatchesTable(_tournamentId, selectedRound);

            matchesDataGridView.AutoGenerateColumns = false;
            matchesDataGridView.DataSource = dt;
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng có chọn dòng nào không
            if (matchesDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn trận đấu cần cập nhật!");
                return;
            }

            // 2. Lấy dữ liệu từ dòng đang chọn ép kiểu về DataRowView
            DataRowView row = (DataRowView)matchesDataGridView.CurrentRow.DataBoundItem;

            // 3. Tạo object Match để truyền sang form Update
            Match m = new Match();
            m.MatchId = (int)row["MatchID"];
            m.Round = (int)row["Round"];

            // Gán tên đội (Dùng object Team tạm để chứa tên)
            m.HomeTeam = new Team { TEAMNAME = row["HomeTeamName"].ToString() };
            m.AwayTeam = new Team { TEAMNAME = row["AwayTeamName"].ToString() };

            // 4. Xử lý điểm số (Nếu null thì cho bằng 0)
            m.HomeScore = row["HomeScore"] == DBNull.Value ? 0 : (int)row["HomeScore"];
            m.AwayScore = row["AwayScore"] == DBNull.Value ? 0 : (int)row["AwayScore"];

            // 5. [QUAN TRỌNG - MỚI] Xử lý trạng thái (Đã đá hay chưa?)
            // Kiểm tra an toàn: Xem cột Status có tồn tại trong dữ liệu lấy lên không
            if (row.Row.Table.Columns.Contains("Status") && row["Status"] != DBNull.Value)
            {
                int status = Convert.ToInt32(row["Status"]);
                // Quy ước: Nếu Status = 2 nghĩa là đã kết thúc -> IsPlayed = true
                m.IsPlayed = (status == 2);
            }
            else
            {
                m.IsPlayed = false; // Mặc định là chưa đá
            }

            // 6. Mở form cập nhật (Truyền object Match vừa tạo vào)
            using (var frm = new MatchResultForm(m))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu người dùng bấm Save và OK:

                    // a. Lưu xuống Database
                    DatabaseHelper.UpdateMatchResult(m.MatchId, m.HomeScore, m.AwayScore);

                    // b. Tải lại lưới trận đấu để cập nhật điểm số mới
                    LoadMatchesToGrid();

                    // c. Tính toán lại Bảng xếp hạng ngay lập tức
                    RecalculateStandings();
                }
            }
        }

        private void RecalculateStandings()
        {
            // Lấy dữ liệu trận đấu CHỈ CỦA GIẢI NÀY
            DataTable dtMatches = DatabaseHelper.GetMatchesTable(_tournamentId, "");
            var originalTeams = DatabaseHelper.GetTeamsByTournament(_tournamentId);

            var standingsList = new List<TeamStanding>();

            // Khởi tạo danh sách team
            foreach (var team in originalTeams)
            {
                standingsList.Add(new TeamStanding { Name = team.TEAMNAME });
            }

            // Tính điểm
            foreach (DataRow row in dtMatches.Rows)
            {
                if (row["HomeScore"] == DBNull.Value || row["AwayScore"] == DBNull.Value) continue;

                int hScore = Convert.ToInt32(row["HomeScore"]);
                int aScore = Convert.ToInt32(row["AwayScore"]);
                string homeName = row["HomeTeamName"].ToString();
                string awayName = row["AwayTeamName"].ToString();

                var homeStats = standingsList.FirstOrDefault(s => s.Name == homeName);
                var awayStats = standingsList.FirstOrDefault(s => s.Name == awayName);

                if (homeStats != null && awayStats != null)
                {
                    homeStats.Played++;
                    awayStats.Played++;
                    homeStats.GF += hScore; homeStats.GA += aScore;
                    awayStats.GF += aScore; awayStats.GA += hScore;

                    if (hScore > aScore)
                    {
                        homeStats.Won++; homeStats.Points += 3;
                        awayStats.Lost++;
                    }
                    else if (aScore > hScore)
                    {
                        awayStats.Won++; awayStats.Points += 3;
                        homeStats.Lost++;
                    }
                    else
                    {
                        homeStats.Drawn++; homeStats.Points += 1;
                        awayStats.Drawn++; awayStats.Points += 1;
                    }
                }
            }

            // Sắp xếp BXH
            var sortedList = standingsList.OrderByDescending(t => t.Points)
                                          .ThenByDescending(t => t.GD)
                                          .ThenByDescending(t => t.GF)
                                          .ToList();

            // Đánh số hạng
            for (int i = 0; i < sortedList.Count; i++) sortedList[i].Rank = i + 1;

            standingsDataGridView.AutoGenerateColumns = false;
            standingsDataGridView.DataSource = sortedList;
        }

        private void InforButton_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng có chọn dòng nào không
            if (matchesDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn trận đấu để xem chi tiết!");
                return;
            }

            // 2. Lấy dữ liệu dòng đang chọn
            DataRowView row = (DataRowView)matchesDataGridView.CurrentRow.DataBoundItem;

            // 3. Tạo object Match và đổ dữ liệu vào
            Match m = new Match();
            m.MatchId = (int)row["MatchID"];
            m.Round = (int)row["Round"];

            // Lấy ID và Tên đội (Cần thiết để load cầu thủ bên Form kia)
            m.HomeTeam = new Team
            {
                ID = (int)row["HomeTeamID"],
                TEAMNAME = row["HomeTeamName"].ToString()
            };
            m.AwayTeam = new Team
            {
                ID = (int)row["AwayTeamID"],
                TEAMNAME = row["AwayTeamName"].ToString()
            };

            m.HomeScore = row["HomeScore"] == DBNull.Value ? 0 : (int)row["HomeScore"];
            m.AwayScore = row["AwayScore"] == DBNull.Value ? 0 : (int)row["AwayScore"];
            m.IsPlayed = row["HomeScore"] != DBNull.Value;

            // --- PHẦN QUAN TRỌNG: LẤY NGÀY GIỜ VÀ ĐỊA ĐIỂM TỪ DB ---

            // Kiểm tra cột MatchDate có tồn tại và có dữ liệu không
            if (row.Row.Table.Columns.Contains("MatchDate") && row["MatchDate"] != DBNull.Value)
            {
                m.MatchDate = Convert.ToDateTime(row["MatchDate"]);
            }
            else
            {
                m.MatchDate = null; // Chưa có lịch
            }

            // Kiểm tra cột Location
            if (row.Row.Table.Columns.Contains("Location") && row["Location"] != DBNull.Value)
            {
                m.Location = row["Location"].ToString();
            }
            else
            {
                m.Location = ""; // Chưa có sân
            }
            // --------------------------------------------------------

            // 4. Mở Form InfoMatchForm
            InfoMatchForm frm = new InfoMatchForm(m);
            frm.ShowDialog();
        }

        private void matchesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            InforButton_Click(sender, e);
        }
    }

    // ==========================================
    // CÁC CLASS MODEL
    // ==========================================

    public class Match
    {
        public int MatchId { get; set; }
        public int Round { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool IsPlayed { get; set; }
        public DateTime? MatchDate { get; set; } // Dùng dấu ? vì ngày có thể chưa có (NULL)
        public string Location { get; set; }
    }

    public class TeamStanding
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GF { get; set; }
        public int GA { get; set; }
        public int Points { get; set; }
        public int GD => GF - GA;
    }
}