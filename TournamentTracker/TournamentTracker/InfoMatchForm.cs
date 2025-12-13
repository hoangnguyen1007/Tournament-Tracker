using System;
using System.Windows.Forms;

namespace TeamListForm
{
    public partial class InfoMatchForm : Form
    {
        private Match _match; // Biến lưu thông tin trận đấu

        public InfoMatchForm(Match match)
        {
            InitializeComponent();
            _match = match;

            // Gán sự kiện
            this.Load += InfoMatchForm_Load;

            // Sự kiện để tự điền số thứ tự (1, 2, 3...)
            homeTeamDataGridView.CellFormatting += DataGridView_CellFormatting;
            awayTeamdataGridView.CellFormatting += DataGridView_CellFormatting;
        }

        private void InfoMatchForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Hiển thị thông tin chung
                LoadMatchInfo();

                // 2. Hiển thị danh sách cầu thủ
                LoadPlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadMatchInfo()
        {
            if (_match.HomeTeam != null)
            {
                HomeTeamTitleLabel.Text = _match.HomeTeam.TEAMNAME.ToUpper();
                label1.Text = "ID: " + _match.HomeTeam.ID;
            }

            if (_match.AwayTeam != null)
            {
                AwayTeamTitleLabel.Text = _match.AwayTeam.TEAMNAME.ToUpper();
                label2.Text = "ID: " + _match.AwayTeam.ID;
            }

            if (_match.IsPlayed)
            {
                homeScoreLabel.Text = _match.HomeScore.ToString();
                awayScoreLabel.Text = _match.AwayScore.ToString();
            }
            else
            {
                homeScoreLabel.Text = "0";
                awayScoreLabel.Text = "0";
            }

            // Ngày giờ hiện tại
            dateLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            locationLabel.Text = "Round " + _match.Round;
        }

        private void LoadPlayers()
        {
            // Tắt tự động tạo cột thừa (Quan trọng)
            homeTeamDataGridView.AutoGenerateColumns = false;
            awayTeamdataGridView.AutoGenerateColumns = false;

            if (_match.HomeTeam != null)
            {
                // Tên biến PlayerName, Position... sẽ tự map vào DataPropertyName bạn vừa chỉnh
                homeTeamDataGridView.DataSource = DatabaseHelper.GetPlayersByTeam(_match.HomeTeam.ID);
            }

            if (_match.AwayTeam != null)
            {
                awayTeamdataGridView.DataSource = DatabaseHelper.GetPlayersByTeam(_match.AwayTeam.ID);
            }
        }

        // Tự động đánh số thứ tự cho cột # (Cột index 0)
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.Value = (e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}