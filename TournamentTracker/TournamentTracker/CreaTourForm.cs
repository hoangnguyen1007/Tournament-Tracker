using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamListForm; 

namespace TourApp
{
    public partial class CreaTourForm : Form
    {
        private int? _tournamentId = null;
        public int CreatedTournamentId { get; private set; } = -1;
        private string _posterPath = ""; // Biến lưu đường dẫn ảnh

        public CreaTourForm(int? id = null)
        {
            InitializeComponent();
            _tournamentId = id;

            // Nếu có ID truyền vào thì là chế độ Sửa (Edit)
            if (_tournamentId.HasValue)
            {
                this.Text = "Update Tournament";
                createBtn.Text = "Save Changes";
                LoadDataForEdit();
            }
        }

        public CreaTourForm()
        {
            InitializeComponent();
        }

        private void LoadDataForEdit()
        {
            DatabaseHelper db = new DatabaseHelper();
            DataRow row = db.GetTournamentById(_tournamentId.Value);

            if (row != null)
            {
                // Load thông tin cơ bản
                nameTextBox.Text = row["NAME"].ToString();
                locationTextBox.Text = row["LOCATION"] != DBNull.Value ? row["LOCATION"].ToString() : "";
                string sportDB = row["SPORT"].ToString();
                if (!string.IsNullOrEmpty(sportDB)) sportCbox.Text = sportDB;

                numPar.Minimum = 2;
                numPar.Maximum = 1000;
                numPar.Value = Convert.ToInt32(row["TEAM_COUNT"]);

                startDate.Value = Convert.ToDateTime(row["STARTDATE"]);
                prizeTextBox.Text = row["PRIZE"].ToString();
                // Load số bảng đấu lên groupCbox
                int groupCount = row["GroupCount"] != DBNull.Value ? Convert.ToInt32(row["GroupCount"]) : 1;
                groupCbox.Text = groupCount.ToString();

                // Load Poster
                _posterPath = row["POSTERPATH"].ToString();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            createBtn.Enabled = false; // Tắt nút để tránh bấm nhiều lần

            // 1. KIỂM TRA TÊN
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a tournament name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();

                // --- SỬA LỖI: Bật lại nút và con trỏ chuột trước khi thoát ---
                createBtn.Enabled = true;
                Cursor.Current = Cursors.Default;
                return;
            }

            // 2. KIỂM TRA MÔN THỂ THAO
            if (sportCbox.SelectedIndex == -1 && string.IsNullOrEmpty(sportCbox.Text))
            {
                MessageBox.Show("Please select a sport type.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // --- SỬA LỖI ---
                createBtn.Enabled = true;
                Cursor.Current = Cursors.Default;
                return;
            }

            // 3. KIỂM TRA SỐ LƯỢNG NGƯỜI/ĐỘI
            if (numPar.Value < 2)
            {
                MessageBox.Show("Participants must be at least 2.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // --- SỬA LỖI ---
                createBtn.Enabled = true;
                Cursor.Current = Cursors.Default;
                return;
            }

            // --- KIỂM TRA LOGIC SỐ BẢNG ---
            int teamCount = (int)numPar.Value;
            int groupCount = 1;

            if (!string.IsNullOrEmpty(groupCbox.Text))
            {
                if (!int.TryParse(groupCbox.Text, out groupCount))
                {
                    groupCount = 1;
                }
            }

            // A. KIỂM TRA TỐI THIỂU
            int minTeamsPerGroup = 2;
            if (teamCount < groupCount * minTeamsPerGroup)
            {
                MessageBox.Show($"Số lượng đội quá ít! Với {groupCount} bảng, bạn cần ít nhất {groupCount * minTeamsPerGroup} đội (Tối thiểu {minTeamsPerGroup} đội/bảng).",
                                "Logic Bảng Đấu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // --- SỬA LỖI ---
                createBtn.Enabled = true;
                Cursor.Current = Cursors.Default;
                return;
            }

            // B. CẢNH BÁO CHIA ĐỀU
            if (teamCount % groupCount != 0)
            {
                var result = MessageBox.Show(
                    $"Số đội ({teamCount}) không chia hết cho số bảng ({groupCount}).\n" +
                    "Hệ thống sẽ tự động chia lệch (Ví dụ: Có bảng nhiều đội hơn).\n\n" +
                    "Bạn có muốn tiếp tục không?",
                    "Cảnh báo phân chia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    // --- SỬA LỖI: Nếu chọn NO thì cũng phải bật lại nút ---
                    createBtn.Enabled = true;
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }

            // --- 2. LẤY DỮ LIỆU & GỌI DATABASE ---
            try
            {
                string name = nameTextBox.Text.Trim();
                string sport = sportCbox.Text;
                DateTime date = startDate.Value;
                string prize = prizeTextBox.Text.Trim();
                // Sửa lỗi nhỏ: locaLabel là Label hay TextBox? Thường nhập liệu phải là TextBox. 
                // Nếu code cũ của bạn là locaLabel.Text thì giữ nguyên, nhưng mình đoán là locationTextBox
                string location = locationTextBox.Text.Trim();

                DatabaseHelper db = new DatabaseHelper();
                bool isSuccess = false;

                if (_tournamentId.HasValue)
                {
                    // UPDATE
                    isSuccess = db.UpdateTournament(
                        _tournamentId.Value,
                        name,
                        location,
                        date,
                        prize,
                        _posterPath,
                        sport,
                        teamCount,
                        groupCount
                    );

                    if (isSuccess) this.CreatedTournamentId = _tournamentId.Value;
                }
                else
                {
                    // CREATE
                    int createdBy = 1;
                    try
                    {
                        // Giả sử bạn có class UserSession (nếu không có thì xóa try-catch này đi)
                        if (TeamListForm.UserSession.CurrentUserId > 0)
                        {
                            createdBy = TeamListForm.UserSession.CurrentUserId;
                        }
                    }
                    catch { }

                    int newId = db.AddTournament(
                        name,
                        location,
                        date,
                        prize,
                        _posterPath,
                        sport,
                        teamCount,
                        groupCount,
                        createdBy
                    );

                    if (newId != -1)
                    {
                        isSuccess = true;
                        this.CreatedTournamentId = newId;
                    }
                }

                if (isSuccess)
                {
                    string msg = _tournamentId.HasValue ? "Update successfully!" : "Create successfully!";
                    MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An error occurred. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // --- SỬA LỖI: Nếu DB lỗi thì cũng phải bật lại nút để thử lại ---
                    createBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                createBtn.Enabled = true;
            }
            finally
            {
                // Luôn trả lại con trỏ chuột bình thường dù có lỗi hay không
                Cursor.Current = Cursors.Default;
            }
        }


        private void numPar_ValueChanged(object sender, EventArgs e)
        {
            numPar.Minimum = 2;
            numPar.Maximum = 1000;
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm homeform = new LoginForm();
            this.Hide();
            homeform.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreaTourForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sportCbox.Text)) sportCbox.Text = "Football";
        }

        private void starTime_ValueChanged(object sender, EventArgs e)
        {
            startDate.CustomFormat = "dd/MM/yyyy";
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Account_Opening(object sender, CancelEventArgs e) { }
    }
}