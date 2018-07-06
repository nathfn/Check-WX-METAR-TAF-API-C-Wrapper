using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Temperature
    {
        /// <summary>
        /// Temperature in celsius
        /// </summary>
        [JsonProperty("celsius")]
        public int Celsius { get; set; }
        /// <summary>
        /// Temperature in fahrenheit
        /// </summary>
        [JsonProperty("fahrenheit")]
        public int Fahrenheit { get; set; }
    }
}