using System;

namespace FitnessTrackerClientApp.Model
{
    public class CheatMealEntry
    {
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string GUID { get; set; }
        public string MealName { get; set; }
        public decimal Calories { get; set; }
        public string WeightEntryGUID { get; set; }
    }
}
