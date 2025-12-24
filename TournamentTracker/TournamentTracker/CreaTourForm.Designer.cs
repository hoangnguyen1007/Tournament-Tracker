namespace TourApp
{
    partial class CreaTourForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreaTourForm));
            label1 = new Label();
            LogOutBtn = new Button();
            sfindBtn = new Button();
            panel1 = new Panel();
            sportCbox = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            nameTextBox = new TextBox();
            label4 = new Label();
            numPar = new NumericUpDown();
            createBtn = new Button();
            Account = new ContextMenuStrip(components);
            myAccountToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            label9 = new Label();
            label10 = new Label();
            startDate = new DateTimePicker();
            prizeTextBox = new TextBox();
            label5 = new Label();
            groupCbox = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPar).BeginInit();
            Account.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Pixel);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(298, 45);
            label1.TabIndex = 2;
            label1.Text = "🏆 TOURNAMENT";
            // 
            // LogOutBtn
            // 
            LogOutBtn.BackColor = Color.Transparent;
            LogOutBtn.Cursor = Cursors.Hand;
            LogOutBtn.FlatAppearance.BorderSize = 0;
            LogOutBtn.FlatAppearance.MouseDownBackColor = Color.Gray;
            LogOutBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            LogOutBtn.FlatStyle = FlatStyle.Flat;
            LogOutBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Pixel);
            LogOutBtn.ForeColor = SystemColors.ActiveCaptionText;
            LogOutBtn.Image = (Image)resources.GetObject("LogOutBtn.Image");
            LogOutBtn.Location = new Point(685, 12);
            LogOutBtn.Name = "LogOutBtn";
            LogOutBtn.Size = new Size(30, 30);
            LogOutBtn.TabIndex = 3;
            LogOutBtn.UseVisualStyleBackColor = false;
            LogOutBtn.Click += LogOutBtn_Click;
            // 
            // sfindBtn
            // 
            sfindBtn.Cursor = Cursors.Hand;
            sfindBtn.FlatAppearance.BorderSize = 0;
            sfindBtn.FlatStyle = FlatStyle.Flat;
            sfindBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            sfindBtn.ForeColor = Color.Transparent;
            sfindBtn.Image = (Image)resources.GetObject("sfindBtn.Image");
            sfindBtn.Location = new Point(607, 12);
            sfindBtn.Name = "sfindBtn";
            sfindBtn.Size = new Size(30, 30);
            sfindBtn.TabIndex = 5;
            sfindBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(sfindBtn);
            panel1.Controls.Add(LogOutBtn);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(737, 60);
            panel1.TabIndex = 1;
            // 
            // sportCbox
            // 
            sportCbox.BackColor = Color.FromArgb(64, 64, 64);
            sportCbox.DropDownStyle = ComboBoxStyle.DropDownList;
            sportCbox.FlatStyle = FlatStyle.Flat;
            sportCbox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            sportCbox.ForeColor = SystemColors.Info;
            sportCbox.FormattingEnabled = true;
            sportCbox.IntegralHeight = false;
            sportCbox.Items.AddRange(new object[] { "Athletics", "Badminton", "Baseball", "Basketball", "Boxing", "Cycling", "Football", "Golf", "Handball", "Hockey", "Judo", "Karate", "Rowing", "Rugby", "Swimming", "Table Tennis", "Taekwondo", "Tennis", "Volleyball" });
            sportCbox.Location = new Point(29, 188);
            sportCbox.Name = "sportCbox";
            sportCbox.Size = new Size(282, 36);
            sportCbox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(129, 155);
            label2.Name = "label2";
            label2.Size = new Size(71, 30);
            label2.TabIndex = 4;
            label2.Text = "Sport";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(321, 78);
            label3.Name = "label3";
            label3.Size = new Size(74, 30);
            label3.TabIndex = 5;
            label3.Text = "Name";
            label3.Click += label3_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = Color.FromArgb(64, 64, 64);
            nameTextBox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            nameTextBox.ForeColor = SystemColors.Info;
            nameTextBox.Location = new Point(214, 111);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.PlaceholderText = "Tournament name";
            nameTextBox.Size = new Size(289, 34);
            nameTextBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(438, 155);
            label4.Name = "label4";
            label4.Size = new Size(256, 30);
            label4.TabIndex = 8;
            label4.Text = "Number of Participants";
            // 
            // numPar
            // 
            numPar.BackColor = Color.FromArgb(64, 64, 64);
            numPar.BorderStyle = BorderStyle.FixedSingle;
            numPar.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            numPar.ForeColor = SystemColors.Info;
            numPar.Location = new Point(438, 188);
            numPar.Name = "numPar";
            numPar.Size = new Size(277, 34);
            numPar.TabIndex = 9;
            numPar.ValueChanged += numPar_ValueChanged;
            // 
            // createBtn
            // 
            createBtn.BackColor = Color.FromArgb(52, 178, 51);
            createBtn.FlatAppearance.BorderSize = 0;
            createBtn.FlatStyle = FlatStyle.Flat;
            createBtn.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            createBtn.ForeColor = Color.White;
            createBtn.Location = new Point(205, 417);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(303, 60);
            createBtn.TabIndex = 15;
            createBtn.Text = "CREATE TOURNAMENT";
            createBtn.UseVisualStyleBackColor = false;
            createBtn.Click += createBtn_Click;
            // 
            // Account
            // 
            Account.ImageScalingSize = new Size(24, 24);
            Account.Items.AddRange(new ToolStripItem[] { myAccountToolStripMenuItem, settingsToolStripMenuItem, logOutToolStripMenuItem, exitToolStripMenuItem });
            Account.Name = "Account";
            Account.Size = new Size(177, 132);
            // 
            // myAccountToolStripMenuItem
            // 
            myAccountToolStripMenuItem.Name = "myAccountToolStripMenuItem";
            myAccountToolStripMenuItem.Size = new Size(176, 32);
            myAccountToolStripMenuItem.Text = "My account";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(176, 32);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(176, 32);
            logOutToolStripMenuItem.Text = "Log out";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(176, 32);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(326, 322);
            label9.Name = "label9";
            label9.Size = new Size(65, 30);
            label9.TabIndex = 16;
            label9.Text = "Prize";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel);
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(105, 236);
            label10.Name = "label10";
            label10.Size = new Size(117, 30);
            label10.TabIndex = 17;
            label10.Text = "Start date";
            // 
            // startDate
            // 
            startDate.CalendarMonthBackground = Color.Gray;
            startDate.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            startDate.Format = DateTimePickerFormat.Custom;
            startDate.Location = new Point(60, 270);
            startDate.Name = "startDate";
            startDate.Size = new Size(206, 31);
            startDate.TabIndex = 18;
            startDate.ValueChanged += starTime_ValueChanged;
            // 
            // prizeTextBox
            // 
            prizeTextBox.BackColor = Color.FromArgb(64, 64, 64);
            prizeTextBox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            prizeTextBox.ForeColor = SystemColors.Info;
            prizeTextBox.Location = new Point(224, 355);
            prizeTextBox.Name = "prizeTextBox";
            prizeTextBox.PlaceholderText = "Tournament Prize";
            prizeTextBox.Size = new Size(279, 34);
            prizeTextBox.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(465, 232);
            label5.Name = "label5";
            label5.Size = new Size(206, 30);
            label5.TabIndex = 21;
            label5.Text = "Number of Groups";
            // 
            // groupCbox
            // 
            groupCbox.BackColor = Color.FromArgb(64, 64, 64);
            groupCbox.DropDownStyle = ComboBoxStyle.DropDownList;
            groupCbox.FlatStyle = FlatStyle.Flat;
            groupCbox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            groupCbox.ForeColor = SystemColors.Info;
            groupCbox.FormattingEnabled = true;
            groupCbox.IntegralHeight = false;
            groupCbox.Items.AddRange(new object[] { "1", "2", "4", "8" });
            groupCbox.Location = new Point(433, 265);
            groupCbox.Name = "groupCbox";
            groupCbox.Size = new Size(282, 36);
            groupCbox.TabIndex = 20;
            // 
            // CreaTourForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(737, 518);
            Controls.Add(label5);
            Controls.Add(groupCbox);
            Controls.Add(prizeTextBox);
            Controls.Add(startDate);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(createBtn);
            Controls.Add(numPar);
            Controls.Add(label4);
            Controls.Add(nameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(sportCbox);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CreaTourForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreaTourForm";
            Load += CreaTourForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPar).EndInit();
            Account.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button LogOutBtn;
        private Button sfindBtn;
        private Panel panel1;
        private ComboBox sportCbox;
        private Label label2;
        private Label label3;
        private TextBox nameTextBox;
        private Label label4;
        private NumericUpDown numPar;
        private DateTimePicker startDate;
        private Button createBtn;
        private ContextMenuStrip Account;
        private ToolStripMenuItem myAccountToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label label9;
        private Label label10;
        private TextBox prizeTextBox;
        private Label label5;
        private ComboBox groupCbox;
    }
}
