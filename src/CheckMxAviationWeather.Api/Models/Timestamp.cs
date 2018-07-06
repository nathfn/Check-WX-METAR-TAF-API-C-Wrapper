using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Timestamp
    {
        [JsonProperty("issued")]
        public string Issued { get; set; }
        [JsonProperty("bulletin")]
        public string Bulletin { get; set; }
        [JsonProperty("valid_from")]
        public string ValidFrom { get; set; }
        [JsonProperty("valid_to")]
        public string ValidTo { get; set; }
    }
}