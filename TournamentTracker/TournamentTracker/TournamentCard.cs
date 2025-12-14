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
    public partial class TournamentCard : UserControl
    {
        public void EnableOwnerMode(bool isOwner)
        {
            // Nếu bạn có nút Manage (như trong hình screenshot 2), hãy đặt tên cho nó ví dụ btnManage
            // contextMenuStrip1 là cái menu chuột phải Xóa/Sửa

            if (isOwner)
            {
                // Là chủ: Cho phép hiện nút Manage và Menu chuột phải
                // btnManage.Visible = true; (nếu có nút này trên card)
                this.ContextMenuStrip = contextMenuStrip1; // Gán menu chuột phải
                this.Cursor = Cursors.Hand;
            }
            else
            {
                // Khách: Ẩn nút Manage, tắt menu chuột phải
                // btnManage.Visible = false;
                this.ContextMenuStrip = null; // Không cho chuột phải để xóa
                this.Cursor = Cursors.Default; // Hoặc Hand tùy bạn
            }
        }
        public event EventHandler<int> OnSelect;

        private int _tournamentId;
        private ContextMenuStrip? contextMenuStrip1;

        public TournamentCard()
        {
            InitializeComponent();

            this.MouseEnter += (s, e) => this.BackColor = Color.FromArgb(70, 70, 70);
            this.MouseLeave += (s, e) => this.BackColor = Color.FromArgb(50, 50, 50);
            this.Cursor = Cursors.Hand;
            this.Click += (s, e) => TriggerSelection();
            foreach (Control c in this.Controls)
            {
                if (c == button1) continue;
                c.Click += (s, e) => this.OnClick(e);
                c.MouseEnter += (s, e) => this.OnMouseEnter(e);
                c.MouseLeave += (s, e) => this.OnMouseLeave(e);
            }
        }
        private void TriggerSelection()
        {
            // Bắn pháo hiệu ra ngoài kèm ID
            OnSelect?.Invoke(this, _tournamentId);
        }
        public void SetData(int id, string name, string sport, string startTime, string prize, string participant, string posterPath)
        {
            _tournamentId = id; // Lưu ID vào biến
            this.Tag = id;
            lblStartDate.Text = startTime.ToString();
            lblTitle.Text = name;
            lblSport.Text = sport;
            lblParticipants.Text = "👥" + participant + " Teams";
            lblPrize.Text = string.IsNullOrEmpty(prize) ? "No Prize" : "💰" + string.Format("{0:N0} VND", decimal.Parse(prize));
            if (!string.IsNullOrEmpty(posterPath) && System.IO.File.Exists(posterPath))
            {
                //pbPoster.Image = Image.FromFile(posterPath);
            }
            else
            {
                // pbPoster.Image = null;
                //pbPoster.BackColor = Color.DimGray; 
            }
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblStartDate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ContextMenuStrip != null)
            {
                this.ContextMenuStrip.Show(button1, new Point(0, button1.Height));
            }
        }
    }
}
