using FitnessTrackerClientApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace FitnessTrackerClientApp.Service
{
    public class CheatMealService
    {
        private static CheatMealService instance;

        private static readonly object lockObject = new object();

        public static CheatMealService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new CheatMealService();
                        }
                    }
                }
                return instance;
            }
        }

       /* public List<CheatMealEntryDTO> GetCheatMeals()
        {
            return DataStorage.LoadData<CheatMealEntry>();
        }*/

       /* public bool CheckIfWeightEntryExistsInCheatMeal(string GUID)
        {
            CheatMealEntry cheatMealEntry = GetCheatMeals().FirstOrDefault(obj => obj.WeightEntryGUID.Equals(GUID));
            if (cheatMealEntry != null)
            {
                return true;
            }
            return false;
        }*/

       /* public CheatMealEntryDTO GetCheatMealEntryByGUID(List<CheatMealEntry> CheatMealEntries, string GUID)
        {
            return CheatMealEntries.FirstOrDefault(obj => obj.GUID.Equals(GUID));
        }*/

        public CheatMealEntryDTO GetCheatMealEntryByGUID(string GUID)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.CheatMealUrl + "/" + GUID, RestClient.BearerToken);
            return client.FetchData<CheatMealEntryDTO>();
        }

        /*public List<CheatMealEntryDTO> FindCheatMealEntriesInAscByUserName(string UserName)
        {
            return GetCheatMeals()
                .Where(obj => obj.UserName.Equals(UserName))
                .OrderBy(obj => obj.Date)
                .ToList();
        }*/

        public List<CheatMealEntryDTO> FindCheatMealEntriesInDescByUserName(string UserName)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.CheatMealUrl, RestClient.BearerToken);
            return client.FetchData<List<CheatMealEntryDTO>>();
        }

        /*public CheatMealEntry FindLatestCheatMealEntryForUser(string UserName)
        {
            List<CheatMealEntry> cheatMealEntries = GetCheatMeals();
            if (cheatMealEntries.Count == 0)
            {
                return new CheatMealEntry();
            }

            return cheatMealEntries.Where(obj => obj.UserName.Equals(UserName)).OrderByDescending(obj => obj.Date).First();
        }*/

        public void DeleteCheatMealEntryByGUID(string GUID)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.CheatMealUrl + "/" + GUID, RestClient.BearerToken);
            client.Delete<CheatMealEntryDTO>();
        }

        public void AddCheatMealEntry(CheatMealEntryDTO cheatMealEntry)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.CheatMealUrl, RestClient.BearerToken);
            client.PostData<CheatMealEntryDTO>(cheatMealEntry);
        }

        public void UpdateCheatMealEntry(CheatMealEntryDTO cheatMealEntry)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.CheatMealUrl + "/" + cheatMealEntry.CheatMealEntryId, RestClient.BearerToken);
            client.PutData<CheatMealEntryDTO>(cheatMealEntry);
        }

    }
}
