using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    /// <summary>
    /// A Station is our term for an Airport, Heliport, Seaplane Base, Gliderport, or Weather Reporting Station.
    /// Stations are identified by a four-character alphanumeric ICAO code.
    /// Our database contains over 44,000 ICAO codes to choose from.
    /// You can search a listing of all ICAO codes on CheckWX.com
    /// </summary>
    public class Station: AviationWeatherBaseObject
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
        /// Conditional! Activated Month/Year
        /// </summary>
        [JsonProperty("activated")]
        public string Activated { get; set; }

        /// <summary>
        /// Conditional! City
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [JsonProperty("country")]
        public Country Country { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// Conditional! Elevation in feet
        /// </summary>
        [JsonProperty("elevation")]
        public Elevation Elevation { get; set; }

        /// <summary>
        /// Conditional! IATA airport code or station indicator
        /// </summary>
        [JsonProperty("iata")]
        public string Iata { get; set; }

        /// <summary>
        /// Latitude information
        /// </summary>
        [JsonProperty("latitude")]
        public Position Latitude { get; set; }

        /// <summary>
        /// Longitude information
        /// </summary>
        [JsonProperty("longitude")]
        public Position Longitude { get; set; }

        /// <summary>
        /// Conditional! The angle between magnetic north and true north
        /// </summary>
        [JsonProperty("magnetic_variation")]
        public string MagneticVariation { get; set; }

        /// <summary>
        /// Conditional! Year of last magnetic variation determination
        /// </summary>
        [JsonProperty("magnetic_variation_year")]
        public string MagneticVariationYear { get; set; }

        /// <summary>
        /// Conditional! Station appears on this FAA Sectional chart(US/Canada)
        /// </summary>
        [JsonProperty("sectional")]
        public string Sectional { get; set; }

        /// <summary>
        /// Conditional! State/province abbreviation(US/Canada)
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Conditional! Status - 'Operational' or 'Closed'
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Timezone information
        /// </summary>
        [JsonProperty("timezone")]
        public TimeZone TimeZone { get; set; }

        /// <summary>
        /// Conditional! Type 'Airport', 'Heliport', 'Seaplane Base', etc.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Conditional! Useage 'Public', 'Private', 'Military', etc.
        /// </summary>
        [JsonProperty("useage")]
        public string Useage { get; set; }
    }
}
