using FitnessTrackerClientApp.Enumeration;
using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerClientApp.DTO
{
    [Serializable]
    public class RegisterUserDTO
    {
        public string Name { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public decimal Height { get; set; }
        public decimal Weight { get; set; }

        
    }
}
