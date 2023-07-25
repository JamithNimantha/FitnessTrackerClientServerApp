using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace FitnessTrackerClientApp.Service
{
    public class RestClient
    {
        public static readonly string BaseUrl = "http://localhost:5156";
        public static readonly string RegisterUserUrl = "/Auth/RegisterUser";
        public static readonly string AuthUrl = "/Auth/Login";
        public static readonly string UserUrl = "/api/Users";
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
