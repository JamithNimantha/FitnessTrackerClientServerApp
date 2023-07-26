using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using FitnessTrackerClientApp.DTO;
using FitnessTrackerClientApp.Exceptions;

namespace FitnessTrackerClientApp.Service
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

       /* public List<WorkoutEntryDTO> FindWorkoutsInAscByUserName(string UserName)
        {
            return GetWorkouts()
                .Where(obj => obj.UserName.Equals(UserName))
                .OrderBy(obj => obj.Date)
                .ToList();
        }*/

        public List<WorkoutEntryDTO> FindWorkoutsInDescByUserName(string UserName)
        {

            var client = new RestClient(RestClient.BaseUrl + RestClient.WorkoutUrl, RestClient.BearerToken);
            var records = client.FetchData<List<WorkoutEntryDTO>>();

            return records;
        }

        /*public WorkoutEntryDTO FindLatestWorkoutForUser(string UserName)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.WorkoutUrl, RestClient.BearerToken);
            var records = client.FetchData<List<WorkoutEntryDTO>>();

            return records;

            return workoutEntries.Where(obj => obj.UserName.Equals(UserName)).OrderByDescending(obj => obj.Date).First();
        }*/

      

        public WorkoutEntryDTO GetWorkoutByGUID(string GUID)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.WorkoutUrl + "/" + GUID, RestClient.BearerToken);
            return client.FetchData<WorkoutEntryDTO>();
        }

       /* public List<WorkoutEntry> GetWorkouts()
        {
            return DataStorage.LoadData<WorkoutEntry>();
        }*/


        public void DeleteWorkoutByGUID(string GUID)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.WorkoutUrl + "/" + GUID, RestClient.BearerToken);
            client.Delete<WorkoutEntryDTO>();

        }

        public void AddWorkout(WorkoutEntryDTO Workout)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.WorkoutUrl, RestClient.BearerToken);
            client.PostData<WorkoutEntryDTO>(Workout);
        }

        public void UpdateWorkout(WorkoutEntryDTO Workout)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.WorkoutUrl  +"/" + Workout.WorkoutEntryId, RestClient.BearerToken);
            client.PutData<WorkoutEntryDTO>(Workout);

        }
    }
}
