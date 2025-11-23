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
            HGLabel = new Label();
            AGLabel = new Label();
            vsLabel = new Label();
            homeLabel = new Label();
            awayLabel = new Label();
            homeNumericUpDown = new NumericUpDown();
            awayNumericUpDown = new NumericUpDown();
            saveMatchButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)homeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)awayNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // HGLabel
            // 
            HGLabel.AutoSize = true;
            HGLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HGLabel.ForeColor = Color.Gold;
            HGLabel.Location = new Point(29, 26);
            HGLabel.Name = "HGLabel";
            HGLabel.Size = new Size(126, 25);
            HGLabel.TabIndex = 0;
            HGLabel.Text = "HOME TEAM";
            // 
            // AGLabel
            // 
            AGLabel.AutoSize = true;
            AGLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AGLabel.ForeColor = Color.Gold;
            AGLabel.Location = new Point(283, 26);
            AGLabel.Name = "AGLabel";
            AGLabel.Size = new Size(123, 25);
            AGLabel.TabIndex = 1;
            AGLabel.Text = "AWAY TEAM";
            // 
            // vsLabel
            // 
            vsLabel.AutoSize = true;
            vsLabel.Font = new Font("Segoe UI", 30F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            vsLabel.ForeColor = Color.FromArgb(64, 64, 64);
            vsLabel.Location = new Point(172, 26);
            vsLabel.Name = "vsLabel";
            vsLabel.Size = new Size(89, 67);
            vsLabel.TabIndex = 2;
            vsLabel.Text = "VS";
            // 
            // homeLabel
            // 
            homeLabel.AutoSize = true;
            homeLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            homeLabel.ForeColor = Color.Silver;
            homeLabel.Location = new Point(29, 69);
            homeLabel.Name = "homeLabel";
            homeLabel.Size = new Size(71, 19);
            homeLabel.TabIndex = 3;
            homeLabel.Text = "HOME🛡️";
            // 
            // awayLabel
            // 
            awayLabel.AutoSize = true;
            awayLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            awayLabel.ForeColor = Color.Silver;
            awayLabel.Location = new Point(283, 69);
            awayLabel.Name = "awayLabel";
            awayLabel.Size = new Size(71, 19);
            awayLabel.TabIndex = 4;
            awayLabel.Text = "AWAY⚔️";
            // 
            // homeNumericUpDown
            // 
            homeNumericUpDown.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeNumericUpDown.Location = new Point(29, 102);
            homeNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            homeNumericUpDown.Name = "homeNumericUpDown";
            homeNumericUpDown.Size = new Size(120, 38);
            homeNumericUpDown.TabIndex = 5;
            // 
            // awayNumericUpDown
            // 
            awayNumericUpDown.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            awayNumericUpDown.Location = new Point(283, 102);
            awayNumericUpDown.Margin = new Padding(3, 4, 3, 4);
            awayNumericUpDown.Name = "awayNumericUpDown";
            awayNumericUpDown.Size = new Size(120, 38);
            awayNumericUpDown.TabIndex = 6;
            // 
            // saveMatchButton
            // 
            saveMatchButton.BackColor = Color.FromArgb(0, 180, 80);
            saveMatchButton.FlatAppearance.BorderColor = Color.SpringGreen;
            saveMatchButton.FlatAppearance.BorderSize = 0;
            saveMatchButton.FlatStyle = FlatStyle.Flat;
            saveMatchButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveMatchButton.ForeColor = Color.White;
            saveMatchButton.Location = new Point(70, 169);
            saveMatchButton.Margin = new Padding(3, 4, 3, 4);
            saveMatchButton.Name = "saveMatchButton";
            saveMatchButton.Size = new Size(293, 61);
            saveMatchButton.TabIndex = 7;
            saveMatchButton.Text = "SAVE MATCH";
            saveMatchButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(178, 93);
            label1.Name = "label1";
            label1.Size = new Size(76, 19);
            label1.TabIndex = 8;
            label1.Text = "FULL TIME";
            // 
            // MatchResultForm
            // 
            AcceptButton = saveMatchButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 33, 36);
            ClientSize = new Size(432, 253);
            Controls.Add(label1);
            Controls.Add(saveMatchButton);
            Controls.Add(awayNumericUpDown);
            Controls.Add(homeNumericUpDown);
            Controls.Add(awayLabel);
            Controls.Add(homeLabel);
            Controls.Add(vsLabel);
            Controls.Add(AGLabel);
            Controls.Add(HGLabel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MatchResultForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UPDATE SCORE";
            ((System.ComponentModel.ISupportInitialize)homeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)awayNumericUpDown).EndInit();
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
    }
}