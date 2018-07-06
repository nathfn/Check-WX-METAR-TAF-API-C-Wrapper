using System;
using System.Collections.Generic;
using CheckMxAviationWeather.Api.Extensions;
using CheckMxAviationWeather.Api.Models;

namespace CheckMxAviationWeather.Api.Services.Json
{
    public class RawTafService: ServicesBase
    {
        internal RawTafService(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes, string acceptHeader) : base(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, acceptHeader) { }

        /// <summary>
        /// Returns the latest TAF information in a RAW format for a single ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <returns></returns>
        public ApiResponse SingleRaw(string icao)
        {
            if (string.IsNullOrEmpty(icao))
                throw new ArgumentNullException(nameof(icao), "Please specify an ICAO code!");
            var handle = ApiHandles.TafSingleRaw.Replace("{icao}", icao);
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest TAF information in a RAW format for multiple ICAO codes.
        /// </summary>
        /// <param name="icaoList">Multiple ICAO codes. Maximum of 25 ICAO codes per API request.</param>
        /// <returns></returns>
        public ApiResponse MultipleRaw(List<string> icaoList)
        {
            if (!icaoList.AnyNullSafe())
                throw new ArgumentException("No ICAO codes specified! You must specify at least one ICAO code!", nameof(icaoList));
            if (icaoList.Count > 25)
                throw new ArgumentException("More than 25 ICAO codes specified. The API can only handle 25 ICAO codes in one request!", nameof(icaoList));
            var handle = ApiHandles.TafMultipleRaw.Replace("{icaos}", string.Join(",", icaoList));
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest TAF information in a DECODED format for a single ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <returns></returns>
        public ApiResponse SingleDecoded(string icao)
        {
            if (string.IsNullOrEmpty(icao))
                throw new ArgumentNullException(nameof(icao), "Please specify an ICAO code!");
            var handle = ApiHandles.TafSingleDecoded.Replace("{icao}", icao);
            return CallApiGet(handle);
        }

        /// <summary>
        /// Returns the latest TAF information in a DECODED format for multiple ICAO codes.
        /// </summary>
        /// <param name="icaoList">Multiple ICAO codes. Maximum of 25 ICAO codes per API request.</param>
        /// <returns></returns>
        public ApiResponse MultipleDecoded(List<string> icaoList)
        {
            if (!icaoList.AnyNullSafe())
                throw new ArgumentException("No ICAO codes specified! You must specify at least one ICAO code!", nameof(icaoList));
            if (icaoList.Count > 25)
                throw new ArgumentException("More than 25 ICAO codes specified. The API can only handle 25 ICAO codes in one request!", nameof(icaoList));
            var handle = ApiHandles.TafMultipleDecoded.Replace("{icaos}", string.Join(",", icaoList));
            return CallApiGet(handle);
        }
    }
}
