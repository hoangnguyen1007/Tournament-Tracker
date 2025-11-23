namespace TeamListForm
{
    partial class TeamListForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Header = new Label();
            labelSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panelSearch = new Panel();
            panelOption = new Panel();
            btnViewPlayers = new Button();
            btnRemove = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            dgvTeams = new DataGridView();
            panelSearch.SuspendLayout();
            panelOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeams).BeginInit();
            SuspendLayout();
            // 
            // Header
            // 
            Header.AutoSize = true;
            Header.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Header.ForeColor = Color.FromArgb(40, 156, 56);
            Header.Location = new Point(333, 41);
            Header.Name = "Header";
            Header.Size = new Size(456, 65);
            Header.TabIndex = 0;
            Header.Text = "Tournament Teams";
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSearch.ForeColor = Color.FromArgb(40, 156, 56);
            labelSearch.Location = new Point(33, 31);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(87, 32);
            labelSearch.TabIndex = 1;
            labelSearch.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(294, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(341, 33);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.FromArgb(40, 156, 56);
            btnSearch.Location = new Point(738, 29);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(117, 33);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += SearchBtn_Click;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(labelSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Location = new Point(135, 109);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(889, 86);
            panelSearch.TabIndex = 9;
            // 
            // panelOption
            // 
            panelOption.Controls.Add(btnViewPlayers);
            panelOption.Controls.Add(btnRemove);
            panelOption.Controls.Add(btnUpdate);
            panelOption.Controls.Add(btnAdd);
            panelOption.Location = new Point(135, 482);
            panelOption.Name = "panelOption";
            panelOption.Size = new Size(889, 100);
            panelOption.TabIndex = 10;
            // 
            // btnViewPlayers
            // 
            btnViewPlayers.BackColor = Color.FromArgb(35, 38, 39);
            btnViewPlayers.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewPlayers.ForeColor = Color.FromArgb(40, 156, 56);
            btnViewPlayers.Location = new Point(759, 35);
            btnViewPlayers.Name = "btnViewPlayers";
            btnViewPlayers.Size = new Size(111, 37);
            btnViewPlayers.TabIndex = 13;
            btnViewPlayers.Text = "Players";
            btnViewPlayers.UseVisualStyleBackColor = false;
            btnViewPlayers.Click += btnViewPlayers_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(35, 38, 39);
            btnRemove.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemove.ForeColor = Color.FromArgb(40, 156, 56);
            btnRemove.Location = new Point(524, 35);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(111, 37);
            btnRemove.TabIndex = 12;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(35, 38, 39);
            btnUpdate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.FromArgb(40, 156, 56);
            btnUpdate.Location = new Point(274, 35);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(111, 37);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(40, 156, 56);
            btnAdd.Location = new Point(33, 35);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(111, 37);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvTeams
            // 
            dgvTeams.AllowUserToAddRows = false;
            dgvTeams.AllowUserToDeleteRows = false;
            dgvTeams.AllowUserToResizeColumns = false;
            dgvTeams.AllowUserToResizeRows = false;
            dgvTeams.BackgroundColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTeams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTeams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.DarkGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTeams.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTeams.EnableHeadersVisualStyles = false;
            dgvTeams.GridColor = Color.DarkGray;
            dgvTeams.Location = new Point(135, 217);
            dgvTeams.Name = "dgvTeams";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTeams.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTeams.Size = new Size(889, 237);
            dgvTeams.TabIndex = 11;
            // 
            // TeamListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 38, 39);
            ClientSize = new Size(1143, 637);
            Controls.Add(dgvTeams);
            Controls.Add(panelOption);
            Controls.Add(panelSearch);
            Controls.Add(Header);
            ForeColor = Color.DarkGray;
            Name = "TeamListForm";
            Text = "TeamListForm";
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTeams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Header;
        private Label labelSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvTeams;
        private Panel panelSearch;
        private Panel panelOption;
        private Button btnRemove;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnViewPlayers;
    }
}
