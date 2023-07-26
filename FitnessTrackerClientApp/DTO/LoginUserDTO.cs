using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerClientApp.DTO
{
    [Serializable]
    public class LoginUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
