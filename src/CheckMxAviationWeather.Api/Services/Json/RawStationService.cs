using System;
using System.Collections.Generic;
using System.Globalization;
using CheckMxAviationWeather.Api.Enum;
using CheckMxAviationWeather.Api.Extensions;
using CheckMxAviationWeather.Api.Models;

namespace CheckMxAviationWeather.Api.Services.Json
{
    public class RawStationService : ServicesBase
    {
        internal RawStationService(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes, string acceptHeader) : base(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, acceptHeader) { }

        /// <summary>
        /// Returns the latest Station information for a single ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <returns></returns>
        public ApiResponse Single(string icao)
        {
            if (string.IsNullOrEmpty(icao))
                throw new ArgumentNullException(nameof(icao), "Please specify an ICAO code!");
            var handle = ApiHandles.StationSingle.Replace("{icao}", icao);
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest Station information for multiple ICAO codes.
        /// </summary>
        /// <param name="icaoList">Multiple ICAO codes. Maximum of 25 ICAO codes per API request.</param>
        /// <returns></returns>
        public ApiResponse Multiple(List<string> icaoList)
        {
            if (!icaoList.AnyNullSafe())
                throw new ArgumentException("No ICAO codes specified! You must specify at least one ICAO code!", nameof(icaoList));
            if (icaoList.Count > 25)
                throw new ArgumentException("More than 25 ICAO codes specified. The API can only handle 25 ICAO codes in one request!", nameof(icaoList));
            var handle = ApiHandles.StationMultiple.Replace("{icaos}", string.Join(",", icaoList));
            return CallApiGet(handle);
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
        public ApiResponse Radius(string icao, int radius, StationType? stationType = null)
        {
            if (string.IsNullOrEmpty(icao))
                throw new ArgumentNullException(nameof(icao), "Please specify an ICAO code!");
            var handle = ApiHandles.StationRadius.Replace("{icao}", icao).Replace("{radius}", Convert.ToString(radius));
            handle = stationType != null ? handle.Replace("{type}", stationType.GetEnumDescription()) : handle.Replace("/?type={type}", string.Empty);
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest Station information for a single station closest to a parameter ©latitude/longitude.
        /// Additional data elements are included in the response data to show the distance and direction from the requested latitude/longitude.
        /// </summary>
        /// <param name="latitude">The decimal latitude</param>
        /// <param name="longitude">The decimal longitude</param>
        /// <param name="stationType">Filter the results by station type.</param>
        /// <returns></returns>
        public ApiResponse LatitudeLongitude(double latitude, double longitude, StationType? stationType = null)
        {
            var handle = ApiHandles.StationLatLon.Replace("{latitude}", latitude.ToString(CultureInfo.InvariantCulture)).Replace("{longitude}",longitude.ToString(CultureInfo.InvariantCulture));
            handle = stationType != null ? handle.Replace("{type}", stationType.GetEnumDescription()) : handle.Replace("?type={type}", string.Empty);
            return CallApiGet(handle);
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
        public ApiResponse LatitudeLongitudeRadius(double latitude, double longitude, int radius, StationType? stationType = null)
        {
            var handle = ApiHandles.StationLatLonRadius.Replace("{latitude}", latitude.ToString(CultureInfo.InvariantCulture)).Replace("{longitude}", longitude.ToString(CultureInfo.InvariantCulture)).Replace("{radius}", Convert.ToString(radius));
            handle = stationType != null ? handle.Replace("{type}", stationType.GetEnumDescription()) : handle.Replace("?type={type}", string.Empty);
            return CallApiGet(handle);
        }
    }
}
