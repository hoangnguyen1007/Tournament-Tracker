namespace TourApp
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            loginPanel = new Panel();
            resLink = new LinkLabel();
            label2 = new Label();
            button1 = new Button();
            loginLabel = new Label();
            passTextBox = new TextBox();
            passLabel = new Label();
            usrnLabel = new Label();
            usnTextBox = new TextBox();
            registerPanel = new Panel();
            label7 = new Label();
            res_conPassTextBox = new TextBox();
            loginLink = new LinkLabel();
            label3 = new Label();
            button2 = new Button();
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
            loginPanel.Controls.Add(resLink);
            loginPanel.Controls.Add(label2);
            loginPanel.Controls.Add(button1);
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 26F);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(136, 275);
            button1.Name = "button1";
            button1.Size = new Size(75, 71);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = false;
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
            // registerPanel
            // 
            registerPanel.BackColor = Color.Transparent;
            registerPanel.Controls.Add(label7);
            registerPanel.Controls.Add(res_conPassTextBox);
            registerPanel.Controls.Add(loginLink);
            registerPanel.Controls.Add(label3);
            registerPanel.Controls.Add(button2);
            registerPanel.Controls.Add(label4);
            registerPanel.Controls.Add(res_passTextBox);
            registerPanel.Controls.Add(label5);
            registerPanel.Controls.Add(label6);
            registerPanel.Controls.Add(res_usnTextBox);
            registerPanel.Location = new Point(12, 100);
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
            label7.Location = new Point(41, 252);
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
            res_conPassTextBox.Location = new Point(50, 285);
            res_conPassTextBox.Name = "res_conPassTextBox";
            res_conPassTextBox.PasswordChar = '*';
            res_conPassTextBox.Size = new Size(253, 37);
            res_conPassTextBox.TabIndex = 8;
            // 
            // loginLink
            // 
            loginLink.ActiveLinkColor = Color.ForestGreen;
            loginLink.AutoSize = true;
            loginLink.Font = new Font("Segoe UI", 8F);
            loginLink.LinkColor = Color.LimeGreen;
            loginLink.Location = new Point(217, 401);
            loginLink.Name = "loginLink";
            loginLink.Size = new Size(53, 21);
            loginLink.TabIndex = 7;
            loginLink.TabStop = true;
            loginLink.Text = "Log in";
            loginLink.LinkClicked += loginLink_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F);
            label3.Location = new Point(91, 401);
            label3.Name = "label3";
            label3.Size = new Size(131, 21);
            label3.TabIndex = 6;
            label3.Text = "Have an account?";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 26F);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(136, 328);
            button2.Name = "button2";
            button2.Size = new Size(75, 71);
            button2.TabIndex = 5;
            button2.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(101, 28);
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
            res_passTextBox.Location = new Point(50, 202);
            res_passTextBox.Name = "res_passTextBox";
            res_passTextBox.PasswordChar = '*';
            res_passTextBox.Size = new Size(253, 37);
            res_passTextBox.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(50, 169);
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
            label6.Location = new Point(50, 89);
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
            res_usnTextBox.Location = new Point(50, 122);
            res_usnTextBox.Name = "res_usnTextBox";
            res_usnTextBox.Size = new Size(253, 37);
            res_usnTextBox.TabIndex = 0;
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
            // HomeForm
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
            Name = "HomeForm";
            Text = "Home";
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
        private Button button1;
        private LinkLabel linkLabel1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel registerPanel;
        private TextBox res_conPassTextBox;
        private LinkLabel linkLabel2;
        private Label label3;
        private Button button2;
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
