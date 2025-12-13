namespace TeamListForm
{
    partial class InfoMatchForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoMatchForm));
            standingsLabel = new Label();
            matchesLabel = new Label();
            standingsDataGridView = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colTeam = new DataGridViewTextBoxColumn();
            colP = new DataGridViewTextBoxColumn();
            colW = new DataGridViewTextBoxColumn();
            colD = new DataGridViewTextBoxColumn();
            colL = new DataGridViewTextBoxColumn();
            colGF = new DataGridViewTextBoxColumn();
            colGA = new DataGridViewTextBoxColumn();
            colGD = new DataGridViewTextBoxColumn();
            colPTS = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)standingsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // standingsLabel
            // 
            standingsLabel.AutoSize = true;
            standingsLabel.BackColor = Color.Transparent;
            standingsLabel.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            standingsLabel.ForeColor = Color.Gold;
            standingsLabel.Location = new Point(661, 67);
            standingsLabel.Name = "standingsLabel";
            standingsLabel.Size = new Size(158, 35);
            standingsLabel.TabIndex = 13;
            standingsLabel.Text = "STANDINGS";
            // 
            // matchesLabel
            // 
            matchesLabel.AutoSize = true;
            matchesLabel.BackColor = Color.Transparent;
            matchesLabel.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            matchesLabel.ForeColor = Color.Gold;
            matchesLabel.Location = new Point(57, 56);
            matchesLabel.Name = "matchesLabel";
            matchesLabel.Size = new Size(262, 35);
            matchesLabel.TabIndex = 8;
            matchesLabel.Text = "MATCHES SCHEDULE";
            // 
            // standingsDataGridView
            // 
            standingsDataGridView.AllowUserToAddRows = false;
            standingsDataGridView.AllowUserToResizeColumns = false;
            standingsDataGridView.AllowUserToResizeRows = false;
            standingsDataGridView.BackgroundColor = Color.FromArgb(45, 48, 53);
            standingsDataGridView.BorderStyle = BorderStyle.None;
            standingsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            standingsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            standingsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            standingsDataGridView.ColumnHeadersHeight = 50;
            standingsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            standingsDataGridView.Columns.AddRange(new DataGridViewColumn[] { colSTT, colTeam, colP, colW, colD, colL, colGF, colGA, colGD, colPTS });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 48, 53);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            standingsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            standingsDataGridView.EnableHeadersVisualStyles = false;
            standingsDataGridView.GridColor = SystemColors.GrayText;
            standingsDataGridView.Location = new Point(57, 114);
            standingsDataGridView.Margin = new Padding(3, 4, 3, 4);
            standingsDataGridView.Name = "standingsDataGridView";
            standingsDataGridView.ReadOnly = true;
            standingsDataGridView.RowHeadersVisible = false;
            standingsDataGridView.RowHeadersWidth = 51;
            standingsDataGridView.RowTemplate.Height = 50;
            standingsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            standingsDataGridView.Size = new Size(528, 463);
            standingsDataGridView.TabIndex = 14;
            // 
            // colSTT
            // 
            colSTT.DataPropertyName = "Rank";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            colSTT.DefaultCellStyle = dataGridViewCellStyle2;
            colSTT.HeaderText = "#";
            colSTT.MinimumWidth = 30;
            colSTT.Name = "colSTT";
            colSTT.ReadOnly = true;
            colSTT.Width = 30;
            // 
            // colTeam
            // 
            colTeam.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTeam.DataPropertyName = "Name";
            colTeam.HeaderText = "TEAM";
            colTeam.MinimumWidth = 100;
            colTeam.Name = "colTeam";
            colTeam.ReadOnly = true;
            // 
            // colP
            // 
            colP.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colP.DataPropertyName = "Player";
            colP.HeaderText = "P";
            colP.MinimumWidth = 30;
            colP.Name = "colP";
            colP.ReadOnly = true;
            colP.Width = 37;
            // 
            // colW
            // 
            colW.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colW.DataPropertyName = "Won";
            colW.HeaderText = "W";
            colW.MinimumWidth = 30;
            colW.Name = "colW";
            colW.ReadOnly = true;
            colW.Width = 40;
            // 
            // colD
            // 
            colD.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colD.DataPropertyName = "Drawn";
            colD.HeaderText = "D";
            colD.MinimumWidth = 30;
            colD.Name = "colD";
            colD.ReadOnly = true;
            colD.Width = 38;
            // 
            // colL
            // 
            colL.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colL.DataPropertyName = "Lost";
            colL.HeaderText = "L";
            colL.MinimumWidth = 30;
            colL.Name = "colL";
            colL.ReadOnly = true;
            colL.Width = 36;
            // 
            // colGF
            // 
            colGF.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGF.DataPropertyName = "GF";
            colGF.HeaderText = "GF";
            colGF.MinimumWidth = 30;
            colGF.Name = "colGF";
            colGF.ReadOnly = true;
            colGF.Width = 42;
            // 
            // colGA
            // 
            colGA.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGA.DataPropertyName = "GA";
            colGA.HeaderText = "GA";
            colGA.MinimumWidth = 30;
            colGA.Name = "colGA";
            colGA.ReadOnly = true;
            colGA.Width = 44;
            // 
            // colGD
            // 
            colGD.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGD.DataPropertyName = "GD";
            colGD.HeaderText = "+/-";
            colGD.MinimumWidth = 30;
            colGD.Name = "colGD";
            colGD.ReadOnly = true;
            colGD.Width = 46;
            // 
            // colPTS
            // 
            colPTS.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPTS.DataPropertyName = "Points";
            colPTS.HeaderText = "PTS";
            colPTS.MinimumWidth = 30;
            colPTS.Name = "colPTS";
            colPTS.ReadOnly = true;
            colPTS.Width = 47;
            // 
            // InfoMatchForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1247, 679);
            Controls.Add(standingsDataGridView);
            Controls.Add(standingsLabel);
            Controls.Add(matchesLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Pixel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "InfoMatchForm";
            Text = "Info Match";
            ((System.ComponentModel.ISupportInitialize)standingsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label standingsLabel;
        private Label matchesLabel;
        private DataGridView standingsDataGridView;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colTeam;
        private DataGridViewTextBoxColumn colP;
        private DataGridViewTextBoxColumn colW;
        private DataGridViewTextBoxColumn colD;
        private DataGridViewTextBoxColumn colL;
        private DataGridViewTextBoxColumn colGF;
        private DataGridViewTextBoxColumn colGA;
        private DataGridViewTextBoxColumn colGD;
        private DataGridViewTextBoxColumn colPTS;
    }
}