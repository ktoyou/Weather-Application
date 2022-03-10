using System.Threading.Tasks;
using WeatherApp.Models.Responses;
using Newtonsoft.Json;
using System.Text;
using System;

namespace WeatherApp.Services
{
    internal class WeatherService
    {
        public string ApiKey { get => _apiKey; private set => _apiKey = value; }

        public static string DOMAIN = "https://api.openweathermap.org/data/2.5/";

        public Exception LastException { get; set; }

        public WeatherService(IHttpAsync http, string apiKey)
        {
            _http = http;
            ApiKey = apiKey;
        }

        public async Task<Response> GetWeatherAsync(string city) => await TryGetWeatherAsync(city);

        private async Task<Response> TryGetWeatherAsync(string city)
        {
            try
            {
                string weatherUrl = DOMAIN + $"weather?appid={_apiKey}&q={city}&lang=ru";
                byte[] buffer = await _http.GetAsync(weatherUrl);
                string encodedJson = Encoding.UTF8.GetString(buffer);

                Response response = JsonConvert.DeserializeObject<Response>(encodedJson);
                ErrorResponse errorResponse;

                switch (response.Cod)
                {
                    case 200: return JsonConvert.DeserializeObject<WeatherResponse>(encodedJson);
                    case 400: return JsonConvert.DeserializeObject<ErrorResponse>(encodedJson);
                    case 401:
                        errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(encodedJson);
                        errorResponse.Message = "Неверный ключ API";
                        return errorResponse;
                    case 404:
                        errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(encodedJson);
                        errorResponse.Message = "Город не найден";
                        return errorResponse;
                }
            }
            catch (Exception ex)
            {
                LastException = ex;
            }

            return null;
        }

        private readonly IHttpAsync _http;

        private string _apiKey;
    }
}
