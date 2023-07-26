using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerServerApp.DTO
{
    [Serializable]
    public class WorkoutEntryDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? WorkoutName { get; set; }
        [Required]
        public string? UserName { get; set; }
        public Guid? WorkoutEntryId { get; set; }
        [Required]
        public string? Intensity { get; set; }
        [Required]
        public decimal CaloriesBurned { get; set; }
        public Guid? WeightEntryId { get; set; }

        public WeightEntryDTO? WeightEntry { get; set; }

    }
}
