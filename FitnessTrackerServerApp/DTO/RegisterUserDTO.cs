using FitnessTrackerServerApp.Enumeration;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitnessTrackerServerApp.DTO
{
    [Serializable]
    public class RegisterUserDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public decimal Height { get; set; }
        public decimal Weight { get; set; }

        
    }
}
