namespace tournament_tracker
{
    partial class mainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.matchesLabel = new System.Windows.Forms.Label();
            this.choiceRoundComboBox = new System.Windows.Forms.ComboBox();
            this.matchesDataGridView = new System.Windows.Forms.DataGridView();
            this.colHome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAway = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateButton = new System.Windows.Forms.Button();
            this.standingsDataGridView = new System.Windows.Forms.DataGridView();
            this.standingsLabel = new System.Windows.Forms.Label();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.standingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1282, 73);
            this.headerPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))));
            this.titleLabel.Location = new System.Drawing.Point(23, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(318, 46);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "🏆 TOURNAMENT";
            // 
            // matchesLabel
            // 
            this.matchesLabel.AutoSize = true;
            this.matchesLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchesLabel.ForeColor = System.Drawing.Color.Gold;
            this.matchesLabel.Location = new System.Drawing.Point(39, 105);
            this.matchesLabel.Name = "matchesLabel";
            this.matchesLabel.Size = new System.Drawing.Size(230, 30);
            this.matchesLabel.TabIndex = 1;
            this.matchesLabel.Text = "MATCHES SCHEDULE";
            // 
            // choiceRoundComboBox
            // 
            this.choiceRoundComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.choiceRoundComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.choiceRoundComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choiceRoundComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choiceRoundComboBox.ForeColor = System.Drawing.Color.White;
            this.choiceRoundComboBox.FormattingEnabled = true;
            this.choiceRoundComboBox.Items.AddRange(new object[] {
            "Round 1",
            "Round 2"});
            this.choiceRoundComboBox.Location = new System.Drawing.Point(305, 105);
            this.choiceRoundComboBox.Name = "choiceRoundComboBox";
            this.choiceRoundComboBox.Size = new System.Drawing.Size(200, 33);
            this.choiceRoundComboBox.TabIndex = 2;
            // 
            // matchesDataGridView
            // 
            this.matchesDataGridView.AllowUserToAddRows = false;
            this.matchesDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(53)))));
            this.matchesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matchesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.matchesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.matchesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.matchesDataGridView.ColumnHeadersHeight = 50;
            this.matchesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHome,
            this.colScore,
            this.colAway});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matchesDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.matchesDataGridView.EnableHeadersVisualStyles = false;
            this.matchesDataGridView.GridColor = System.Drawing.SystemColors.GrayText;
            this.matchesDataGridView.Location = new System.Drawing.Point(44, 161);
            this.matchesDataGridView.Name = "matchesDataGridView";
            this.matchesDataGridView.RowHeadersVisible = false;
            this.matchesDataGridView.RowHeadersWidth = 51;
            this.matchesDataGridView.RowTemplate.Height = 50;
            this.matchesDataGridView.Size = new System.Drawing.Size(585, 487);
            this.matchesDataGridView.TabIndex = 3;
            // 
            // colHome
            // 
            this.colHome.DataPropertyName = "HomeTeamName";
            this.colHome.FillWeight = 85.82887F;
            this.colHome.HeaderText = "HOME";
            this.colHome.MinimumWidth = 150;
            this.colHome.Name = "colHome";
            this.colHome.Width = 180;
            // 
            // colScore
            // 
            this.colScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colScore.DataPropertyName = "ScoreDisplay";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colScore.DefaultCellStyle = dataGridViewCellStyle2;
            this.colScore.FillWeight = 128.3422F;
            this.colScore.HeaderText = "SCORE";
            this.colScore.MinimumWidth = 80;
            this.colScore.Name = "colScore";
            this.colScore.Width = 80;
            // 
            // colAway
            // 
            this.colAway.DataPropertyName = "AwayTeamName";
            this.colAway.FillWeight = 85.82887F;
            this.colAway.HeaderText = "AWAY";
            this.colAway.MinimumWidth = 150;
            this.colAway.Name = "colAway";
            this.colAway.Width = 179;
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))));
            this.updateButton.FlatAppearance.BorderColor = System.Drawing.Color.SpringGreen;
            this.updateButton.FlatAppearance.BorderSize = 0;
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Location = new System.Drawing.Point(44, 658);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(585, 61);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "UPDATE RESULTS";
            this.updateButton.UseVisualStyleBackColor = false;
            // 
            // standingsDataGridView
            // 
            this.standingsDataGridView.AllowUserToAddRows = false;
            this.standingsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(53)))));
            this.standingsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.standingsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.standingsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.standingsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.standingsDataGridView.ColumnHeadersHeight = 50;
            this.standingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTeam,
            this.colP,
            this.colW,
            this.colD,
            this.colL,
            this.colGF,
            this.colGA,
            this.colGD,
            this.colPTS});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.standingsDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.standingsDataGridView.EnableHeadersVisualStyles = false;
            this.standingsDataGridView.GridColor = System.Drawing.SystemColors.GrayText;
            this.standingsDataGridView.Location = new System.Drawing.Point(654, 161);
            this.standingsDataGridView.Name = "standingsDataGridView";
            this.standingsDataGridView.RowHeadersVisible = false;
            this.standingsDataGridView.RowHeadersWidth = 51;
            this.standingsDataGridView.RowTemplate.Height = 24;
            this.standingsDataGridView.Size = new System.Drawing.Size(585, 558);
            this.standingsDataGridView.TabIndex = 5;
            // 
            // standingsLabel
            // 
            this.standingsLabel.AutoSize = true;
            this.standingsLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.standingsLabel.ForeColor = System.Drawing.Color.Gold;
            this.standingsLabel.Location = new System.Drawing.Point(649, 105);
            this.standingsLabel.Name = "standingsLabel";
            this.standingsLabel.Size = new System.Drawing.Size(136, 30);
            this.standingsLabel.TabIndex = 6;
            this.standingsLabel.Text = "STANDINGS";
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "Rank";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            this.colSTT.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSTT.HeaderText = "#";
            this.colSTT.MinimumWidth = 30;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 30;
            // 
            // colTeam
            // 
            this.colTeam.DataPropertyName = "Name";
            this.colTeam.HeaderText = "TEAM";
            this.colTeam.MinimumWidth = 150;
            this.colTeam.Name = "colTeam";
            this.colTeam.Width = 154;
            // 
            // colP
            // 
            this.colP.DataPropertyName = "Player";
            this.colP.HeaderText = "P";
            this.colP.MinimumWidth = 30;
            this.colP.Name = "colP";
            this.colP.Width = 30;
            // 
            // colW
            // 
            this.colW.DataPropertyName = "Won";
            this.colW.HeaderText = "W";
            this.colW.MinimumWidth = 30;
            this.colW.Name = "colW";
            this.colW.Width = 30;
            // 
            // colD
            // 
            this.colD.DataPropertyName = "Drawn";
            this.colD.HeaderText = "D";
            this.colD.MinimumWidth = 30;
            this.colD.Name = "colD";
            this.colD.Width = 30;
            // 
            // colL
            // 
            this.colL.DataPropertyName = "Lost";
            this.colL.HeaderText = "L";
            this.colL.MinimumWidth = 30;
            this.colL.Name = "colL";
            this.colL.Width = 30;
            // 
            // colGF
            // 
            this.colGF.DataPropertyName = "GF";
            this.colGF.HeaderText = "GF";
            this.colGF.MinimumWidth = 30;
            this.colGF.Name = "colGF";
            this.colGF.Width = 30;
            // 
            // colGA
            // 
            this.colGA.DataPropertyName = "GA";
            this.colGA.HeaderText = "GA";
            this.colGA.MinimumWidth = 30;
            this.colGA.Name = "colGA";
            this.colGA.Width = 30;
            // 
            // colGD
            // 
            this.colGD.DataPropertyName = "GD";
            this.colGD.HeaderText = "+/-";
            this.colGD.MinimumWidth = 35;
            this.colGD.Name = "colGD";
            this.colGD.Width = 35;
            // 
            // colPTS
            // 
            this.colPTS.DataPropertyName = "Points";
            this.colPTS.HeaderText = "PTS";
            this.colPTS.MinimumWidth = 40;
            this.colPTS.Name = "colPTS";
            this.colPTS.Width = 40;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1282, 773);
            this.Controls.Add(this.standingsLabel);
            this.Controls.Add(this.standingsDataGridView);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.matchesDataGridView);
            this.Controls.Add(this.choiceRoundComboBox);
            this.Controls.Add(this.matchesLabel);
            this.Controls.Add(this.headerPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Tournament Tracker";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.standingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label matchesLabel;
        private System.Windows.Forms.ComboBox choiceRoundComboBox;
        private System.Windows.Forms.DataGridView matchesDataGridView;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.DataGridView standingsDataGridView;
        private System.Windows.Forms.Label standingsLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAway;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colW;
        private System.Windows.Forms.DataGridViewTextBoxColumn colD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPTS;
    }
}

