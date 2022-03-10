using Newtonsoft.Json;

namespace WeatherApp.Models.Weather
{
    internal class Weather
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("main")] public string Main { get; set; }

        [JsonProperty("description")] public string Description { get; set; }
    }
}
