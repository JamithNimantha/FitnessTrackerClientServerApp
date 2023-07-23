using FitnessTrackerServerApp.Enumeration;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitnessTrackerServerApp.DTO
{
    [Serializable]
    public class UserDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string? UserName { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public decimal Height { get; set; }
        
    }
}
