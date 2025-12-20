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
        private int _tournamentId;
        public MatchesScheduleForm(int tournamentId)
        {
            InitializeComponent();
            _tournamentId = tournamentId;
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
        // Load danh sách vòng đấu lên ComboBox
        private void LoadRounds()
        {
            // Lấy danh sách vòng đấu mới nhất từ DB
            var rounds = DatabaseHelper.GetRounds(_tournamentId);

            // Xử lý hiển thị lên ComboBox
            choiceRoundComboBox.DataSource = null;
            if (rounds.Count > 0)
            {
                choiceRoundComboBox.DataSource = rounds;
            }
        }
        // Sự kiện Load Form
        private void MatchesScheduleForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRounds();

                RecalculateStandings();
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        // Hiển thị bảng xếp hạng
        private void RecalculateStandings()
        {
            // Lấy dữ liệu trận đấu CHỈ CỦA GIẢI NÀY
            DataTable dtMatches = DatabaseHelper.GetMatchesTable(_tournamentId, "");
            var originalTeams = DatabaseHelper.GetTeams(_tournamentId);
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
            List<Team> teams = DatabaseHelper.GetTeams(_tournamentId);
            if (teams.Count < 2)
            {
                MessageBox.Show("Cần ít nhất 2 đội để bắt đầu giải đấu!");
                return;
            }

            // Có thể check thêm: teams.Count < (Số bảng * 2) thì cảnh báo...

            // 2. Gọi SQL để chia bảng và xếp lịch (Code Mới)
            DatabaseHelper db = new DatabaseHelper();
            bool success = db.GenerateSchedule(_tournamentId);

            if (success)
            {
                MessageBox.Show("Đã sinh lịch thi đấu và chia bảng thành công!", "Thành công");

                // 3. Load lại giao diện
                LoadRounds(); // Load danh sách vòng (Round 1, 2...)

                // Tự động chọn Round 1
                if (choiceRoundComboBox.Items.Count > 0)
                {
                    choiceRoundComboBox.SelectedIndex = 0;
                }
                else
                {
                    // Fallback nếu combo chưa kịp update
                    LoadMatchesToGrid();
                }

                UpdateButtonState(); // Ẩn nút Start, hiện nút Next
            }
            else
            {
                MessageBox.Show("Lỗi khi sinh lịch thi đấu. Vui lòng kiểm tra lại số lượng đội!", "Lỗi");
            }
        }
        private void btnNextRound_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Tạo dữ liệu vòng mới trong SQL
                MatchGenerator.GenerateNextRound(_tournamentId);

                // 2. Load lại danh sách vòng đấu vào ComboBox
                LoadRounds();

                // 3. Cập nhật trạng thái nút
                UpdateButtonState();

                // 4. Chọn vòng mới nhất
                if (choiceRoundComboBox.Items.Count > 0)
                {
                    choiceRoundComboBox.SelectedIndex = choiceRoundComboBox.Items.Count - 1;
                    LoadMatchesToGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        // INFO BUTTON
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
        public int TournamentID { get; set; }
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