using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerServerApp.DTO
{
    [Serializable]

    public class WeightEntryDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public string? UserName { get; set; }
        public Guid? WeightEntryId { get; set; }
    }
}
