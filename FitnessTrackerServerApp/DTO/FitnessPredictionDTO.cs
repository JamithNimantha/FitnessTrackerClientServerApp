using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerServerApp.DTO
{
    [Serializable]
    public class FitnessPredictionDTO
    {
        [Required]
        public DateTime Date { get; set; }
        public decimal PredictedWeight { get; set; }
        public string? PredictedFitnessStatus { get; set; }
    }
}
