using Newtonsoft.Json;

namespace WeatherApp.Models.Weather
{
    internal class Sys
    {
        [JsonProperty("sunrise")] public int Sunrise { get; set; }

        [JsonProperty("sunset")] public int Sunset { get; set; }
    }
}
