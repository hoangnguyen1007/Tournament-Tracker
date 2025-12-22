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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamListForm));
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
            btnCloseForm = new Button();
            btnMinimize = new Button();
            panelSearch.SuspendLayout();
            panelOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeams).BeginInit();
            SuspendLayout();
            // 
            // Header
            // 
            Header.BackColor = Color.Transparent;
            Header.Font = new Font("Segoe UI", 54F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            Header.ForeColor = Color.FromArgb(40, 156, 56);
            Header.Location = new Point(195, 26);
            Header.Name = "Header";
            Header.Size = new Size(620, 65);
            Header.TabIndex = 0;
            Header.Text = "Tournament Teams";
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            labelSearch.ForeColor = Color.FromArgb(40, 156, 56);
            labelSearch.Location = new Point(33, 27);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(152, 32);
            labelSearch.TabIndex = 0;
            labelSearch.Text = "Search Team";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(35, 38, 39);
            txtSearch.Font = new Font("Segoe UI", 24F, FontStyle.Italic, GraphicsUnit.Pixel, 0);
            txtSearch.ForeColor = Color.DarkGray;
            txtSearch.Location = new Point(294, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(382, 39);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Transparent;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            btnSearch.ForeColor = Color.Transparent;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(795, 19);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(59, 56);
            btnSearch.TabIndex = 2;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += SearchBtn_Click;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.Transparent;
            panelSearch.Controls.Add(labelSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Location = new Point(195, 109);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(889, 86);
            panelSearch.TabIndex = 9;
            // 
            // panelOption
            // 
            panelOption.BackColor = Color.Transparent;
            panelOption.Controls.Add(btnViewPlayers);
            panelOption.Controls.Add(btnRemove);
            panelOption.Controls.Add(btnUpdate);
            panelOption.Controls.Add(btnAdd);
            panelOption.Location = new Point(195, 669);
            panelOption.Name = "panelOption";
            panelOption.Size = new Size(889, 100);
            panelOption.TabIndex = 10;
            // 
            // btnViewPlayers
            // 
            btnViewPlayers.BackColor = Color.FromArgb(35, 38, 39);
            btnViewPlayers.Cursor = Cursors.Hand;
            btnViewPlayers.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            btnViewPlayers.ForeColor = Color.FromArgb(40, 156, 56);
            btnViewPlayers.Location = new Point(759, 35);
            btnViewPlayers.Name = "btnViewPlayers";
            btnViewPlayers.Size = new Size(111, 37);
            btnViewPlayers.TabIndex = 7;
            btnViewPlayers.Text = "Players";
            btnViewPlayers.UseVisualStyleBackColor = false;
            btnViewPlayers.Click += btnViewPlayers_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(35, 38, 39);
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            btnRemove.ForeColor = Color.FromArgb(40, 156, 56);
            btnRemove.Location = new Point(524, 35);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(111, 37);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(35, 38, 39);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            btnUpdate.ForeColor = Color.FromArgb(40, 156, 56);
            btnUpdate.Location = new Point(274, 35);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(111, 37);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(35, 38, 39);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            btnAdd.ForeColor = Color.FromArgb(40, 156, 56);
            btnAdd.Location = new Point(33, 35);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(111, 37);
            btnAdd.TabIndex = 4;
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
            dgvTeams.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeams.BackgroundColor = Color.FromArgb(35, 38, 39);
            dgvTeams.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTeams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTeams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.DarkGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTeams.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTeams.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTeams.EnableHeadersVisualStyles = false;
            dgvTeams.GridColor = Color.DarkGray;
            dgvTeams.Location = new Point(195, 231);
            dgvTeams.Name = "dgvTeams";
            dgvTeams.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(40, 156, 56);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(35, 38, 39);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTeams.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTeams.RowHeadersVisible = false;
            dgvTeams.RowHeadersWidth = 62;
            dgvTeams.RowTemplate.Height = 42;
            dgvTeams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeams.Size = new Size(889, 416);
            dgvTeams.TabIndex = 0;
            // 
            // btnCloseForm
            // 
            btnCloseForm.BackColor = Color.Transparent;
            btnCloseForm.BackgroundImage = (Image)resources.GetObject("btnCloseForm.BackgroundImage");
            btnCloseForm.BackgroundImageLayout = ImageLayout.Stretch;
            btnCloseForm.Cursor = Cursors.Hand;
            btnCloseForm.FlatAppearance.BorderSize = 0;
            btnCloseForm.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnCloseForm.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCloseForm.FlatStyle = FlatStyle.Flat;
            btnCloseForm.ForeColor = Color.Transparent;
            btnCloseForm.Location = new Point(1226, 1);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(60, 60);
            btnCloseForm.TabIndex = 9;
            btnCloseForm.UseVisualStyleBackColor = false;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.BackgroundImage = (Image)resources.GetObject("btnMinimize.BackgroundImage");
            btnMinimize.BackgroundImageLayout = ImageLayout.Stretch;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.ForeColor = Color.Transparent;
            btnMinimize.Location = new Point(1175, 1);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(60, 60);
            btnMinimize.TabIndex = 8;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // TeamListForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(35, 38, 39);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1284, 781);
            Controls.Add(btnMinimize);
            Controls.Add(btnCloseForm);
            Controls.Add(dgvTeams);
            Controls.Add(panelOption);
            Controls.Add(panelSearch);
            Controls.Add(Header);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Pixel);
            ForeColor = Color.DarkGray;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TeamListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TeamListForm";
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTeams).EndInit();
            ResumeLayout(false);
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
        private Button btnCloseForm;
        private Button btnMinimize;
    }
}
