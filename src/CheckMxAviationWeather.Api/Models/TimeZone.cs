using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class TimeZone
    {
        /// <summary>
        /// Timezone offset subtracted or added to GMT time
        /// </summary>
        [JsonProperty("gmt")]
        public int Gmt { get; set; }

        /// <summary>
        /// Timezone offset subtracted or added to GMT time including DST
        /// </summary>
        [JsonProperty("dst")]
        public int Dst { get; set; }

        /// <summary>
        /// Timezone text string
        /// </summary>
        [JsonProperty("tzid")]
        public string Tzid { get; set; }
    }
}