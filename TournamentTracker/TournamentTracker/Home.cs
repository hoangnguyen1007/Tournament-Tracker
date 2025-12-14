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
        private bool _isViewingMyTournaments = true;
        private int _currentHeroId = -1;
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

            // 2. --- THÊM MỚI: Xóa trong Ổ cứng ---
            TeamListForm.Properties.Settings.Default.SavedUserId = -1; // Reset về -1
            TeamListForm.Properties.Settings.Default.Save();
            // ------------------------------------

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

            // Truyền userId và chế độ xem vào
            DataRow stats = repo.GetTournamentStats(UserSession.CurrentUserId, viewMineOnly);

            int total = 0;
            int active = 0; // Đã bắt đầu/Kết thúc
            int upcoming = 0; // Sắp tới

            if (stats != null)
            {
                total = stats.IsNull("TotalTournaments") ? 0 : Convert.ToInt32(stats["TotalTournaments"]);

                // Lưu ý: Logic Active/Upcoming của bạn ở SQL đang là:
                // Upcoming: StartDate > Now
                // Active/Finished: StartDate <= Now
                active = stats.IsNull("StartedOrFinishedTournaments") ? 0 : Convert.ToInt32(stats["StartedOrFinishedTournaments"]);
                upcoming = stats.IsNull("UpcomingTournaments") ? 0 : Convert.ToInt32(stats["UpcomingTournaments"]);
            }

            // Cập nhật Label
            lblTotal.Text = $"Total: {total}";
            lblActive.Text = $"Active: {active}";
            lblUpcoming.Text = $"Upcoming: {upcoming}";

            // [GỢI Ý UX] Đổi màu hoặc tiêu đề để người dùng hiểu họ đang xem stats của ai
            if (viewMineOnly)
            {
                // Ví dụ: Đổi màu chữ sang màu Xanh (My Stats)
                lblTotal.ForeColor = Color.LightGreen;
            }
            else
            {
                // Ví dụ: Đổi màu chữ sang màu Cam (Community Stats)
                lblTotal.ForeColor = Color.Orange;
            }
        }
        private void LoadHeroTournament(bool viewMineOnly)
        {
            DatabaseHelper db = new DatabaseHelper();

            // Gọi hàm mới bên DatabaseHelper với ID người dùng hiện tại
            DataRow hero = db.GetHeroTournament(UserSession.CurrentUserId, viewMineOnly);

            // Reset ID Hero
            _currentHeroId = -1;

            if (hero == null)
            {
                // Xử lý Empty State (Giữ nguyên logic cũ của bạn nhưng sửa text cho hợp lý)
                heroTitleLabel.Text = viewMineOnly ? "No upcoming tournaments" : "No public tournaments found";
                heroSubLabel.Text = viewMineOnly ? "Create your first tournament" : "Check back later";
                heroInfoLabel.Text = "";

                viewDetailsBtn.Visible = false;
                manageBtn.Visible = false;
                return;
            }

            // --- CÓ DỮ LIỆU ---
            _currentHeroId = Convert.ToInt32(hero["ID"]);
            viewDetailsBtn.Visible = true;

            // --- LOGIC PHÂN QUYỀN NÚT MANAGE (QUAN TRỌNG) ---
            // Chỉ hiện nút Manage nếu User hiện tại là chủ nhân giải đấu này
            int creatorId = hero["CreatedBy"] != DBNull.Value ? Convert.ToInt32(hero["CreatedBy"]) : 0;

            if (creatorId == UserSession.CurrentUserId)
            {
                manageBtn.Visible = true; // Là chủ -> Được sửa
            }
            else
            {
                manageBtn.Visible = false; // Là khách -> Ẩn nút sửa
            }
            // ------------------------------------------------

            heroTitleLabel.Text = hero["NAME"].ToString();
            heroSubLabel.Text = $"{hero["SPORT"]} • {hero["TEAM_COUNT"]} teams";

            DateTime startDate = Convert.ToDateTime(hero["STARTDATE"]);
            heroInfoLabel.Text = "Starts on " + startDate.ToString("dd MMM yyyy");
        }
        public void LoadDashboard(bool viewMineOnly)
        {
            _isViewingMyTournaments = viewMineOnly; // Lưu trạng thái
            flowPanelCards.Controls.Clear();

            DatabaseHelper repo = new DatabaseHelper();
            DataTable dt;

            // --- QUYẾT ĐỊNH LẤY DỮ LIỆU NÀO ---
            if (viewMineOnly)
            {
                // Chế độ 1: Chỉ lấy giải của tôi
                dt = repo.GetMyTournaments(UserSession.CurrentUserId);
                // Đổi tiêu đề cho người dùng biết (nếu bạn có label tiêu đề danh sách)
                // lblListTitle.Text = "My Tournaments"; 
            }
            else
            {
                // Chế độ 2: Lấy giải người khác (Find)
                dt = repo.GetOtherTournaments(UserSession.CurrentUserId);
                // lblListTitle.Text = "Public Tournaments";
            }
            // -----------------------------------

            if (dt.Rows.Count == 0)
            {
                // Nếu là xem của mình mà trống -> Hiện "Tạo giải đầu tiên đi"
                // Nếu là Find mà trống -> Hiện "Không tìm thấy giải nào"
                pnlEmptyState.Visible = true;
                pnlEmptyState.BringToFront();
                flowPanelCards.Visible = false;

                // Cập nhật text empty state cho hợp ngữ cảnh
                if (viewMineOnly)
                    heroSubLabel.Text = "Create your first tournament";
                else
                    heroSubLabel.Text = "No public tournaments found";

                return;
            }

            pnlEmptyState.Visible = false;
            flowPanelCards.Visible = true;
            flowPanelCards.BringToFront();

            foreach (DataRow row in dt.Rows)
            {
                TournamentCard card = new TournamentCard();

                // ... (Code map dữ liệu cũ giữ nguyên) ...
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
                card.OnSelect += Card_Selected_Handler;

                // --- XỬ LÝ QUYỀN (QUAN TRỌNG) ---
                if (viewMineOnly)
                {
                    // Nếu đang xem list của mình -> Chắc chắn là chủ -> Hiện nút Manage
                    card.EnableOwnerMode(true);
                }
                else
                {
                    // Nếu đang xem list người khác -> Chắc chắn là khách -> Ẩn nút Manage
                    card.EnableOwnerMode(false);
                }

                card.ContextMenuStrip = contextMenuStrip1;
                flowPanelCards.Controls.Add(card);
            }
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
            // Sau này sẽ là: new frmTournamentDashboard(tourId).Show();
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

                // Hỏi xác nhận
                if (MessageBox.Show("Xóa giải đấu này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Gọi hàm xóa
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
        }

        private void Account_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, EventArgs e)
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

                // 2. Mở Form Sửa
                CreaTourForm editForm = new CreaTourForm(tournamentId);

                // Khi Form Sửa đóng lại và trả về OK
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDashboard(true);
                    LoadHeroTournament(true);
                    LoadTournamentStats(true);
                    if (MessageBox.Show("Tournament updated successfully!\nDo you want to manage the team list now ? ",  "Next Step", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        TeamListForm.TeamListForm teamList = new TeamListForm.TeamListForm(tournamentId);
                        teamList.ShowDialog();
                    }
                }
            }
        }
    }
}
