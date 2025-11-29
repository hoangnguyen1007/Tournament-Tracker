using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace TeamListForm
{
    public partial class TeamListForm : Form
    {
        private static string connectionString = @"Data Source=DESKTOP-LOJ3INE\SQLEXPRESS;Initial Catalog=TournamentTracker;Integrated Security=True;TrustServerCertificate=True;";
        public TeamListForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            LoadTeams(); // Load lần đầu
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            LoadTeams(txtSearch.Text.Trim());
        }
        private void LoadTeams(string search = "")
        {
            var teams = DatabaseHelper.GetTeams(search);

            dgvTeams.DataSource = null;
            dgvTeams.DataSource = teams;

            // Ẩn cột ID
            if (dgvTeams.Columns["ID"] != null) dgvTeams.Columns["ID"].Visible = false;

            // Đổi tiêu đề cột 
            if (dgvTeams.Columns["TEAMNAME"] != null) dgvTeams.Columns["TEAMNAME"].HeaderText = "TEAM";
            if (dgvTeams.Columns["COACH"] != null) dgvTeams.Columns["COACH"].HeaderText = "COACH";

            // Bonus: chặn luôn sự kiện bắt đầu sửa
            dgvTeams.CellBeginEdit += (s, e) => e.Cancel = true;

            if (dgvTeams.Rows.Count > 0)
            {
                // Highlight dòng đầu tiên
                dgvTeams.Rows[0].Selected = true;

                // Gán CurrentCell vào ô nhìn thấy được (để CurrentRow có giá trị)
                // Cột 0 là ID bị ẩn, nên gán vào cột 1 (TEAMNAME)
                if (dgvTeams.Columns.Count > 1 && dgvTeams.Rows[0].Cells[1].Visible)
                    dgvTeams.CurrentCell = dgvTeams.Rows[0].Cells[1];
            }
            else
                // Nếu không có dữ liệu thì mới set null
                dgvTeams.CurrentCell = null;
        }
        // PANEL OPTION CRUD NÈ 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editor = new TeamEditorForm(EditorMode.Add);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                var newTeam = (Team)editor.Tag;
                // Check đã tồn tại chưa
                if (!DatabaseHelper.CheckTeam(newTeam.TEAMNAME))
                {
                    MessageBox.Show("Tên đội đã tồn tại!", "Trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Chưa tồn tại thì bắt đầu thêm vào
                DatabaseHelper.InsertTeam(newTeam);
                LoadTeams(txtSearch.Text.Trim()); // reload danh sách
                MessageBox.Show("Thêm đội bóng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Lấy dòng đang chọn
            if (dgvTeams.CurrentRow == null || dgvTeams.CurrentRow.DataBoundItem is not Team selectedTeam)
            {
                MessageBox.Show("Vui lòng chọn một đội để sửa!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var editor = new TeamEditorForm(EditorMode.Update, selectedTeam);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                var updatedTeam = (Team)editor.Tag;
                updatedTeam.ID = selectedTeam.ID; // giữ nguyên ID
                DatabaseHelper.UpdateTeam(updatedTeam);
                LoadTeams(txtSearch.Text.Trim());
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null || dgvTeams.CurrentRow.DataBoundItem is not Team selectedTeam)
            {
                MessageBox.Show("Vui lòng chọn một đội để xóa!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn XÓA đội \"{selectedTeam.TEAMNAME}\" không?\n\nHành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                DatabaseHelper.DeleteTeam(selectedTeam.ID);
                LoadTeams(txtSearch.Text.Trim());
                MessageBox.Show("Xóa đội bóng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewPlayers_Click(object sender, EventArgs e)
        {
            if (dgvTeams.CurrentRow == null || !(dgvTeams.CurrentRow.DataBoundItem is Team selectedTeam))
            {
                MessageBox.Show("Vui lòng chọn một đội!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var playerForm = new PlayerListForm(selectedTeam.ID, selectedTeam.TEAMNAME);
            playerForm.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
