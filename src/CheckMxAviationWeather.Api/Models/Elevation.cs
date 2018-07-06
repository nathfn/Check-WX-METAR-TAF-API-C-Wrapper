using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Elevation
    {
        /// <summary>
        /// Conditional! Elevation in feet
        /// </summary>
        [JsonProperty("feet")]
        public int Feet { get; set; }

        /// <summary>
        /// Conditional! Elevation in metres
        /// </summary>
        [JsonProperty("meters")]
        public int Meters { get; set; }

        /// <summary>
        /// Conditional! Method used to determine elevation - 'Surveyed' or 'Estimated'
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }
    }
}