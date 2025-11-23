namespace TourApp
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
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
            loginPanel.Visible = false;
            registerPanel.Visible = true;
            res_conPassTextBox.Text = "";
            res_passTextBox.Text = "";
            res_usnTextBox.Text = "";
        }

        private void loginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registerPanel.Visible = false;
            loginPanel.Visible = true;
        }

        private void registerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
