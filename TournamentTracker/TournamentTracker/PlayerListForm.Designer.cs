namespace TeamListForm
{
    partial class PlayerListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerListForm));
            panelHeader = new Panel();
            lblTitle = new Label();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lbSearch = new Label();
            panelOptionBtn = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            dgvPlayers = new DataGridView();
            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            panelOptionBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(35, 38, 39);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Location = new Point(272, 73);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(814, 63);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(40, 156, 56);
            lblTitle.Location = new Point(35, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(474, 45);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "DANH SÁCH CẦU THỦ CỦA ...";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.Transparent;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lbSearch);
            panelSearch.ForeColor = Color.FromArgb(40, 156, 56);
            panelSearch.Location = new Point(272, 142);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(814, 90);
            panelSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(35, 38, 39);
            btnSearch.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(679, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(135, 47);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(35, 38, 39);
            txtSearch.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.DarkGray;
            txtSearch.Location = new Point(250, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(350, 39);
            txtSearch.TabIndex = 3;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSearch.Location = new Point(35, 29);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(161, 32);
            lbSearch.TabIndex = 2;
            lbSearch.Text = "Search Player";
            // 
            // panelOptionBtn
            // 
            panelOptionBtn.BackColor = Color.Transparent;
            panelOptionBtn.Controls.Add(btnDelete);
            panelOptionBtn.Controls.Add(btnUpdate);
            panelOptionBtn.Controls.Add(btnAdd);
            panelOptionBtn.ForeColor = Color.FromArgb(40, 156, 56);
            panelOptionBtn.Location = new Point(272, 633);
            panelOptionBtn.Name = "panelOptionBtn";
            panelOptionBtn.Size = new Size(814, 113);
            panelOptionBtn.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(35, 38, 39);
            btnDelete.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(624, 27);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 41);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(35, 38, 39);
            btnUpdate.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(342, 27);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(133, 41);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(35, 38, 39);
            btnAdd.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(35, 27);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(115, 41);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvPlayers
            // 
            dgvPlayers.AllowUserToAddRows = false;
            dgvPlayers.AllowUserToDeleteRows = false;
            dgvPlayers.AllowUserToResizeColumns = false;
            dgvPlayers.AllowUserToResizeRows = false;
            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlayers.BackgroundColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.DarkGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPlayers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPlayers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPlayers.EnableHeadersVisualStyles = false;
            dgvPlayers.Location = new Point(272, 238);
            dgvPlayers.Name = "dgvPlayers";
            dgvPlayers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPlayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPlayers.RowHeadersVisible = false;
            dgvPlayers.RowTemplate.Height = 42;
            dgvPlayers.RowTemplate.ReadOnly = true;
            dgvPlayers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlayers.Size = new Size(814, 389);
            dgvPlayers.TabIndex = 3;
            // 
            // PlayerListForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1284, 781);
            Controls.Add(dgvPlayers);
            Controls.Add(panelOptionBtn);
            Controls.Add(panelSearch);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Pixel);
            Name = "PlayerListForm";
            Text = "Form1";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelOptionBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelSearch;
        private Panel panelOptionBtn;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lbSearch;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private DataGridView dgvPlayers;
    }
}