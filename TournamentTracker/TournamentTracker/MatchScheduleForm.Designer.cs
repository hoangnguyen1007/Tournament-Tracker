namespace tournament_tracker
{
    partial class MatchScheduleForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            label1 = new Label();
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
            headerPanel.Controls.Add(label1);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1282, 73);
            headerPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 180, 80);
            label1.Location = new Point(23, 12);
            label1.Name = "label1";
            label1.Size = new Size(318, 46);
            label1.TabIndex = 0;
            label1.Text = "🏆 TOURNAMENT";
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
            matchesLabel.Location = new Point(39, 105);
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
            choiceRoundComboBox.Location = new Point(305, 105);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            matchesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            matchesDataGridView.ColumnHeadersHeight = 50;
            matchesDataGridView.Columns.AddRange(new DataGridViewColumn[] { colHome, colScore, colAway });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 48, 53);
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            matchesDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            matchesDataGridView.EnableHeadersVisualStyles = false;
            matchesDataGridView.GridColor = SystemColors.GrayText;
            matchesDataGridView.Location = new Point(44, 161);
            matchesDataGridView.Margin = new Padding(3, 4, 3, 4);
            matchesDataGridView.Name = "matchesDataGridView";
            matchesDataGridView.RowHeadersVisible = false;
            matchesDataGridView.RowHeadersWidth = 51;
            matchesDataGridView.RowTemplate.Height = 50;
            matchesDataGridView.Size = new Size(585, 487);
            matchesDataGridView.TabIndex = 3;
            // 
            // colHome
            // 
            colHome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHome.DataPropertyName = "HomeTeamName";
            colHome.FillWeight = 85.82887F;
            colHome.HeaderText = "HOME";
            colHome.MinimumWidth = 150;
            colHome.Name = "colHome";
            // 
            // colScore
            // 
            colScore.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colScore.DataPropertyName = "ScoreDisplay";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colScore.DefaultCellStyle = dataGridViewCellStyle2;
            colScore.FillWeight = 128.3422F;
            colScore.HeaderText = "SCORE";
            colScore.MinimumWidth = 80;
            colScore.Name = "colScore";
            colScore.Width = 80;
            // 
            // colAway
            // 
            colAway.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAway.DataPropertyName = "AwayTeamName";
            colAway.FillWeight = 85.82887F;
            colAway.HeaderText = "AWAY";
            colAway.MinimumWidth = 150;
            colAway.Name = "colAway";
            // 
            // updateButton
            // 
            updateButton.BackColor = Color.FromArgb(0, 180, 80);
            updateButton.FlatAppearance.BorderColor = Color.SpringGreen;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateButton.ForeColor = Color.White;
            updateButton.Location = new Point(44, 658);
            updateButton.Margin = new Padding(3, 4, 3, 4);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(585, 61);
            updateButton.TabIndex = 4;
            updateButton.Text = "UPDATE RESULTS";
            updateButton.UseVisualStyleBackColor = false;
            updateButton.Click += updateButton_Click;
            // 
            // standingsDataGridView
            // 
            standingsDataGridView.AllowUserToAddRows = false;
            standingsDataGridView.BackgroundColor = Color.FromArgb(45, 48, 53);
            standingsDataGridView.BorderStyle = BorderStyle.None;
            standingsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            standingsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            standingsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            standingsDataGridView.ColumnHeadersHeight = 50;
            standingsDataGridView.Columns.AddRange(new DataGridViewColumn[] { colSTT, colTeam, colP, colW, colD, colL, colGF, colGA, colGD, colPTS });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(45, 48, 53);
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            standingsDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            standingsDataGridView.EnableHeadersVisualStyles = false;
            standingsDataGridView.GridColor = SystemColors.GrayText;
            standingsDataGridView.Location = new Point(654, 161);
            standingsDataGridView.Margin = new Padding(3, 4, 3, 4);
            standingsDataGridView.Name = "standingsDataGridView";
            standingsDataGridView.RowHeadersVisible = false;
            standingsDataGridView.RowHeadersWidth = 51;
            standingsDataGridView.RowTemplate.Height = 24;
            standingsDataGridView.Size = new Size(585, 558);
            standingsDataGridView.TabIndex = 5;
            // 
            // colSTT
            // 
            colSTT.DataPropertyName = "Rank";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Black;
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.Black;
            colSTT.DefaultCellStyle = dataGridViewCellStyle5;
            colSTT.HeaderText = "#";
            colSTT.MinimumWidth = 30;
            colSTT.Name = "colSTT";
            colSTT.Width = 30;
            // 
            // colTeam
            // 
            colTeam.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTeam.DataPropertyName = "Name";
            colTeam.HeaderText = "TEAM";
            colTeam.MinimumWidth = 150;
            colTeam.Name = "colTeam";
            // 
            // colP
            // 
            colP.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colP.DataPropertyName = "Player";
            colP.HeaderText = "P";
            colP.MinimumWidth = 30;
            colP.Name = "colP";
            colP.Width = 44;
            // 
            // colW
            // 
            colW.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colW.DataPropertyName = "Won";
            colW.HeaderText = "W";
            colW.MinimumWidth = 30;
            colW.Name = "colW";
            colW.Width = 48;
            // 
            // colD
            // 
            colD.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colD.DataPropertyName = "Drawn";
            colD.HeaderText = "D";
            colD.MinimumWidth = 30;
            colD.Name = "colD";
            colD.Width = 45;
            // 
            // colL
            // 
            colL.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colL.DataPropertyName = "Lost";
            colL.HeaderText = "L";
            colL.MinimumWidth = 30;
            colL.Name = "colL";
            colL.Width = 42;
            // 
            // colGF
            // 
            colGF.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGF.DataPropertyName = "GF";
            colGF.HeaderText = "GF";
            colGF.MinimumWidth = 30;
            colGF.Name = "colGF";
            colGF.Width = 54;
            // 
            // colGA
            // 
            colGA.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGA.DataPropertyName = "GA";
            colGA.HeaderText = "GA";
            colGA.MinimumWidth = 30;
            colGA.Name = "colGA";
            colGA.Width = 55;
            // 
            // colGD
            // 
            colGD.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGD.DataPropertyName = "GD";
            colGD.HeaderText = "+/-";
            colGD.MinimumWidth = 35;
            colGD.Name = "colGD";
            colGD.Width = 52;
            // 
            // colPTS
            // 
            colPTS.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPTS.DataPropertyName = "Points";
            colPTS.HeaderText = "PTS";
            colPTS.MinimumWidth = 40;
            colPTS.Name = "colPTS";
            colPTS.Width = 64;
            // 
            // standingsLabel
            // 
            standingsLabel.AutoSize = true;
            standingsLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            standingsLabel.ForeColor = Color.Gold;
            standingsLabel.Location = new Point(649, 105);
            standingsLabel.Name = "standingsLabel";
            standingsLabel.Size = new Size(136, 30);
            standingsLabel.TabIndex = 6;
            standingsLabel.Text = "STANDINGS";
            // 
            // MatchScheduleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(32, 33, 36);
            ClientSize = new Size(1282, 773);
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
            Name = "MatchScheduleForm";
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
        private Label label1;
        private DataGridViewTextBoxColumn colHome;
        private DataGridViewTextBoxColumn colScore;
        private DataGridViewTextBoxColumn colAway;
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

