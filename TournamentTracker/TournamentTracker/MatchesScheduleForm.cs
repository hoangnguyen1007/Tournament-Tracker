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
            if (matchesDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn trận đấu cần cập nhật!");
                return;
            }

            // Lấy dữ liệu dòng đang chọn
            DataRowView row = (DataRowView)matchesDataGridView.CurrentRow.DataBoundItem;

            // Tạo object Match truyền sang form Update
            Match m = new Match();
            m.MatchId = (int)row["MatchID"];
            m.Round = (int)row["Round"];
            m.HomeTeam = new Team { TEAMNAME = row["HomeTeamName"].ToString() };
            m.AwayTeam = new Team { TEAMNAME = row["AwayTeamName"].ToString() };

            // Xử lý null
            m.HomeScore = row["HomeScore"] == DBNull.Value ? 0 : (int)row["HomeScore"];
            m.AwayScore = row["AwayScore"] == DBNull.Value ? 0 : (int)row["AwayScore"];

            // Mở form cập nhật
            using (var frm = new MatchResultForm(m))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Lưu xuống DB
                    DatabaseHelper.UpdateMatchResult(m.MatchId, m.HomeScore, m.AwayScore);

                    // Tải lại giao diện
                    LoadMatchesToGrid();
                    RecalculateStandings();
                }
            }
        }

        private void RecalculateStandings()
        {
            // Lấy dữ liệu trận đấu CHỈ CỦA GIẢI NÀY
            DataTable dtMatches = DatabaseHelper.GetMatchesTable(_tournamentId, "");
            var originalTeams = DatabaseHelper.GetTeams();

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
    }

    // ==========================================
    // CÁC CLASS MODEL (ĐÃ SỬA LỖI ISPLAYED)
    // ==========================================

    public class Match
    {
        public int MatchId { get; set; }
        public int Round { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        // [QUAN TRỌNG] Đã thêm dòng này để sửa lỗi bên MatchResultForm
        public bool IsPlayed { get; set; }
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