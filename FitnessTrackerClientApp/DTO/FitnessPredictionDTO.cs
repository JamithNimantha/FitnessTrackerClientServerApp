using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerClientApp.DTO
{
    [Serializable]
    public class FitnessPredictionDTO
    {
        public DateTime Date { get; set; }
        public decimal PredictedWeight { get; set; }
        public string PredictedFitnessStatus { get; set; }
    }
}
