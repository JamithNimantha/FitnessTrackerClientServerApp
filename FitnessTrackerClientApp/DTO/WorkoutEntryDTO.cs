using System;

namespace FitnessTrackerClientApp.DTO
{
    [Serializable]
    public class WorkoutEntryDTO
    {
        public DateTime Date { get; set; }
        public string WorkoutName { get; set; }
        public string UserName { get; set; }
        public string WorkoutEntryId { get; set; }
        public string Intensity { get; set; }
        public decimal CaloriesBurned { get; set; }
        public string WeightEntryId { get; set; }

        public WeightEntryDTO WeightEntry { get; set; }

    }
}
