using System.Collections.Generic;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class ApiResponseObject<T>
    {
        [JsonProperty("errors")]
        public List<ErrorObject> Errors { get; set; }
        [JsonProperty("results")]
        public int Results { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
