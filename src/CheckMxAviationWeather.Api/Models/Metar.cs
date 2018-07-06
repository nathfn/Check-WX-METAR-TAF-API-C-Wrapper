using System.Collections.Generic;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    public class Metar: AviationWeatherBaseObject
    {
        /// <summary>
        /// ICAO airport code or station indicator
        /// </summary>
        [JsonProperty("icao")]
        public string Icao { get; set; }
        /// <summary>
        /// Station name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// METAR created date and time
        /// </summary>
        [JsonProperty("observed")]
        public string Observed { get; set; }
        /// <summary>
        /// Raw METAR text string
        /// </summary>
        [JsonProperty("raw_text")]
        public string RawText { get; set; }
        [JsonProperty("barometer")]
        public Barometer Barometer { get; set; }
        [JsonProperty("ceiling")]
        public Ceiling Ceiling { get; set; }
        /// <summary>
        /// Array of cloud levels each with the following properties
        /// </summary>
        [JsonProperty("clouds")]
        public List<Cloud> Clouds { get; set; }
        /// <summary>
        /// Array of conditions each with the following properties
        /// </summary>
        [JsonProperty("conditions")]
        public List<Condition> Conditions { get; set; }
        [JsonProperty("dewpoint")]
        public Temperature Dewpoint { get; set; }
        [JsonProperty("elevation")]
        public Elevation Elevation { get; set; }
        /// <summary>
        /// Flight rules category 'VFR', 'MVFR', 'IFR', 'LIFR'
        /// </summary>
        [JsonProperty("flight_category")]
        public string FlightCategory { get; set; }
        /// <summary>
        /// Humidity percentage
        /// </summary>
        [JsonProperty("humidity_percent")]
        public int HumidityPercent { get; set; }
        /// <summary>
        /// Rainfall in inches
        /// </summary>
        [JsonProperty("rain_in")]
        public int RainIn { get; set; }
        /// <summary>
        /// Snowfall in inches
        /// </summary>
        [JsonProperty("snow_in")]
        public int SnowIn { get; set; }
        [JsonProperty("temperature")]
        public Temperature Temperature { get; set; }
        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }
}
