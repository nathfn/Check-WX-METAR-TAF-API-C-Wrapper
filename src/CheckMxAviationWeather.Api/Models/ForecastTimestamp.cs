using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class ForecastTimestamp
    {
        [JsonProperty("forecast_from")]
        public string ForecastFrom { get; set; }
        [JsonProperty("forecast_to")]
        public string ForecastTo { get; set; }
    }
}