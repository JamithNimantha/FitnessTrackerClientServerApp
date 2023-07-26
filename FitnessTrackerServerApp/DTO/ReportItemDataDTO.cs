namespace FitnessTrackerServerApp.DTO
{
    [Serializable]
    public class ReportItemDataDTO
    {
        public DateTime Date { get; set; }
        public int Workouts { get; set; }
        public int CheatMeals { get; set; }
        public decimal CaloriesBurned { get; set; }
        public decimal CaloriesGained { get; set; }
        public decimal AverageWeight { get; set; }
    }
}