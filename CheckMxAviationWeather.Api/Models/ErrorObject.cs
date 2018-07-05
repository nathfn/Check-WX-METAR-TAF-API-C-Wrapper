using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class ErrorObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("help")]
        public string Help { get; set; }
    }
}
