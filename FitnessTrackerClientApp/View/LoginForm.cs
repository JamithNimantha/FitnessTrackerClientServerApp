using FitnessTrackerApp.Service;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        public LoginForm()
        {
            InitializeComponent();
            _userService = UserService.Instance;
        }

        private void usernameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void passwordField_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string _UserName = usernameField.Text.Trim();
            string _Password = passwordField.Text.Trim();

            if (string.IsNullOrEmpty(_UserName))
            {
                MessageBox.Show("Please Enter UserName!");
                return;
            }

            if (string.IsNullOrEmpty(_Password))
            {
                MessageBox.Show("Please Enter PassWord!");
                return;
            }

            if (_userService.Authenticate(_UserName, _Password))
            {
                this.Hide();
                var mainForm = new MainForm(_UserName);
                mainForm.Location = this.Location;
                mainForm.StartPosition = FormStartPosition.Manual;
                mainForm.FormClosing += delegate { Application.Exit(); };
                mainForm.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please provide valid credentials!");
                return;
            }

        }

        private void lblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var signUpForm = new SignUpForm();
            signUpForm.Location = this.Location;
            signUpForm.StartPosition = FormStartPosition.Manual;
            signUpForm.FormClosing += delegate { this.Show(); };
            signUpForm.Show();
            this.Hide();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
