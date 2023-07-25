using System;

namespace FitnessTrackerClientApp.Exceptions
{
    public class UserNameNotFoundException : Exception
    {
        public UserNameNotFoundException(string userName)
            : base($"Username '{userName}' not found.")
        {
        }

        public UserNameNotFoundException(string userName, Exception innerException)
            : base($"Username '{userName}' not found.", innerException)
        {
        }
    }
}
