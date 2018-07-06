using System;
using System.Collections.Generic;
using System.Globalization;
using CheckMxAviationWeather.Api.Extensions;
using CheckMxAviationWeather.Api.Models;

namespace CheckMxAviationWeather.Api.Services.Json
{
    public class RawMetarService: ServicesBase
    {
        internal RawMetarService(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes, string acceptHeader) : base(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, acceptHeader) { }

        /// <summary>
        /// Returns the latest METAR information in a RAW format for a single ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <returns></returns>
        public ApiResponse SingleRaw(string icao)
        {
            if (string.IsNullOrEmpty(icao))
                throw new ArgumentNullException(nameof(icao), "Please specify an ICAO code!");
            var handle = ApiHandles.MetarSingleRaw.Replace("{icao}", icao);
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest METAR information in a RAW format for multiple ICAO codes.
        /// </summary>
        /// <param name="icaoList">Multiple ICAO codes. Maximum of 25 ICAO codes per API request.</param>
        /// <returns></returns>
        public ApiResponse MultipleRaw(List<string> icaoList)
        {
            if (!icaoList.AnyNullSafe())
                throw new ArgumentException("No ICAO codes specified! You must specify at least one ICAO code!", nameof(icaoList));
            if (icaoList.Count > 25)
                throw new ArgumentException("More than 25 ICAO codes specified. The API can only handle 25 ICAO codes in one request!", nameof(icaoList));
            var handle = ApiHandles.MetarMultipleRaw.Replace("{icaos}", string.Join(",", icaoList));
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest METAR information in a RAW format for additional METARS within a parameter radius of one ICAO code.
        /// The results are sorted based on the distance from the requested ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <param name="radius">The surrounding radius in miles from the parameter ICAO code</param>
        /// <param name="includeBaseAirport">Includes the base airport in the results</param>
        /// <returns></returns>
        public ApiResponse RadiusRaw(string icao, int radius, bool includeBaseAirport = false)
        {
            if (string.IsNullOrEmpty(icao))
                throw new ArgumentNullException(nameof(icao), "Please specify an ICAO code!");
            var handle = ApiHandles.MetarRadiusRaw.Replace("{icao}", icao).Replace("{radius}", Convert.ToString(radius));
            handle = !includeBaseAirport ? handle.Replace("?include=1", string.Empty) : handle;
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest METAR information in a RAW format for a single station closest to a parameter latitude/longitude.
        /// </summary>
        /// <param name="latitude">The decimal latitude</param>
        /// <param name="longitude">The decimal longitude</param>
        /// <returns></returns>
        public ApiResponse LatitudeLongitudeRaw(double latitude, double longitude)
        {
            var handle = ApiHandles.MetarLatLonRaw.Replace("{latitude}", latitude.ToString(CultureInfo.InvariantCulture)).Replace("{longitude}", longitude.ToString(CultureInfo.InvariantCulture));
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest METAR information in a DECODED format for a single ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <returns></returns>
        public ApiResponse SingleDecoded(string icao)
        {
            if (string.IsNullOrEmpty(icao))
                throw new ArgumentNullException(nameof(icao), "Please specify an ICAO code!");
            var handle = ApiHandles.MetarSingleDecoded.Replace("{icao}", icao);
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest METAR information in a DECODED format for multiple ICAO codes.
        /// </summary>
        /// <param name="icaoList">Multiple ICAO codes. Maximum of 25 ICAO codes per API request.</param>
        /// <returns></returns>
        public ApiResponse MultipleDecoded(List<string> icaoList)
        {
            if (!icaoList.AnyNullSafe())
                throw new ArgumentException("No ICAO codes specified! You must specify at least one ICAO code!", nameof(icaoList));
            if (icaoList.Count > 25)
                throw new ArgumentException("More than 25 ICAO codes specified. The API can only handle 25 ICAO codes in one request!", nameof(icaoList));
            var handle = ApiHandles.MetarMultipleDecoded.Replace("{icaos}", string.Join(",", icaoList));
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest METAR information in a DECODED format for additional METARS within a parameter radius of one ICAO code.
        /// The results are sorted based on the distance from the requested ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <param name="radius">The surrounding radius in miles from the parameter ICAO code</param>
        /// <param name="includeBaseAirport">Includes the base airport in the results</param>
        /// <returns></returns>
        public ApiResponse RadiusDecoded(string icao, int radius, bool includeBaseAirport = false)
        {
            if (string.IsNullOrEmpty(icao))
                throw new ArgumentNullException(nameof(icao), "Please specify an ICAO code!");
            var handle = ApiHandles.MetarRadiusDecoded.Replace("{icao}", icao).Replace("{radius}", Convert.ToString(radius));
            handle = !includeBaseAirport ? handle.Replace("?include=1", string.Empty) : handle;
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest METAR information in a DECODED format for a single station closest to a parameter latitude/longitude.
        /// </summary>
        /// <param name="latitude">The decimal latitude</param>
        /// <param name="longitude">The decimal longitude</param>
        /// <returns></returns>
        public ApiResponse LatitudeLongitudeDecoded(double latitude, double longitude)
        {
            var handle = ApiHandles.MetarLatLonDecoded.Replace("{latitude}", latitude.ToString(CultureInfo.InvariantCulture)).Replace("{longitude}", longitude.ToString(CultureInfo.InvariantCulture));
            return CallApiGet(handle);
        }
    }
}
