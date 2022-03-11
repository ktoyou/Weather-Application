using Newtonsoft.Json;

namespace WeatherApp.Models.Responses
{
    internal class GeolocationResponse : Response
    {
        [JsonProperty("city")] public string City { get; set; }
    }
}
