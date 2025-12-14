using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace TeamListForm
{
    public partial class TeamListForm : System.Windows.Forms.Form
    {
        private int _tournamentId;
        private static string connectionString = @"Data Source=DESKTOP-LOJ3INE\SQLEXPRESS;Initial Catalog=TournamentTracker;Integrated Security=True;TrustServerCertificate=True;";
        public TeamListForm(int tournamentId)
        {
            InitializeComponent();
            _tournamentId = tournamentId;
            LoadTeams(); 
        }
        

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            LoadTeams(txtSearch.Text.Trim());
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadTeams(txtSearch.Text.Trim());

                // tắt tiếng "Ting" của Windows
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void LoadTeams(string search = "")
        {
            var teams = DatabaseHelper.GetTeams(_tournamentId, txtSearch.Text.Trim());

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
            TeamEditorForm editor = new TeamEditorForm(EditorMode.Add);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                // Lấy team từ form con (nếu CreatedTeam null thì thử lấy từ Tag)
                Team newTeam = editor.CreatedTeam ?? (editor.Tag as Team);

                if (newTeam != null)
                {
                    // 1. Kiểm tra trùng tên trong giải này
                    if (DatabaseHelper.CheckTeam(newTeam.TEAMNAME, _tournamentId))
                    {
                        // 2. Thêm vào DB kèm ID Giải Đấu (Quan trọng!)
                        DatabaseHelper.InsertTeam(newTeam, _tournamentId);

                        // 3. Tải lại lưới
                        LoadTeams();
                    }
                    else
                    {
                        MessageBox.Show("Tên đội đã tồn tại trong giải đấu này!");
                    }
                }
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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}