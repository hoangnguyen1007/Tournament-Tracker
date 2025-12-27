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
        private bool _isOwner = false;
        public MatchesScheduleForm(int tournamentId)
        {
            InitializeComponent();
            _tournamentId = tournamentId;
            matchesDataGridView.AutoGenerateColumns = false; // Giữ nguyên design cột
        }

        private void choiceRoundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchesToGrid();
        }

        private void LoadMatchesToGrid()
        {
            // Kiểm tra nếu chưa chọn vòng đấu thì thoát
            if (choiceRoundComboBox.SelectedItem == null) return;
            matchesDataGridView.AutoGenerateColumns = false; // Giữ nguyên design cột
            try
            {
                int roundNum = 1;
                string roundText = choiceRoundComboBox.SelectedItem.ToString();
                string cleanRound = roundText.Replace("Round ", "").Replace("Vòng ", "").Trim();
                int.TryParse(cleanRound, out roundNum);
                // Hiển thị/ẩn ComboBox lọc bảng dựa vào vòng đấu (Từ round 2 thì ko hiện cái chọn Bảng nữa, mặc định là chọn tất cả)
                if (roundNum == 1)
                {
                    comboGroupFilter.Visible = true;
                }
                else
                {
                    if (comboGroupFilter.Items.Count > 0 && comboGroupFilter.SelectedIndex != 0)
                    {
                        comboGroupFilter.SelectedIndex = 0; // Chọn về "All"
                    }
                    comboGroupFilter.Visible = false; // Ẩn đi cho gọn
                }
                string groupName = "All"; // Mặc định lấy tất cả
                // Kiểm tra xem ComboBox lọc bảng có đang chọn gì không
                if (comboGroupFilter != null && comboGroupFilter.SelectedItem != null)
                {
                    string groupText = comboGroupFilter.SelectedItem.ToString();
                    if (groupText.Contains("Bảng"))
                    {
                        groupName = groupText.Replace("Bảng ", "").Trim();
                    }
                    // Nếu chọn "Tất cả..." thì giữ nguyên là "All"
                }
                DataTable dt = DatabaseHelper.GetMatchesTable(_tournamentId, roundNum, groupName);
                matchesDataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch thi đấu: " + ex.Message);
            }
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
            choiceRoundComboBox.Items.Clear();
            // Lấy danh sách thật từ DB
            List<string> rounds = DatabaseHelper.GetRounds(_tournamentId);
            // Chỉ thêm vào nếu có dữ liệu thật
            if (rounds.Count > 0)
            {
                foreach (string r in rounds)
                {
                    choiceRoundComboBox.Items.Add(r);
                }
                // Chọn cái mới nhất
                choiceRoundComboBox.SelectedIndex = choiceRoundComboBox.Items.Count - 1;
            }
        }
        // Sự kiện Load Form
        private void MatchesScheduleForm_Load(object sender, EventArgs e)
        {
            try
            {
                int currentUserId = Properties.Settings.Default.SavedUserId;

                DatabaseHelper db = new DatabaseHelper();
                DataRow tourRow = db.GetTournamentById(_tournamentId);

                if (tourRow != null)
                {
                    int createdBy = tourRow["CreatedBy"] != DBNull.Value ? Convert.ToInt32(tourRow["CreatedBy"]) : -1;

                    // SO SÁNH:
                    // 1. Nếu ID người dùng trùng với người tạo (Current == CreatedBy)
                    // 2. Hoặc là Admin (ID = 1)
                    if (currentUserId == createdBy)
                    {
                        _isOwner = true;
                    }
                    else
                    {
                        _isOwner = false;
                    }
                }
                LoadRounds();
                LoadGroupComboBox();
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
            try
            {
                string groupName = "All"; // Giá trị mặc định là xem hết
                if (comboGroupFilter != null && comboGroupFilter.SelectedItem != null)
                {
                    string selectedText = comboGroupFilter.SelectedItem.ToString();
                    if (selectedText.Contains("Bảng"))
                    {
                        groupName = selectedText.Replace("Bảng ", "").Trim();
                    }
                }
                DataTable dt = DatabaseHelper.GetStandings(_tournamentId, groupName);
                // Gán dữ liệu vào GridView
                standingsDataGridView.AutoGenerateColumns = false;
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
            // Lấy vòng lớn nhất hiện tại
            int currentRound = DatabaseHelper.GetMaxRound(_tournamentId);
            if (_isOwner == false)
            {
                btnStart.Visible = false;
                btnNextRound.Visible = false;
                updateButton.Visible = false;
                btnReset.Visible = false;
                choiceRoundComboBox.Visible = (currentRound > 0);
                return;
            }
            if (currentRound == 0)
            {
                // TRƯỜNG HỢP 1: GIẢI CHƯA BẮT ĐẦU
                btnStart.Visible = true;
                btnNextRound.Visible = false;
                btnReset.Visible = false;
                // QUAN TRỌNG: Ẩn luôn ComboBox vì chưa có gì để xem
                choiceRoundComboBox.Visible = false;
            }
            else
            {
                // TRƯỜNG HỢP 2: ĐANG DIỄN RA
                btnStart.Visible = false;
                btnNextRound.Visible = true;
                btnReset.Visible = true;
                choiceRoundComboBox.Visible = true; // Hiện ComboBox để chọn vòng
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            var info = db.GetTeamCountInfo(_tournamentId);
            if (info.CurrentCount < info.MaxCount)
            {
                MessageBox.Show($"Không thể chia bảng/bắt đầu giải đấu!\n\n" +
                                $"Số lượng đội hiện tại: {info.CurrentCount}\n" +
                                $"Yêu cầu của giải: {info.MaxCount}\n\n" +
                                $"Vui lòng vào danh sách đội (Team List) thêm đủ {info.MaxCount - info.CurrentCount} đội nữa.",
                                "Chưa đủ đội bóng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại ngay
            }
            // Tất cả logic kiểm tra và gọi SQL đã nằm trong hàm này rồi
            MatchGenerator.GenerateRound1(_tournamentId);
            UpdateButtonState();
            // Cập nhật giao diện sau khi tạo xong
            LoadRounds();
            if (choiceRoundComboBox.Items.Count > 0) choiceRoundComboBox.SelectedIndex = 0;
            else LoadMatchesToGrid();
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
        // Xem theo từng bảng đấu (comboGroupFilter)
        private void LoadGroupComboBox()
        {
            comboGroupFilter.Items.Clear();
            // Luôn có lựa chọn xem tất cả
            comboGroupFilter.Items.Add("All");
            // Lấy số lượng bảng từ DB 
            int groupCount = DatabaseHelper.GetTournamentGroupCount(_tournamentId);
            // 
            for (int i = 0; i < groupCount; i++)
            {
                string name = ((char)('A' + i)).ToString();
                comboGroupFilter.Items.Add($"Bảng {name}");
            }
            // Mặc định chọn "Tất cả"
            comboGroupFilter.SelectedIndex = 0;
        }
        // Tải lại dữ liệu khi chọn bảng lọc
        private void comboGroupFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchesToGrid();
            RecalculateStandings();
            LoadData();
        }
        // Hàm tải dữ liệu với bộ lọc vòng và bảng
        private void LoadData()
        {
            // Lấy round và group từ 2 combobox
            int selectedRound = 1;
            if (choiceRoundComboBox.SelectedItem != null)
            {
                // Logic tách số từ chuỗi "Round 1" -> 1
                string roundStr = choiceRoundComboBox.SelectedItem.ToString().Replace("Round ", "");
                int.TryParse(roundStr, out selectedRound);
            }
            // Lấy Group (Ví dụ combobox đang chọn "Bảng A")
            string selectedGroup = "All";
            if (comboGroupFilter.SelectedItem != null)
            {
                string txt = comboGroupFilter.SelectedItem.ToString();
                if (txt.Contains("Bảng"))
                    selectedGroup = txt.Replace("Bảng", "").Trim(); // Lấy chữ "A"
                else
                    selectedGroup = "All";
            }
            // GỌI HÀM VỪA SỬA
            DataTable dtMatches = DatabaseHelper.GetMatchesTable(_tournamentId, selectedRound, selectedGroup);
            // Gán vào lưới
            matchesDataGridView.DataSource = dtMatches;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!_isOwner)
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này!");
                return;
            }

            // 2. Kiểm tra xem giải đã có lịch đấu chưa (để tránh reset khi chưa có gì)
            if (!DatabaseHelper.HasSchedule(_tournamentId))
            {
                MessageBox.Show("Giải đấu chưa bắt đầu, không cần reset.", "Thông báo");
                return;
            }

            // 3. Hỏi xác nhận (QUAN TRỌNG)
            DialogResult result = MessageBox.Show(
                "CẢNH BÁO NGUY HIỂM:\n\n" +
                "Hành động này sẽ XÓA TOÀN BỘ LỊCH THI ĐẤU và KẾT QUẢ hiện tại.\n" +
                "Giải đấu sẽ quay về trạng thái chưa chia bảng.\n\n" +
                "Bạn có chắc chắn muốn làm lại từ đầu không?",
                "Xác nhận Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2); // Mặc định chọn No để an toàn

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 4. Gọi hàm xóa dữ liệu trong Database
                    DatabaseHelper.ResetTournamentMatches(_tournamentId);

                    // 5. Xóa dữ liệu trên giao diện
                    matchesDataGridView.DataSource = null;
                    standingsDataGridView.DataSource = null;
                    choiceRoundComboBox.Items.Clear();

                    // Reset bộ lọc bảng về mặc định
                    if (comboGroupFilter.Items.Count > 0) comboGroupFilter.SelectedIndex = 0;

                    // 6. Cập nhật lại trạng thái các nút (Nút Start sẽ hiện lại)
                    UpdateButtonState();

                    // Load lại các thông tin bổ trợ (để đảm bảo sạch sẽ)
                    LoadRounds();

                    MessageBox.Show("Đã xóa dữ liệu thành công! Bạn có thể chia bảng và bắt đầu lại.",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi reset giải đấu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

}
