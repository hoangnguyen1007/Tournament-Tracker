using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TeamListForm
{
    public partial class PlayerEditorForm : System.Windows.Forms.Form
    {
        private readonly int _teamId;
        private Player? _player;
        private readonly bool _isEdit;

        // THÊM MỚI
        public PlayerEditorForm(int teamId)
        {
            InitializeComponent();
            _teamId = teamId;
            _isEdit = false;
            this.Text = "Thêm cầu thủ";
        }

        // SỬA
        public PlayerEditorForm(int teamId, Player player)
        {
            InitializeComponent();
            _teamId = teamId;
            _player = player;
            _isEdit = true;
            this.Text = "Sửa thông tin cầu thủ";

            LoadToForm();
        }

        private void LoadToForm()
        {
            if (_player == null) return;

            txtPlayerName.Text = _player.PlayerName;
            txtPosition.Text = _player.Position;
            txtAge.Text = _player.Age.ToString();
            txtNumber.Text = _player.Number.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtPlayerName.Text.Trim();
            string pos = txtPosition.Text.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tên cầu thủ không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(pos))
            {
                MessageBox.Show("Vị trí không được để trống!");
                return;
            }
            if (!int.TryParse(txtAge.Text.Trim(), out int age))
            {
                MessageBox.Show("Tuổi phải là số nguyên!");
                return;
            }
            if (!int.TryParse(txtNumber.Text.Trim(), out int number))
            {
                MessageBox.Show("Số áo phải là số nguyên!", "Lỗi nhập liệu");
                txtNumber.Focus();
                return;
            }
            if (_isEdit)
            {
                // Gán lại giá trị cho object Player
                _player.PlayerName = name;
                _player.Position = pos;
                _player.Age = age;
                _player.Number = number;

                // Gọi hàm UPDATE trong DataHelper
                DatabaseHelper.UpdatePlayer(_player);
            }
            else
            {
                var newPlayer = new Player
                {
                    PlayerName = name,
                    Position = pos,
                    Age = age,
                    TeamID = _teamId,
                    Number = number 
                };

                // Gọi hàm INSERT trong DataHelper
                DatabaseHelper.InsertPlayer(newPlayer);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }


}
