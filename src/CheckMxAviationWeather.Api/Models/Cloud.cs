using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Cloud
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
        [JsonProperty("base_feet_agl")]
        public double BaseFeetAgl { get; set; }
        /// <summary>
        /// Ceiling meters above ground level
        /// </summary>
        [JsonProperty("base_meters_agl")]
        public double BaseMetersAgl { get; set; }
    }
}