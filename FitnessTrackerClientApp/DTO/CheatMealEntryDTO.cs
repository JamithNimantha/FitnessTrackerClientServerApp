using System;

namespace FitnessTrackerClientApp.DTO
{
    [Serializable]
    public class CheatMealEntryDTO
    {
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public Guid CheatMealEntryId { get; set; }
        public string MealName { get; set; }
        public decimal Calories { get; set; }
        public Guid WeightEntryId { get; set; }
        public WeightEntryDTO WeightEntry { get; set; }
    }
}
