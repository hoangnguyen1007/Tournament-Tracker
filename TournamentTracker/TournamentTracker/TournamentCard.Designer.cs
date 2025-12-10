namespace TeamListForm
{
    partial class TournamentCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSport = new Label();
            lblParticipants = new Label();
            lblStartDate = new Label();
            lblPrize = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(380, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // lblSport
            // 
            lblSport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSport.BackColor = Color.Transparent;
            lblSport.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSport.ForeColor = Color.Goldenrod;
            lblSport.Location = new Point(0, 48);
            lblSport.Name = "lblSport";
            lblSport.Size = new Size(380, 38);
            lblSport.TabIndex = 1;
            lblSport.Text = "label1";
            lblSport.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblParticipants
            // 
            lblParticipants.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblParticipants.BackColor = Color.Transparent;
            lblParticipants.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblParticipants.ForeColor = Color.Silver;
            lblParticipants.Location = new Point(3, 86);
            lblParticipants.Name = "lblParticipants";
            lblParticipants.Size = new Size(380, 35);
            lblParticipants.TabIndex = 2;
            lblParticipants.Text = "lblParticipants";
            lblParticipants.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStartDate
            // 
            lblStartDate.BackColor = Color.Transparent;
            lblStartDate.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStartDate.ForeColor = Color.Orange;
            lblStartDate.Location = new Point(186, 174);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(183, 28);
            lblStartDate.TabIndex = 3;
            lblStartDate.Text = "label1";
            lblStartDate.TextAlign = ContentAlignment.TopRight;
            lblStartDate.Click += lblStartDate_Click;
            // 
            // lblPrize
            // 
            lblPrize.BackColor = Color.Transparent;
            lblPrize.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPrize.ForeColor = Color.Yellow;
            lblPrize.Location = new Point(0, 177);
            lblPrize.Name = "lblPrize";
            lblPrize.Size = new Size(191, 25);
            lblPrize.TabIndex = 4;
            lblPrize.Text = "lblPrize";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LawnGreen;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(370, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 172);
            panel1.TabIndex = 5;
            // 
            // TournamentCard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(45, 45, 45);
            Controls.Add(panel1);
            Controls.Add(lblPrize);
            Controls.Add(lblStartDate);
            Controls.Add(lblParticipants);
            Controls.Add(lblSport);
            Controls.Add(lblTitle);
            Name = "TournamentCard";
            Size = new Size(380, 220);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblSport;
        private Label lblParticipants;
        private Label lblStartDate;
        private Label lblPrize;
        private Panel panel1;
    }
}
