using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Wind
    {
        /// <summary>
        /// Wind direction in degrees
        /// </summary>
        [JsonProperty("degrees")]
        public int Degrees { get; set; }
        /// <summary>
        /// Wind speed in knots
        /// </summary>
        [JsonProperty("speed_kts")]
        public int SpeedKts { get; set; }
        /// <summary>
        /// Wind speed in miles per hour
        /// </summary>
        [JsonProperty("speed_mph")]
        public int SpeedMph { get; set; }
        /// <summary>
        /// Wind speed in meters per second
        /// </summary>
        [JsonProperty("speed_mps")]
        public int SpeedMps { get; set; }
        /// <summary>
        /// Wind gust speed in knots
        /// </summary>
        [JsonProperty("gust_kts")]
        public int GustKts { get; set; }
        /// <summary>
        /// Wind gust speed in miles per hour
        /// </summary>
        [JsonProperty("gust_mph")]
        public int GustMph { get; set; }
        /// <summary>
        /// Wind gust speed in meters per second
        /// </summary>
        [JsonProperty("gust_mps")]
        public int GustMps { get; set; }
    }
}