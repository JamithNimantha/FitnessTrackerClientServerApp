using FitnessTrackerServerApp.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerServerApp.Service
{
    public class ReportService : IReportService
    {
        private readonly IWeightEntryService weightEntryService;
        private readonly IWorkoutEntryService workoutEntryService;
        private readonly ICheatMealEntryService cheatMealEntryService;

        public ReportService(IWeightEntryService weightEntryService, IWorkoutEntryService workoutEntryService, ICheatMealEntryService cheatMealEntryService)
        {
            this.weightEntryService = weightEntryService;
            this.workoutEntryService = workoutEntryService;
            this.cheatMealEntryService = cheatMealEntryService;
        }

        public async Task<ActionResult<ReportDataDTO>> GenerateReport(string UserName, ReportDataDTO ReportData)
        {

            var weights = await weightEntryService.GetAllByUsername(UserName);
            var workouts = await workoutEntryService.GetAllByUsername(UserName);
            var cheatMeals = await cheatMealEntryService.GetAllByUsername(UserName);


            List<WorkoutEntryDTO> workoutEntries = workouts.Value.Where(w => w.Date >= ReportData.StartDate && w.Date <= ReportData.EndDate).ToList();
            List<CheatMealEntryDTO> cheatMealEntries = cheatMeals.Value.Where(w => w.Date >= ReportData.StartDate && w.Date <= ReportData.EndDate).ToList();
            List<WeightEntryDTO> weightEntries = weights.Value.Where(w => w.Date >= ReportData.StartDate && w.Date <= ReportData.EndDate).ToList();

            ReportData.TotolCaloriesBurned = workoutEntries.Sum(w => w.CaloriesBurned);
            ReportData.TotalCaloriesGained = cheatMealEntries.Sum(c => c.Calories);
            ReportData.AverageWeight = weightEntries.Average(w => w.Weight);

            ReportData.ReportItemData = weightEntries
                .GroupBy(w => w.Date.Date)
                .Select(w => 
                {
                    var record = new ReportItemDataDTO()
                    {
                        Date = w.Key,
                        Workouts = workoutEntries.Where(c => c.Date.Date == w.Key).Count(),
                        CheatMeals = cheatMealEntries.Where(c => c.Date.Date == w.Key).Count(),
                        CaloriesBurned = workoutEntries.Where(c => c.Date.Date == w.Key).Sum(c => c.CaloriesBurned),
                        CaloriesGained = cheatMealEntries.Where(c => c.Date.Date == w.Key).Sum(c => c.Calories),
                        AverageWeight = weightEntries.Where(c => c.Date.Date == w.Key).Average(c => c.Weight)
                    };
                    return record;
                }).ToList();

            return ReportData;

        }

        public async Task<ActionResult<List<WeightEntryDTO>>> GetLast20WeightEntries(string UserName)
        {

            var actionResult = await weightEntryService.GetAllByUsername(UserName);

            var filteredWeightEntries = actionResult.Value.GroupBy(entry => entry.Date.Date)
                                                    .Select(group => group.First())
                                                    .ToList();

            int startIndex = Math.Max(filteredWeightEntries.Count - 20, 0);
            var last20WeightEntries = filteredWeightEntries.GetRange(startIndex, Math.Min(20, filteredWeightEntries.Count - startIndex));

            return filteredWeightEntries;


        }


        public async Task<ActionResult<FitnessPredictionDTO>> PredictFitness(string UserName, FitnessPredictionDTO FitnessPredictionDTO)
        {
            
            var weightEntries = await weightEntryService.GetAllByUsername(UserName);
            var workouts = await workoutEntryService.GetAllByUsername(UserName);
            var cheatMeals = await cheatMealEntryService.GetAllByUsername(UserName);

            FitnessPredictionDTO.PredictedWeight = PredictWeight(weightEntries.Value.ToList(), workouts.Value.ToList(), cheatMeals.Value.ToList(), FitnessPredictionDTO.Date);
            FitnessPredictionDTO.PredictedFitnessStatus = PredictFitnessStatus(workouts.Value.ToList());

            return FitnessPredictionDTO;
        }

        public decimal PredictWeight(List<WeightEntryDTO> weightEntries, List<WorkoutEntryDTO> workouts, List<CheatMealEntryDTO> cheatMeals, DateTime futureDate)
        {
            // Calculate average weight change per day
            decimal averageWeightChangePerDay = CalculateAverageWeightChangePerDay(weightEntries);

            // Calculate the number of days between the latest weight entry and the future date
            int daysDifference = (int)(futureDate.Date - weightEntries[weightEntries.Count - 1].Date.Date).TotalDays;

            // Predict weight for the future date
            decimal predictedWeight = weightEntries[weightEntries.Count - 1].Weight + (averageWeightChangePerDay * daysDifference);

            // Adjust predicted weight based on workout patterns
            decimal workoutAdjustment = GetWorkoutWeightAdjustment(workouts);
            predictedWeight += workoutAdjustment;

            // Adjust predicted weight based on cheat meals
            decimal cheatMealAdjustment = GetCheatMealWeightAdjustment(cheatMeals);
            predictedWeight += cheatMealAdjustment;

            return predictedWeight;
        }

        private decimal CalculateAverageWeightChangePerDay(List<WeightEntryDTO> weightEntries)
        {
            // Calculate the average weight change per day based on the recorded weight entries
            decimal totalWeightChange = weightEntries[weightEntries.Count - 1].Weight - weightEntries[0].Weight;
            int totalDays = (int)(weightEntries[weightEntries.Count - 1].Date.Date - weightEntries[0].Date.Date).TotalDays;

            decimal averageWeightChangePerDay = totalWeightChange / totalDays;
            return averageWeightChangePerDay;
        }

        private decimal GetWorkoutWeightAdjustment(List<WorkoutEntryDTO> workouts)
        {
            decimal totalWorkoutAdjustment = 0;
            foreach (var workout in workouts)
            {
                // If the workout intensity is "High", add 0.5 kg to the weight
                if (workout.Intensity == "Intense")
                {
                    totalWorkoutAdjustment += (decimal)0.5;
                }

                if (workout.Intensity == "High")
                {
                    totalWorkoutAdjustment += (decimal)0.3;
                }

                if (workout.Intensity == "Medium")
                {
                    totalWorkoutAdjustment += (decimal)0.1;
                }

                if (workout.Intensity == "Low")
                {
                    totalWorkoutAdjustment += (decimal)0.0;
                }
            }

            return totalWorkoutAdjustment;
        }

        private decimal GetCheatMealWeightAdjustment(List<CheatMealEntryDTO> cheatMeals)
        {
            decimal totalCheatMealAdjustment = 0;
            foreach (var cheatMeal in cheatMeals)
            {
                // If the cheat meal calories are above 500, add 0.2 kg to the weight
                if (cheatMeal.Calories > 500)
                {
                    totalCheatMealAdjustment += (decimal)0.2;
                }
            }

            return totalCheatMealAdjustment;
        }



        public string PredictFitnessStatus(List<WorkoutEntryDTO> workouts)
        {
            // Calculate average intensity
            double totalIntensity = 0;
            foreach (var workout in workouts)
            {
                totalIntensity += GetIntensityValue(workout.Intensity);
            }
            double averageIntensity = totalIntensity / workouts.Count;

            // Assess progression
            bool isProgressing = IsProgressing(workouts);

            // Evaluate frequency
            bool isConsistent = IsConsistent(workouts);

            // Determine fitness status based on criteria
            if (averageIntensity >= 0.8 && isProgressing && isConsistent)
            {
                return "Excellent";
            }
            else if (averageIntensity >= 0.6 && isProgressing && isConsistent)
            {
                return "Good";
            }
            else if (averageIntensity >= 0.4 && isConsistent)
            {
                return "Average";
            }
            else
            {
                return "Poor";
            }
        }

        private double GetIntensityValue(string intensity)
        {
            switch (intensity)
            {
                case "Low":
                    return 0.2;
                case "Moderate":
                    return 0.4;
                case "High":
                    return 0.6;
                case "Intense":
                    return 0.8;
                default:
                    return 0;
            }
        }

        private bool IsProgressing(List<WorkoutEntryDTO> workouts)
        {
            // Check if there is a progression in workout intensity or duration over time
            for (int i = 1; i < workouts.Count; i++)
            {
                if (GetIntensityValue(workouts[i].Intensity) > GetIntensityValue(workouts[i - 1].Intensity))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsConsistent(List<WorkoutEntryDTO> workouts)
        {
            // Check if there is consistent frequency of workouts
            return workouts.Count >= 3; // At least 3 workouts per week considered consistent
        }
    }
}
