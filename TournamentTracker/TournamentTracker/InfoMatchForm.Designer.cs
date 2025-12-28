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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoMatchForm));
            AwayTeamTitleLabel = new Label();
            HomeTeamTitleLabel = new Label();
            homeTeamDataGridView = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colTeam = new DataGridViewTextBoxColumn();
            colP = new DataGridViewTextBoxColumn();
            colW = new DataGridViewTextBoxColumn();
            colD = new DataGridViewTextBoxColumn();
            colL = new DataGridViewTextBoxColumn();
            homeLabel = new Label();
            awayLabel = new Label();
            awayTeamdataGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dateLabel = new Label();
            homeScoreLabel = new Label();
            locationLabel = new Label();
            h2Label = new Label();
            awayScoreLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            resultHTeamLabel = new Label();
            resultATeamLabel = new Label();
            backButton = new Button();
            ((System.ComponentModel.ISupportInitialize)homeTeamDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)awayTeamdataGridView).BeginInit();
            SuspendLayout();
            // 
            // AwayTeamTitleLabel
            // 
            AwayTeamTitleLabel.BackColor = Color.Transparent;
            AwayTeamTitleLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            AwayTeamTitleLabel.ForeColor = Color.Gold;
            AwayTeamTitleLabel.Location = new Point(746, 81);
            AwayTeamTitleLabel.Name = "AwayTeamTitleLabel";
            AwayTeamTitleLabel.Size = new Size(407, 40);
            AwayTeamTitleLabel.TabIndex = 13;
            AwayTeamTitleLabel.Text = "AWAY TEAM";
            AwayTeamTitleLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // HomeTeamTitleLabel
            // 
            HomeTeamTitleLabel.BackColor = Color.Transparent;
            HomeTeamTitleLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            HomeTeamTitleLabel.ForeColor = Color.Gold;
            HomeTeamTitleLabel.Location = new Point(120, 81);
            HomeTeamTitleLabel.Name = "HomeTeamTitleLabel";
            HomeTeamTitleLabel.Size = new Size(407, 40);
            HomeTeamTitleLabel.TabIndex = 8;
            HomeTeamTitleLabel.Text = "HOME TEAM";
            HomeTeamTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // homeTeamDataGridView
            // 
            homeTeamDataGridView.AllowUserToAddRows = false;
            homeTeamDataGridView.AllowUserToResizeColumns = false;
            homeTeamDataGridView.AllowUserToResizeRows = false;
            homeTeamDataGridView.BackgroundColor = Color.FromArgb(45, 48, 53);
            homeTeamDataGridView.BorderStyle = BorderStyle.None;
            homeTeamDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            homeTeamDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            homeTeamDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            homeTeamDataGridView.ColumnHeadersHeight = 50;
            homeTeamDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            homeTeamDataGridView.Columns.AddRange(new DataGridViewColumn[] { colSTT, colTeam, colP, colW, colD, colL });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(45, 48, 53);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            homeTeamDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            homeTeamDataGridView.EnableHeadersVisualStyles = false;
            homeTeamDataGridView.GridColor = SystemColors.GrayText;
            homeTeamDataGridView.Location = new Point(45, 191);
            homeTeamDataGridView.Margin = new Padding(3, 4, 3, 4);
            homeTeamDataGridView.Name = "homeTeamDataGridView";
            homeTeamDataGridView.ReadOnly = true;
            homeTeamDataGridView.RowHeadersVisible = false;
            homeTeamDataGridView.RowHeadersWidth = 51;
            homeTeamDataGridView.RowTemplate.Height = 50;
            homeTeamDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            homeTeamDataGridView.Size = new Size(575, 494);
            homeTeamDataGridView.TabIndex = 14;
            homeTeamDataGridView.CellFormatting += homeTeamDataGridView_CellFormatting;
            // 
            // colSTT
            // 
            colSTT.DataPropertyName = "#";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            colSTT.DefaultCellStyle = dataGridViewCellStyle2;
            colSTT.HeaderText = "#";
            colSTT.MinimumWidth = 40;
            colSTT.Name = "colSTT";
            colSTT.ReadOnly = true;
            colSTT.Width = 40;
            // 
            // colTeam
            // 
            colTeam.DataPropertyName = "ID";
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colTeam.DefaultCellStyle = dataGridViewCellStyle3;
            colTeam.HeaderText = "ID";
            colTeam.MinimumWidth = 80;
            colTeam.Name = "colTeam";
            colTeam.ReadOnly = true;
            colTeam.Width = 80;
            // 
            // colP
            // 
            colP.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colP.DataPropertyName = "PlayerName";
            colP.HeaderText = "PLAYER NAME";
            colP.MinimumWidth = 100;
            colP.Name = "colP";
            colP.ReadOnly = true;
            // 
            // colW
            // 
            colW.DataPropertyName = "Position";
            colW.HeaderText = "POSITION";
            colW.MinimumWidth = 100;
            colW.Name = "colW";
            colW.ReadOnly = true;
            colW.Width = 125;
            // 
            // colD
            // 
            colD.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colD.DataPropertyName = "Age";
            colD.HeaderText = "AGE";
            colD.MinimumWidth = 30;
            colD.Name = "colD";
            colD.ReadOnly = true;
            colD.Width = 64;
            // 
            // colL
            // 
            colL.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colL.DataPropertyName = "Number";
            colL.HeaderText = "NUMBER";
            colL.MinimumWidth = 30;
            colL.Name = "colL";
            colL.ReadOnly = true;
            colL.Width = 96;
            // 
            // homeLabel
            // 
            homeLabel.BackColor = Color.Transparent;
            homeLabel.Font = new Font("Segoe UI", 80F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            homeLabel.ForeColor = Color.Silver;
            homeLabel.Location = new Point(8, 58);
            homeLabel.Name = "homeLabel";
            homeLabel.Size = new Size(154, 106);
            homeLabel.TabIndex = 15;
            homeLabel.Text = "🛡️";
            // 
            // awayLabel
            // 
            awayLabel.BackColor = Color.Transparent;
            awayLabel.Font = new Font("Segoe UI", 80F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            awayLabel.ForeColor = Color.Silver;
            awayLabel.Location = new Point(1123, 58);
            awayLabel.Name = "awayLabel";
            awayLabel.Size = new Size(154, 106);
            awayLabel.TabIndex = 16;
            awayLabel.Text = "⚔️";
            // 
            // awayTeamdataGridView
            // 
            awayTeamdataGridView.AllowUserToAddRows = false;
            awayTeamdataGridView.AllowUserToResizeColumns = false;
            awayTeamdataGridView.AllowUserToResizeRows = false;
            awayTeamdataGridView.BackgroundColor = Color.FromArgb(45, 48, 53);
            awayTeamdataGridView.BorderStyle = BorderStyle.None;
            awayTeamdataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            awayTeamdataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Black;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            awayTeamdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            awayTeamdataGridView.ColumnHeadersHeight = 50;
            awayTeamdataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            awayTeamdataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(45, 48, 53);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            awayTeamdataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            awayTeamdataGridView.EnableHeadersVisualStyles = false;
            awayTeamdataGridView.GridColor = SystemColors.GrayText;
            awayTeamdataGridView.Location = new Point(663, 191);
            awayTeamdataGridView.Margin = new Padding(3, 4, 3, 4);
            awayTeamdataGridView.Name = "awayTeamdataGridView";
            awayTeamdataGridView.ReadOnly = true;
            awayTeamdataGridView.RowHeadersVisible = false;
            awayTeamdataGridView.RowHeadersWidth = 51;
            awayTeamdataGridView.RowTemplate.Height = 50;
            awayTeamdataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            awayTeamdataGridView.Size = new Size(575, 494);
            awayTeamdataGridView.TabIndex = 17;
            awayTeamdataGridView.CellFormatting += awayTeamdataGridView_CellFormatting;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "#";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Black;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.Black;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn1.HeaderText = "#";
            dataGridViewTextBoxColumn1.MinimumWidth = 40;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "ID";
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn2.HeaderText = "ID";
            dataGridViewTextBoxColumn2.MinimumWidth = 80;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.DataPropertyName = "PlayerName";
            dataGridViewTextBoxColumn3.HeaderText = "PLAYER NAME";
            dataGridViewTextBoxColumn3.MinimumWidth = 100;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Position";
            dataGridViewTextBoxColumn4.HeaderText = "POSITION";
            dataGridViewTextBoxColumn4.MinimumWidth = 100;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn5.DataPropertyName = "Age";
            dataGridViewTextBoxColumn5.HeaderText = "AGE";
            dataGridViewTextBoxColumn5.MinimumWidth = 30;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 64;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn6.DataPropertyName = "Number";
            dataGridViewTextBoxColumn6.HeaderText = "NUMBER";
            dataGridViewTextBoxColumn6.MinimumWidth = 30;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 96;
            // 
            // dateLabel
            // 
            dateLabel.BackColor = Color.Transparent;
            dateLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            dateLabel.ForeColor = Color.FromArgb(224, 224, 224);
            dateLabel.Location = new Point(464, 118);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(354, 28);
            dateLabel.TabIndex = 18;
            dateLabel.Text = "yyyy-MM-dd HH:mm:ss";
            dateLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // homeScoreLabel
            // 
            homeScoreLabel.BackColor = Color.Transparent;
            homeScoreLabel.Font = new Font("Segoe UI", 90F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            homeScoreLabel.ForeColor = Color.White;
            homeScoreLabel.Location = new Point(484, 16);
            homeScoreLabel.Name = "homeScoreLabel";
            homeScoreLabel.Size = new Size(151, 120);
            homeScoreLabel.TabIndex = 19;
            homeScoreLabel.Text = "0";
            homeScoreLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // locationLabel
            // 
            locationLabel.BackColor = Color.Transparent;
            locationLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            locationLabel.ForeColor = Color.FromArgb(224, 224, 224);
            locationLabel.Location = new Point(468, 146);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(346, 28);
            locationLabel.TabIndex = 21;
            locationLabel.Text = "LOCATION";
            locationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // h2Label
            // 
            h2Label.BackColor = Color.Transparent;
            h2Label.Font = new Font("Segoe UI", 90F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            h2Label.ForeColor = Color.White;
            h2Label.Location = new Point(612, 9);
            h2Label.Name = "h2Label";
            h2Label.Size = new Size(74, 120);
            h2Label.TabIndex = 22;
            h2Label.Text = ":";
            h2Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // awayScoreLabel
            // 
            awayScoreLabel.BackColor = Color.Transparent;
            awayScoreLabel.Font = new Font("Segoe UI", 90F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            awayScoreLabel.ForeColor = Color.White;
            awayScoreLabel.Location = new Point(659, 16);
            awayScoreLabel.Name = "awayScoreLabel";
            awayScoreLabel.Size = new Size(151, 120);
            awayScoreLabel.TabIndex = 23;
            awayScoreLabel.Text = "0";
            awayScoreLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(125, 125);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 24;
            label1.Text = "HOME ID";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            label2.ForeColor = Color.FromArgb(224, 224, 224);
            label2.Location = new Point(960, 125);
            label2.Name = "label2";
            label2.Size = new Size(188, 25);
            label2.TabIndex = 25;
            label2.Text = "AWAY ID";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // resultHTeamLabel
            // 
            resultHTeamLabel.BackColor = Color.Transparent;
            resultHTeamLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            resultHTeamLabel.ForeColor = Color.FromArgb(224, 224, 224);
            resultHTeamLabel.Location = new Point(123, 48);
            resultHTeamLabel.Name = "resultHTeamLabel";
            resultHTeamLabel.Size = new Size(235, 31);
            resultHTeamLabel.TabIndex = 26;
            resultHTeamLabel.Text = "HOME RESULT";
            resultHTeamLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // resultATeamLabel
            // 
            resultATeamLabel.BackColor = Color.Transparent;
            resultATeamLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            resultATeamLabel.ForeColor = Color.FromArgb(224, 224, 224);
            resultATeamLabel.Location = new Point(914, 48);
            resultATeamLabel.Name = "resultATeamLabel";
            resultATeamLabel.Size = new Size(236, 31);
            resultATeamLabel.TabIndex = 27;
            resultATeamLabel.Text = "AWAY RESULT";
            resultATeamLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backButton.BackColor = Color.Transparent;
            backButton.Cursor = Cursors.Hand;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Pixel);
            backButton.ForeColor = SystemColors.ActiveBorder;
            backButton.Location = new Point(0, 688);
            backButton.Name = "backButton";
            backButton.Size = new Size(79, 65);
            backButton.TabIndex = 28;
            backButton.Text = "❮❮";
            backButton.TextAlign = ContentAlignment.TopCenter;
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // InfoMatchForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1282, 753);
            Controls.Add(backButton);
            Controls.Add(resultATeamLabel);
            Controls.Add(resultHTeamLabel);
            Controls.Add(dateLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(awayScoreLabel);
            Controls.Add(h2Label);
            Controls.Add(locationLabel);
            Controls.Add(homeScoreLabel);
            Controls.Add(AwayTeamTitleLabel);
            Controls.Add(HomeTeamTitleLabel);
            Controls.Add(awayTeamdataGridView);
            Controls.Add(awayLabel);
            Controls.Add(homeLabel);
            Controls.Add(homeTeamDataGridView);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Pixel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "InfoMatchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Info Match";
            ((System.ComponentModel.ISupportInitialize)homeTeamDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)awayTeamdataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label AwayTeamTitleLabel;
        private Label HomeTeamTitleLabel;
        private DataGridView homeTeamDataGridView;
        private Label homeLabel;
        private Label awayLabel;
        private DataGridView awayTeamdataGridView;
        private Label dateLabel;
        private Label homeScoreLabel;
        private Label locationLabel;
        private Label h2Label;
        private Label awayScoreLabel;
        private Label label1;
        private Label label2;
        private Label resultHTeamLabel;
        private Label resultATeamLabel;
        private Button backButton;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colTeam;
        private DataGridViewTextBoxColumn colP;
        private DataGridViewTextBoxColumn colW;
        private DataGridViewTextBoxColumn colD;
        private DataGridViewTextBoxColumn colL;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}