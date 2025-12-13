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
    public enum EditorMode
    {
        Add,     // Thêm mới
        Update,  // Sửa
        Delete   // Xóa (chỉ hiển thị thông tin + hỏi xác nhận)
    }
    public partial class TeamEditorForm : System.Windows.Forms.Form
    {
        private Team _team;
        private EditorMode _mode;
        public TeamEditorForm(EditorMode mode, Team team = null)
        {
            InitializeComponent();
            _mode = mode;
            _team = team ?? new Team(); // nếu null thì tạo mới

            SetupForm();
        }
        private void SetupForm()
        {
            switch (_mode)
            {
                case EditorMode.Add:
                    this.Text = "Thêm đội bóng mới";
                    btnOption.Text = "Add";
                    break;

                case EditorMode.Update:
                    this.Text = "Sửa thông tin đội bóng";
                    btnOption.Text = "Save as";
                    txtTeamName.Text = _team.TEAMNAME;
                    txtCoach.Text = _team.COACH;
                    break;

                case EditorMode.Delete:
                    this.Text = "Xóa đội bóng";
                    btnOption.Text = "Xóa vĩnh viễn";
                    btnOption.BackColor = Color.IndianRed;
                    txtTeamName.Text = _team.TEAMNAME;
                    txtCoach.Text = _team.COACH;
                    txtTeamName.ReadOnly = true;
                    txtCoach.ReadOnly = true;
                    break;
            }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                MessageBox.Show("Nhập tên đội đi bro!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo team mới từ dữ liệu người dùng nhập
            var team = new Team
            {
                TEAMNAME = txtTeamName.Text.Trim(),
                COACH = txtCoach.Text.Trim()
            };

            this.Tag = team;                     // Đưa dữ liệu về form chính
            this.DialogResult = DialogResult.OK; // Báo "OK" để form chính biết
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
