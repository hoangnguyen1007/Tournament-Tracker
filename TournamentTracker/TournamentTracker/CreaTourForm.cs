using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using TeamListForm;

namespace TourApp
{
    public partial class CreaTourForm : System.Windows.Forms.Form
    {
        public CreaTourForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void singleRad_CheckedChanged(object sender, EventArgs e)
        {
            panelMulti.Visible = false;
            panelSingle.Visible = true;
            panelSingle.ResetText();
        }

        private void multiRad_CheckedChanged(object sender, EventArgs e)
        {
            panelMulti.Visible = true;
            panelSingle.Visible = false;
            panelMulti.ResetText();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a tournament name.", "Missing Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();
                return;
            }

            if (sportCbox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a sport type.", "Missing Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPar.Value < 2)
            {
                MessageBox.Show("The number of participants must be at least 2.", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 2. GATHER DATA ---
            string name = nameTextBox.Text.Trim();
            string sport = sportCbox.SelectedItem.ToString();
            int teamCount = (int)numPar.Value;

            // Fix for CS0165 and CS1061: Ensure startDate is properly initialized and use the correct property
            DateTime date = startDate.Value; // Assuming 'startDatePicker' is the correct DateTimePicker control
            string prize = prizeTextBox.Text.Trim();

            // Location & PosterPath (Optional fields)
            string location = null;
            string posterPath = null;

            // --- 3. SAVE TO DATABASE ---
            DatabaseHelper db = new DatabaseHelper();

            bool isSuccess = db.AddTournament(name, location, date, prize, posterPath, sport, teamCount);

            if (isSuccess)
            {
                MessageBox.Show("Tournament created successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Thông báo lỗi chung (Generic error message)
                MessageBox.Show("An error occurred while saving to the database. Please try again.", "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numPar_ValueChanged(object sender, EventArgs e)
        {
            numPar.Minimum = 2;
            numPar.Maximum = 256;
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            ContextMenuStrip myMenu = Account;
            myMenu.Show(LogOutBtn, 0, LogOutBtn.Height);
        }

        private void CreaTourForm_Load(object sender, EventArgs e)
        {
            singleRad.Checked = true;
            sportCbox.Text = "Football";
        }

        private void starTime_ValueChanged(object sender, EventArgs e)
        {
            startDate.CustomFormat = "dd/MM/yyyy";
        }

        private void Account_Opening(object sender, CancelEventArgs e)
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
    }
}
