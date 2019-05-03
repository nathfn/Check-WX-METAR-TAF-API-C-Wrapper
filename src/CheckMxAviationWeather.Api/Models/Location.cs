using System.Collections.Generic;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Location
    {
        public Location()
        {
            Coordinates = new List<double>();
        }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }

}
