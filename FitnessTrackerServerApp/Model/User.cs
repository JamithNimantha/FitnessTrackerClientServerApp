
using FitnessTrackerServerApp.Enumeration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerServerApp.Model
{
    [Table("User")]
    public class User
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Key]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(4,2)")]
        public decimal Height { get; set; }

    }
}
