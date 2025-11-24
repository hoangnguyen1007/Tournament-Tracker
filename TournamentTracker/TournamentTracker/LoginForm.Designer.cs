namespace TourApp
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            loginPanel = new Panel();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            resLink = new LinkLabel();
            label2 = new Label();
            logBtn = new Button();
            loginLabel = new Label();
            passTextBox = new TextBox();
            passLabel = new Label();
            usrnLabel = new Label();
            usnTextBox = new TextBox();
            registerPanel = new Panel();
            label12 = new Label();
            label11 = new Label();
            label7 = new Label();
            label13 = new Label();
            res_conPassTextBox = new TextBox();
            loginLink = new LinkLabel();
            label3 = new Label();
            resBtn = new Button();
            label4 = new Label();
            res_passTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            res_usnTextBox = new TextBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            loginPanel.SuspendLayout();
            registerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.Transparent;
            loginPanel.Controls.Add(label10);
            loginPanel.Controls.Add(label9);
            loginPanel.Controls.Add(label8);
            loginPanel.Controls.Add(resLink);
            loginPanel.Controls.Add(label2);
            loginPanel.Controls.Add(logBtn);
            loginPanel.Controls.Add(loginLabel);
            loginPanel.Controls.Add(passTextBox);
            loginPanel.Controls.Add(passLabel);
            loginPanel.Controls.Add(usrnLabel);
            loginPanel.Controls.Add(usnTextBox);
            loginPanel.Location = new Point(12, 100);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(512, 671);
            loginPanel.TabIndex = 0;
            loginPanel.Paint += loginPanel_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.ForeColor = Color.FromArgb(224, 224, 224);
            label10.Location = new Point(163, 169);
            label10.Name = "label10";
            label10.Size = new Size(150, 28);
            label10.TabIndex = 10;
            label10.Text = " Welcome back!";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.ForeColor = Color.FromArgb(225, 225, 225);
            label9.Location = new Point(3, 60);
            label9.Name = "label9";
            label9.Size = new Size(502, 28);
            label9.TabIndex = 9;
            label9.Text = "─────────────────────────────────────────────────";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.ForeColor = Color.FromArgb(230, 230, 230);
            label8.Location = new Point(130, 10);
            label8.Name = "label8";
            label8.Size = new Size(237, 32);
            label8.TabIndex = 8;
            label8.Text = "Compete. Track. Win.";
            // 
            // resLink
            // 
            resLink.ActiveLinkColor = Color.ForestGreen;
            resLink.AutoSize = true;
            resLink.Font = new Font("Segoe UI", 9F);
            resLink.LinkColor = Color.FromArgb(50, 230, 118);
            resLink.Location = new Point(305, 597);
            resLink.Name = "resLink";
            resLink.Size = new Size(73, 25);
            resLink.TabIndex = 7;
            resLink.TabStop = true;
            resLink.Text = "Sign up";
            resLink.LinkClicked += resLink_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(110, 597);
            label2.Name = "label2";
            label2.Size = new Size(206, 25);
            label2.TabIndex = 6;
            label2.Text = "Don't have an account?, ";
            // 
            // logBtn
            // 
            logBtn.BackColor = Color.FromArgb(44, 44, 44);
            logBtn.BackgroundImage = (Image)resources.GetObject("logBtn.BackgroundImage");
            logBtn.FlatAppearance.BorderSize = 0;
            logBtn.FlatStyle = FlatStyle.Flat;
            logBtn.Font = new Font("Segoe UI", 26F);
            logBtn.ForeColor = Color.Transparent;
            logBtn.Location = new Point(200, 465);
            logBtn.Name = "logBtn";
            logBtn.Size = new Size(75, 71);
            logBtn.TabIndex = 5;
            logBtn.UseVisualStyleBackColor = false;
            logBtn.Click += logBtn_Click;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            loginLabel.ForeColor = Color.FromArgb(230, 230, 230);
            loginLabel.Location = new Point(177, 98);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(127, 54);
            loginLabel.TabIndex = 4;
            loginLabel.Text = "Login";
            loginLabel.Click += loginLabel_Click;
            // 
            // passTextBox
            // 
            passTextBox.BackColor = Color.FromArgb(58, 58, 58);
            passTextBox.Font = new Font("Sitka Banner", 12.999999F);
            passTextBox.ForeColor = SystemColors.Info;
            passTextBox.Location = new Point(78, 345);
            passTextBox.Name = "passTextBox";
            passTextBox.PasswordChar = '*';
            passTextBox.Size = new Size(341, 40);
            passTextBox.TabIndex = 3;
            passTextBox.KeyDown += passTextBox_KeyDown;
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            passLabel.ForeColor = Color.FromArgb(230, 230, 230);
            passLabel.Location = new Point(78, 312);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(112, 30);
            passLabel.TabIndex = 2;
            passLabel.Text = "Password";
            // 
            // usrnLabel
            // 
            usrnLabel.AutoSize = true;
            usrnLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            usrnLabel.ForeColor = Color.FromArgb(230, 230, 230);
            usrnLabel.Location = new Point(78, 228);
            usrnLabel.Name = "usrnLabel";
            usrnLabel.Size = new Size(117, 30);
            usrnLabel.TabIndex = 1;
            usrnLabel.Text = "Username";
            // 
            // usnTextBox
            // 
            usnTextBox.BackColor = Color.FromArgb(58, 58, 58);
            usnTextBox.Font = new Font("Sitka Banner", 12.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usnTextBox.ForeColor = SystemColors.Info;
            usnTextBox.Location = new Point(78, 261);
            usnTextBox.Name = "usnTextBox";
            usnTextBox.Size = new Size(341, 40);
            usnTextBox.TabIndex = 0;
            usnTextBox.TextChanged += textBox1_TextChanged;
            // 
            // registerPanel
            // 
            registerPanel.BackColor = Color.Transparent;
            registerPanel.Controls.Add(label12);
            registerPanel.Controls.Add(label11);
            registerPanel.Controls.Add(label7);
            registerPanel.Controls.Add(label13);
            registerPanel.Controls.Add(res_conPassTextBox);
            registerPanel.Controls.Add(loginLink);
            registerPanel.Controls.Add(label3);
            registerPanel.Controls.Add(resBtn);
            registerPanel.Controls.Add(label4);
            registerPanel.Controls.Add(res_passTextBox);
            registerPanel.Controls.Add(label5);
            registerPanel.Controls.Add(label6);
            registerPanel.Controls.Add(res_usnTextBox);
            registerPanel.Location = new Point(9, 97);
            registerPanel.Name = "registerPanel";
            registerPanel.Size = new Size(512, 671);
            registerPanel.TabIndex = 3;
            registerPanel.Paint += registerPanel_Paint;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F);
            label12.ForeColor = Color.FromArgb(225, 225, 225);
            label12.Location = new Point(3, 45);
            label12.Name = "label12";
            label12.Size = new Size(502, 28);
            label12.TabIndex = 12;
            label12.Text = "─────────────────────────────────────────────────";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.FromArgb(230, 230, 230);
            label11.Location = new Point(134, 145);
            label11.Name = "label11";
            label11.Size = new Size(225, 25);
            label11.TabIndex = 10;
            label11.Text = "Welcome! Let's get started.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(230, 230, 230);
            label7.Location = new Point(74, 351);
            label7.Name = "label7";
            label7.Size = new Size(207, 30);
            label7.TabIndex = 9;
            label7.Text = " Confirm Password";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.ForeColor = Color.FromArgb(230, 230, 230);
            label13.Location = new Point(133, 3);
            label13.Name = "label13";
            label13.Size = new Size(229, 32);
            label13.TabIndex = 11;
            label13.Text = "Create your account";
            // 
            // res_conPassTextBox
            // 
            res_conPassTextBox.BackColor = Color.FromArgb(58, 58, 58);
            res_conPassTextBox.Font = new Font("Sitka Banner", 12.999999F);
            res_conPassTextBox.ForeColor = SystemColors.Info;
            res_conPassTextBox.Location = new Point(83, 384);
            res_conPassTextBox.Name = "res_conPassTextBox";
            res_conPassTextBox.PasswordChar = '*';
            res_conPassTextBox.Size = new Size(341, 40);
            res_conPassTextBox.TabIndex = 2;
            res_conPassTextBox.KeyDown += res_conPassTextBox_KeyDown;
            // 
            // loginLink
            // 
            loginLink.ActiveLinkColor = Color.ForestGreen;
            loginLink.AutoSize = true;
            loginLink.Font = new Font("Segoe UI", 9F);
            loginLink.LinkColor = Color.FromArgb(50, 230, 118);
            loginLink.Location = new Point(298, 575);
            loginLink.Name = "loginLink";
            loginLink.Size = new Size(61, 25);
            loginLink.TabIndex = 4;
            loginLink.TabStop = true;
            loginLink.Text = "Log in";
            loginLink.LinkClicked += loginLink_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(152, 575);
            label3.Name = "label3";
            label3.Size = new Size(155, 25);
            label3.TabIndex = 6;
            label3.Text = "Have an account?,";
            // 
            // resBtn
            // 
            resBtn.BackColor = Color.FromArgb(44, 44, 44);
            resBtn.BackgroundImage = (Image)resources.GetObject("resBtn.BackgroundImage");
            resBtn.FlatAppearance.BorderSize = 0;
            resBtn.FlatStyle = FlatStyle.Flat;
            resBtn.Font = new Font("Segoe UI", 26F);
            resBtn.ForeColor = Color.Transparent;
            resBtn.Location = new Point(206, 469);
            resBtn.Name = "resBtn";
            resBtn.Size = new Size(75, 71);
            resBtn.TabIndex = 3;
            resBtn.UseVisualStyleBackColor = false;
            resBtn.Click += resBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(230, 230, 230);
            label4.Location = new Point(157, 73);
            label4.Name = "label4";
            label4.Size = new Size(178, 54);
            label4.TabIndex = 4;
            label4.Text = "Register";
            // 
            // res_passTextBox
            // 
            res_passTextBox.BackColor = Color.FromArgb(58, 58, 58);
            res_passTextBox.Font = new Font("Sitka Banner", 12.999999F);
            res_passTextBox.ForeColor = SystemColors.Info;
            res_passTextBox.Location = new Point(83, 304);
            res_passTextBox.Name = "res_passTextBox";
            res_passTextBox.PasswordChar = '*';
            res_passTextBox.Size = new Size(341, 40);
            res_passTextBox.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(230, 230, 230);
            label5.Location = new Point(83, 271);
            label5.Name = "label5";
            label5.Size = new Size(112, 30);
            label5.TabIndex = 2;
            label5.Text = "Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(230, 230, 230);
            label6.Location = new Point(83, 191);
            label6.Name = "label6";
            label6.Size = new Size(117, 30);
            label6.TabIndex = 1;
            label6.Text = "Username";
            // 
            // res_usnTextBox
            // 
            res_usnTextBox.BackColor = Color.FromArgb(58, 58, 58);
            res_usnTextBox.Font = new Font("Sitka Banner", 12.999999F);
            res_usnTextBox.ForeColor = SystemColors.Info;
            res_usnTextBox.Location = new Point(83, 224);
            res_usnTextBox.Name = "res_usnTextBox";
            res_usnTextBox.Size = new Size(341, 40);
            res_usnTextBox.TabIndex = 0;
            res_usnTextBox.TextChanged += res_usnTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(50, 230, 118);
            label1.Location = new Point(122, 30);
            label1.Name = "label1";
            label1.Size = new Size(280, 41);
            label1.TabIndex = 1;
            label1.Text = "🏆 TOURNAMENT";
            label1.Click += label1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(523, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(758, 767);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 44);
            ClientSize = new Size(1278, 764);
            Controls.Add(registerPanel);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(loginPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            Text = "Home";
            FormClosed += LoginForm_FormClosed;
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            registerPanel.ResumeLayout(false);
            registerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel loginPanel;
        private TextBox usnTextBox;
        private Label usrnLabel;
        private Label passLabel;
        private TextBox passTextBox;
        private Label label1;
        private Label loginLabel;
        private Button logBtn;
        private LinkLabel linkLabel1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel registerPanel;
        private TextBox res_conPassTextBox;
        private LinkLabel linkLabel2;
        private Label label3;
        private Button resBtn;
        private Label label4;
        private TextBox res_passTextBox;
        private Label label5;
        private Label label6;
        private TextBox res_usnTextBox;
        private LinkLabel resLink;
        private Label label7;
        private LinkLabel loginLink;
        private Label label8;
        private Label label10;
        private Label label9;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}
