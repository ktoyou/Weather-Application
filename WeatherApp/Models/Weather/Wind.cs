using Newtonsoft.Json;

namespace WeatherApp.Models.Weather
{
    internal class Wind
    {
        [JsonProperty("speed")] public float Speed { get; set; }

        [JsonProperty("deg")] public float Deg { get; set; }

        [JsonProperty("gust")] public float Gust { get; set; }
    }
}
