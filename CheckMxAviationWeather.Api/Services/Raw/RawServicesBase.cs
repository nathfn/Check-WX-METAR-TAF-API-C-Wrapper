using CheckMxAviationWeather.Api.Communication;
using CheckMxAviationWeather.Api.Config;
using CheckMxAviationWeather.Api.Factories;
using CheckMxAviationWeather.Api.Models;

namespace CheckMxAviationWeather.Api.Services.Raw
{
    /// <summary>
    /// Base class for all raw service interactions
    /// </summary>
    public abstract class RawServicesBase
    {
        protected readonly Http Http;
        protected readonly int MetarTafCacheTimeInMinutes;
        protected readonly int StationCacheTimeInMinutes;
        protected readonly ApiHandles ApiHandles;
        protected readonly RawStreakApiResponseFactory RawStreakApiResponseFactory;

        internal RawServicesBase(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes)
        {
            Http = new Http(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes);
            ApiHandles = new ApiHandles();
            RawStreakApiResponseFactory = new RawStreakApiResponseFactory();
            MetarTafCacheTimeInMinutes = metarTafCacheTimeInMinutes;
            StationCacheTimeInMinutes = stationCacheTimeInMinutes;
        }

        protected RawApiResponse CallApiGet(string handle)
        {
            var json = Http.Get(handle,
                out var httpStatusCode);
            return RawStreakApiResponseFactory.BuildRawStreakApiResponse(json, httpStatusCode);
        }
    }
}
