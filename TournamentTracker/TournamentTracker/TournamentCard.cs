using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamListForm
{
    public partial class TournamentCard : UserControl
    {
        public TournamentCard()
        {
            InitializeComponent();
            this.MouseEnter += (s, e) => this.BackColor = Color.FromArgb(70, 70, 70);
            this.MouseLeave += (s, e) => this.BackColor = Color.FromArgb(50, 50, 50);
            this.Cursor = Cursors.Hand;
            foreach (Control c in this.Controls)
            {
                c.Click += (s, e) => this.OnClick(e);
                c.MouseEnter += (s, e) => this.OnMouseEnter(e);
                c.MouseLeave += (s, e) => this.OnMouseLeave(e);
            }
        }
        public void SetData(int id, string name, string sport, string startTime, string prize, string participant, string posterPath)
        {
            this.Tag = id;
            lblStartDate.Text = startTime.ToString();
            lblTitle.Text = name;
            lblSport.Text = sport;
            lblParticipants.Text = "👥"+ participant + " Teams";
            lblPrize.Text = string.IsNullOrEmpty(prize) ? "No Prize" : "💰" + string.Format("{0:N0} VND", decimal.Parse(prize));
            if (!string.IsNullOrEmpty(posterPath) && System.IO.File.Exists(posterPath))
            {
                //pbPoster.Image = Image.FromFile(posterPath);
            }
            else
            {
                // pbPoster.Image = null;
                //pbPoster.BackColor = Color.DimGray; 
            }
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblStartDate_Click(object sender, EventArgs e)
        {

        }
    }
}
