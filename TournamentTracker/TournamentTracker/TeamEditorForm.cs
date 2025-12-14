using System;
using System.Drawing;
using System.Windows.Forms;

namespace TeamListForm
{
    public enum EditorMode
    {
        Add,     // Thêm mới
        Update,  // Sửa
        Delete   // Xóa
    }

    public partial class TeamEditorForm : Form
    {
        private Team _team;
        private EditorMode _mode;
        public Team CreatedTeam { get; set; }

        public TeamEditorForm(EditorMode mode, Team team = null)
        {
            InitializeComponent();
            _mode = mode;
            _team = team ?? new Team(); // Nếu null thì tạo mới

            SetupForm();
        }

        public TeamEditorForm()
        {
            InitializeComponent();
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
                    btnOption.Text = "Save";
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
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                MessageBox.Show("Nhập tên đội đi bro!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo object Team từ dữ liệu nhập vào
            var team = new Team
            {
                TEAMNAME = txtTeamName.Text.Trim(),
                COACH = txtCoach.Text.Trim()
            };

            this.CreatedTeam = team; 
            this.Tag = team;         

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}