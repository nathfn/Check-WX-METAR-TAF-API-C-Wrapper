using CheckMxAviationWeather.Api.Services;

namespace CheckMxAviationWeather.Api
{
    public class CheckWxServices
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CheckMxAviationWeather.Api.CheckWxServices" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public CheckWxServices(string apiKey) : this(apiKey, "https://api.checkwx.com", 30, 43200) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckWxServices"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="apiBaseUrl">The API base URL.</param>
        /// <param name="metarTafCacheTimeInMinutes">The amount of time the METARs and TAFs are cached on the server (HttpRuntimeCache). Defaults to 30 minutes as dictated by the API developers. Set to 0 to disable caching (not recommended due to the 2000 request limit per day!)</param>
        /// <param name="stationCacheTimeInMinutes">The amount of time the stations are cached on the server (HttpRuntimeCache). Defaults to 43200 minutes (30 days) as dictated by the API developers. Set to 0 to disable caching (not recommended due to the 2000 request limit per day!)</param>
        public CheckWxServices(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes)
        {
            Stations = new StationService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes);
            Metars = new MetarService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes);
        }

        /// <summary>
        /// Provides access to the station service for interacting with stations in a .NET object.
        /// </summary>
        /// <value>
        /// The station services.
        /// </value>
        public StationService Stations { get; }

        public MetarService Metars { get; set; }
    }
}
