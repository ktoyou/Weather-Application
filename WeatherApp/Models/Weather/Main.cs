using Newtonsoft.Json;

namespace WeatherApp.Models.Weather
{
    internal class Main
    {
        [JsonProperty("temp")] public float Temp { get; set; }

        [JsonProperty("feels_like")] public float FeelsLike { get; set; }

        [JsonProperty("temp_min")] public float TempMin { get; set; }

        [JsonProperty("temp_max")] public float TempMax { get; set; }

        [JsonProperty("humidity")] public float Humidity { get; set; }

        [JsonProperty("sea_level")] public float SeaLevel { get; set; }

        [JsonProperty("grnd_level")] public float GroundLevel { get; set; }
    }
}
