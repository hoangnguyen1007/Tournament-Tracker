using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tournament_tracker
{
    public partial class MatchScheduleForm : Form
    {
        public MatchScheduleForm()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            MatchResultForm resultForm = new MatchResultForm();
            resultForm.ShowDialog();
        }
    }
}
