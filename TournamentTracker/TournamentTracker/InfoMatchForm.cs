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
        }

        private void InfoMatchForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị thông tin chung
                LoadMatchInfo();

                // Hiển thị danh sách cầu thủ
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
            if (_match.MatchDate != null)
            {
                // Định dạng: "yyyy-MM-dd HH:mm:ss"
                dateLabel.Text = _match.MatchDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                dateLabel.Text = "Chưa có lịch";
            }
            // Kiểm tra nếu có địa điểm thì hiện, không thì để trống
            if (!string.IsNullOrEmpty(_match.Location))
            {
                locationLabel.Text = _match.Location;
            }
            else
            {
                locationLabel.Text = "Sân chưa xác định";
            }
        }

        private void LoadPlayers()
        {
            // Tắt tự động tạo cột thừa
            homeTeamDataGridView.AutoGenerateColumns = false;
            awayTeamdataGridView.AutoGenerateColumns = false;

            if (_match.HomeTeam != null)
            {
                // Tên biến PlayerName, Position... sẽ tự map vào DataPropertyName
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

        private void homeTeamDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView_CellFormatting(sender, e);
        }

        private void awayTeamdataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView_CellFormatting(sender, e);
        }
    }
}