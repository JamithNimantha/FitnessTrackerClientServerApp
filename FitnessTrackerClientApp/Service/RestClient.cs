using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace FitnessTrackerClientApp.Service
{
    public class RestClient
    {
       // public static readonly string BaseUrl = "http://localhost:5156";
        public static readonly string BaseUrl = "https://fitnesstrackerserverapp20230727003520.azurewebsites.net";
        public static readonly string RegisterUserUrl = "/Auth/RegisterUser";
        public static readonly string AuthUrl = "/Auth/Login";
        public static readonly string UserUrl = "/api/Users";
        public static readonly string CheatMealUrl = "/api/CheatMealEntry";
        public static readonly string WeightUrl = "/api/WeightEntry";
        public static readonly string WorkoutUrl = "/api/WorkoutEntry";
        public static readonly string LatestWeightEntriesUrl = "/api/Report/GetLatestWeightEntries";
        public static readonly string FitnessPredictionUrl = "/api/Report/PredictFitness";
        public static readonly string ReportUrl = "/api/Report/GetReport";

        public static string BearerToken { get; set; }

        private readonly HttpClient _httpClient;

        public RestClient(string apiUrl)
        {
            

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiUrl)
            };

        }

        public RestClient(string apiUrl, string bearerToken)
            : this(apiUrl)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        }

        private void LogRequestResponse(string request, string response)
        {
            var settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineHandling = NewLineHandling.Entitize
            };

            XElement rootElement;
            if (File.Exists("RequestResponseLog.xml"))
            {
                rootElement = XElement.Load("RequestResponseLog.xml");
            }
            else
            {
                rootElement = new XElement("LogEntries");
            }

            XElement logEntry = new XElement("LogEntry",
                new XElement("DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("Request", request),
                new XElement("Response", response)
            );

            rootElement.Add(logEntry);

            using (XmlWriter writer = XmlWriter.Create("RequestResponseLog.xml", settings))
            {
                rootElement.Save(writer);
            }
        }

        public T FetchData<T>()
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync("").GetAwaiter().GetResult();

                response.EnsureSuccessStatusCode();

                string responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (typeof(T) == typeof(string))
                {
                    return (T)(object)responseData;
                }

                T result = JsonConvert.DeserializeObject<T>(responseData);

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error fetching data from the REST API: " + ex.Message);
                throw;
            }
        }

        public T Delete<T>()
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync("").GetAwaiter().GetResult();

                response.EnsureSuccessStatusCode();

                string responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (typeof(T) == typeof(string))
                {
                    return (T)(object)responseData;
                }

                T result = JsonConvert.DeserializeObject<T>(responseData);

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error fetching data from the REST API: " + ex.Message);
                throw;
            }
        }

        public T PostData<T>(object data)
        {
            return SendData<T>(HttpMethod.Post, data);
        }

        public T PutData<T>(object data)
        {
            return SendData<T>(HttpMethod.Put, data);
        }

        private T SendData<T>(HttpMethod httpMethod, object data)
        {
            HttpResponseMessage response;
            try
            {
                string jsonData = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                switch (httpMethod.Method)
                {
                    case "POST":
                        response = _httpClient.PostAsync(_httpClient.BaseAddress, httpContent).GetAwaiter().GetResult();
                        break;
                    case "PUT":
                        response = _httpClient.PutAsync(_httpClient.BaseAddress, httpContent).GetAwaiter().GetResult();
                        break;
                    default:
                        throw new NotSupportedException($"HTTP method {httpMethod.Method} is not supported.");
                }

                response.EnsureSuccessStatusCode();

                string responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                LogRequestResponse(jsonData, responseData);


                if (typeof(T) == typeof(string))
                {
                    return (T)(object)responseData;
                }

                T result = JsonConvert.DeserializeObject<T>(responseData);

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error sending data to the REST API: " + ex.Message);
                throw;
            }
        }

    }
}
