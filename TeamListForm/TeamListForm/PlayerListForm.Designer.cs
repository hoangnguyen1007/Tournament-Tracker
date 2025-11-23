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
            panel1 = new Panel();
            lbTitle = new Label();
            panel2 = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lbSearch = new Label();
            panel4 = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            dgvPlayers = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lbTitle);
            panel1.Location = new Point(52, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(814, 100);
            panel1.TabIndex = 0;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Location = new Point(35, 29);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(167, 15);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "DANH SÁCH CẦU THỦ CỦA ...";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(lbSearch);
            panel2.Location = new Point(52, 189);
            panel2.Name = "panel2";
            panel2.Size = new Size(814, 90);
            panel2.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(624, 27);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(220, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(241, 23);
            txtSearch.TabIndex = 3;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Location = new Point(35, 36);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(77, 15);
            lbSearch.TabIndex = 2;
            lbSearch.Text = "Search Player";
            // 
            // panel4
            // 
            panel4.Controls.Add(btnDelete);
            panel4.Controls.Add(btnUpdate);
            panel4.Controls.Add(btnAdd);
            panel4.Location = new Point(52, 478);
            panel4.Name = "panel4";
            panel4.Size = new Size(814, 90);
            panel4.TabIndex = 2;
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
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "PlayerListForm";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbTitle;
        private Panel panel2;
        private Panel panel4;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lbSearch;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private DataGridView dgvPlayers;
    }
}