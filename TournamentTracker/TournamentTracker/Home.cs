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
        private Button _currentFilterBtn = null;
        private bool _isViewingMyTournaments = true;
        private int _currentHeroId = -1;
        private DataTable _rawDataTable = new DataTable();
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
            UserSession.Logout();
            TeamListForm.Properties.Settings.Default.SavedUserId = -1;
            TeamListForm.Properties.Settings.Default.Save();
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
            LoadTournamentStats(true);
            LoadDashboard(true);
            LoadHeroTournament(true);
        }
        private void LoadTournamentStats(bool viewMineOnly)
        {
            DatabaseHelper repo = new DatabaseHelper();
            DataRow stats = repo.GetTournamentStats(UserSession.CurrentUserId, viewMineOnly);

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

            if (viewMineOnly)
            {
                lblTotal.ForeColor = Color.LightGreen;
            }
            else
            {
                lblTotal.ForeColor = Color.Orange;
            }
        }
        private void LoadHeroTournament(bool viewMineOnly)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataRow hero = db.GetHeroTournament(UserSession.CurrentUserId, viewMineOnly);
            _currentHeroId = -1;

            if (hero == null)
            {
                if (viewMineOnly)
                {
                    heroTitleLabel.Text = "No upcoming tournaments";
                    heroSubLabel.Text = "Create your first tournament";
                }
                heroInfoLabel.Text = "";

                viewDetailsBtn.Visible = false;
                manageBtn.Visible = false;
                return;
            }
            _currentHeroId = Convert.ToInt32(hero["ID"]);
            viewDetailsBtn.Visible = true;

            int creatorId = hero["CreatedBy"] != DBNull.Value ? Convert.ToInt32(hero["CreatedBy"]) : 0;

            if (creatorId == UserSession.CurrentUserId)
            {
                manageBtn.Visible = true; 
            }
            else
            {
                manageBtn.Visible = false; 
            }

            heroTitleLabel.Text = hero["NAME"].ToString();
            heroSubLabel.Text = $"{hero["SPORT"]} • {hero["TEAM_COUNT"]} teams";

            DateTime startDate = Convert.ToDateTime(hero["STARTDATE"]);
            heroInfoLabel.Text = "Starts on " + startDate.ToString("dd MMM yyyy");
        }
        public void LoadDashboard(bool viewMineOnly)
        {
            _isViewingMyTournaments = viewMineOnly;
            flowPanelCards.Controls.Clear();

            if (viewMineOnly)
            {
                addBtn.Visible = true;
            }
            else
            {
                addBtn.Visible = false;
            }
            DatabaseHelper repo = new DatabaseHelper();
            DataTable dt;

            if (viewMineOnly)
                dt = repo.GetMyTournaments(UserSession.CurrentUserId);
            else
                dt = repo.GetOtherTournaments(UserSession.CurrentUserId); 

            if (dt.Rows.Count == 0)
            {
                pnlEmptyState.Visible = true;
                pnlEmptyState.BringToFront(); 
                flowPanelCards.Visible = false;
                if (viewMineOnly)
                {
                    label2.Text = "No tournaments yet!";
                    label3.Text = "Get started by creating your first tournament.";
                }
                else
                {
                    label2.Text = "Not Found";
                    label3.Text = "Couldn't find any tournaments matching your criteria.";
                }
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
                card.Cursor = Cursors.Hand;
                card.Margin = new Padding(15);
                card.OnSelect += Card_Selected_Handler;

                if (viewMineOnly)
                {
                    card.EnableOwnerMode(true);
                }
                else
                {
                    card.EnableOwnerMode(false);
                }
                card.ContextMenuStrip = contextMenuStrip1;
                flowPanelCards.Controls.Add(card);
            }
        }
        private void LoadPublicTournaments(string keyword)
        {
            flowPanelCards.SuspendLayout();
            DatabaseHelper repo = new DatabaseHelper();
            DataTable dt = repo.GetOtherTournaments(UserSession.CurrentUserId, keyword);
            RenderCards(dt);
            if (dt.Rows.Count == 0 && !_isViewingMyTournaments)
            {
                label3.Text = $"Couldn't find any results for '{keyword}'";
            }
            flowPanelCards.ResumeLayout();
        }
        private void RenderCards(DataTable dt)
        {
            flowPanelCards.SuspendLayout();
            flowPanelCards.Controls.Clear();
            if (dt.Rows.Count == 0)
            {
                pnlEmptyState.Visible = true;
                flowPanelCards.Visible = false;
                if (_isViewingMyTournaments)
                {
                    label2.Text = "No tournaments yet!";
                    label3.Text = "Get started by creating your first tournament.";
                    addBtn.Visible = true;
                }
                else
                {
                    label2.Text = "Not Found";
                    label3.Text = "Couldn't find any tournaments matching your criteria.";

                  
                    addBtn.Visible = false;
                }

                flowPanelCards.ResumeLayout();
                return;
            }
            pnlEmptyState.Visible = false;
            flowPanelCards.Visible = true;

            foreach (DataRow row in dt.Rows)
            {
                TournamentCard card = new TournamentCard();
                card.SetData(
                    Convert.ToInt32(row["ID"]),
                    row["NAME"].ToString(),
                    row["SPORT"].ToString(),
                    Convert.ToDateTime(row["STARTDATE"]).ToString("dd MMM yyyy"),
                    row["PRIZE"].ToString(),
                    row["TEAM_COUNT"].ToString(),
                    row["POSTERPATH"].ToString()
                );

                card.Tag = Convert.ToInt32(row["ID"]);
                card.Cursor = Cursors.Hand;
                card.Margin = new Padding(15);
                card.EnableOwnerMode(false);
                card.ContextMenuStrip = null;
                card.OnSelect += Card_Selected_Handler;

                flowPanelCards.Controls.Add(card);
            }
            flowPanelCards.ResumeLayout();
        }
        private void LoadTournamentsAsync(string filterMode)
        {
            flowPanelCards.Controls.Clear();
            heroSubLabel.Text = "Loading...";
            Task.Run(() =>
            {
                DatabaseHelper repo = new DatabaseHelper();
                DataTable dt = repo.GetTournamentsByFilter(UserSession.CurrentUserId, filterMode);
                this.Invoke(new Action(() =>
                {
                    RenderCards(dt);
                }));
            });
        }

        private void ShowEmptyState(string msg)
        {
            pnlEmptyState.Visible = true;
            flowPanelCards.Visible = false;
            heroSubLabel.Text = msg;
            addBtn.Visible = false;
        }
        private void Card_Selected_Handler(object sender, int tournamentId)
        {
            OpenTournamentDetail(tournamentId);
        }
        private void ViewDetailsBtn_Click(object sender, EventArgs e)
        {
            if (_currentHeroId != -1)
            {
                OpenTournamentDetail(_currentHeroId);
            }
        }
        private void OpenTournamentDetail(int id)
        {

            MatchesScheduleForm matchesScheduleForm = new MatchesScheduleForm(id);
            matchesScheduleForm.ShowDialog();
        }
        private void Card_Click(object sender, EventArgs e)
        {
            TournamentCard card = (TournamentCard)sender;
            int tourId = (int)card.Tag;
            MatchesScheduleForm matchForm = new MatchesScheduleForm(tourId);
            matchForm.Show();
        }

        private void screateBtn_Click(object sender, EventArgs e)
        {
            CreaTourForm createForm = new CreaTourForm();
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadDashboard(true);
                LoadHeroTournament(true);
                LoadTournamentStats(true);
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

                if (MessageBox.Show("Xóa giải đấu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DatabaseHelper repo = new DatabaseHelper();
                    if (repo.DeleteTournament(tournamentId))
                    {
                        MessageBox.Show("Đã xóa!");
                        LoadDashboard(true);
                        LoadHeroTournament(true);
                        LoadTournamentStats(true);
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
                LoadDashboard(true);
                LoadHeroTournament(true);
                LoadTournamentStats(true);
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            CreaTourForm createForm = new CreaTourForm();

            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadDashboard(true);
                LoadHeroTournament(true);
                LoadTournamentStats(true);
                int newTourId = createForm.CreatedTournamentId;
                if (newTourId != -1)
                {
                    DialogResult result = MessageBox.Show(
                        "Tournament created successfully!\nDo you want to manage the team list now?",
                        "Next Step",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        TeamListForm.TeamListForm teamList = new TeamListForm.TeamListForm(newTourId);
                        teamList.ShowDialog();
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewDetailsBtn_Click(object sender, EventArgs e)
        {
            if (_currentHeroId != -1)
            {
                OpenTournamentDetail(_currentHeroId);
            }
            else
            {
                MessageBox.Show("Chưa có giải đấu nổi bật để xem!");
            }
        }

        private void manageBtn_Click(object sender, EventArgs e)
        {
            if (_currentHeroId != -1)
            {
                TeamListForm.TeamListForm teamlist = new TeamListForm.TeamListForm(_currentHeroId);
                teamlist.ShowDialog();
                LoadHeroTournament(true);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giải đấu trước!");
            }
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            _isViewingMyTournaments = false;
            pnlHeroSection.Visible = false;
            createBtn.Visible = false;
            addBtn.Visible = false;
            findBtn.Visible = false;
            pnlSearchSection.Visible = true;
            btnMyTournaments.Visible = true;

            txtSearchGlobal.Visible = true;
            txtSearchGlobal.Focus();
            LoadPublicTournaments("");
            LoadTournamentStats(false);
        }

        private void Account_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
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
                CreaTourForm editForm = new CreaTourForm(tournamentId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDashboard(true);
                    LoadHeroTournament(true);
                    LoadTournamentStats(true);
                    if (MessageBox.Show("Tournament updated successfully!\nDo you want to manage the team list now ? ", "Next Step", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        TeamListForm.TeamListForm teamList = new TeamListForm.TeamListForm(tournamentId);
                        teamList.ShowDialog();
                    }
                }
            }
        }

        private void txtSearchGlobal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!_isViewingMyTournaments)
                {
                    string keyword = txtSearchGlobal.Text.Trim();
                    LoadPublicTournaments(keyword);
                }
                e.SuppressKeyPress = true;
            }
        }
        private void QuickFilter_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            if (_currentFilterBtn != null)
            {
                _currentFilterBtn.BackColor = Color.FromArgb(50, 50, 50); 
                _currentFilterBtn.ForeColor = Color.White;
            }

            btn.BackColor = Color.DarkOrange;
            btn.ForeColor = Color.White;
            _currentFilterBtn = btn;

            string filterMode = "All";
            if (btn.Text.Contains("Active")) filterMode = "Active";
            else if (btn.Text.Contains("Upcoming")) filterMode = "Upcoming";
            else if (btn.Text.Contains("High Prize")) filterMode = "HighPrize";

            LoadTournamentsAsync(filterMode);
        }
        private void btnMyTournaments_Click(object sender, EventArgs e)
        {
            _isViewingMyTournaments = true;

            pnlSearchSection.Visible = false; // Ẩn cụm Search & Filter
            btnMyTournaments.Visible = false; // Ẩn nút quay về

            txtSearchGlobal.Visible = false;  // Ẩn thanh Search (YÊU CẦU CỦA BẠN)
            txtSearchGlobal.Clear();          // Xóa chữ

            pnlHeroSection.Visible = true;    // Hiện lại Hero Banner
            createBtn.Visible = true;         // Hiện nút Tạo
            addBtn.Visible = true;            // Hiện nút Cộng
            findBtn.Visible = true;           // Hiện nút Find
            LoadDashboard(true);
            LoadHeroTournament(true);
            LoadTournamentStats(true);
        }

        private void txtSearchGlobal_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = txtSearchGlobal.Text.Trim();
                LoadPublicTournaments(keyword);

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
