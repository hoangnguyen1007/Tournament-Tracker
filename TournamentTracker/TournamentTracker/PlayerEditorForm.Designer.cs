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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerEditorForm));
            btnCancel = new Button();
            btnOption = new Button();
            txtPlayerName = new TextBox();
            txtPosition = new TextBox();
            lbPosition = new Label();
            lbPlayerName = new Label();
            txtAge = new TextBox();
            lbAge = new Label();
            panelOption = new Panel();
            panelEditPlayer = new Panel();
            txtNumber = new TextBox();
            lbNumber = new Label();
            panelOption.SuspendLayout();
            panelEditPlayer.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(35, 38, 39);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            btnCancel.Location = new Point(441, 32);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 48);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOption
            // 
            btnOption.BackColor = Color.FromArgb(35, 38, 39);
            btnOption.Cursor = Cursors.Hand;
            btnOption.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            btnOption.Location = new Point(39, 32);
            btnOption.Margin = new Padding(3, 2, 3, 2);
            btnOption.Name = "btnOption";
            btnOption.Size = new Size(112, 48);
            btnOption.TabIndex = 5;
            btnOption.Text = "Save";
            btnOption.UseVisualStyleBackColor = false;
            btnOption.Click += btnSave_Click;
            // 
            // txtPlayerName
            // 
            txtPlayerName.BackColor = Color.FromArgb(35, 38, 39);
            txtPlayerName.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel, 0);
            txtPlayerName.ForeColor = Color.FromArgb(40, 156, 56);
            txtPlayerName.Location = new Point(230, 25);
            txtPlayerName.Margin = new Padding(3, 2, 3, 2);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(323, 32);
            txtPlayerName.TabIndex = 1;
            // 
            // txtPosition
            // 
            txtPosition.BackColor = Color.FromArgb(35, 38, 39);
            txtPosition.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel, 0);
            txtPosition.ForeColor = Color.FromArgb(40, 156, 56);
            txtPosition.Location = new Point(230, 72);
            txtPosition.Margin = new Padding(3, 2, 3, 2);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(323, 32);
            txtPosition.TabIndex = 2;
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.BackColor = Color.FromArgb(35, 38, 39);
            lbPosition.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbPosition.Location = new Point(39, 74);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(100, 32);
            lbPosition.TabIndex = 0;
            lbPosition.Text = "Position";
            // 
            // lbPlayerName
            // 
            lbPlayerName.AutoSize = true;
            lbPlayerName.BackColor = Color.Transparent;
            lbPlayerName.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbPlayerName.ForeColor = Color.White;
            lbPlayerName.Location = new Point(39, 26);
            lbPlayerName.Name = "lbPlayerName";
            lbPlayerName.Size = new Size(153, 32);
            lbPlayerName.TabIndex = 0;
            lbPlayerName.Text = "Player Name";
            // 
            // txtAge
            // 
            txtAge.BackColor = Color.FromArgb(35, 38, 39);
            txtAge.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel, 0);
            txtAge.ForeColor = Color.FromArgb(40, 156, 56);
            txtAge.Location = new Point(230, 121);
            txtAge.Margin = new Padding(3, 2, 3, 2);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(323, 32);
            txtAge.TabIndex = 3;
            // 
            // lbAge
            // 
            lbAge.AutoSize = true;
            lbAge.BackColor = Color.FromArgb(35, 38, 39);
            lbAge.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbAge.Location = new Point(39, 122);
            lbAge.Name = "lbAge";
            lbAge.Size = new Size(57, 32);
            lbAge.TabIndex = 0;
            lbAge.Text = "Age";
            // 
            // panelOption
            // 
            panelOption.BackColor = Color.Transparent;
            panelOption.Controls.Add(btnOption);
            panelOption.Controls.Add(btnCancel);
            panelOption.ForeColor = Color.FromArgb(40, 156, 56);
            panelOption.Location = new Point(13, 252);
            panelOption.Margin = new Padding(3, 2, 3, 2);
            panelOption.Name = "panelOption";
            panelOption.Size = new Size(601, 100);
            panelOption.TabIndex = 0;
            // 
            // panelEditPlayer
            // 
            panelEditPlayer.BackColor = Color.Transparent;
            panelEditPlayer.Controls.Add(txtNumber);
            panelEditPlayer.Controls.Add(lbNumber);
            panelEditPlayer.Controls.Add(txtPosition);
            panelEditPlayer.Controls.Add(lbPlayerName);
            panelEditPlayer.Controls.Add(txtAge);
            panelEditPlayer.Controls.Add(lbPosition);
            panelEditPlayer.Controls.Add(lbAge);
            panelEditPlayer.Controls.Add(txtPlayerName);
            panelEditPlayer.ForeColor = Color.FromArgb(40, 156, 56);
            panelEditPlayer.Location = new Point(13, 12);
            panelEditPlayer.Margin = new Padding(3, 2, 3, 2);
            panelEditPlayer.Name = "panelEditPlayer";
            panelEditPlayer.Size = new Size(601, 218);
            panelEditPlayer.TabIndex = 0;
            // 
            // txtNumber
            // 
            txtNumber.BackColor = Color.FromArgb(35, 38, 39);
            txtNumber.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel, 0);
            txtNumber.ForeColor = Color.FromArgb(40, 156, 56);
            txtNumber.Location = new Point(230, 170);
            txtNumber.Margin = new Padding(3, 2, 3, 2);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(323, 32);
            txtNumber.TabIndex = 4;
            // 
            // lbNumber
            // 
            lbNumber.AutoSize = true;
            lbNumber.BackColor = Color.FromArgb(35, 38, 39);
            lbNumber.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Pixel, 0);
            lbNumber.Location = new Point(39, 171);
            lbNumber.Name = "lbNumber";
            lbNumber.Size = new Size(103, 32);
            lbNumber.TabIndex = 0;
            lbNumber.Text = "Number";
            // 
            // PlayerEditorForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(35, 38, 39);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(634, 361);
            Controls.Add(panelEditPlayer);
            Controls.Add(panelOption);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Pixel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "PlayerEditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panelOption.ResumeLayout(false);
            panelEditPlayer.ResumeLayout(false);
            panelEditPlayer.PerformLayout();
            ResumeLayout(false);
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
        private Panel panelOption;
        private Panel panelEditPlayer;
        private TextBox txtNumber;
        private Label lbNumber;
    }
}