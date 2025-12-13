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
    public partial class PlayerListForm : Form
    {
        private int _teamId;
        private string _teamName;

        public PlayerListForm(int teamId, string teamName)
        {
            InitializeComponent();
            _teamId = teamId;
            _teamName = teamName;
            this.Text = $"Danh sách cầu thủ - {_teamName}";
            lblTitle.Text = $"DANH SÁCH ĐỘI {_teamName.ToUpper()}";
            LoadPlayers();
        }

        private void LoadPlayers(string search = "")
        {
            var players = DatabaseHelper.GetPlayersByTeam(_teamId, search);
            dgvPlayers.DataSource = null;
            dgvPlayers.DataSource = players;

            // Ẩn cột không cần
            if (dgvPlayers.Columns["ID"] != null) dgvPlayers.Columns["ID"].Visible = false;
            if (dgvPlayers.Columns["TeamID"] != null) dgvPlayers.Columns["TeamID"].Visible = false;
            if (dgvPlayers.Columns["TeamName"] != null) dgvPlayers.Columns["TeamName"].Visible = false;

            dgvPlayers.Columns["PlayerName"].HeaderText = "PLAYER NAME";
            dgvPlayers.Columns["Age"].HeaderText = "AGE";
            dgvPlayers.Columns["Position"].HeaderText = "POSITION";
            if (dgvPlayers.Rows.Count > 0)
            {
                // Highlight dòng đầu tiên
                dgvPlayers.Rows[0].Selected = true;

                // Gán CurrentCell vào ô nhìn thấy được (để CurrentRow có giá trị)
                // Cột 0 là ID bị ẩn, nên gán vào cột 1 (TEAMNAME)
                if (dgvPlayers.Columns.Count > 1 && dgvPlayers.Rows[0].Cells[1].Visible)
                    dgvPlayers.CurrentCell = dgvPlayers.Rows[0].Cells[1];
            }
            else
                // Nếu không có dữ liệu thì mới set null
                dgvPlayers.CurrentCell = null;
        }

        // BUTTON OPTIONS (PlayersEditorForm)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editor = new PlayerEditorForm(_teamId);
            if (editor.ShowDialog() == DialogResult.OK)
                LoadPlayers(txtSearch.Text.Trim());
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPlayers.CurrentRow?.DataBoundItem is Player player)
            {
                var editor = new PlayerEditorForm(_teamId, player);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    LoadPlayers(txtSearch.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cầu thủ để sửa!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlayers.CurrentRow?.DataBoundItem is Player player)
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa cầu thủ \"{player.PlayerName}\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    DatabaseHelper.DeletePlayer(player);
                    LoadPlayers(txtSearch.Text.Trim());
                    MessageBox.Show("Xóa thành công!", "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cầu thủ để xóa!", "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPlayers(txtSearch.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPlayers(txtSearch.Text.Trim());
        }

        private void dgvPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Bật chế độ Double buffering của Windows
                return cp;
            }
        }
    }
}
