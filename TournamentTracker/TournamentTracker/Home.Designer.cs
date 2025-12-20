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
            Label label6;
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
            flowPanelCards = new FlowLayoutPanel();
            pnlEmptyState = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            addBtn = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editBtn = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripMenuItem();
            pnlHeroSection = new Panel();
            manageBtn = new Button();
            viewDetailsBtn = new Button();
            heroInfoLabel = new Label();
            heroSubLabel = new Label();
            heroTitleLabel = new Label();
            label5 = new Label();
            lblTotal = new Label();
            lblActive = new Label();
            lblUpcoming = new Label();
            panel3 = new Panel();
            txtSearchGlobal = new TextBox();
            btnMyTournaments = new Button();
            pnlSearchSection = new Panel();
            label8 = new Label();
            flowQuickFilters = new FlowLayoutPanel();
            btnFilterAll = new Button();
            btnFilterActive = new Button();
            btnFilterUpcoming = new Button();
            label7 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            Account.SuspendLayout();
            pnlEmptyState.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            pnlHeroSection.SuspendLayout();
            panel3.SuspendLayout();
            pnlSearchSection.SuspendLayout();
            flowQuickFilters.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Pixel);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(44, 91);
            label6.Name = "label6";
            label6.Size = new Size(198, 30);
            label6.TabIndex = 12;
            label6.Text = "Tournament Name:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
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
            panel1.Size = new Size(1278, 72);
            panel1.TabIndex = 0;
            // 
            // sfindBtn
            // 
            sfindBtn.Cursor = Cursors.Hand;
            sfindBtn.FlatAppearance.BorderSize = 0;
            sfindBtn.FlatStyle = FlatStyle.Flat;
            sfindBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            sfindBtn.ForeColor = Color.Transparent;
            sfindBtn.Image = (Image)resources.GetObject("sfindBtn.Image");
            sfindBtn.Location = new Point(1074, 24);
            sfindBtn.Name = "sfindBtn";
            sfindBtn.Size = new Size(30, 30);
            sfindBtn.TabIndex = 5;
            sfindBtn.UseVisualStyleBackColor = true;
            // 
            // screateBtn
            // 
            screateBtn.BackColor = Color.FromArgb(30, 30, 30);
            screateBtn.Cursor = Cursors.Hand;
            screateBtn.FlatAppearance.BorderSize = 0;
            screateBtn.FlatStyle = FlatStyle.Flat;
            screateBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            screateBtn.ForeColor = Color.Transparent;
            screateBtn.Image = (Image)resources.GetObject("screateBtn.Image");
            screateBtn.Location = new Point(1149, 24);
            screateBtn.Name = "screateBtn";
            screateBtn.Size = new Size(30, 30);
            screateBtn.TabIndex = 6;
            screateBtn.UseVisualStyleBackColor = false;
            screateBtn.Click += screateBtn_Click;
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
            LogOutBtn.Location = new Point(1221, 22);
            LogOutBtn.Name = "LogOutBtn";
            LogOutBtn.Size = new Size(30, 30);
            LogOutBtn.TabIndex = 7;
            LogOutBtn.UseVisualStyleBackColor = false;
            LogOutBtn.Click += LogOutBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Pixel);
            label1.ForeColor = Color.FromArgb(52, 178, 51);
            label1.Location = new Point(25, 9);
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
            Account.Size = new Size(177, 132);
            Account.Opening += Account_Opening;
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
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(176, 32);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // createBtn
            // 
            createBtn.BackColor = Color.FromArgb(52, 178, 51);
            createBtn.Cursor = Cursors.Hand;
            createBtn.FlatAppearance.BorderSize = 0;
            createBtn.FlatStyle = FlatStyle.Flat;
            createBtn.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel);
            createBtn.ForeColor = Color.White;
            createBtn.Location = new Point(134, 91);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(339, 74);
            createBtn.TabIndex = 1;
            createBtn.Text = "CREATE TOURNAMENT";
            createBtn.UseVisualStyleBackColor = false;
            createBtn.Click += createBtn_Click;
            // 
            // findBtn
            // 
            findBtn.BackColor = Color.FromArgb(52, 178, 51);
            findBtn.Cursor = Cursors.Hand;
            findBtn.FlatAppearance.BorderSize = 0;
            findBtn.FlatStyle = FlatStyle.Flat;
            findBtn.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel);
            findBtn.ForeColor = Color.White;
            findBtn.Location = new Point(134, 208);
            findBtn.Name = "findBtn";
            findBtn.Size = new Size(339, 74);
            findBtn.TabIndex = 2;
            findBtn.Text = "FIND TOURNAMENTS";
            findBtn.UseVisualStyleBackColor = false;
            findBtn.Click += findBtn_Click;
            // 
            // flowPanelCards
            // 
            flowPanelCards.AutoScroll = true;
            flowPanelCards.BackColor = Color.Transparent;
            flowPanelCards.Dock = DockStyle.Bottom;
            flowPanelCards.Location = new Point(0, 452);
            flowPanelCards.Name = "flowPanelCards";
            flowPanelCards.Padding = new Padding(20, 20, 0, 0);
            flowPanelCards.Size = new Size(1278, 312);
            flowPanelCards.TabIndex = 4;
            flowPanelCards.Paint += flowPanelCards_Paint;
            // 
            // pnlEmptyState
            // 
            pnlEmptyState.BackColor = Color.Transparent;
            pnlEmptyState.Controls.Add(label4);
            pnlEmptyState.Controls.Add(label3);
            pnlEmptyState.Controls.Add(label2);
            pnlEmptyState.Controls.Add(addBtn);
            pnlEmptyState.ForeColor = Color.Transparent;
            pnlEmptyState.Location = new Point(0, 452);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new Size(1243, 282);
            pnlEmptyState.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 38F, FontStyle.Bold, GraphicsUnit.Pixel);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(613, 1);
            label4.Name = "label4";
            label4.Size = new Size(83, 51);
            label4.TabIndex = 5;
            label4.Text = "🏆 ";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(278, 109);
            label3.Name = "label3";
            label3.Size = new Size(742, 32);
            label3.TabIndex = 2;
            label3.Text = "Get started";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Pixel);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(465, 52);
            label2.Name = "label2";
            label2.Size = new Size(371, 48);
            label2.TabIndex = 1;
            label2.Text = "No tournaments yet!";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addBtn
            // 
            addBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addBtn.Cursor = Cursors.Hand;
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
            addBtn.FlatAppearance.MouseOverBackColor = Color.DimGray;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            addBtn.Image = (Image)resources.GetObject("addBtn.Image");
            addBtn.Location = new Point(596, 144);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(100, 100);
            addBtn.TabIndex = 3;
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click_1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editBtn, toolStripTextBox1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(214, 68);
            // 
            // editBtn
            // 
            editBtn.BackColor = Color.White;
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(213, 32);
            editBtn.Text = "✏️ Chỉnh sửa";
            editBtn.Click += editBtn_Click;
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(213, 32);
            toolStripTextBox1.Text = "🗑️ Xóa giải đấu";
            toolStripTextBox1.Click += toolStripTextBox1_Click;
            // 
            // pnlHeroSection
            // 
            pnlHeroSection.BackColor = Color.FromArgb(30, 31, 35);
            pnlHeroSection.Controls.Add(manageBtn);
            pnlHeroSection.Controls.Add(viewDetailsBtn);
            pnlHeroSection.Controls.Add(heroInfoLabel);
            pnlHeroSection.Controls.Add(heroSubLabel);
            pnlHeroSection.Controls.Add(heroTitleLabel);
            pnlHeroSection.Controls.Add(label5);
            pnlHeroSection.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlHeroSection.Location = new Point(647, 91);
            pnlHeroSection.Name = "pnlHeroSection";
            pnlHeroSection.Size = new Size(562, 323);
            pnlHeroSection.TabIndex = 5;
            pnlHeroSection.Paint += panel2_Paint;
            // 
            // manageBtn
            // 
            manageBtn.BackColor = Color.FromArgb(30, 31, 35);
            manageBtn.Cursor = Cursors.Hand;
            manageBtn.FlatAppearance.BorderColor = Color.FromArgb(63, 68, 76);
            manageBtn.FlatStyle = FlatStyle.Flat;
            manageBtn.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            manageBtn.ForeColor = Color.FromArgb(209, 213, 219);
            manageBtn.Location = new Point(363, 243);
            manageBtn.Name = "manageBtn";
            manageBtn.Size = new Size(142, 46);
            manageBtn.TabIndex = 5;
            manageBtn.Text = "⚙ Manage";
            manageBtn.UseVisualStyleBackColor = false;
            manageBtn.Click += manageBtn_Click;
            // 
            // viewDetailsBtn
            // 
            viewDetailsBtn.BackColor = Color.FromArgb(79, 209, 197);
            viewDetailsBtn.Cursor = Cursors.Hand;
            viewDetailsBtn.FlatAppearance.BorderSize = 0;
            viewDetailsBtn.FlatStyle = FlatStyle.Flat;
            viewDetailsBtn.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            viewDetailsBtn.ForeColor = Color.FromArgb(15, 23, 42);
            viewDetailsBtn.Location = new Point(61, 251);
            viewDetailsBtn.Name = "viewDetailsBtn";
            viewDetailsBtn.Size = new Size(147, 38);
            viewDetailsBtn.TabIndex = 4;
            viewDetailsBtn.Text = "▶ View Details";
            viewDetailsBtn.UseVisualStyleBackColor = false;
            viewDetailsBtn.Click += viewDetailsBtn_Click;
            // 
            // heroInfoLabel
            // 
            heroInfoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            heroInfoLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            heroInfoLabel.ForeColor = Color.Goldenrod;
            heroInfoLabel.Location = new Point(0, 181);
            heroInfoLabel.Name = "heroInfoLabel";
            heroInfoLabel.Size = new Size(559, 32);
            heroInfoLabel.TabIndex = 3;
            heroInfoLabel.Text = "Info";
            heroInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // heroSubLabel
            // 
            heroSubLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            heroSubLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            heroSubLabel.ForeColor = Color.FromArgb(181, 184, 190);
            heroSubLabel.Location = new Point(0, 126);
            heroSubLabel.Name = "heroSubLabel";
            heroSubLabel.Size = new Size(562, 32);
            heroSubLabel.TabIndex = 2;
            heroSubLabel.Text = "Sub label";
            heroSubLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // heroTitleLabel
            // 
            heroTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            heroTitleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            heroTitleLabel.ForeColor = Color.White;
            heroTitleLabel.Location = new Point(0, 71);
            heroTitleLabel.Name = "heroTitleLabel";
            heroTitleLabel.Size = new Size(559, 32);
            heroTitleLabel.TabIndex = 1;
            heroTitleLabel.Text = "Title";
            heroTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Pixel);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(84, 11);
            label5.Name = "label5";
            label5.Size = new Size(406, 41);
            label5.TabIndex = 0;
            label5.Text = "UPCOMING TOURNAMENT";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTotal.ForeColor = Color.WhiteSmoke;
            lblTotal.Location = new Point(33, 35);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(70, 32);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblActive.ForeColor = Color.Chartreuse;
            lblActive.Location = new Point(165, 35);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(85, 32);
            lblActive.TabIndex = 7;
            lblActive.Text = "Active";
            lblActive.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUpcoming
            // 
            lblUpcoming.AutoSize = true;
            lblUpcoming.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblUpcoming.ForeColor = Color.Cyan;
            lblUpcoming.Location = new Point(312, 35);
            lblUpcoming.Name = "lblUpcoming";
            lblUpcoming.Size = new Size(132, 32);
            lblUpcoming.TabIndex = 8;
            lblUpcoming.Text = "Upcoming";
            lblUpcoming.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(lblUpcoming);
            panel3.Controls.Add(lblTotal);
            panel3.Controls.Add(lblActive);
            panel3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            panel3.ForeColor = Color.Chocolate;
            panel3.Location = new Point(56, 299);
            panel3.Name = "panel3";
            panel3.Size = new Size(464, 100);
            panel3.TabIndex = 9;
            // 
            // txtSearchGlobal
            // 
            txtSearchGlobal.BackColor = Color.FromArgb(18, 18, 18);
            txtSearchGlobal.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSearchGlobal.ForeColor = SystemColors.Info;
            txtSearchGlobal.Location = new Point(248, 86);
            txtSearchGlobal.Name = "txtSearchGlobal";
            txtSearchGlobal.PlaceholderText = "Search tournament";
            txtSearchGlobal.Size = new Size(352, 39);
            txtSearchGlobal.TabIndex = 10;
            txtSearchGlobal.Visible = false;
            txtSearchGlobal.KeyDown += txtSearchGlobal_KeyDown_1;
            // 
            // btnMyTournaments
            // 
            btnMyTournaments.BackColor = Color.FromArgb(52, 178, 51);
            btnMyTournaments.Cursor = Cursors.Hand;
            btnMyTournaments.FlatAppearance.BorderSize = 0;
            btnMyTournaments.FlatStyle = FlatStyle.Flat;
            btnMyTournaments.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            btnMyTournaments.ForeColor = Color.White;
            btnMyTournaments.Location = new Point(134, 154);
            btnMyTournaments.Name = "btnMyTournaments";
            btnMyTournaments.Size = new Size(339, 74);
            btnMyTournaments.TabIndex = 11;
            btnMyTournaments.Text = "MY TOURNAMENTS";
            btnMyTournaments.UseVisualStyleBackColor = false;
            btnMyTournaments.Visible = false;
            btnMyTournaments.Click += btnMyTournaments_Click;
            // 
            // pnlSearchSection
            // 
            pnlSearchSection.Controls.Add(label8);
            pnlSearchSection.Controls.Add(flowQuickFilters);
            pnlSearchSection.Controls.Add(label7);
            pnlSearchSection.Controls.Add(label6);
            pnlSearchSection.Controls.Add(txtSearchGlobal);
            pnlSearchSection.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlSearchSection.Location = new Point(579, 91);
            pnlSearchSection.Name = "pnlSearchSection";
            pnlSearchSection.Size = new Size(665, 323);
            pnlSearchSection.TabIndex = 12;
            pnlSearchSection.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            label8.ForeColor = Color.WhiteSmoke;
            label8.Location = new Point(290, 149);
            label8.Name = "label8";
            label8.Size = new Size(72, 32);
            label8.TabIndex = 15;
            label8.Text = "Filter";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowQuickFilters
            // 
            flowQuickFilters.AutoSize = true;
            flowQuickFilters.Controls.Add(btnFilterAll);
            flowQuickFilters.Controls.Add(btnFilterActive);
            flowQuickFilters.Controls.Add(btnFilterUpcoming);
            flowQuickFilters.Location = new Point(71, 208);
            flowQuickFilters.Name = "flowQuickFilters";
            flowQuickFilters.Size = new Size(514, 64);
            flowQuickFilters.TabIndex = 14;
            // 
            // btnFilterAll
            // 
            btnFilterAll.BackColor = Color.FromArgb(42, 42, 42);
            btnFilterAll.Cursor = Cursors.Hand;
            btnFilterAll.FlatAppearance.BorderSize = 0;
            btnFilterAll.FlatStyle = FlatStyle.Flat;
            btnFilterAll.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnFilterAll.ForeColor = Color.FromArgb(189, 189, 189);
            btnFilterAll.Location = new Point(3, 3);
            btnFilterAll.Name = "btnFilterAll";
            btnFilterAll.Size = new Size(164, 48);
            btnFilterAll.TabIndex = 0;
            btnFilterAll.Text = "All";
            btnFilterAll.UseVisualStyleBackColor = false;
            btnFilterAll.Click += QuickFilter_Click;
            // 
            // btnFilterActive
            // 
            btnFilterActive.BackColor = Color.FromArgb(42, 42, 42);
            btnFilterActive.Cursor = Cursors.Hand;
            btnFilterActive.FlatAppearance.BorderSize = 0;
            btnFilterActive.FlatStyle = FlatStyle.Flat;
            btnFilterActive.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnFilterActive.ForeColor = Color.FromArgb(189, 189, 189);
            btnFilterActive.Location = new Point(173, 3);
            btnFilterActive.Name = "btnFilterActive";
            btnFilterActive.Size = new Size(164, 48);
            btnFilterActive.TabIndex = 1;
            btnFilterActive.Text = "🔥 Active Now";
            btnFilterActive.UseVisualStyleBackColor = false;
            btnFilterActive.Click += QuickFilter_Click;
            // 
            // btnFilterUpcoming
            // 
            btnFilterUpcoming.BackColor = Color.FromArgb(42, 42, 42);
            btnFilterUpcoming.Cursor = Cursors.Hand;
            btnFilterUpcoming.FlatAppearance.BorderSize = 0;
            btnFilterUpcoming.FlatStyle = FlatStyle.Flat;
            btnFilterUpcoming.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnFilterUpcoming.ForeColor = Color.FromArgb(189, 189, 189);
            btnFilterUpcoming.Location = new Point(343, 3);
            btnFilterUpcoming.Name = "btnFilterUpcoming";
            btnFilterUpcoming.Size = new Size(164, 48);
            btnFilterUpcoming.TabIndex = 2;
            btnFilterUpcoming.Text = "⏳ Upcoming";
            btnFilterUpcoming.UseVisualStyleBackColor = false;
            btnFilterUpcoming.Click += QuickFilter_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Pixel);
            label7.ForeColor = Color.FromArgb(52, 178, 51);
            label7.Location = new Point(193, 11);
            label7.Name = "label7";
            label7.Size = new Size(289, 45);
            label7.TabIndex = 13;
            label7.Text = "Find Tournaments";
            // 
            // Home
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(32, 34, 37);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1278, 764);
            Controls.Add(pnlSearchSection);
            Controls.Add(btnMyTournaments);
            Controls.Add(panel3);
            Controls.Add(pnlHeroSection);
            Controls.Add(pnlEmptyState);
            Controls.Add(flowPanelCards);
            Controls.Add(findBtn);
            Controls.Add(createBtn);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlDarkDark;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Home";
            FormClosed += Home_FormClosed;
            Load += Home_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            Account.ResumeLayout(false);
            pnlEmptyState.ResumeLayout(false);
            pnlEmptyState.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            pnlHeroSection.ResumeLayout(false);
            pnlHeroSection.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlSearchSection.ResumeLayout(false);
            pnlSearchSection.PerformLayout();
            flowQuickFilters.ResumeLayout(false);
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
        private Button Screate;
        private Button btnFilterActive;
        private Button sfindBtn;
        private Button screateBtn;
        private FlowLayoutPanel flowPanelCards;
        private Panel pnlEmptyState;
        private Button addBtn;
        private Label label3;
        private Label label2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editBtn;
        private ToolStripMenuItem toolStripTextBox1;
        private Label label4;
        private Panel pnlHeroSection;
        private Label heroTitleLabel;
        private Label heroInfoLabel;
        private Label heroSubLabel;
        private Button viewDetailsBtn;
        private Label label5;
        private Button manageBtn;
        private Label lblTotal;
        private Label lblActive;
        private Label lblUpcoming;
        private Panel panel3;
        private TextBox textBox1;
        private TextBox txtSearchGlobal;
        private Button btnMyTournaments;
        private Panel pnlSearchSection;
        private Label label7;
        private FlowLayoutPanel flowQuickFilters;
        private Button btnFilterAll;
        private Button btnFilterUpcoming;
        private Label label8;
    }
}