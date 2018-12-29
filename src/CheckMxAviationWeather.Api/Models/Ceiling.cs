using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Ceiling
    {
        /// <summary>
        /// Ceiling abbreviation code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// Ceiling English text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
        /// <summary>
        /// Ceiling feet above ground level
        /// </summary>
        [JsonProperty("feet_agl")]
        public double FeetAgl { get; set; }
        /// <summary>
        /// Ceiling meters above ground level
        /// </summary>
        [JsonProperty("meters_agl")]
        public double MetersAgl { get; set; }
    }
}