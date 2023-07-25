using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerServerApp.Model
{
    public class WorkoutEntry
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? WorkoutName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? WorkoutEntryId { get; set; }
        [Required]
        public string? Intensity { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal CaloriesBurned { get; set; }
        [Required]
        public Guid? WeightEntryId { get; set; }

        public WeightEntry? WeightEntry { get; set; }

    }
}
