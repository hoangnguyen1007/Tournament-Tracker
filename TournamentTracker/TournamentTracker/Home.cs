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
    public partial class Home : System.Windows.Forms.Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public Home()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            ContextMenuStrip myMenu = Account;
            myMenu.Show(LogOutBtn, 0, LogOutBtn.Height);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm homeform = new LoginForm();
            this.Hide();
            homeform.Show();
        }
        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            LoadTournamentStats();
            LoadDashboard();
            LoadHeroTournament();
        }
        private void LoadTournamentStats()
        {
            DatabaseHelper repo = new DatabaseHelper();
            DataRow stats = repo.GetTournamentStats();
            int total = 0;
            int active = 0;
            int upcoming = 0;

            if (stats != null)
            {
                total = stats.IsNull("TotalTournaments") ? 0 : Convert.ToInt32(stats["TotalTournaments"]);
                active = stats.IsNull("StartedOrFinishedTournaments") ? 0 : Convert.ToInt32(stats["StartedOrFinishedTournaments"]);
                upcoming = stats.IsNull("UpcomingTournaments") ? 0 : Convert.ToInt32(stats["UpcomingTournaments"]);
            }
            lblTotal.Text = $"Total: {total}";
            lblActive.Text = $"Active: {active}";
            lblUpcoming.Text = $"Upcoming: {upcoming}";
        }
        private void LoadHeroTournament()
        {
            DatabaseHelper db = new DatabaseHelper();
            DataRow hero = db.GetHeroTournament();

            if (hero == null)
            {
                heroTitleLabel.Text = "No tournaments yet";
                heroSubLabel.Text = "Create your first tournament";
                heroInfoLabel.Text = "";

                viewDetailsBtn.Visible = false;
                manageBtn.Visible = false;
                return;
            }
            viewDetailsBtn.Visible = true;
            manageBtn.Visible = true;

            heroTitleLabel.Text = hero["NAME"].ToString();
            heroSubLabel.Text = $"{hero["SPORT"]} • {hero["TEAM_COUNT"]} teams";

            DateTime startDate = Convert.ToDateTime(hero["STARTDATE"]);

            heroInfoLabel.Text = startDate >= DateTime.Today
                ? "Starts on " + startDate.ToString("dd MMM yyyy")
                : "Started on " + startDate.ToString("dd MMM yyyy");
        }
        public void LoadDashboard()
        {
            flowPanelCards.Controls.Clear();
            DatabaseHelper repo = new DatabaseHelper();
            DataTable dt = repo.GetAllTournaments();
            if (dt.Rows.Count == 0)
            {
                pnlEmptyState.Visible = true;
                pnlEmptyState.BringToFront();

                flowPanelCards.Visible = false;
                return;
            }

            pnlEmptyState.Visible = false;
            flowPanelCards.Visible = true;
            flowPanelCards.BringToFront();

            foreach (DataRow row in dt.Rows)
            {
                TournamentCard card = new TournamentCard();
                int id = Convert.ToInt32(row["ID"]);
                string name = row["NAME"].ToString();
                string sport = row["SPORT"].ToString();
                string prize = row["PRIZE"].ToString();
                string path = row["POSTERPATH"].ToString();
                DateTime startDate = Convert.ToDateTime(row["STARTDATE"]);
                string date = startDate.ToString("dd MMM yyyy");
                string participant = row["TEAM_COUNT"].ToString();
                card.SetData(id, name, sport, date, prize, participant, path);
                card.Margin = new Padding(15);
                card.Click += Card_Click;
                flowPanelCards.Controls.Add(card);
                card.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            TournamentCard card = (TournamentCard)sender;
            int tourId = (int)card.Tag;
            // Sau này sẽ là: new frmTournamentDashboard(tourId).Show();
        }

        private void screateBtn_Click(object sender, EventArgs e)
        {
            CreaTourForm createForm = new CreaTourForm();
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadDashboard();
                LoadHeroTournament();
                LoadTournamentStats();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            ContextMenuStrip menu = (ContextMenuStrip)item.Owner;


            Control sourceControl = menu.SourceControl;

            while (sourceControl != null && !(sourceControl is TournamentCard))
            {
                sourceControl = sourceControl.Parent;
            }


            if (sourceControl is TournamentCard card)
            {
                int tournamentId = Convert.ToInt32(card.Tag);

                // Hỏi xác nhận
                if (MessageBox.Show("Xóa giải đấu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Gọi hàm xóa
                    DatabaseHelper repo = new DatabaseHelper();
                    if (repo.DeleteTournament(tournamentId))
                    {
                        MessageBox.Show("Đã xóa!");
                        LoadDashboard(); // Load lại
                        LoadHeroTournament();
                        LoadTournamentStats();
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thẻ để xóa!");
            }
        }

        private void flowPanelCards_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            CreaTourForm createForm = new CreaTourForm();
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadDashboard();
                LoadHeroTournament();
                LoadTournamentStats();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            CreaTourForm createForm = new CreaTourForm();
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadDashboard();
                LoadHeroTournament();
                LoadTournamentStats();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
