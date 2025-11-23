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

namespace TourApp
{
    public partial class CreaTourForm : Form
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
            if (nameTextBox.Text == "") MessageBox.Show("Name cannot be empty", "Empty name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (sportCbox.Text == "") MessageBox.Show("Sport cannot be empty", "Empty sport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (numPar.Value < 2) MessageBox.Show("Number of participants must be larger than 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!singleRad.Checked && !multiRad.Checked) MessageBox.Show("Please select a tournament format.", "Format not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
