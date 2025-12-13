using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamListForm
{
    public partial class MatchesScheduleForm : Form
    {
        public MatchesScheduleForm()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra chọn dòng
            if (matchesDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn trận đấu cần cập nhật!");
                return;
            }

            // Lấy dữ liệu dòng đang chọn
            DataRowView row = (DataRowView)matchesDataGridView.CurrentRow.DataBoundItem;

            // Tạo object Match để chuyển sang Form nhập điểm
            Match m = new Match();
            m.MatchId = (int)row["MatchID"];
            m.Round = (int)row["Round"];
            m.HomeTeam = new Team { TEAMNAME = row["HomeTeamName"].ToString() };
            m.AwayTeam = new Team { TEAMNAME = row["AwayTeamName"].ToString() };

            // Xử lý điểm số (tránh lỗi NULL)
            m.HomeScore = row["HomeScore"] == DBNull.Value ? 0 : (int)row["HomeScore"];
            m.AwayScore = row["AwayScore"] == DBNull.Value ? 0 : (int)row["AwayScore"];

            // Mở Form con
            using (var frm = new MatchResultForm(m))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Lưu xuống Database
                    DatabaseHelper.UpdateMatchResult(m.MatchId, m.HomeScore, m.AwayScore);
                    // Tải lại bảng
                    LoadMatchesToGrid();

                    RecalculateStandings();
                }
            }
        }

        private void MatchesScheduleForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách vòng đấu đổ vào ComboBox
                var rounds = DatabaseHelper.GetRounds();
                if (rounds.Count > 0)
                {
                    choiceRoundComboBox.DataSource = rounds;
                }
                RecalculateStandings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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

            // Gọi DatabaseHelper lấy dữ liệu
            DataTable dt = DatabaseHelper.GetMatchesTable(selectedRound);

            // Gán vào bảng
            matchesDataGridView.AutoGenerateColumns = false;
            matchesDataGridView.DataSource = dt;
        }
        private void RecalculateStandings()
        {
            // 1. Lấy dữ liệu gốc
            var originalTeams = DatabaseHelper.GetTeams();
            DataTable dtMatches = DatabaseHelper.GetMatchesTable(""); // Lấy hết trận đấu

            // 2. Tạo danh sách TeamStanding để tính toán
            var standingsList = new List<TeamStanding>();

            // Chuyển từ Team (Database) sang TeamStanding (Hiển thị)
            foreach (var team in originalTeams)
            {
                standingsList.Add(new TeamStanding { Name = team.TEAMNAME });
            }

            // 3. Duyệt qua từng trận đấu để cộng điểm
            foreach (DataRow row in dtMatches.Rows)
            {
                // Bỏ qua nếu chưa đá (HomeScore hoặc AwayScore là NULL)
                if (row["HomeScore"] == DBNull.Value || row["AwayScore"] == DBNull.Value) continue;

                int hScore = Convert.ToInt32(row["HomeScore"]);
                int aScore = Convert.ToInt32(row["AwayScore"]);
                string homeName = row["HomeTeamName"].ToString();
                string awayName = row["AwayTeamName"].ToString();

                // Tìm đội trong danh sách xếp hạng
                var homeStats = standingsList.FirstOrDefault(s => s.Name == homeName);
                var awayStats = standingsList.FirstOrDefault(s => s.Name == awayName);

                if (homeStats != null && awayStats != null)
                {
                    homeStats.Played++;
                    awayStats.Played++;

                    homeStats.GF += hScore; homeStats.GA += aScore;
                    awayStats.GF += aScore; awayStats.GA += hScore;

                    if (hScore > aScore)
                    { // Chủ nhà thắng
                        homeStats.Won++; homeStats.Points += 3;
                        awayStats.Lost++;
                    }
                    else if (aScore > hScore)
                    { // Khách thắng
                        awayStats.Won++; awayStats.Points += 3;
                        homeStats.Lost++;
                    }
                    else
                    { // Hòa
                        homeStats.Drawn++; homeStats.Points += 1;
                        awayStats.Drawn++; awayStats.Points += 1;
                    }
                }
            }

            // 4. Sắp xếp: Điểm -> Hiệu số -> Bàn thắng
            var sortedList = standingsList.OrderByDescending(t => t.Points)
                                          .ThenByDescending(t => t.GD)
                                          .ThenByDescending(t => t.GF)
                                          .ToList();

            // 5. Đánh số thứ tự (Hạng)
            for (int i = 0; i < sortedList.Count; i++) sortedList[i].Rank = i + 1;

            // 6. Đổ lên bảng xếp hạng (SỬA TÊN Ở ĐÂY)
            standingsDataGridView.AutoGenerateColumns = false;
            standingsDataGridView.DataSource = null;
            standingsDataGridView.DataSource = sortedList;
        }   

    }

    public class Match
    {
        public int MatchId { get; set; }
        public int Round { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool IsPlayed { get; set; }

    }

    public class TeamStanding
    {
        public int Rank { get; set; }       // Hạng
        public string Name { get; set; }    // Tên đội
        public int Played { get; set; }     // Số trận
        public int Won { get; set; }        // Thắng
        public int Drawn { get; set; }      // Hòa
        public int Lost { get; set; }       // Thua
        public int GF { get; set; }         // Bàn thắng
        public int GA { get; set; }         // Bàn thua
        public int Points { get; set; }     // Điểm số

        public int GD => GF - GA;           // Hiệu số (Tự động tính)
    }
}
