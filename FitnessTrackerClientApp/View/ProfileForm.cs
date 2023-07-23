using FitnessTrackerApp.Service;
using FitnessTrackerApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using FitnessTrackerApp.Enumeration;
using FitnessTrackerApp.Utility;
using FitnessTrackerApp.Exceptions;

namespace FitnessTrackerApp.View
{
    public partial class ProfileForm : UserControl
    {
        private readonly string _userName;
        private User User;
        public ProfileForm(string UserName)
        {
            _userName = UserName;
            InitializeComponent();
            LoadDate();
        }

        private void lblSep_Click(object sender, EventArgs e)
        {

        }

        private void LoadDate()
        { 
            this.User = UserService.Instance.FindUserByUserName(_userName);
            this.txtUserName.Text = User.UserName;
            this.txtUserName.Enabled = false;
            this.txtName.Text = User.Name;
            this.txtHeight.Text = User.Height.ToString();
            this.datePickerDOB.Value = User.DateofBirth;
            this.cmbGender.SelectedItem = User.Gender;
            this.txtPassword.Text = "";
            this.txtConfirmPassword.Text = "";
           
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string Name = this.txtName.Text;
            decimal Height = Convert.ToDecimal(this.txtHeight.Text);
            Gender Gender = (Gender)cmbGender.SelectedItem;
            DateTime DOB = datePickerDOB.Value.Date;

            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Please Enter Name!");
                return;
            }

            if (Height <= 0)
            {
                MessageBox.Show("Please Enter Height!");
                return;
            }

            if (DOB >= DateTime.Now)
            {
                MessageBox.Show("Please Enter Valid Date of Birth!");
                return;
            }


            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Please Enter Name!");
                return;
            }

            try
            {
                User.Name = Name;
                User.Height = Height;
                User.Gender = Gender;
                User.DateofBirth = DOB;
                UserService.Instance.UpdateUser(User);
                MessageBox.Show("User Profile Details Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string Password = txtPassword.Text;
            string ConfirmPassword = txtConfirmPassword.Text;

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
            else
            {
                User.Password = PasswordManager.GetSaltedHash(Password);
                UserService.Instance.UpdateUser(User);
                LoadDate();
                MessageBox.Show("Password Updated!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadDate();
        }
    }
}
