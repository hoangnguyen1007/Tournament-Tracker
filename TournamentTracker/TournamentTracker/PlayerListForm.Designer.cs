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
            panelHeader = new Panel();
            lbTitle = new Label();
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
            panelHeader.Controls.Add(lbTitle);
            panelHeader.Location = new Point(52, 30);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(814, 100);
            panelHeader.TabIndex = 0;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.ForeColor = Color.FromArgb(40, 156, 56);
            lbTitle.Location = new Point(35, 29);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(352, 32);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "DANH SÁCH CẦU THỦ CỦA ...";
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lbSearch);
            panelSearch.ForeColor = Color.FromArgb(40, 156, 56);
            panelSearch.Location = new Point(52, 189);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(814, 90);
            panelSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(624, 27);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(135, 34);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(220, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(241, 33);
            txtSearch.TabIndex = 3;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbSearch.Location = new Point(35, 36);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(127, 25);
            lbSearch.TabIndex = 2;
            lbSearch.Text = "Search Player";
            // 
            // panelOptionBtn
            // 
            panelOptionBtn.Controls.Add(btnDelete);
            panelOptionBtn.Controls.Add(btnUpdate);
            panelOptionBtn.Controls.Add(btnAdd);
            panelOptionBtn.Location = new Point(52, 478);
            panelOptionBtn.Name = "panelOptionBtn";
            panelOptionBtn.Size = new Size(814, 90);
            panelOptionBtn.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(624, 27);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(386, 27);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(35, 27);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvPlayers
            // 
            dgvPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlayers.Location = new Point(52, 300);
            dgvPlayers.Name = "dgvPlayers";
            dgvPlayers.Size = new Size(814, 150);
            dgvPlayers.TabIndex = 3;
            // 
            // PlayerListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 617);
            Controls.Add(dgvPlayers);
            Controls.Add(panelOptionBtn);
            Controls.Add(panelSearch);
            Controls.Add(panelHeader);
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
        private Label lbTitle;
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