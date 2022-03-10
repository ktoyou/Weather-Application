using Newtonsoft.Json;

namespace WeatherApp.Models.Responses
{
    internal class Response
    {
        [JsonProperty("cod")] public int Cod { get; set; }
    }
}
