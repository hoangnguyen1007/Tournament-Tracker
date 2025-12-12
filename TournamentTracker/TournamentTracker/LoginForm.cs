using TeamListForm;
using TeamListForm.Properties;
namespace TourApp
{
    public partial class LoginForm : Form
    {
        private void Enter_Is_Tab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public LoginForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            res_usnTextBox.KeyDown += Enter_Is_Tab_KeyDown;
            res_passTextBox.KeyDown += Enter_Is_Tab_KeyDown;
            usnTextBox.KeyDown += Enter_Is_Tab_KeyDown;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void resLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registerPanel.Visible = true;
            loginPanel.Visible = false;
            res_conPassTextBox.Text = "";
            res_passTextBox.Text = "";
            res_usnTextBox.Text = "";
        }

        private void loginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginPanel.Visible = true;
            registerPanel.Visible = false;
        }

        private void registerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void res_usnTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private DatabaseHelper db = new DatabaseHelper();
        private void resBtn_Click(object sender, EventArgs e)
        {
            string user = res_usnTextBox.Text.Trim(); 
            if (user.Length < 3)
            {
                MessageBox.Show("username too short!");
                return;
            }
            if (user.Length > 20)
            {
                MessageBox.Show("username too long!");
                return;
            }
            if (res_usnTextBox.Text == "")
            {
                MessageBox.Show("Please enter username!");
                return;
            }
            if (res_passTextBox.Text == "")
            {
                MessageBox.Show("Please enter password!");
                return;
            }
            if (res_passTextBox.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 character long!");
                return;
            }
            if (res_passTextBox.Text != res_conPassTextBox.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match!");
                return;
            }
            if (db.Register(res_usnTextBox.Text, res_passTextBox.Text))
            {
                MessageBox.Show("Register Succesfully!");
                registerPanel.Visible = false;
                loginPanel.Visible = true;
            }
            else
            {
                MessageBox.Show("Register fail or a username has exist!");
            }
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            if (usnTextBox.Text == "")
            {
                MessageBox.Show("Please enter username!");
                return;
            }
            if (passTextBox.Text == "")
            {
                MessageBox.Show("Please enter password!");
                return;
            }
            if (db.Login(usnTextBox.Text, passTextBox.Text))
            {
                TeamListForm.Properties.Settings.Default.SavedUserId = UserSession.CurrentUserId;
                TeamListForm.Properties.Settings.Default.Save();
                Home homeform = new Home();
                homeform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username not exist or wrong password!");
            }
        }

        private void res_conPassTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                resBtn.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void passTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logBtn.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void showBtn1_Click(object sender, EventArgs e)
        {
            if (res_passTextBox.PasswordChar == '*')
            {
                res_passTextBox.PasswordChar = '\0';
            }
            else
            {
                res_passTextBox.PasswordChar = '*';
            }
        }

        private void showBtn2_Click(object sender, EventArgs e)
        {
            if (res_conPassTextBox.PasswordChar == '*')
            {
                res_conPassTextBox.PasswordChar = '\0';
            }
            else
            {
                res_conPassTextBox.PasswordChar = '*';
            }
        }

        private void showBtn3_Click(object sender, EventArgs e)
        {
            if (passTextBox.PasswordChar == '*')
            {
                passTextBox.PasswordChar = '\0';
            }
            else
            {
                passTextBox.PasswordChar = '*';
            }
        }
    }
}
