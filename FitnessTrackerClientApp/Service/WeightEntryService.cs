using System.Collections.Generic;
using System.Linq;
using FitnessTrackerClientApp.DTO;

namespace FitnessTrackerClientApp.Service
{
    public class WeightEntryService
    {
        private static WeightEntryService instance;
        private static readonly object lockObject = new object();

        public static WeightEntryService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new WeightEntryService();
                        }
                    }
                }
                return instance;
            }
        }

        public List<WeightEntryDTO> FindWeightEntriesInAscByUserName(string UserName)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.LatestWeightEntriesUrl, RestClient.BearerToken);
            return client.FetchData<List<WeightEntryDTO>>();
        }

        public List<WeightEntryDTO> FindWeightEntriesInDescByUserName(string UserName)
        {

            var client = new RestClient(RestClient.BaseUrl + RestClient.WeightUrl, RestClient.BearerToken);
            return client.FetchData<List<WeightEntryDTO>>();
        }

        public WeightEntryDTO FindLatestWeightEntryForUser(string UserName)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.WeightUrl, RestClient.BearerToken);
            return client.FetchData<List<WeightEntryDTO>>().OrderByDescending(obj => obj.Date).First();
        }

       /* public WeightEntry GetWeightEntryByGUID(List<WeightEntry> WeightEntries, string GUID)
        {
            return WeightEntries.FirstOrDefault(obj => obj.GUID.Equals(GUID));
        }*/

        public WeightEntryDTO AddEntry(WeightEntryDTO WeightEntry)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.WeightUrl, RestClient.BearerToken);
            return client.PostData<WeightEntryDTO>(WeightEntry);
        }

        public void DeleteEntry(string GUID)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.WeightUrl + "/" + GUID, RestClient.BearerToken);
            client.Delete<WeightEntryDTO>();

        }

        public void UpdateEntry(WeightEntryDTO Entry, string GUID)
        {
            var client = new RestClient(RestClient.BaseUrl + RestClient.WeightUrl + "/" + Entry.WeightEntryId, RestClient.BearerToken);
            client.PutData<WeightEntryDTO>(Entry);
        }

    }
}
