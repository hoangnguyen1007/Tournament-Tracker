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
    public partial class MatchResultForm : System.Windows.Forms.Form
    {
        // Biến lưu trữ trận đấu đang sửa
        private Match _match;

        public MatchResultForm(Match match)
        {
            InitializeComponent();

            _match = match; // Lưu lại biến match để sử dụng khi bấm nút Save

            // Hiển thị thông tin tiêu đề (Vòng đấu - Mã trận)
            MatchInfoLabel.Text = $"Round {_match.Round} - Match {_match.MatchId}";

            // Hiển thị tên 2 đội bóng
            if (_match.HomeTeam != null)
                HGLabel.Text = _match.HomeTeam.TEAMNAME;

            if (_match.AwayTeam != null)
                AGLabel.Text = _match.AwayTeam.TEAMNAME;

            // Đổ điểm số hiện tại lên ô nhập
            homeNumericUpDown.Value = _match.HomeScore;
            awayNumericUpDown.Value = _match.AwayScore;

            // Đổ trạng thái "Đã kết thúc" vào Checkbox
            // Nếu _match.IsPlayed là true -> Checkbox sẽ được tích
            finishedCheckBox.Checked = _match.IsPlayed;

            // Cập nhật trạng thái khóa/mở ô nhập ngay lập tức
            // Gọi hàm sự kiện này để: Nếu Checkbox được tích -> Khóa ô nhập, ngược lại -> Mở ô nhập
            finishedCheckBox_CheckedChanged(null, null);
            if (_match.IsPlayed)
            {
                // Khóa nút Lưu
                saveMatchButton.Enabled = false;
                // Khóa Checkbox (Không cho bỏ tích nữa)
                finishedCheckBox.Enabled = false;
            }
        }

        private void saveMatchButton_Click(object sender, EventArgs e)
        {
            // Cập nhật điểm mới vào biến _match
            _match.HomeScore = (int)homeNumericUpDown.Value;
            _match.AwayScore = (int)awayNumericUpDown.Value;
            _match.IsPlayed = finishedCheckBox.Checked;
            // Đóng form và báo kết quả OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void finishedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (finishedCheckBox.Checked && finishedCheckBox.Focused)
            {
                DialogResult result = MessageBox.Show(
                    "Xác nhận kết thúc trận đấu?\n\nLưu ý: Sau khi kết thúc, kết quả không thể chỉnh sửa được nữa.",
                    "Xác nhận kết thúc",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2); // Mặc định chọn No để an toàn

                if (result == DialogResult.No)
                {
                    // Nếu chọn No: Bỏ tích checkbox
                    // (Lệnh này sẽ kích hoạt lại sự kiện này một lần nữa, nhưng Checked sẽ là false nên không bị lặp)
                    finishedCheckBox.Checked = false;
                    return; // Thoát hàm để phần logic đệ quy tự xử lý việc mở khóa ô nhập
                }
            }
            // Kiểm tra: Nếu ĐÃ TÍCH (Checked) thì KHÓA ô nhập (Enabled = false)
            // Nếu CHƯA TÍCH thì MỞ ô nhập (Enabled = true)

            bool choPhepSua = !finishedCheckBox.Checked; // Đảo ngược trạng thái

            homeNumericUpDown.Enabled = choPhepSua;
            awayNumericUpDown.Enabled = choPhepSua;
        }
    }
}
