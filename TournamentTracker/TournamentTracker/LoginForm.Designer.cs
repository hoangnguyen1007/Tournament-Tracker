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
            registerPanel = new Panel();
            label7 = new Label();
            res_conPassTextBox = new TextBox();
            loginLink = new LinkLabel();
            label3 = new Label();
            resBtn = new Button();
            label4 = new Label();
            res_passTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            res_usnTextBox = new TextBox();
            resLink = new LinkLabel();
            label2 = new Label();
            logBtn = new Button();
            loginLabel = new Label();
            passTextBox = new TextBox();
            passLabel = new Label();
            usrnLabel = new Label();
            usnTextBox = new TextBox();
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
            loginPanel.Size = new Size(376, 457);
            loginPanel.TabIndex = 0;
            loginPanel.Paint += loginPanel_Paint;
            // 
            // registerPanel
            // 
            registerPanel.BackColor = Color.Transparent;
            registerPanel.Controls.Add(label7);
            registerPanel.Controls.Add(res_conPassTextBox);
            registerPanel.Controls.Add(loginLink);
            registerPanel.Controls.Add(label3);
            registerPanel.Controls.Add(resBtn);
            registerPanel.Controls.Add(label4);
            registerPanel.Controls.Add(res_passTextBox);
            registerPanel.Controls.Add(label5);
            registerPanel.Controls.Add(label6);
            registerPanel.Controls.Add(res_usnTextBox);
            registerPanel.Location = new Point(12, 112);
            registerPanel.Name = "registerPanel";
            registerPanel.Size = new Size(376, 457);
            registerPanel.TabIndex = 3;
            registerPanel.Paint += registerPanel_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(42, 253);
            label7.Name = "label7";
            label7.Size = new Size(207, 30);
            label7.TabIndex = 9;
            label7.Text = " Confirm Password";
            // 
            // res_conPassTextBox
            // 
            res_conPassTextBox.BackColor = Color.FromArgb(64, 64, 64);
            res_conPassTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            res_conPassTextBox.ForeColor = SystemColors.Info;
            res_conPassTextBox.Location = new Point(51, 286);
            res_conPassTextBox.Name = "res_conPassTextBox";
            res_conPassTextBox.PasswordChar = '*';
            res_conPassTextBox.Size = new Size(253, 37);
            res_conPassTextBox.TabIndex = 2;
            res_conPassTextBox.KeyDown += res_conPassTextBox_KeyDown;
            // 
            // loginLink
            // 
            loginLink.ActiveLinkColor = Color.ForestGreen;
            loginLink.AutoSize = true;
            loginLink.Font = new Font("Segoe UI", 8F);
            loginLink.LinkColor = Color.LimeGreen;
            loginLink.Location = new Point(218, 402);
            loginLink.Name = "loginLink";
            loginLink.Size = new Size(53, 21);
            loginLink.TabIndex = 4;
            loginLink.TabStop = true;
            loginLink.Text = "Log in";
            loginLink.LinkClicked += loginLink_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(92, 402);
            label3.Name = "label3";
            label3.Size = new Size(131, 21);
            label3.TabIndex = 6;
            label3.Text = "Have an account?";
            // 
            // resBtn
            // 
            resBtn.BackColor = Color.FromArgb(64, 64, 64);
            resBtn.BackgroundImage = (Image)resources.GetObject("resBtn.BackgroundImage");
            resBtn.FlatAppearance.BorderSize = 0;
            resBtn.FlatStyle = FlatStyle.Flat;
            resBtn.Font = new Font("Segoe UI", 26F);
            resBtn.ForeColor = Color.Transparent;
            resBtn.Location = new Point(137, 329);
            resBtn.Name = "resBtn";
            resBtn.Size = new Size(75, 71);
            resBtn.TabIndex = 3;
            resBtn.UseVisualStyleBackColor = false;
            resBtn.Click += resBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(102, 29);
            label4.Name = "label4";
            label4.Size = new Size(157, 48);
            label4.TabIndex = 4;
            label4.Text = "Register";
            // 
            // res_passTextBox
            // 
            res_passTextBox.BackColor = Color.FromArgb(64, 64, 64);
            res_passTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            res_passTextBox.ForeColor = SystemColors.Info;
            res_passTextBox.Location = new Point(51, 203);
            res_passTextBox.Name = "res_passTextBox";
            res_passTextBox.PasswordChar = '*';
            res_passTextBox.Size = new Size(253, 37);
            res_passTextBox.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(51, 170);
            label5.Name = "label5";
            label5.Size = new Size(112, 30);
            label5.TabIndex = 2;
            label5.Text = "Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(51, 90);
            label6.Name = "label6";
            label6.Size = new Size(117, 30);
            label6.TabIndex = 1;
            label6.Text = "Username";
            // 
            // res_usnTextBox
            // 
            res_usnTextBox.BackColor = Color.FromArgb(64, 64, 64);
            res_usnTextBox.Font = new Font("Segoe UI", 11F);
            res_usnTextBox.ForeColor = SystemColors.Info;
            res_usnTextBox.Location = new Point(51, 123);
            res_usnTextBox.Name = "res_usnTextBox";
            res_usnTextBox.Size = new Size(253, 37);
            res_usnTextBox.TabIndex = 0;
            res_usnTextBox.TextChanged += res_usnTextBox_TextChanged;
            // 
            // resLink
            // 
            resLink.ActiveLinkColor = Color.ForestGreen;
            resLink.AutoSize = true;
            resLink.Font = new Font("Segoe UI", 8F);
            resLink.LinkColor = Color.LimeGreen;
            resLink.Location = new Point(227, 364);
            resLink.Name = "resLink";
            resLink.Size = new Size(63, 21);
            resLink.TabIndex = 7;
            resLink.TabStop = true;
            resLink.Text = "Sign up";
            resLink.LinkClicked += resLink_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F);
            label2.Location = new Point(55, 364);
            label2.Name = "label2";
            label2.Size = new Size(178, 21);
            label2.TabIndex = 6;
            label2.Text = "Don't have an account?, ";
            // 
            // logBtn
            // 
            logBtn.BackColor = Color.FromArgb(64, 64, 64);
            logBtn.BackgroundImage = (Image)resources.GetObject("logBtn.BackgroundImage");
            logBtn.FlatAppearance.BorderSize = 0;
            logBtn.FlatStyle = FlatStyle.Flat;
            logBtn.Font = new Font("Segoe UI", 26F);
            logBtn.ForeColor = Color.Transparent;
            logBtn.Location = new Point(136, 275);
            logBtn.Name = "logBtn";
            logBtn.Size = new Size(75, 71);
            logBtn.TabIndex = 5;
            logBtn.UseVisualStyleBackColor = false;
            logBtn.Click += logBtn_Click;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            loginLabel.ForeColor = SystemColors.ButtonFace;
            loginLabel.Location = new Point(119, 25);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(114, 48);
            loginLabel.TabIndex = 4;
            loginLabel.Text = "Login";
            // 
            // passTextBox
            // 
            passTextBox.BackColor = Color.FromArgb(64, 64, 64);
            passTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            passTextBox.ForeColor = SystemColors.Info;
            passTextBox.Location = new Point(50, 211);
            passTextBox.Name = "passTextBox";
            passTextBox.PasswordChar = '*';
            passTextBox.Size = new Size(253, 37);
            passTextBox.TabIndex = 3;
            passTextBox.KeyDown += passTextBox_KeyDown;
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            passLabel.ForeColor = SystemColors.ButtonFace;
            passLabel.Location = new Point(50, 178);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(112, 30);
            passLabel.TabIndex = 2;
            passLabel.Text = "Password";
            // 
            // usrnLabel
            // 
            usrnLabel.AutoSize = true;
            usrnLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            usrnLabel.ForeColor = SystemColors.ButtonFace;
            usrnLabel.Location = new Point(50, 98);
            usrnLabel.Name = "usrnLabel";
            usrnLabel.Size = new Size(117, 30);
            usrnLabel.TabIndex = 1;
            usrnLabel.Text = "Username";
            // 
            // usnTextBox
            // 
            usnTextBox.BackColor = Color.FromArgb(64, 64, 64);
            usnTextBox.Font = new Font("Segoe UI", 11F);
            usnTextBox.ForeColor = SystemColors.Info;
            usnTextBox.Location = new Point(50, 131);
            usnTextBox.Name = "usnTextBox";
            usnTextBox.Size = new Size(253, 37);
            usnTextBox.TabIndex = 0;
            usnTextBox.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.LimeGreen;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(368, 54);
            label1.TabIndex = 1;
            label1.Text = "🏆 TOURNAMENT";
            label1.Click += label1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(394, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(591, 569);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(984, 569);
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
    }
}
