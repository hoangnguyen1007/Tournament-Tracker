namespace TeamListForm
{
    partial class TeamEditorForm
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
            label1 = new Label();
            label2 = new Label();
            txtCoach = new TextBox();
            txtTeamName = new TextBox();
            btnOption = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(89, 150);
            label1.Name = "label1";
            label1.Size = new Size(144, 32);
            label1.TabIndex = 0;
            label1.Text = "Team Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(89, 211);
            label2.Name = "label2";
            label2.Size = new Size(81, 32);
            label2.TabIndex = 1;
            label2.Text = "Coach";
            // 
            // txtCoach
            // 
            txtCoach.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCoach.Location = new Point(289, 210);
            txtCoach.Name = "txtCoach";
            txtCoach.Size = new Size(420, 33);
            txtCoach.TabIndex = 4;
            // 
            // txtTeamName
            // 
            txtTeamName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTeamName.Location = new Point(289, 149);
            txtTeamName.Name = "txtTeamName";
            txtTeamName.Size = new Size(420, 33);
            txtTeamName.TabIndex = 6;
            // 
            // btnOption
            // 
            btnOption.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOption.Location = new Point(132, 387);
            btnOption.Name = "btnOption";
            btnOption.Size = new Size(112, 47);
            btnOption.TabIndex = 7;
            btnOption.Text = "Save";
            btnOption.UseVisualStyleBackColor = true;
            btnOption.Click += btnOption_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(597, 387);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 47);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // TeamEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 38, 39);
            ClientSize = new Size(923, 512);
            Controls.Add(btnCancel);
            Controls.Add(btnOption);
            Controls.Add(txtTeamName);
            Controls.Add(txtCoach);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.FromArgb(40, 156, 56);
            Name = "TeamEditorForm";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtCoach;
        private TextBox textBox3;
        private TextBox txtTeamName;
        private Button btnOption;
        private Button btnCancel;
    }
}