namespace TeamListForm
{
    partial class MatchResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchResultForm));
            HGLabel = new Label();
            AGLabel = new Label();
            vsLabel = new Label();
            homeLabel = new Label();
            awayLabel = new Label();
            homeNumericUpDown = new NumericUpDown();
            awayNumericUpDown = new NumericUpDown();
            saveMatchButton = new Button();
            label1 = new Label();
            closeButton = new Button();
            MatchInfoLabel = new Label();
            panel1 = new Panel();
            finishedCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)homeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)awayNumericUpDown).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // HGLabel
            // 
            HGLabel.BackColor = Color.Transparent;
            HGLabel.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            HGLabel.ForeColor = Color.Gold;
            HGLabel.Location = new Point(50, 17);
            HGLabel.Name = "HGLabel";
            HGLabel.Size = new Size(200, 40);
            HGLabel.TabIndex = 0;
            HGLabel.Text = "HOME TEAM";
            HGLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AGLabel
            // 
            AGLabel.BackColor = Color.Transparent;
            AGLabel.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            AGLabel.ForeColor = Color.Gold;
            AGLabel.Location = new Point(324, 17);
            AGLabel.Name = "AGLabel";
            AGLabel.Size = new Size(200, 40);
            AGLabel.TabIndex = 1;
            AGLabel.Text = "AWAY TEAM";
            AGLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // vsLabel
            // 
            vsLabel.AutoSize = true;
            vsLabel.Font = new Font("Segoe UI", 50F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel, 0);
            vsLabel.ForeColor = Color.FromArgb(64, 64, 64);
            vsLabel.Location = new Point(246, 58);
            vsLabel.Name = "vsLabel";
            vsLabel.Size = new Size(89, 67);
            vsLabel.TabIndex = 2;
            vsLabel.Text = "VS";
            // 
            // homeLabel
            // 
            homeLabel.AutoSize = true;
            homeLabel.Font = new Font("Segoe UI", 41F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            homeLabel.ForeColor = Color.Silver;
            homeLabel.Location = new Point(-12, 7);
            homeLabel.Name = "homeLabel";
            homeLabel.Size = new Size(70, 55);
            homeLabel.TabIndex = 3;
            homeLabel.Text = "🛡️";
            // 
            // awayLabel
            // 
            awayLabel.AutoSize = true;
            awayLabel.Font = new Font("Segoe UI", 41F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            awayLabel.ForeColor = Color.Silver;
            awayLabel.Location = new Point(509, 7);
            awayLabel.Name = "awayLabel";
            awayLabel.Size = new Size(81, 55);
            awayLabel.TabIndex = 4;
            awayLabel.Text = "⚔️";
            // 
            // homeNumericUpDown
            // 
            homeNumericUpDown.BackColor = Color.FromArgb(32, 33, 36);
            homeNumericUpDown.BorderStyle = BorderStyle.None;
            homeNumericUpDown.Font = new Font("Microsoft Sans Serif", 83.4F, FontStyle.Regular, GraphicsUnit.Pixel, 0);
            homeNumericUpDown.ForeColor = Color.White;
            homeNumericUpDown.Location = new Point(77, 68);
            homeNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            homeNumericUpDown.Name = "homeNumericUpDown";
            homeNumericUpDown.Size = new Size(119, 98);
            homeNumericUpDown.TabIndex = 5;
            // 
            // awayNumericUpDown
            // 
            awayNumericUpDown.BackColor = Color.FromArgb(32, 33, 36);
            awayNumericUpDown.BorderStyle = BorderStyle.None;
            awayNumericUpDown.Font = new Font("Microsoft Sans Serif", 83.4F, FontStyle.Regular, GraphicsUnit.Pixel, 0);
            awayNumericUpDown.ForeColor = Color.White;
            awayNumericUpDown.Location = new Point(384, 68);
            awayNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            awayNumericUpDown.Name = "awayNumericUpDown";
            awayNumericUpDown.Size = new Size(119, 98);
            awayNumericUpDown.TabIndex = 6;
            // 
            // saveMatchButton
            // 
            saveMatchButton.BackColor = Color.FromArgb(0, 180, 80);
            saveMatchButton.Cursor = Cursors.Hand;
            saveMatchButton.FlatAppearance.BorderColor = Color.SpringGreen;
            saveMatchButton.FlatAppearance.BorderSize = 0;
            saveMatchButton.FlatStyle = FlatStyle.Flat;
            saveMatchButton.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            saveMatchButton.ForeColor = Color.White;
            saveMatchButton.Location = new Point(308, 284);
            saveMatchButton.Margin = new Padding(3, 4, 3, 4);
            saveMatchButton.Name = "saveMatchButton";
            saveMatchButton.Size = new Size(247, 61);
            saveMatchButton.TabIndex = 7;
            saveMatchButton.Text = "SAVE MATCH";
            saveMatchButton.UseVisualStyleBackColor = false;
            saveMatchButton.Click += saveMatchButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.4F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(252, 125);
            label1.Name = "label1";
            label1.Size = new Size(76, 19);
            label1.TabIndex = 8;
            label1.Text = "FULL TIME";
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.Silver;
            closeButton.Cursor = Cursors.Hand;
            closeButton.FlatAppearance.BorderColor = Color.Silver;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Pixel);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(25, 284);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(247, 61);
            closeButton.TabIndex = 9;
            closeButton.Text = "CANCEL";
            closeButton.UseVisualStyleBackColor = false;
            // 
            // MatchInfoLabel
            // 
            MatchInfoLabel.Anchor = AnchorStyles.Top;
            MatchInfoLabel.AutoSize = true;
            MatchInfoLabel.BackColor = Color.Transparent;
            MatchInfoLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.World);
            MatchInfoLabel.ForeColor = Color.Silver;
            MatchInfoLabel.Location = new Point(175, 10);
            MatchInfoLabel.Name = "MatchInfoLabel";
            MatchInfoLabel.Size = new Size(226, 32);
            MatchInfoLabel.TabIndex = 10;
            MatchInfoLabel.Text = "Round 0 - Match 0";
            MatchInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 33, 36);
            panel1.Controls.Add(AGLabel);
            panel1.Controls.Add(awayLabel);
            panel1.Controls.Add(finishedCheckBox);
            panel1.Controls.Add(awayNumericUpDown);
            panel1.Controls.Add(HGLabel);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(vsLabel);
            panel1.Controls.Add(homeLabel);
            panel1.Controls.Add(homeNumericUpDown);
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 215);
            panel1.TabIndex = 11;
            // 
            // finishedCheckBox
            // 
            finishedCheckBox.AutoSize = true;
            finishedCheckBox.Location = new Point(211, 180);
            finishedCheckBox.Name = "finishedCheckBox";
            finishedCheckBox.Size = new Size(162, 27);
            finishedCheckBox.TabIndex = 9;
            finishedCheckBox.Text = "Mark as Finished";
            finishedCheckBox.UseVisualStyleBackColor = true;
            finishedCheckBox.CheckedChanged += finishedCheckBox_CheckedChanged;
            // 
            // MatchResultForm
            // 
            AcceptButton = saveMatchButton;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(25, 25, 25);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = closeButton;
            ClientSize = new Size(580, 360);
            Controls.Add(MatchInfoLabel);
            Controls.Add(closeButton);
            Controls.Add(saveMatchButton);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Pixel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MatchResultForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)homeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)awayNumericUpDown).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HGLabel;
        private System.Windows.Forms.Label AGLabel;
        private System.Windows.Forms.Label vsLabel;
        private System.Windows.Forms.Label homeLabel;
        private System.Windows.Forms.Label awayLabel;
        private System.Windows.Forms.NumericUpDown homeNumericUpDown;
        private System.Windows.Forms.NumericUpDown awayNumericUpDown;
        private System.Windows.Forms.Button saveMatchButton;
        private System.Windows.Forms.Label label1;
        private Button closeButton;
        private Label MatchInfoLabel;
        private Panel panel1;
        private CheckBox finishedCheckBox;
    }
}