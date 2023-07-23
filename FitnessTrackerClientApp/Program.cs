using System;
using System.Windows.Forms;
using FitnessTrackerApp.View;
using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using FitnessTrackerApp.Utility;
using FitnessTrackerApp.Exceptions;

namespace FitnessTrackerApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //InitializeData();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        static void InitializeData()
        {
            try
            {
                var UserDetail = new User
                {
                    Name = "Jamith Nimantha",
                    Gender = Enumeration.Gender.MALE,
                    UserName = "jamith",
                    Password = PasswordManager.GetSaltedHash("1234"),
                    Height = 183,
                    DateofBirth = new DateTime(1998, 04, 19),
                };
                UserService.Instance.AddUser(UserDetail);
            }
            catch (UserNameAlreadyExistsExeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        
        }
    }
}
