using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Position
    {
        /// <summary>
        /// Decimal degrees
        /// </summary>
        [JsonProperty("decimal")]
        public double Decimal { get; set; }

        /// <summary>
        /// Degrees, minutes, seconds
        /// </summary>
        [JsonProperty("degrees")]
        public string Degrees { get; set; }
    }
}