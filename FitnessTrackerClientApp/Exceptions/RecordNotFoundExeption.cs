using System;

namespace FitnessTrackerClientApp.Exceptions
{
    public class RecordNotFoundExeption : Exception
    {
        public RecordNotFoundExeption(string userName)
            : base($"Record for '{userName}' not found.")
        {
        }

        public RecordNotFoundExeption(string userName, Exception innerException)
            : base($"Record for '{userName}' not found.", innerException)
        {
        }
    }
}
