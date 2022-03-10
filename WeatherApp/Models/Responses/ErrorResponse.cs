using Newtonsoft.Json;

namespace WeatherApp.Models.Responses
{
    internal class ErrorResponse : Response
    {
        [JsonProperty("message")] public string Message { get; set; }
    }
}
