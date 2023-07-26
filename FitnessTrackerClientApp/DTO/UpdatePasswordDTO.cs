using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerClientApp.DTO
{
    [Serializable]
    public class UpdatePasswordDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
