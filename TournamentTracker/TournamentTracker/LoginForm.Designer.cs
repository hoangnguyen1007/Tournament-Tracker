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
            showBtn3 = new Button();
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
            showBtn2 = new Button();
            showBtn1 = new Button();
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
            loginPanel.Controls.Add(showBtn3);
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
            resources.ApplyResources(loginPanel, "loginPanel");
            loginPanel.Name = "loginPanel";
            loginPanel.Paint += loginPanel_Paint;
            // 
            // showBtn3
            // 
            showBtn3.BackColor = Color.FromArgb(35, 39, 47);
            resources.ApplyResources(showBtn3, "showBtn3");
            showBtn3.FlatAppearance.BorderSize = 0;
            showBtn3.ForeColor = Color.Transparent;
            showBtn3.Name = "showBtn3";
            showBtn3.UseVisualStyleBackColor = false;
            showBtn3.Click += showBtn3_Click;
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.ForeColor = Color.White;
            label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.ForeColor = Color.FromArgb(225, 225, 225);
            label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.ForeColor = Color.White;
            label8.Name = "label8";
            // 
            // resLink
            // 
            resLink.ActiveLinkColor = Color.ForestGreen;
            resources.ApplyResources(resLink, "resLink");
            resLink.LinkColor = Color.FromArgb(50, 230, 118);
            resLink.Name = "resLink";
            resLink.TabStop = true;
            resLink.LinkClicked += resLink_LinkClicked;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // logBtn
            // 
            logBtn.BackColor = Color.Transparent;
            resources.ApplyResources(logBtn, "logBtn");
            logBtn.Cursor = Cursors.Hand;
            logBtn.FlatAppearance.BorderSize = 0;
            logBtn.ForeColor = Color.Transparent;
            logBtn.Name = "logBtn";
            logBtn.UseVisualStyleBackColor = false;
            logBtn.Click += logBtn_Click;
            // 
            // loginLabel
            // 
            resources.ApplyResources(loginLabel, "loginLabel");
            loginLabel.ForeColor = Color.White;
            loginLabel.Name = "loginLabel";
            loginLabel.Click += loginLabel_Click;
            // 
            // passTextBox
            // 
            passTextBox.BackColor = Color.FromArgb(35, 39, 47);
            resources.ApplyResources(passTextBox, "passTextBox");
            passTextBox.ForeColor = Color.FromArgb(232, 232, 232);
            passTextBox.Name = "passTextBox";
            passTextBox.KeyDown += passTextBox_KeyDown;
            // 
            // passLabel
            // 
            resources.ApplyResources(passLabel, "passLabel");
            passLabel.ForeColor = Color.FromArgb(240, 240, 230);
            passLabel.Name = "passLabel";
            // 
            // usrnLabel
            // 
            resources.ApplyResources(usrnLabel, "usrnLabel");
            usrnLabel.ForeColor = Color.FromArgb(240, 240, 230);
            usrnLabel.Name = "usrnLabel";
            // 
            // usnTextBox
            // 
            usnTextBox.BackColor = Color.FromArgb(35, 39, 47);
            resources.ApplyResources(usnTextBox, "usnTextBox");
            usnTextBox.ForeColor = Color.FromArgb(232, 232, 232);
            usnTextBox.Name = "usnTextBox";
            usnTextBox.TextChanged += textBox1_TextChanged;
            // 
            // registerPanel
            // 
            registerPanel.BackColor = Color.Transparent;
            registerPanel.Controls.Add(showBtn2);
            registerPanel.Controls.Add(showBtn1);
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
            resources.ApplyResources(registerPanel, "registerPanel");
            registerPanel.Name = "registerPanel";
            registerPanel.Paint += registerPanel_Paint;
            // 
            // showBtn2
            // 
            showBtn2.BackColor = Color.FromArgb(35, 39, 47);
            resources.ApplyResources(showBtn2, "showBtn2");
            showBtn2.FlatAppearance.BorderSize = 0;
            showBtn2.ForeColor = Color.Transparent;
            showBtn2.Name = "showBtn2";
            showBtn2.UseVisualStyleBackColor = false;
            showBtn2.Click += showBtn2_Click;
            // 
            // showBtn1
            // 
            showBtn1.BackColor = Color.FromArgb(35, 39, 47);
            resources.ApplyResources(showBtn1, "showBtn1");
            showBtn1.FlatAppearance.BorderSize = 0;
            showBtn1.ForeColor = Color.Transparent;
            showBtn1.Name = "showBtn1";
            showBtn1.UseVisualStyleBackColor = false;
            showBtn1.Click += showBtn1_Click;
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.ForeColor = Color.FromArgb(225, 225, 225);
            label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.ForeColor = Color.White;
            label11.Name = "label11";
            label11.Click += label11_Click;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.ForeColor = Color.FromArgb(240, 240, 230);
            label7.Name = "label7";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.ForeColor = Color.White;
            label13.Name = "label13";
            // 
            // res_conPassTextBox
            // 
            res_conPassTextBox.BackColor = Color.FromArgb(35, 39, 47);
            resources.ApplyResources(res_conPassTextBox, "res_conPassTextBox");
            res_conPassTextBox.ForeColor = Color.FromArgb(232, 232, 232);
            res_conPassTextBox.Name = "res_conPassTextBox";
            res_conPassTextBox.KeyDown += res_conPassTextBox_KeyDown;
            // 
            // loginLink
            // 
            loginLink.ActiveLinkColor = Color.ForestGreen;
            resources.ApplyResources(loginLink, "loginLink");
            loginLink.LinkColor = Color.FromArgb(50, 230, 118);
            loginLink.Name = "loginLink";
            loginLink.TabStop = true;
            loginLink.LinkClicked += loginLink_LinkClicked;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // resBtn
            // 
            resBtn.BackColor = Color.Transparent;
            resources.ApplyResources(resBtn, "resBtn");
            resBtn.Cursor = Cursors.Hand;
            resBtn.FlatAppearance.BorderSize = 0;
            resBtn.ForeColor = Color.Transparent;
            resBtn.Name = "resBtn";
            resBtn.UseVisualStyleBackColor = false;
            resBtn.Click += resBtn_Click;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = Color.White;
            label4.Name = "label4";
            // 
            // res_passTextBox
            // 
            res_passTextBox.BackColor = Color.FromArgb(35, 39, 47);
            resources.ApplyResources(res_passTextBox, "res_passTextBox");
            res_passTextBox.ForeColor = Color.FromArgb(232, 232, 232);
            res_passTextBox.Name = "res_passTextBox";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.ForeColor = Color.FromArgb(240, 240, 230);
            label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.ForeColor = Color.FromArgb(240, 240, 230);
            label6.Name = "label6";
            // 
            // res_usnTextBox
            // 
            res_usnTextBox.BackColor = Color.FromArgb(35, 39, 47);
            resources.ApplyResources(res_usnTextBox, "res_usnTextBox");
            res_usnTextBox.ForeColor = Color.FromArgb(232, 232, 232);
            res_usnTextBox.Name = "res_usnTextBox";
            res_usnTextBox.TextChanged += res_usnTextBox_TextChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.SpringGreen;
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(44, 44, 44);
            resources.ApplyResources(this, "$this");
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(loginPanel);
            Controls.Add(registerPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "LoginForm";
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
        private Button showBtn1;
        private Button showBtn2;
        private Button showBtn3;
    }
}
