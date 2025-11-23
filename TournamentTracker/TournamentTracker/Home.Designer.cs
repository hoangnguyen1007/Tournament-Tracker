namespace TourApp
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            panel1 = new Panel();
            sfindBtn = new Button();
            screateBtn = new Button();
            LogOutBtn = new Button();
            label1 = new Label();
            Account = new ContextMenuStrip(components);
            myAccountToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            createBtn = new Button();
            findBtn = new Button();
            tourList = new DataGridView();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            Account.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tourList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(sfindBtn);
            panel1.Controls.Add(screateBtn);
            panel1.Controls.Add(LogOutBtn);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(928, 60);
            panel1.TabIndex = 0;
            // 
            // sfindBtn
            // 
            sfindBtn.FlatAppearance.BorderSize = 0;
            sfindBtn.FlatStyle = FlatStyle.Flat;
            sfindBtn.ForeColor = Color.Transparent;
            sfindBtn.Image = (Image)resources.GetObject("sfindBtn.Image");
            sfindBtn.Location = new Point(726, 16);
            sfindBtn.Name = "sfindBtn";
            sfindBtn.Size = new Size(30, 30);
            sfindBtn.TabIndex = 5;
            sfindBtn.UseVisualStyleBackColor = true;
            // 
            // screateBtn
            // 
            screateBtn.BackColor = Color.FromArgb(30, 30, 30);
            screateBtn.FlatAppearance.BorderSize = 0;
            screateBtn.FlatStyle = FlatStyle.Flat;
            screateBtn.ForeColor = Color.Transparent;
            screateBtn.Image = (Image)resources.GetObject("screateBtn.Image");
            screateBtn.Location = new Point(801, 16);
            screateBtn.Name = "screateBtn";
            screateBtn.Size = new Size(30, 30);
            screateBtn.TabIndex = 4;
            screateBtn.UseVisualStyleBackColor = false;
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
            LogOutBtn.Location = new Point(875, 16);
            LogOutBtn.Name = "LogOutBtn";
            LogOutBtn.Size = new Size(30, 30);
            LogOutBtn.TabIndex = 3;
            LogOutBtn.UseVisualStyleBackColor = false;
            LogOutBtn.Click += LogOutBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(28, 7);
            label1.Name = "label1";
            label1.Size = new Size(298, 45);
            label1.TabIndex = 2;
            label1.Text = "🏆 TOURNAMENT";
            // 
            // Account
            // 
            Account.ImageScalingSize = new Size(24, 24);
            Account.Items.AddRange(new ToolStripItem[] { myAccountToolStripMenuItem, settingsToolStripMenuItem, logOutToolStripMenuItem, exitToolStripMenuItem });
            Account.Name = "Account";
            Account.Size = new Size(241, 165);
            // 
            // myAccountToolStripMenuItem
            // 
            myAccountToolStripMenuItem.Name = "myAccountToolStripMenuItem";
            myAccountToolStripMenuItem.Size = new Size(240, 32);
            myAccountToolStripMenuItem.Text = "My account";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(240, 32);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(240, 32);
            logOutToolStripMenuItem.Text = "Log out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(240, 32);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // createBtn
            // 
            createBtn.BackColor = Color.FromArgb(52, 178, 51);
            createBtn.FlatAppearance.BorderSize = 0;
            createBtn.FlatStyle = FlatStyle.Flat;
            createBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            createBtn.ForeColor = Color.White;
            createBtn.Location = new Point(62, 93);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(303, 70);
            createBtn.TabIndex = 2;
            createBtn.Text = "CREATE TOURNAMENT";
            createBtn.UseVisualStyleBackColor = false;
            // 
            // findBtn
            // 
            findBtn.BackColor = Color.FromArgb(52, 178, 51);
            findBtn.FlatAppearance.BorderSize = 0;
            findBtn.FlatStyle = FlatStyle.Flat;
            findBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            findBtn.ForeColor = Color.White;
            findBtn.Location = new Point(62, 197);
            findBtn.Name = "findBtn";
            findBtn.Size = new Size(303, 70);
            findBtn.TabIndex = 3;
            findBtn.Text = "FIND TOURNAMENTS";
            findBtn.UseVisualStyleBackColor = false;
            // 
            // tourList
            // 
            tourList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tourList.Location = new Point(62, 301);
            tourList.Name = "tourList";
            tourList.RowHeadersWidth = 62;
            tourList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tourList.Size = new Size(799, 225);
            tourList.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(383, 66);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(478, 229);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(928, 538);
            Controls.Add(pictureBox1);
            Controls.Add(tourList);
            Controls.Add(findBtn);
            Controls.Add(createBtn);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlDark;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Home";
            Text = " ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            Account.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tourList).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button LogOutBtn;
        private Label label1;
        private ContextMenuStrip Account;
        private ToolStripMenuItem myAccountToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button createBtn;
        private Button findBtn;
        private DataGridView tourList;
        private PictureBox pictureBox1;
        private Button Screate;
        private Button button2;
        private Button sfindBtn;
        private Button screateBtn;
    }
}