namespace TeamListForm
{
    partial class PlayerEditorForm
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
            btnCancel = new Button();
            btnOption = new Button();
            txtPlayerName = new TextBox();
            txtPosition = new TextBox();
            lbPosition = new Label();
            lbPlayerName = new Label();
            txtAge = new TextBox();
            lbAge = new Label();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(598, 402);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 47);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOption
            // 
            btnOption.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOption.Location = new Point(90, 402);
            btnOption.Name = "btnOption";
            btnOption.Size = new Size(112, 47);
            btnOption.TabIndex = 13;
            btnOption.Text = "Save";
            btnOption.UseVisualStyleBackColor = true;
            // 
            // txtPlayerName
            // 
            txtPlayerName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPlayerName.Location = new Point(290, 137);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(420, 33);
            txtPlayerName.TabIndex = 12;
            // 
            // txtPosition
            // 
            txtPosition.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPosition.Location = new Point(290, 198);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(420, 33);
            txtPosition.TabIndex = 11;
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPosition.Location = new Point(90, 199);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(100, 32);
            lbPosition.TabIndex = 10;
            lbPosition.Text = "Position";
            // 
            // lbPlayerName
            // 
            lbPlayerName.AutoSize = true;
            lbPlayerName.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPlayerName.Location = new Point(90, 138);
            lbPlayerName.Name = "lbPlayerName";
            lbPlayerName.Size = new Size(153, 32);
            lbPlayerName.TabIndex = 9;
            lbPlayerName.Text = "Player Name";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAge.Location = new Point(290, 270);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(420, 33);
            txtAge.TabIndex = 18;
            // 
            // lbAge
            // 
            lbAge.AutoSize = true;
            lbAge.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbAge.Location = new Point(90, 271);
            lbAge.Name = "lbAge";
            lbAge.Size = new Size(57, 32);
            lbAge.TabIndex = 15;
            lbAge.Text = "Age";
            // 
            // PlayerEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 612);
            Controls.Add(txtAge);
            Controls.Add(lbAge);
            Controls.Add(btnCancel);
            Controls.Add(btnOption);
            Controls.Add(txtPlayerName);
            Controls.Add(txtPosition);
            Controls.Add(lbPosition);
            Controls.Add(lbPlayerName);
            Name = "PlayerEditorForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnOption;
        private TextBox txtPlayerName;
        private TextBox txtPosition;
        private Label lbPosition;
        private Label lbPlayerName;
        private TextBox txtAge;
        private Label lbAge;
    }
}