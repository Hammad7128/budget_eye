using System;
using System.Windows.Forms;

namespace budget_eye
{
    public partial class Form1 : Form
    {
        private Application _app;

        public Form1()
        {
            InitializeComponent();
            _app = new Application();
            lblError.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter both username and password.";
                return;
            }

            string result = _app.Login(username, password);

            if (result == "Invalid credentials")
            {
                lblError.Text = "Invalid entry. Please check your credentials.";
                txtPassword.Clear();
                txtUsername.Focus();
            }
            else
            {
                MainForm main = new MainForm(_app);
                this.Hide();
                main.FormClosed += (s, args) => this.Close();
                main.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtUsername_TextChanged(object sender, EventArgs e) { }

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}