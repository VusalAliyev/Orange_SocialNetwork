using Newtonsoft.Json;
using SocialNetwork.UI.Services.Interfaces;
using System.Text;

namespace SocialNetwork.UI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var baseUrl = _config["ApiSettings:BaseUrl"];
            var requestUrl = $"{baseUrl}/{endpoint}";

            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<T>(responseString);

            return responseData;

        }

        public async Task<T> CreateAsync<T>(string endpoint, T data)
        {
            var baseUrl = _config["ApiSettings:BaseUrl"];
            var requestUrl = $"{baseUrl}/{endpoint}";

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response= await _httpClient.PostAsync(requestUrl, content);
            response.EnsureSuccessStatusCode();

            var responseString=await response.Content.ReadAsStringAsync();
            var responseData=JsonConvert.DeserializeObject<T>(responseString);

            return responseData;


        }
    }
}
