using System;

namespace FitnessTrackerClientApp.Model
{
    public class WeightEntry
    {

        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public string UserName { get; set; }
        public string GUID { get; set; }
    }
}
