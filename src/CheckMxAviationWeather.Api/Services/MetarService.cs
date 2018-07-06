using System.Collections.Generic;
using System.Linq;
using CheckMxAviationWeather.Api.Models;
using CheckMxAviationWeather.Api.Services.Json;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Services
{
    public class MetarService
    {
        private readonly JsonMetarService _jsonMetarService;

        internal MetarService(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes)
        {
            _jsonMetarService = new JsonMetarService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes);
        }

        /// <summary>
        /// Returns the latest METAR information in a raw format for a single ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <returns></returns>
        public string SingleRaw(string icao)
        {
            var station = _jsonMetarService.SingleRaw(icao);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<string>>>(station.Json);
            return asObj?.Data?.FirstOrDefault();
        }

        /// <summary>
        /// Returns the latest METAR information in a raw format for multiple ICAO codes.
        /// </summary>
        /// <param name="icaoList">Multiple ICAO codes. Maximum of 25 ICAO codes per API request.</param>
        /// <returns></returns>
        public List<string> MultipleRaw(List<string> icaoList)
        {
            var station = _jsonMetarService.MultipleRaw(icaoList);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<string>>>(station.Json);
            return asObj?.Data ?? new List<string>();
        }

        /// <summary>
        /// Returns the latest METAR information in a raw format for additional METARS within a parameter radius of one ICAO code.
        /// The results are sorted based on the distance from the requested ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <param name="radius">The surrounding radius in miles from the parameter ICAO code</param>
        /// <param name="includeBaseAirport">Includes the base airport in the results</param>
        /// <returns></returns>
        public List<string> RadiusRaw(string icao, int radius, bool includeBaseAirport = false)
        {
            var station = _jsonMetarService.RadiusRaw(icao, radius, includeBaseAirport);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<string>>>(station.Json);
            return asObj?.Data ?? new List<string>();
        }

        /// <summary>
        /// Returns the latest METAR information in a raw format for a single station closest to a parameter latitude/longitude.
        /// </summary>
        /// <param name="latitude">The decimal latitude</param>
        /// <param name="longitude">The decimal longitude</param>
        /// <returns></returns>
        public string LatitudeLongitudeRaw(double latitude, double longitude)
        {
            var station = _jsonMetarService.LatitudeLongitudeRaw(latitude, longitude);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<string>>>(station.Json);
            return asObj?.Data?.FirstOrDefault();
        }
    }
}
