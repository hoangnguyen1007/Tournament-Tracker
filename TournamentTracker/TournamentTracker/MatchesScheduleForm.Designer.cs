namespace TeamListForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchesScheduleForm));
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
            colGF = new DataGridViewTextBoxColumn();
            colGA = new DataGridViewTextBoxColumn();
            colGD = new DataGridViewTextBoxColumn();
            colPTS = new DataGridViewTextBoxColumn();
            standingsLabel = new Label();
            titleLabel = new Label();
            btnStart = new Button();
            btnNextRound = new Button();
            InforButton = new Button();
            comboGroupFilter = new ComboBox();
            backButton = new Button();
            minimizeButton = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)matchesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)standingsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // matchesLabel
            // 
            matchesLabel.AutoSize = true;
            matchesLabel.BackColor = Color.Transparent;
            matchesLabel.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            matchesLabel.ForeColor = Color.Gold;
            matchesLabel.Location = new Point(44, 114);
            matchesLabel.Name = "matchesLabel";
            matchesLabel.Size = new Size(262, 35);
            matchesLabel.TabIndex = 1;
            matchesLabel.Text = "MATCHES SCHEDULE";
            // 
            // choiceRoundComboBox
            // 
            choiceRoundComboBox.BackColor = Color.FromArgb(32, 33, 36);
            choiceRoundComboBox.Cursor = Cursors.Hand;
            choiceRoundComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            choiceRoundComboBox.FlatStyle = FlatStyle.Flat;
            choiceRoundComboBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            choiceRoundComboBox.ForeColor = Color.White;
            choiceRoundComboBox.FormattingEnabled = true;
            choiceRoundComboBox.Location = new Point(379, 119);
            choiceRoundComboBox.Margin = new Padding(3, 4, 3, 4);
            choiceRoundComboBox.Name = "choiceRoundComboBox";
            choiceRoundComboBox.Size = new Size(129, 33);
            choiceRoundComboBox.TabIndex = 2;
            choiceRoundComboBox.SelectedIndexChanged += choiceRoundComboBox_SelectedIndexChanged;
            // 
            // matchesDataGridView
            // 
            matchesDataGridView.AllowUserToAddRows = false;
            matchesDataGridView.AllowUserToResizeColumns = false;
            matchesDataGridView.AllowUserToResizeRows = false;
            matchesDataGridView.BackgroundColor = Color.FromArgb(45, 48, 53);
            matchesDataGridView.BorderStyle = BorderStyle.None;
            matchesDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            matchesDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            matchesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            matchesDataGridView.ColumnHeadersHeight = 50;
            matchesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            matchesDataGridView.Columns.AddRange(new DataGridViewColumn[] { colHome, colScore, colAway });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(45, 48, 53);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            matchesDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            matchesDataGridView.EnableHeadersVisualStyles = false;
            matchesDataGridView.GridColor = SystemColors.GrayText;
            matchesDataGridView.Location = new Point(44, 170);
            matchesDataGridView.Margin = new Padding(3, 4, 3, 4);
            matchesDataGridView.Name = "matchesDataGridView";
            matchesDataGridView.ReadOnly = true;
            matchesDataGridView.RowHeadersVisible = false;
            matchesDataGridView.RowHeadersWidth = 51;
            matchesDataGridView.RowTemplate.Height = 50;
            matchesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            matchesDataGridView.Size = new Size(585, 478);
            matchesDataGridView.TabIndex = 3;
            matchesDataGridView.CellDoubleClick += matchesDataGridView_CellDoubleClick;
            // 
            // colHome
            // 
            colHome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHome.DataPropertyName = "HomeTeamName";
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            colHome.DefaultCellStyle = dataGridViewCellStyle2;
            colHome.FillWeight = 85.82887F;
            colHome.HeaderText = "HOME";
            colHome.MinimumWidth = 150;
            colHome.Name = "colHome";
            colHome.ReadOnly = true;
            // 
            // colScore
            // 
            colScore.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colScore.DataPropertyName = "ScoreDisplay";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colScore.DefaultCellStyle = dataGridViewCellStyle3;
            colScore.FillWeight = 128.3422F;
            colScore.HeaderText = "SCORE";
            colScore.MinimumWidth = 80;
            colScore.Name = "colScore";
            colScore.ReadOnly = true;
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
            colAway.ReadOnly = true;
            // 
            // updateButton
            // 
            updateButton.BackColor = Color.FromArgb(0, 180, 80);
            updateButton.Cursor = Cursors.Hand;
            updateButton.FlatAppearance.BorderColor = Color.SpringGreen;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
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
            standingsDataGridView.AllowUserToResizeColumns = false;
            standingsDataGridView.AllowUserToResizeRows = false;
            standingsDataGridView.BackgroundColor = Color.FromArgb(45, 48, 53);
            standingsDataGridView.BorderStyle = BorderStyle.None;
            standingsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            standingsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Black;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            standingsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            standingsDataGridView.ColumnHeadersHeight = 50;
            standingsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            standingsDataGridView.Columns.AddRange(new DataGridViewColumn[] { colSTT, colTeam, colGF, colGA, colGD, colPTS });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(45, 48, 53);
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            standingsDataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            standingsDataGridView.EnableHeadersVisualStyles = false;
            standingsDataGridView.GridColor = SystemColors.GrayText;
            standingsDataGridView.Location = new Point(654, 170);
            standingsDataGridView.Margin = new Padding(3, 4, 3, 4);
            standingsDataGridView.Name = "standingsDataGridView";
            standingsDataGridView.ReadOnly = true;
            standingsDataGridView.RowHeadersVisible = false;
            standingsDataGridView.RowHeadersWidth = 51;
            standingsDataGridView.RowTemplate.Height = 50;
            standingsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            standingsDataGridView.Size = new Size(585, 549);
            standingsDataGridView.TabIndex = 5;
            // 
            // colSTT
            // 
            colSTT.DataPropertyName = "Rank";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Black;
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.Black;
            colSTT.DefaultCellStyle = dataGridViewCellStyle6;
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
            // colGF
            // 
            colGF.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGF.DataPropertyName = "GF";
            colGF.HeaderText = "GF";
            colGF.MinimumWidth = 30;
            colGF.Name = "colGF";
            colGF.ReadOnly = true;
            colGF.Width = 53;
            // 
            // colGA
            // 
            colGA.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGA.DataPropertyName = "GA";
            colGA.HeaderText = "GA";
            colGA.MinimumWidth = 30;
            colGA.Name = "colGA";
            colGA.ReadOnly = true;
            colGA.Width = 56;
            // 
            // colGD
            // 
            colGD.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colGD.DataPropertyName = "GD";
            colGD.HeaderText = "+/-";
            colGD.MinimumWidth = 30;
            colGD.Name = "colGD";
            colGD.ReadOnly = true;
            colGD.Width = 58;
            // 
            // colPTS
            // 
            colPTS.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPTS.DataPropertyName = "Points";
            colPTS.HeaderText = "PTS";
            colPTS.MinimumWidth = 30;
            colPTS.Name = "colPTS";
            colPTS.ReadOnly = true;
            colPTS.Width = 60;
            // 
            // standingsLabel
            // 
            standingsLabel.AutoSize = true;
            standingsLabel.BackColor = Color.Transparent;
            standingsLabel.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            standingsLabel.ForeColor = Color.Gold;
            standingsLabel.Location = new Point(654, 114);
            standingsLabel.Name = "standingsLabel";
            standingsLabel.Size = new Size(158, 35);
            standingsLabel.TabIndex = 6;
            standingsLabel.Text = "STANDINGS";
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            titleLabel.ForeColor = Color.FromArgb(0, 180, 80);
            titleLabel.Location = new Point(23, 30);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(371, 54);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "🏆 TOURNAMENT";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Transparent;
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderColor = Color.SpringGreen;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 31F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(315, 110);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(50, 50);
            btnStart.TabIndex = 7;
            btnStart.Text = "🎲";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnNextRound
            // 
            btnNextRound.BackColor = Color.Transparent;
            btnNextRound.Cursor = Cursors.Hand;
            btnNextRound.FlatAppearance.BorderColor = Color.SpringGreen;
            btnNextRound.FlatAppearance.BorderSize = 0;
            btnNextRound.FlatStyle = FlatStyle.Flat;
            btnNextRound.Font = new Font("Segoe UI", 31F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            btnNextRound.ForeColor = Color.White;
            btnNextRound.Location = new Point(315, 110);
            btnNextRound.Margin = new Padding(3, 4, 3, 4);
            btnNextRound.Name = "btnNextRound";
            btnNextRound.Size = new Size(50, 50);
            btnNextRound.TabIndex = 8;
            btnNextRound.Text = "⏭";
            btnNextRound.UseVisualStyleBackColor = false;
            btnNextRound.Click += btnNextRound_Click;
            // 
            // InforButton
            // 
            InforButton.BackColor = Color.Transparent;
            InforButton.Cursor = Cursors.Hand;
            InforButton.FlatAppearance.BorderSize = 0;
            InforButton.FlatStyle = FlatStyle.Flat;
            InforButton.Font = new Font("Segoe UI", 31F, FontStyle.Regular, GraphicsUnit.Pixel);
            InforButton.ForeColor = Color.White;
            InforButton.Location = new Point(1177, 110);
            InforButton.Name = "InforButton";
            InforButton.Size = new Size(62, 50);
            InforButton.TabIndex = 0;
            InforButton.Text = "⌞⌝";
            InforButton.TextAlign = ContentAlignment.TopCenter;
            InforButton.UseVisualStyleBackColor = false;
            InforButton.Click += InforButton_Click;
            // 
            // comboGroupFilter
            // 
            comboGroupFilter.BackColor = Color.FromArgb(32, 33, 36);
            comboGroupFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboGroupFilter.FlatStyle = FlatStyle.Flat;
            comboGroupFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboGroupFilter.ForeColor = Color.White;
            comboGroupFilter.FormattingEnabled = true;
            comboGroupFilter.Location = new Point(514, 119);
            comboGroupFilter.Margin = new Padding(3, 4, 3, 4);
            comboGroupFilter.Name = "comboGroupFilter";
            comboGroupFilter.Size = new Size(115, 33);
            comboGroupFilter.TabIndex = 9;
            comboGroupFilter.SelectedIndexChanged += comboGroupFilter_SelectedIndexChanged;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            backButton.BackColor = Color.Transparent;
            backButton.Cursor = Cursors.Hand;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Pixel);
            backButton.ForeColor = SystemColors.ActiveBorder;
            backButton.Location = new Point(1184, 18);
            backButton.Name = "backButton";
            backButton.Size = new Size(79, 63);
            backButton.TabIndex = 29;
            backButton.Text = "✕";
            backButton.TextAlign = ContentAlignment.TopCenter;
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // minimizeButton
            // 
            minimizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            minimizeButton.BackColor = Color.Transparent;
            minimizeButton.Cursor = Cursors.Hand;
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Pixel);
            minimizeButton.ForeColor = SystemColors.ActiveBorder;
            minimizeButton.Location = new Point(1125, 18);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(56, 63);
            minimizeButton.TabIndex = 30;
            minimizeButton.Text = "─";
            minimizeButton.TextAlign = ContentAlignment.TopCenter;
            minimizeButton.UseVisualStyleBackColor = false;
            minimizeButton.Click += minimizeButton_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Transparent;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderColor = Color.SpringGreen;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 31F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(1121, 110);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(50, 50);
            btnReset.TabIndex = 31;
            btnReset.Text = "🔄";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // MatchesScheduleForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            BackColor = Color.FromArgb(32, 33, 36);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1282, 773);
            Controls.Add(btnReset);
            Controls.Add(minimizeButton);
            Controls.Add(backButton);
            Controls.Add(comboGroupFilter);
            Controls.Add(btnNextRound);
            Controls.Add(btnStart);
            Controls.Add(InforButton);
            Controls.Add(titleLabel);
            Controls.Add(standingsLabel);
            Controls.Add(standingsDataGridView);
            Controls.Add(updateButton);
            Controls.Add(matchesDataGridView);
            Controls.Add(choiceRoundComboBox);
            Controls.Add(matchesLabel);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Pixel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "MatchesScheduleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tournament Tracker";
            Load += MatchesScheduleForm_Load;
            ((System.ComponentModel.ISupportInitialize)matchesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)standingsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label matchesLabel;
        private System.Windows.Forms.ComboBox choiceRoundComboBox;
        private System.Windows.Forms.DataGridView matchesDataGridView;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.DataGridView standingsDataGridView;
        private System.Windows.Forms.Label standingsLabel;
        private Label titleLabel;
        private DataGridViewTextBoxColumn colHome;
        private DataGridViewTextBoxColumn colScore;
        private DataGridViewTextBoxColumn colAway;
        private Button btnStart;
        private Button btnNextRound;
        private Button InforButton;
        private ComboBox comboGroupFilter;
        private Button backButton;
        private Button minimizeButton;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colTeam;
        private DataGridViewTextBoxColumn colGF;
        private DataGridViewTextBoxColumn colGA;
        private DataGridViewTextBoxColumn colGD;
        private DataGridViewTextBoxColumn colPTS;
        private Button btnReset;
    }
}

