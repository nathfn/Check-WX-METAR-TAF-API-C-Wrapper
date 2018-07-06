using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Visibility
    {
        /// <summary>
        /// Visibility in miles (Expressed as a string to support values like '1/2 mile')
        /// </summary>
        [JsonProperty("miles")]
        public string Miles { get; set; }
        /// <summary>
        /// Visibility in meters (Expressed as a string to support values like '> 9000')
        /// </summary>
        [JsonProperty("meters")]
        public string Meters { get; set; }
    }
}