/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTrackerApp.Exceptions;
using FitnessTrackerApp.Model;

namespace FitnessTrackerApp.Service
{
    public class WorkoutService
    {
        private static readonly object lockObject = new object();
        private static WorkoutService instance;

        public static WorkoutService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new WorkoutService();
                        }
                    }
                }
                return instance;
            }
        }   

        public List<WorkoutEntry> FindWorkoutsInAscByUserName(string UserName)
        {
            return GetWorkouts()
                .Where(obj => obj.UserName.Equals(UserName))
                .OrderBy(obj => obj.Date)
                .ToList();
        }

        public List<WorkoutEntry> FindWorkoutsInDescByUserName(string UserName)
        {

            return GetWorkouts()
                .Where(obj => obj.UserName.Equals(UserName))
                .OrderByDescending(obj => obj.Date)
                .ToList();
        }

        public WorkoutEntry FindLatestWorkoutForUser(string UserName)
        {
            List<WorkoutEntry> workoutEntries = GetWorkouts();
            if (workoutEntries.Count == 0)
            {
                return new WorkoutEntry();
            }

            return workoutEntries.Where(obj => obj.UserName.Equals(UserName)).OrderByDescending(obj => obj.Date).First();
        }

        public WorkoutEntry GetWorkoutByGUID(List<WorkoutEntry> Workouts, string GUID)
        {
            return Workouts.FirstOrDefault(obj => obj.GUID.Equals(GUID));
        }

        public WorkoutEntry GetWorkoutByGUID(string GUID)
        {
            return GetWorkouts().FirstOrDefault(obj => obj.GUID.Equals(GUID));
        }

        public List<WorkoutEntry> GetWorkouts()
        {
            return DataStorage.LoadData<WorkoutEntry>();
        }


        public void DeleteWorkoutByGUID(string GUID)
        {
            List<WorkoutEntry> Workouts = GetWorkouts();
            var ExistingWorkout = GetWorkoutByGUID(Workouts, GUID);
            if (ExistingWorkout != null)
            {
                WeightEntryService.Instance.DeleteEntry(ExistingWorkout.WeightEntryGUID);
                Workouts.Remove(ExistingWorkout);
                DataStorage.SaveData(Workouts);
            } else
            {
                throw new RecordNotFoundExeption(GUID);
            }
           
        }

        public void AddWorkout(WorkoutEntry Workout, WeightEntry WeightEntry)
        {
            List<WorkoutEntry> Workouts = GetWorkouts();
            WeightEntry = WeightEntryService.Instance.AddEntry(WeightEntry);

            Workouts.Add(Workout);
            Workout.GUID = Guid.NewGuid().ToString();
            Workout.WeightEntryGUID = WeightEntry.GUID;
            DataStorage.SaveData(Workouts);
        }

        public void UpdateWorkout(WorkoutEntry Workout, WeightEntry WeightEntry)
        {
            List<WorkoutEntry> Workouts = GetWorkouts();
            var ExistingWorkout = GetWorkoutByGUID(Workouts, Workout.GUID);
            if (ExistingWorkout != null)
            {
                ExistingWorkout.WorkoutName = Workout.WorkoutName;
                ExistingWorkout.Date = Workout.Date;
                ExistingWorkout.Intensity = Workout.Intensity;
                ExistingWorkout.CaloriesBurned = Workout.CaloriesBurned;
                
                WeightEntryService.Instance.UpdateEntry(WeightEntry, Workout.WeightEntryGUID);
                DataStorage.SaveData(Workouts);
            }
            else
            {
                throw new RecordNotFoundExeption(Workout.GUID);
            }
            
        }

        public bool CheckIfWeightEntryExistsInWorkout(string GUID)
        {            
            var ExistingWorkout = GetWorkouts().FirstOrDefault(obj => obj.WeightEntryGUID.Equals(GUID));
            if (ExistingWorkout != null)
            {
                return true;
            }
            return false;
        }
    }
}
*/