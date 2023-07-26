using System;

namespace FitnessTrackerClientApp.DTO
{
    [Serializable]

    public class WeightEntryDTO
    {
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public string UserName { get; set; }
        public String WeightEntryId { get; set; }
    }
}
