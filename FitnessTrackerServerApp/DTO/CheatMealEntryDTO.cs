using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerServerApp.DTO
{
    public class CheatMealEntryDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? UserName { get; set; }
        public Guid? CheatMealEntryId { get; set; }
        [Required]
        public string? MealName { get; set; }
        [Required]
        public decimal Calories { get; set; }
        public Guid? WeightEntryId { get; set; }
        public WeightEntryDTO? WeightEntry { get; set; }
    }
}
