using System.Collections.Generic;
using System.Linq;
using CheckMxAviationWeather.Api.Factories;
using CheckMxAviationWeather.Api.Models;
using CheckMxAviationWeather.Api.Services.Json;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Services
{
    public class TafService
    {
        private readonly RawTafService _jsonTafService;
        private readonly TafFactory _tafFactory;

        internal TafService(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes, string acceptHeader)
        {
            _jsonTafService = new RawTafService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, acceptHeader);
            _tafFactory = new TafFactory();
        }

        /// <summary>
        /// Returns the latest TAF information in a RAW format for a single ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <returns></returns>
        public string SingleRaw(string icao)
        {
            var station = _jsonTafService.SingleRaw(icao);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<string>>>(station.Json);
            return asObj?.Data?.FirstOrDefault();
        }

        /// <summary>
        /// Returns the latest TAF information in a RAW format for multiple ICAO codes.
        /// </summary>
        /// <param name="icaoList">Multiple ICAO codes. Maximum of 25 ICAO codes per API request.</param>
        /// <returns></returns>
        public List<string> MultipleRaw(List<string> icaoList)
        {
            var station = _jsonTafService.MultipleRaw(icaoList);
            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<string>>>(station.Json);
            return asObj?.Data ?? new List<string>();
        }

        /// <summary>
        /// Returns the latest TAF information in a DECODED format for a single ICAO code.
        /// </summary>
        /// <param name="icao">A single ICAO code</param>
        /// <returns></returns>
        public Taf SingleDecoded(string icao)
        {
            return _tafFactory.BuildMultiple(_jsonTafService.SingleDecoded(icao).Json).FirstOrDefault();
        }

        /// <summary>
        /// Returns the latest TAF information in a DECODED format for multiple ICAO codes.
        /// </summary>
        /// <param name="icaoList">Multiple ICAO codes. Maximum of 25 ICAO codes per API request.</param>
        /// <returns></returns>
        public List<Taf> MultipleDecoded(List<string> icaoList)
        {
            return _tafFactory.BuildMultiple(_jsonTafService.MultipleDecoded(icaoList).Json);
        }
    }
}
