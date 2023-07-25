using FitnessTrackerClientApp.Service;
using System;
using System.Windows.Forms;
using FitnessTrackerClientApp.Enumeration;
using FitnessTrackerClientApp.DTO;
using FitnessTrackerClientApp.Exceptions;

namespace FitnessTrackerClientApp.View
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }


        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text.Trim();
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();
            string ConfirmPassword = txtConfirmPassword.Text.Trim();
            Gender Gender = (Gender)cmbGender.SelectedItem;
            decimal Weight = Convert.ToDecimal(txtWeight.Text.Trim());
            decimal Height = Convert.ToDecimal(txtHeight.Text.Trim());
            DateTime DOB = datePickerDOB.Value.Date;

            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Please Enter Name!");
                return;
            }

            if (string.IsNullOrEmpty(UserName))
            {
                MessageBox.Show("Please Enter UserName!");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please Enter PassWord!");
                return;
            }

            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                MessageBox.Show("Please Enter Confirm PassWord!");
                return;
            }

            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Password and Confirm Password does not match!");
                return;
            }

            // validate weight

            if (Weight <= 0)
            {
                MessageBox.Show("Please Enter Valid Weight!");
                return;
            }

            // validate height

            if (Height <= 0)
            {
                MessageBox.Show("Please Enter Valid Height!");
                return;
            }

            if (DOB >= DateTime.Now)
            {
                MessageBox.Show("Please Enter Valid Date of Birth!");
                return;
            }


            var User = new RegisterUserDTO();
            // assign all the declared values to User object
            User.Name = Name;
            User.UserName = UserName;
            User.Password = Password;
            User.ConfirmPassword = ConfirmPassword;
            User.Height = Height;
            User.DateofBirth = DOB;
            User.Gender = Gender;
            User.Weight = Weight;

            try
            {
                UserService.Instance.AddUser(User);
                MessageBox.Show("User Sign Up Successfully!");
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.Location = this.Location;
                loginForm.StartPosition = FormStartPosition.Manual;
                loginForm.FormClosing += delegate { Application.Exit(); };
                loginForm.ShowDialog();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
