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
    public partial class MatchResultForm : Form
    {
        // Biến lưu trữ trận đấu đang sửa
        private Match _match;

        public MatchResultForm(Match match)
        {
            InitializeComponent();

            _match = match; // Lưu lại để dùng

            MatchInfoLabel.Text = $"Round {_match.Round} - Match {_match.MatchId}";

            // Đổ dữ liệu lên giao diện
            if (_match.HomeTeam != null)
                HGLabel.Text = _match.HomeTeam.TEAMNAME;

            if (_match.AwayTeam != null)
                AGLabel.Text = _match.AwayTeam.TEAMNAME;

            // Đổ điểm số cũ lên ô nhập
            homeNumericUpDown.Value = _match.HomeScore;
            awayNumericUpDown.Value = _match.AwayScore;
        }

        private void saveMatchButton_Click(object sender, EventArgs e)
        {
            // Cập nhật điểm mới vào biến _match
            _match.HomeScore = (int)homeNumericUpDown.Value;
            _match.AwayScore = (int)awayNumericUpDown.Value;
            _match.IsPlayed = true; // Đánh dấu là đã đá

            // Đổ dữ liệu Checkbox
            finishedCheckBox.Checked = _match.IsPlayed;

            // Gọi sự kiện 1 lần để khóa/mở ô nhập ngay khi vừa mở Form
            finishedCheckBox_CheckedChanged(null, null);

            // Đóng form và báo kết quả OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void finishedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra: Nếu ĐÃ TÍCH (Checked) thì KHÓA ô nhập (Enabled = false)
            // Nếu CHƯA TÍCH thì MỞ ô nhập (Enabled = true)

            bool choPhepSua = !finishedCheckBox.Checked; // Đảo ngược trạng thái

            homeNumericUpDown.Enabled = choPhepSua;
            awayNumericUpDown.Enabled = choPhepSua; 
        }
    }
}
