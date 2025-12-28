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
        private string _posterPath = ""; 

        public CreaTourForm(int? id = null)
        {
            InitializeComponent();
            _tournamentId = id;

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
                nameTextBox.Text = row["NAME"].ToString();
                locationTextBox.Text = row["LOCATION"] != DBNull.Value ? row["LOCATION"].ToString() : "";
                string sportDB = row["SPORT"].ToString();
                if (!string.IsNullOrEmpty(sportDB)) sportCbox.Text = sportDB;

                numPar.Minimum = 2;
                numPar.Maximum = 1000;
                numPar.Value = Convert.ToInt32(row["TEAM_COUNT"]);

                startDate.Value = Convert.ToDateTime(row["STARTDATE"]);
                prizeTextBox.Text = row["PRIZE"].ToString();
                int groupCount = row["GroupCount"] != DBNull.Value ? Convert.ToInt32(row["GroupCount"]) : 1;
                groupCbox.Text = groupCount.ToString();

                _posterPath = row["POSTERPATH"].ToString();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            createBtn.Enabled = false;

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a tournament name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();
                
                createBtn.Enabled = true;
                Cursor.Current = Cursors.Default;
                return;
            }

            if (sportCbox.SelectedIndex == -1 && string.IsNullOrEmpty(sportCbox.Text))
            {
                MessageBox.Show("Please select a sport type.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                createBtn.Enabled = true;
                Cursor.Current = Cursors.Default;
                return;
            }

            if (numPar.Value < 2)
            {
                MessageBox.Show("Participants must be at least 2.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                createBtn.Enabled = true;
                Cursor.Current = Cursors.Default;
                return;
            }

            int teamCount = (int)numPar.Value;
            int groupCount = 1;

            if (!string.IsNullOrEmpty(groupCbox.Text))
            {
                if (!int.TryParse(groupCbox.Text, out groupCount))
                {
                    groupCount = 1;
                }
            }

            int minTeamsPerGroup = 2;
            if (teamCount < groupCount * minTeamsPerGroup)
            {
                MessageBox.Show($"Số lượng đội quá ít! Với {groupCount} bảng, bạn cần ít nhất {groupCount * minTeamsPerGroup} đội (Tối thiểu {minTeamsPerGroup} đội/bảng).",
                                "Logic Bảng Đấu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                createBtn.Enabled = true;
                Cursor.Current = Cursors.Default;
                return;
            }

            if (teamCount % groupCount != 0)
            {
                var result = MessageBox.Show(
                    $"Số đội ({teamCount}) không chia hết cho số bảng ({groupCount}).\n" +
                    "Hệ thống sẽ tự động chia lệch (Ví dụ: Có bảng nhiều đội hơn).\n\n" +
                    "Bạn có muốn tiếp tục không?",
                    "Cảnh báo phân chia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    createBtn.Enabled = true;
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }
            try
            {
                string name = nameTextBox.Text.Trim();
                string sport = sportCbox.Text;
                DateTime date = startDate.Value;
                string prize = prizeTextBox.Text.Trim();
                string location = locationTextBox.Text.Trim();

                DatabaseHelper db = new DatabaseHelper();
                bool isSuccess = false;

                if (_tournamentId.HasValue)
                {
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
                    int createdBy = 1;
                    try
                    {
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
