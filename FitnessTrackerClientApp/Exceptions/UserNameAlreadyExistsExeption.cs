using System;

namespace FitnessTrackerClientApp.Exceptions
{
    public class UserNameAlreadyExistsExeption : Exception
    {
        public UserNameAlreadyExistsExeption(string userName)
            : base($"Username '{userName}' already exists.")
        {
        }

        public UserNameAlreadyExistsExeption(string userName, Exception innerException)
            : base($"Username '{userName}' already exists.", innerException)
        {
        }
    }
}
