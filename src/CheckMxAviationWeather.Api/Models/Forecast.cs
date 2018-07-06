using System.Collections.Generic;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Forecast
    {
        [JsonProperty("timestamp")]
        public ForecastTimestamp Timestamp { get; set; }
        [JsonProperty("clouds")]
        public List<Cloud> Clouds { get; set; }
        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("change_indicator")]
        public string ChangeIndicator { get; set; }
    }
}