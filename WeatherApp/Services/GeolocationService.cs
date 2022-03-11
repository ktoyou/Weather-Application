using System.Threading.Tasks;
using WeatherApp.Models.Responses;
using Newtonsoft.Json;
using System.Text;

namespace WeatherApp.Services
{
    internal class GeolocationService
    {
        public string ApiKey { get => _apiKey; private set => _apiKey = value; }

        public GeolocationService(IHttpAsync http, string apiKey)
        {
            ApiKey = apiKey;
            _http = http;
        }

        public async Task<Response> GetGeolocationAsync()
        {
            byte[] buffer = await _http.GetAsync($"https://api.ipgeolocation.io/ipgeo?apiKey={ApiKey}");
            string encodedJson = Encoding.UTF8.GetString(buffer);
            GeolocationResponse response = JsonConvert.DeserializeObject<GeolocationResponse>(encodedJson);
            if (response != null) return response;
            else return JsonConvert.DeserializeObject<ErrorResponse>(encodedJson);
        }

        private string _apiKey;
        
        private readonly IHttpAsync _http;
    }
}
