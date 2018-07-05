using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Models
{
    /// <summary>
    /// A Station is our term for an Airport, Heliport, Seaplane Base, Gliderport, or Weather Reporting Station.
    /// Stations are identified by a four-character alphanumeric ICAO code.
    /// Our database contains over 44,000 ICAO codes to choose from.
    /// You can search a listing of all ICAO codes on CheckWX.com
    /// </summary>
    public class Station
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
        /// Country abbreviation
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

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

    public class Position
    {
        /// <summary>
        /// Decimal degrees
        /// </summary>
        [JsonProperty("decimal")]
        public double Decimal { get; set; }

        /// <summary>
        /// Degrees, minutes, seconds
        /// </summary>
        [JsonProperty("degrees")]
        public string Degrees { get; set; }
    }

    public class Elevation
    {
        /// <summary>
        /// Conditional! Elevation in feet
        /// </summary>
        [JsonProperty("feet")]
        public int Feet { get; set; }

        /// <summary>
        /// Conditional! Method used to determine elevation - 'Surveyed' or 'Estimated'
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }
    }

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
