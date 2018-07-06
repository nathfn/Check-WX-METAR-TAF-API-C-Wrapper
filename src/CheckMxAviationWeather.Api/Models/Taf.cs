using System.Collections.Generic;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Taf: AviationWeatherBaseObject
    {
        [JsonProperty("icao")]
        public string Icao { get; set; }
        [JsonProperty("timestamp")]
        public Timestamp Timestamp { get; set; }
        [JsonProperty("raw_text")]
        public string RawText { get; set; }
        [JsonProperty("forecast")]
        public List<Forecast> Forecast { get; set; }
    }
}
