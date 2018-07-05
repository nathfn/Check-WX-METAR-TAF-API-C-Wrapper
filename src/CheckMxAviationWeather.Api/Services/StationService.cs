using System.Collections.Generic;
using System.Linq;
using CheckMxAviationWeather.Api.Enum;
using CheckMxAviationWeather.Api.Models;
using CheckMxAviationWeather.Api.Services.Raw;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Services
{
    public class StationService
    {
        private readonly RawStationService _rawStationService;

        internal StationService(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes)
        {
            _rawStationService = new RawStationService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes);
        }

        /// <summary>
        /// Returns the latest Station information for a single ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <returns></returns>
        public Station Single(string icao)
        {
            var station = _rawStationService.Single(icao);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<Station>>>(station.Json);
            return asObj?.Data?.FirstOrDefault();
        }

        /// <summary>
        /// Returns the latest Station information for multiple ICAO codes.
        /// </summary>
        /// <param name="icaoList">Multiple ICAO codes. Maximum of 25 ICAO codes per API request.</param>
        /// <returns></returns>
        public List<Station> Multiple(List<string> icaoList)
        {
            var station = _rawStationService.Multiple(icaoList);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<Station>>>(station.Json);
            return asObj?.Data ?? new List<Station>();
        }

        /// <summary>
        /// Returns the latest Station information for stations within a parameter radius of a single ICAO code.
        /// The results are sorted based on the distance from the requested ICAO code.
        /// Additional data elements are included in the response data to show the distance and direction of additional stations from the requested ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <param name="radius">The surrounding radius in miles from the parameter ICAO code</param>
        /// <param name="stationType">Filter the results by station type.</param>
        /// <returns></returns>
        public List<Station> Radius(string icao, int radius, StationType? stationType = null)
        {
            var station = _rawStationService.Radius(icao, radius, stationType);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<Station>>>(station.Json);
            return asObj?.Data ?? new List<Station>();
        }

        /// <summary>
        /// Returns the latest Station information for a single station closest to a parameter ©latitude/longitude.
        /// Additional data elements are included in the response data to show the distance and direction from the requested latitude/longitude.
        /// </summary>
        /// <param name="latitude">The decimal latitude</param>
        /// <param name="longitude">The decimal longitude</param>
        /// <param name="stationType">Filter the results by station type.</param>
        /// <returns></returns>
        public Station LatitudeLongitude(double latitude, double longitude, StationType? stationType = null)
        {
            var station = _rawStationService.LatitudeLongitude(latitude, longitude, stationType);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<Station>>>(station.Json);
            return asObj?.Data?.FirstOrDefault();
        }

        /// <summary>
        /// Returns the latest Station information for multiple stations within a radius of a parameter latitude/longitude.
        /// Additional data elements are included in the response data to show the distance and direction from the requested latitude/longitude.
        /// </summary>
        /// <param name="latitude">The decimal latitude</param>
        /// <param name="longitude">The decimal longitude</param>
        /// <param name="radius">The surrounding radius in miles from the parameter ICAO code</param>
        /// <param name="stationType">Filter the results by station type.</param>
        /// <returns></returns>
        public List<Station> LatitudeLongitudeRadius(double latitude, double longitude, int radius, StationType? stationType = null)
        {
            var station = _rawStationService.LatitudeLongitudeRadius(latitude, longitude, radius, stationType);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<Station>>>(station.Json);
            return asObj?.Data ?? new List<Station>();
        }
    }
}
