using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Country
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
