using CheckMxAviationWeather.Api.Communication;
using CheckMxAviationWeather.Api.Config;
using CheckMxAviationWeather.Api.Factories;
using CheckMxAviationWeather.Api.Models;

namespace CheckMxAviationWeather.Api.Services
{
    /// <summary>
    /// Base class for all raw service interactions
    /// </summary>
    public abstract class ServicesBase
    {
        protected readonly Http Http;
        protected readonly int MetarTafCacheTimeInMinutes;
        protected readonly int StationCacheTimeInMinutes;
        protected readonly ApiHandles ApiHandles;
        protected readonly ApiResponseFactory RawStreakApiResponseFactory;

        internal ServicesBase(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes)
        {
            Http = new Http(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes);
            ApiHandles = new ApiHandles();
            RawStreakApiResponseFactory = new ApiResponseFactory();
            MetarTafCacheTimeInMinutes = metarTafCacheTimeInMinutes;
            StationCacheTimeInMinutes = stationCacheTimeInMinutes;
        }

        protected ApiResponse CallApiGet(string handle)
        {
            var json = Http.Get(handle,
                out var httpStatusCode);
            return RawStreakApiResponseFactory.BuildApiResponse(json, httpStatusCode);
        }
    }
}
