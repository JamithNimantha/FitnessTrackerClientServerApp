using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerApp.Model
{
    public class CheatMealEntry
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? CheatMealEntryId { get; set; }
        [Required]
        public string? MealName { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal Calories { get; set; }
        [Required]
        public Guid? WeightEntryId { get; set; }
        [Required]
        public WeightEntry? WeightEntry { get; set; }
    }
}
