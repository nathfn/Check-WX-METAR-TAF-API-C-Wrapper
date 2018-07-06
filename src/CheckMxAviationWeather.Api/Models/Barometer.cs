using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Barometer
    {
        /// <summary>
        /// Barometer in inches of mercury
        /// </summary>
        [JsonProperty("hg")]
        public double Hg { get; set; }
        /// <summary>
        /// Barometer in kilopascals
        /// </summary>
        [JsonProperty("kpa")]
        public double Kpa { get; set; }
        /// <summary>
        /// Barometer in millibars
        /// </summary>
        [JsonProperty("mb")]
        public double Mb { get; set; }
    }
}