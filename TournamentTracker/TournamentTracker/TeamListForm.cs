using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using ExcelDataReader;
using System.Data;

namespace TeamListForm
{
    public partial class TeamListForm : System.Windows.Forms.Form
    {
        private int _tournamentId;
        private static string connectionString = @"Data Source=DESKTOP-LOJ3INE\SQLEXPRESS;Initial Catalog=TournamentTracker;Integrated Security=True;TrustServerCertificate=True;";
        public TeamListForm(int tournamentId)
        {
            InitializeComponent();
            _tournamentId = tournamentId;
            LoadTeams();
        }


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            LoadTeams(txtSearch.Text.Trim());
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadTeams(txtSearch.Text.Trim());

                // tắt tiếng "Ting" của Windows
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void LoadTeams(string search = "")
        {
            var teams = DatabaseHelper.GetTeams(_tournamentId, txtSearch.Text.Trim());

            dgvTeams.DataSource = null;
            dgvTeams.DataSource = teams;

            // Ẩn cột ID
            if (dgvTeams.Columns["ID"] != null) dgvTeams.Columns["ID"].Visible = false;

            // Đổi tiêu đề cột 
            if (dgvTeams.Columns["TEAMNAME"] != null) dgvTeams.Columns["TEAMNAME"].HeaderText = "TEAM";
            if (dgvTeams.Columns["COACH"] != null) dgvTeams.Columns["COACH"].HeaderText = "COACH";

            // Bonus: chặn luôn sự kiện bắt đầu sửa
            dgvTeams.CellBeginEdit += (s, e) => e.Cancel = true;

            if (dgvTeams.Rows.Count > 0)
            {
                // Highlight dòng đầu tiên
                dgvTeams.Rows[0].Selected = true;

                // Gán CurrentCell vào ô nhìn thấy được (để CurrentRow có giá trị)
                // Cột 0 là ID bị ẩn, nên gán vào cột 1 (TEAMNAME)
                if (dgvTeams.Columns.Count > 1 && dgvTeams.Rows[0].Cells[1].Visible)
                    dgvTeams.CurrentCell = dgvTeams.Rows[0].Cells[1];
            }
            else
                // Nếu không có dữ liệu thì mới set null
                dgvTeams.CurrentCell = null;
        }
        // PANEL OPTION CRUD NÈ 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            TeamEditorForm editor = new TeamEditorForm(EditorMode.Add);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                // Lấy team từ form con (nếu CreatedTeam null thì thử lấy từ Tag)
                Team newTeam = editor.CreatedTeam ?? (editor.Tag as Team);

                if (newTeam != null)
                {
                    // 1. Kiểm tra trùng tên trong giải này
                    if (DatabaseHelper.CheckTeam(newTeam.TEAMNAME, _tournamentId))
                    {
                        // 2. Thêm vào DB kèm ID Giải Đấu (Quan trọng!)
                        newTeam.TournamentID = _tournamentId;

                        // 2. Gọi hàm Insert chỉ với 1 tham số
                        DatabaseHelper.InsertTeam(newTeam);

                        // 3. Tải lại lưới
                        LoadTeams();
                    }
                    else
                    {
                        MessageBox.Show("Tên đội đã tồn tại trong giải đấu này!");
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Lấy dòng đang chọn
            if (dgvTeams.CurrentRow == null || dgvTeams.CurrentRow.DataBoundItem is not Team selectedTeam)
            {
                MessageBox.Show("Vui lòng chọn một đội để sửa!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var editor = new TeamEditorForm(EditorMode.Update, selectedTeam);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                var updatedTeam = (Team)editor.Tag;
                updatedTeam.ID = selectedTeam.ID; // giữ nguyên ID
                DatabaseHelper.UpdateTeam(updatedTeam);
                LoadTeams(txtSearch.Text.Trim());
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null || dgvTeams.CurrentRow.DataBoundItem is not Team selectedTeam)
            {
                MessageBox.Show("Vui lòng chọn một đội để xóa!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn XÓA đội \"{selectedTeam.TEAMNAME}\" không?\n\nHành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                DatabaseHelper.DeleteTeam(selectedTeam.ID);
                LoadTeams(txtSearch.Text.Trim());
                MessageBox.Show("Xóa đội bóng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewPlayers_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null || !(dgvTeams.CurrentRow.DataBoundItem is Team selectedTeam))
            {
                MessageBox.Show("Vui lòng chọn một đội!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var playerForm = new PlayerListForm(selectedTeam.ID, selectedTeam.TEAMNAME);
            playerForm.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            openFileDialog.Title = "Chọn file dữ liệu Giải đấu (Teams + Players)";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. Đăng ký encoding để đọc được file Excel đời cũ và mới
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            // 2. Đọc Excel ra bảng dữ liệu
                            var result = reader.AsDataSet();
                            DataTable table = result.Tables[0]; // Lấy Sheet 1

                            // Bộ nhớ tạm để lưu: "Tên Đội" -> "ID trong DB"
                            // Giúp tránh việc tạo lại đội bóng nếu file Excel sắp xếp lộn xộn
                            Dictionary<string, int> teamCache = new Dictionary<string, int>();

                            int teamCount = 0;
                            int playerCount = 0;

                            // 3. Duyệt từng dòng (Bỏ dòng 0 là tiêu đề, chạy từ i = 1)
                            for (int i = 1; i < table.Rows.Count; i++)
                            {
                                DataRow row = table.Rows[i];

                                // Lấy thông tin cơ bản
                                string teamName = row[0]?.ToString().Trim(); // Cột A
                                string coachName = row[1]?.ToString().Trim(); // Cột B
                                string playerName = row[2]?.ToString().Trim(); // Cột C

                                // Nếu dòng này không có tên đội thì bỏ qua
                                if (string.IsNullOrEmpty(teamName)) continue;

                                int currentTeamId = 0;

                                // --- LOGIC XỬ LÝ ĐỘI BÓNG ---
                                if (teamCache.ContainsKey(teamName))
                                {
                                    // Nếu đội này đã tạo rồi thì lấy ID trong cache ra dùng
                                    currentTeamId = teamCache[teamName];
                                }
                                else
                                {
                                    // Nếu chưa có, kiểm tra trong DB xem có chưa (tránh trùng khi import 2 lần)
                                    // Bạn có thể bỏ qua bước check DB nếu muốn import đè, nhưng nên check cho chắc

                                    // Ở đây mình giả định là tạo mới luôn cho đơn giản
                                    Team newTeam = new Team();
                                    newTeam.TournamentID = _tournamentId; 
                                    newTeam.TEAMNAME = teamName;
                                    newTeam.COACH = coachName;

                                    // Gọi hàm thêm đội và LẤY ID VỀ NGAY
                                    currentTeamId = DatabaseHelper.InsertTeamAndGetID(newTeam);

                                    // Lưu vào cache để những dòng sau dùng lại ID này
                                    teamCache.Add(teamName, currentTeamId);
                                    teamCount++;
                                }

                                // --- LOGIC XỬ LÝ CẦU THỦ ---
                                if (!string.IsNullOrEmpty(playerName))
                                {
                                    Player newPlayer = new Player();
                                    newPlayer.TeamID = currentTeamId; // Gắn ID đội vừa lấy được
                                    newPlayer.PlayerName = playerName;

                                    // Parse số áo (Cột D)
                                    int.TryParse(row[3]?.ToString(), out int num);
                                    newPlayer.Number = num;

                                    // Vị trí (Cột E)
                                    newPlayer.Position = row[4]?.ToString();

                                    // Tuổi (Cột F)
                                    int.TryParse(row[5]?.ToString(), out int age);
                                    newPlayer.Age = age;

                                    // Thêm cầu thủ vào DB
                                    DatabaseHelper.InsertPlayer(newPlayer);
                                    playerCount++;
                                }
                            }

                            MessageBox.Show($"Nhập dữ liệu thành công!\n- {teamCount} Đội bóng mới\n- {playerCount} Cầu thủ",
                                            "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Load lại danh sách lên màn hình
                            LoadTeams();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
                }
            }
        }
    }
}