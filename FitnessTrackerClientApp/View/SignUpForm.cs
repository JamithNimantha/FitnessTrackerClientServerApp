using FitnessTrackerApp.Enumeration;
using FitnessTrackerApp.Exceptions;
using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using FitnessTrackerApp.Utility;
using System;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
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


            var User = new User();
            var WeightEntry = new WeightEntry();

            // assign all the declared values to User object
            User.Name = Name;
            User.UserName = UserName;
            User.Password = PasswordManager.GetSaltedHash(Password);
            User.Height = Height;
            User.DateofBirth = DOB;
            User.Gender = Gender;
            WeightEntry.Weight = Weight;
            WeightEntry.Date = DateTime.Now;
            WeightEntry.UserName = UserName;

            try
            {
                UserService.Instance.AddUser(User);
                WeightEntryService.Instance.AddEntry(WeightEntry);
                MessageBox.Show("User Sign Up Successfully!");
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.Location = this.Location;
                loginForm.StartPosition = FormStartPosition.Manual;
                loginForm.FormClosing += delegate { Application.Exit(); };
                loginForm.ShowDialog();
                this.Dispose();
            }
            catch (UserNameAlreadyExistsExeption ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
