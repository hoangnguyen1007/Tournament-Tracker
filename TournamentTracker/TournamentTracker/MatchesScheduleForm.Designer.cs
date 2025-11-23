namespace tournament_tracker
{
    partial class MatchesScheduleForm
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            titleLabel = new Label();
            matchesLabel = new Label();
            choiceRoundComboBox = new ComboBox();
            matchesDataGridView = new DataGridView();
            colHome = new DataGridViewTextBoxColumn();
            colScore = new DataGridViewTextBoxColumn();
            colAway = new DataGridViewTextBoxColumn();
            updateButton = new Button();
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
            standingsLabel = new Label();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)matchesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)standingsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(25, 25, 25);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1261, 91);
            headerPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(0, 180, 80);
            titleLabel.Location = new Point(23, 15);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(318, 46);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "🏆 TOURNAMENT";
            // 
            // matchesLabel
            // 
            matchesLabel.AutoSize = true;
            matchesLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            matchesLabel.ForeColor = Color.Gold;
            matchesLabel.Location = new Point(39, 131);
            matchesLabel.Name = "matchesLabel";
            matchesLabel.Size = new Size(230, 30);
            matchesLabel.TabIndex = 1;
            matchesLabel.Text = "MATCHES SCHEDULE";
            // 
            // choiceRoundComboBox
            // 
            choiceRoundComboBox.BackColor = Color.FromArgb(32, 33, 36);
            choiceRoundComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            choiceRoundComboBox.FlatStyle = FlatStyle.Flat;
            choiceRoundComboBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            choiceRoundComboBox.ForeColor = Color.White;
            choiceRoundComboBox.FormattingEnabled = true;
            choiceRoundComboBox.Items.AddRange(new object[] { "Round 1", "Round 2" });
            choiceRoundComboBox.Location = new Point(305, 131);
            choiceRoundComboBox.Margin = new Padding(3, 4, 3, 4);
            choiceRoundComboBox.Name = "choiceRoundComboBox";
            choiceRoundComboBox.Size = new Size(200, 33);
            choiceRoundComboBox.TabIndex = 2;
            // 
            // matchesDataGridView
            // 
            matchesDataGridView.AllowUserToAddRows = false;
            matchesDataGridView.BackgroundColor = Color.FromArgb(45, 48, 53);
            matchesDataGridView.BorderStyle = BorderStyle.None;
            matchesDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            matchesDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.Black;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            matchesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            matchesDataGridView.ColumnHeadersHeight = 50;
            matchesDataGridView.Columns.AddRange(new DataGridViewColumn[] { colHome, colScore, colAway });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(45, 48, 53);
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.White;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            matchesDataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            matchesDataGridView.EnableHeadersVisualStyles = false;
            matchesDataGridView.GridColor = SystemColors.GrayText;
            matchesDataGridView.Location = new Point(44, 202);
            matchesDataGridView.Margin = new Padding(3, 4, 3, 4);
            matchesDataGridView.Name = "matchesDataGridView";
            matchesDataGridView.RowHeadersVisible = false;
            matchesDataGridView.RowHeadersWidth = 51;
            matchesDataGridView.RowTemplate.Height = 50;
            matchesDataGridView.Size = new Size(585, 609);
            matchesDataGridView.TabIndex = 3;
            // 
            // colHome
            // 
            colHome.DataPropertyName = "HomeTeamName";
            colHome.FillWeight = 85.82887F;
            colHome.HeaderText = "HOME";
            colHome.MinimumWidth = 150;
            colHome.Name = "colHome";
            colHome.Width = 180;
            // 
            // colScore
            // 
            colScore.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colScore.DataPropertyName = "ScoreDisplay";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colScore.DefaultCellStyle = dataGridViewCellStyle8;
            colScore.FillWeight = 128.3422F;
            colScore.HeaderText = "SCORE";
            colScore.MinimumWidth = 80;
            colScore.Name = "colScore";
            colScore.Width = 80;
            // 
            // colAway
            // 
            colAway.DataPropertyName = "AwayTeamName";
            colAway.FillWeight = 85.82887F;
            colAway.HeaderText = "AWAY";
            colAway.MinimumWidth = 150;
            colAway.Name = "colAway";
            colAway.Width = 179;
            // 
            // updateButton
            // 
            updateButton.BackColor = Color.FromArgb(0, 180, 80);
            updateButton.FlatAppearance.BorderColor = Color.SpringGreen;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateButton.ForeColor = Color.White;
            updateButton.Location = new Point(44, 822);
            updateButton.Margin = new Padding(3, 4, 3, 4);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(585, 76);
            updateButton.TabIndex = 4;
            updateButton.Text = "UPDATE RESULTS";
            updateButton.UseVisualStyleBackColor = false;
            // 
            // standingsDataGridView
            // 
            standingsDataGridView.AllowUserToAddRows = false;
            standingsDataGridView.BackgroundColor = Color.FromArgb(45, 48, 53);
            standingsDataGridView.BorderStyle = BorderStyle.None;
            standingsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            standingsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.Black;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.Black;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            standingsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            standingsDataGridView.ColumnHeadersHeight = 50;
            standingsDataGridView.Columns.AddRange(new DataGridViewColumn[] { colSTT, colTeam, colP, colW, colD, colL, colGF, colGA, colGD, colPTS });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(45, 48, 53);
            dataGridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            standingsDataGridView.DefaultCellStyle = dataGridViewCellStyle12;
            standingsDataGridView.EnableHeadersVisualStyles = false;
            standingsDataGridView.GridColor = SystemColors.GrayText;
            standingsDataGridView.Location = new Point(654, 202);
            standingsDataGridView.Margin = new Padding(3, 4, 3, 4);
            standingsDataGridView.Name = "standingsDataGridView";
            standingsDataGridView.RowHeadersVisible = false;
            standingsDataGridView.RowHeadersWidth = 51;
            standingsDataGridView.RowTemplate.Height = 24;
            standingsDataGridView.Size = new Size(585, 698);
            standingsDataGridView.TabIndex = 5;
            // 
            // colSTT
            // 
            colSTT.DataPropertyName = "Rank";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.Black;
            dataGridViewCellStyle11.ForeColor = Color.White;
            dataGridViewCellStyle11.SelectionBackColor = Color.Black;
            colSTT.DefaultCellStyle = dataGridViewCellStyle11;
            colSTT.HeaderText = "#";
            colSTT.MinimumWidth = 30;
            colSTT.Name = "colSTT";
            colSTT.Width = 30;
            // 
            // colTeam
            // 
            colTeam.DataPropertyName = "Name";
            colTeam.HeaderText = "TEAM";
            colTeam.MinimumWidth = 150;
            colTeam.Name = "colTeam";
            colTeam.Width = 154;
            // 
            // colP
            // 
            colP.DataPropertyName = "Player";
            colP.HeaderText = "P";
            colP.MinimumWidth = 30;
            colP.Name = "colP";
            colP.Width = 30;
            // 
            // colW
            // 
            colW.DataPropertyName = "Won";
            colW.HeaderText = "W";
            colW.MinimumWidth = 30;
            colW.Name = "colW";
            colW.Width = 30;
            // 
            // colD
            // 
            colD.DataPropertyName = "Drawn";
            colD.HeaderText = "D";
            colD.MinimumWidth = 30;
            colD.Name = "colD";
            colD.Width = 30;
            // 
            // colL
            // 
            colL.DataPropertyName = "Lost";
            colL.HeaderText = "L";
            colL.MinimumWidth = 30;
            colL.Name = "colL";
            colL.Width = 30;
            // 
            // colGF
            // 
            colGF.DataPropertyName = "GF";
            colGF.HeaderText = "GF";
            colGF.MinimumWidth = 30;
            colGF.Name = "colGF";
            colGF.Width = 30;
            // 
            // colGA
            // 
            colGA.DataPropertyName = "GA";
            colGA.HeaderText = "GA";
            colGA.MinimumWidth = 30;
            colGA.Name = "colGA";
            colGA.Width = 30;
            // 
            // colGD
            // 
            colGD.DataPropertyName = "GD";
            colGD.HeaderText = "+/-";
            colGD.MinimumWidth = 35;
            colGD.Name = "colGD";
            colGD.Width = 35;
            // 
            // colPTS
            // 
            colPTS.DataPropertyName = "Points";
            colPTS.HeaderText = "PTS";
            colPTS.MinimumWidth = 40;
            colPTS.Name = "colPTS";
            colPTS.Width = 40;
            // 
            // standingsLabel
            // 
            standingsLabel.AutoSize = true;
            standingsLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            standingsLabel.ForeColor = Color.Gold;
            standingsLabel.Location = new Point(649, 131);
            standingsLabel.Name = "standingsLabel";
            standingsLabel.Size = new Size(136, 30);
            standingsLabel.TabIndex = 6;
            standingsLabel.Text = "STANDINGS";
            // 
            // MatchesScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(32, 33, 36);
            ClientSize = new Size(1282, 840);
            Controls.Add(standingsLabel);
            Controls.Add(standingsDataGridView);
            Controls.Add(updateButton);
            Controls.Add(matchesDataGridView);
            Controls.Add(choiceRoundComboBox);
            Controls.Add(matchesLabel);
            Controls.Add(headerPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "MatchesScheduleForm";
            Text = "Tournament Tracker";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)matchesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)standingsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();

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

