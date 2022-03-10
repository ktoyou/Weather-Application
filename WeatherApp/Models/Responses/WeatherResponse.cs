using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherApp.Models.Weather;

namespace WeatherApp.Models.Responses
{
    internal class WeatherResponse : Response
    {
        [JsonProperty("weather")] public List<Weather.Weather> Weather { get; set; }

        [JsonProperty("main")] public Main Main { get; set; }

        [JsonProperty("wind")] public Wind Wind { get; set; }

        [JsonProperty("sys")] public Sys Sys { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("timezone")] public int TimeZone { get; set; }

        public string Sunset { get; set; }

        public string Sunrise { get; set; }
    }
}
