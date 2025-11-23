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
            panelSingle = new Panel();
            label8 = new Label();
            comboBox2 = new ComboBox();
            panelMulti = new Panel();
            label5 = new Label();
            label6 = new Label();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            singleRad = new RadioButton();
            multiRad = new RadioButton();
            label7 = new Label();
            createBtn = new Button();
            Account = new ContextMenuStrip(components);
            myAccountToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPar).BeginInit();
            panelSingle.SuspendLayout();
            panelMulti.SuspendLayout();
            Account.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
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
            LogOutBtn.FlatAppearance.BorderSize = 0;
            LogOutBtn.FlatAppearance.MouseDownBackColor = Color.Gray;
            LogOutBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            LogOutBtn.FlatStyle = FlatStyle.Flat;
            LogOutBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LogOutBtn.ForeColor = SystemColors.ActiveCaptionText;
            LogOutBtn.Image = (Image)resources.GetObject("LogOutBtn.Image");
            LogOutBtn.Location = new Point(673, 12);
            LogOutBtn.Name = "LogOutBtn";
            LogOutBtn.Size = new Size(30, 30);
            LogOutBtn.TabIndex = 3;
            LogOutBtn.UseVisualStyleBackColor = false;
            LogOutBtn.Click += LogOutBtn_Click;
            // 
            // sfindBtn
            // 
            sfindBtn.FlatAppearance.BorderSize = 0;
            sfindBtn.FlatStyle = FlatStyle.Flat;
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
            sportCbox.FlatStyle = FlatStyle.Flat;
            sportCbox.Font = new Font("Segoe UI", 10F);
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
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
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
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
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
            nameTextBox.Font = new Font("Segoe UI", 10F);
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
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
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
            numPar.Font = new Font("Segoe UI", 10F);
            numPar.ForeColor = SystemColors.Info;
            numPar.Location = new Point(438, 188);
            numPar.Name = "numPar";
            numPar.Size = new Size(277, 34);
            numPar.TabIndex = 9;
            numPar.ValueChanged += numPar_ValueChanged;
            // 
            // panelSingle
            // 
            panelSingle.Controls.Add(label8);
            panelSingle.Controls.Add(comboBox2);
            panelSingle.Location = new Point(303, 282);
            panelSingle.Name = "panelSingle";
            panelSingle.Size = new Size(400, 81);
            panelSingle.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8F);
            label8.ForeColor = SystemColors.Control;
            label8.Location = new Point(36, 9);
            label8.Name = "label8";
            label8.Size = new Size(73, 21);
            label8.TabIndex = 15;
            label8.Text = "Stage 1st";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.FromArgb(64, 64, 64);
            comboBox2.FlatStyle = FlatStyle.Flat;
            comboBox2.ForeColor = SystemColors.Info;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Knockout Bracket", "Round-robin League" });
            comboBox2.Location = new Point(31, 22);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(345, 33);
            comboBox2.TabIndex = 0;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // panelMulti
            // 
            panelMulti.Controls.Add(label5);
            panelMulti.Controls.Add(label6);
            panelMulti.Controls.Add(comboBox4);
            panelMulti.Controls.Add(comboBox3);
            panelMulti.Location = new Point(303, 378);
            panelMulti.Name = "panelMulti";
            panelMulti.Size = new Size(400, 122);
            panelMulti.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(36, 54);
            label5.Name = "label5";
            label5.Size = new Size(79, 21);
            label5.TabIndex = 15;
            label5.Text = "Stage 2nd";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8F);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(36, 0);
            label6.Name = "label6";
            label6.Size = new Size(73, 21);
            label6.TabIndex = 14;
            label6.Text = "Stage 1st";
            label6.Click += label6_Click;
            // 
            // comboBox4
            // 
            comboBox4.BackColor = Color.FromArgb(64, 64, 64);
            comboBox4.FlatStyle = FlatStyle.Flat;
            comboBox4.ForeColor = SystemColors.Info;
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Knockout Bracket", "Round-robin League" });
            comboBox4.Location = new Point(32, 70);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(345, 33);
            comboBox4.TabIndex = 1;
            // 
            // comboBox3
            // 
            comboBox3.BackColor = Color.FromArgb(64, 64, 64);
            comboBox3.FlatStyle = FlatStyle.Flat;
            comboBox3.ForeColor = SystemColors.Info;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Knockout Bracket", "Round-robin League" });
            comboBox3.Location = new Point(32, 18);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(345, 33);
            comboBox3.TabIndex = 0;
            // 
            // singleRad
            // 
            singleRad.AutoSize = true;
            singleRad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            singleRad.ForeColor = SystemColors.Info;
            singleRad.Location = new Point(60, 305);
            singleRad.Name = "singleRad";
            singleRad.Size = new Size(140, 29);
            singleRad.TabIndex = 12;
            singleRad.TabStop = true;
            singleRad.Text = "Single stage";
            singleRad.UseVisualStyleBackColor = true;
            singleRad.CheckedChanged += singleRad_CheckedChanged;
            // 
            // multiRad
            // 
            multiRad.AutoSize = true;
            multiRad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            multiRad.ForeColor = SystemColors.Info;
            multiRad.Location = new Point(60, 410);
            multiRad.Name = "multiRad";
            multiRad.Size = new Size(133, 29);
            multiRad.TabIndex = 13;
            multiRad.TabStop = true;
            multiRad.Text = "Multi stage";
            multiRad.UseVisualStyleBackColor = true;
            multiRad.CheckedChanged += multiRad_CheckedChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(321, 236);
            label7.Name = "label7";
            label7.Size = new Size(87, 30);
            label7.TabIndex = 14;
            label7.Text = "Format";
            // 
            // createBtn
            // 
            createBtn.BackColor = Color.FromArgb(52, 178, 51);
            createBtn.FlatAppearance.BorderSize = 0;
            createBtn.FlatStyle = FlatStyle.Flat;
            createBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            createBtn.ForeColor = Color.White;
            createBtn.Location = new Point(214, 526);
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
            // CreaTourForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(737, 619);
            Controls.Add(createBtn);
            Controls.Add(label7);
            Controls.Add(multiRad);
            Controls.Add(singleRad);
            Controls.Add(panelMulti);
            Controls.Add(panelSingle);
            Controls.Add(numPar);
            Controls.Add(label4);
            Controls.Add(nameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(sportCbox);
            Controls.Add(panel1);
            Name = "CreaTourForm";
            Text = "CreaTourForm";
            Load += CreaTourForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPar).EndInit();
            panelSingle.ResumeLayout(false);
            panelSingle.PerformLayout();
            panelMulti.ResumeLayout(false);
            panelMulti.PerformLayout();
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
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Panel panelSingle;
        private ComboBox comboBox2;
        private Panel panelMulti;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private RadioButton singleRad;
        private RadioButton multiRad;
        private Label label6;
        private Label label8;
        private Label label7;
        private Button createBtn;
        private ContextMenuStrip Account;
        private ToolStripMenuItem myAccountToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}