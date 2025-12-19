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
        private int _tournamentId;
        public MatchesScheduleForm(int tournamentId)
        {
            InitializeComponent();
            _tournamentId = tournamentId;
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
                UpdateButtonState();
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
        // Hiển thị bảng xếp hạng
        private void RecalculateStandings()
        {
            try
            {
                // Gọi Stored Procedure qua DatabaseHelper để lấy bảng xếp hạng đã tính sẵn
                DataTable dt = DatabaseHelper.GetStandingsTable(_tournamentId);

                // Gán dữ liệu vào GridView
                standingsDataGridView.AutoGenerateColumns = false; // Giữ nguyên cấu hình cột đã thiết kế
                standingsDataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bảng xếp hạng: " + ex.Message);
            }
        }
        // Nút bắt đầu giải (Round 1 - Chưa bấm thì Round 1 null)
        // Nút tiếp vòng (Round 2 trở đi - Chỉ hiện khi đã bấm nút bắt đầu)
        private void UpdateButtonState()
        {
            // Lấy vòng đấu lớn nhất hiện tại từ DB
            int currentRound = DatabaseHelper.GetMaxRound(_tournamentId);

            if (currentRound == 0)
            {
                // Chưa có trận nào -> Hiện nút START, Ẩn nút NEXT
                btnStart.Visible = true;
                btnNextRound.Visible = false;
                choiceRoundComboBox.Visible = false; // Ẩn luôn combo chọn vòng cho gọn (vì chưa đá mà ..)
            }
            else
            {
                // Đã có trận -> Ẩn nút START, Hiện nút NEXT
                btnStart.Visible = false;
                btnNextRound.Visible = true;
                choiceRoundComboBox.Visible = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Lấy danh sách tất cả các đội
            List<Team> teams = DatabaseHelper.GetTeams();
            List<int> teamIds = teams.Select(t => t.ID).ToList();

            if (teamIds.Count < 2)
            {
                MessageBox.Show("Cần ít nhất 2 đội để bắt đầu giải đấu!");
                return;
            }
            // Gọi hàm tạo vòng 1 (đá vòng tròn, tất cả các đội trong bảng đều gặp nhau)
            MatchGenerator.GenerateRound1(_tournamentId, teamIds);
            // Load lại giao diện
            LoadMatchesToGrid();
            UpdateButtonState(); // Tự động ẩn nút Start, hiện nút Next
            // Tự chọn Round 1 để hiển thị ngay
            if (choiceRoundComboBox.Items.Count > 0)
                choiceRoundComboBox.SelectedIndex = 0;
        }
        private void btnNextRound_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi hàm tạo vòng tiếp theo (đá knockout dựa trên đội winner hoặc chéo giữa 2 đội đầu bảng)
                MatchGenerator.GenerateNextRound(_tournamentId);
                // Load lại giao diện
                LoadMatchesToGrid();
                UpdateButtonState();
                // Tự động chọn vòng mới nhất vừa tạo
                if (choiceRoundComboBox.Items.Count > 0)
                    choiceRoundComboBox.SelectedIndex = choiceRoundComboBox.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
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
        public int Points { get; set; }     // Điểm s
        public int GD => GF - GA;           // Hiệu số (Tự động tính)
    }
}
