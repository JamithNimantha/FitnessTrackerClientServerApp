using FitnessTrackerClientApp.Model;
using FitnessTrackerClientApp.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FitnessTrackerClientApp.View
{
    public partial class PredictionForm : UserControl
    {
        private readonly string _userName;
        public PredictionForm(string UserName)
        {
            InitializeComponent();
            _userName = UserName;
            Clear();
        }


        public decimal PredictWeight(List<WeightEntry> weightEntries, List<WorkoutEntry> workouts, List<CheatMealEntry> cheatMeals, DateTime futureDate)
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

        private decimal CalculateAverageWeightChangePerDay(List<WeightEntry> weightEntries)
        {
            // Calculate the average weight change per day based on the recorded weight entries
            decimal totalWeightChange = weightEntries[weightEntries.Count - 1].Weight - weightEntries[0].Weight;
            int totalDays = (int)(weightEntries[weightEntries.Count - 1].Date.Date - weightEntries[0].Date.Date).TotalDays;

            decimal averageWeightChangePerDay = totalWeightChange / totalDays;
            return averageWeightChangePerDay;
        }
        private decimal GetWorkoutWeightAdjustment(List<WorkoutEntry> workouts)
        {
            decimal totalWorkoutAdjustment = 0;
            foreach (var workout in workouts)
            {
                // If the workout intensity is "High", add 0.5 kg to the weight
                if (workout.Intensity == "Intense" )
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

        private decimal GetCheatMealWeightAdjustment(List<CheatMealEntry> cheatMeals)
        {
            decimal totalCheatMealAdjustment = 0;
            foreach (var cheatMeal in cheatMeals)
            {
                // If the cheat meal calories are above 500, add 0.2 kg to the weight
                if (cheatMeal.Calories > 500)
                {
                    totalCheatMealAdjustment += (decimal) 0.2;
                }
            }

            return totalCheatMealAdjustment;
        }



        public string PredictFitnessStatus(List<WorkoutEntry> workouts)
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

        private bool IsProgressing(List<WorkoutEntry> workouts)
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

        private bool IsConsistent(List<WorkoutEntry> workouts)
        {
            // Check if there is consistent frequency of workouts
            return workouts.Count >= 3; // At least 3 workouts per week considered consistent
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbltotalCaloriesGained_Click(object sender, EventArgs e)
        {

        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
           /* List<WorkoutEntry> workoutEntries = WorkoutService.Instance.FindWorkoutsInAscByUserName(_userName);
            List<WeightEntry> weightEntries = WeightEntryService.Instance.FindWeightEntriesInDescByUserName(_userName);
            List<CheatMealEntry> cheatMealEntries = CheatMealService.Instance.FindCheatMealEntriesInDescByUserName(_userName);

            DateTime futureDate = datePicker.Value.Date;

            decimal predictedWeight = PredictWeight(weightEntries, workoutEntries, cheatMealEntries, futureDate);
            string predictedFitnessStatus = PredictFitnessStatus(workoutEntries);

            lblWeight.Text = "Predicted Weight: " + predictedWeight.ToString("0.00") + " KG";
            lblStatus.Text = "Predicted Fitness Status : " + predictedFitnessStatus;*/
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        { 
            lblStatus.Text = "Predicted Fitness Status :";
            lblWeight.Text = "Predicted Weight (KG) :";
            datePicker.MinDate = DateTime.Today.Add(TimeSpan.FromDays(1));
            datePicker.Value = DateTime.Today.Add(TimeSpan.FromDays(1));

        }
    }
}
