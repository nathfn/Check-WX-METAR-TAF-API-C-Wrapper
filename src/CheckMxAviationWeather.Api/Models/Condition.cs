using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Condition
    {
        /// <summary>
        /// Condition abbreviation code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// Condition English text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}