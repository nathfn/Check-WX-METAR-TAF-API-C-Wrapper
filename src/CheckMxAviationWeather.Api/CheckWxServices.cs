using CheckMxAviationWeather.Api.Services;
using CheckMxAviationWeather.Api.Services.Json;

namespace CheckMxAviationWeather.Api
{
    public class CheckWxServices
    {
        private const string AcceptHeaderJson = "application/json";
        private const string AcceptHeaderXml = "application/xml";

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
            Stations = new StationService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, AcceptHeaderJson);
            Metars = new MetarService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, AcceptHeaderJson);
            Tafs = new TafService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, AcceptHeaderJson);

            JsonStations = new RawStationService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, AcceptHeaderJson);
            JsonTafs = new RawTafService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, AcceptHeaderJson);
            JsonMetars = new RawMetarService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, AcceptHeaderJson);

            XmlStations = new RawStationService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, AcceptHeaderXml);
            XmlTafs = new RawTafService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, AcceptHeaderXml);
            XmlMetars = new RawMetarService(apiKey, apiBaseUrl, metarTafCacheTimeInMinutes, stationCacheTimeInMinutes, AcceptHeaderXml);
        }

        /// <summary>
        /// Provides access to the station services in a strongly typed way (.NET objects)
        /// </summary>
        /// <value>
        /// The station services.
        /// </value>
        public StationService Stations { get; }

        /// <summary>
        /// Provides access to the METAR services in a strongly typed way (.NET objects)
        /// </summary>
        public MetarService Metars { get; }

        /// <summary>
        /// Provides access to the TAF services in a strongly typed way (.NET objects)
        /// </summary>
        public TafService Tafs { get; }

        /// <summary>
        /// Provides access to the station services by directly accesing the JSON returned from the API
        /// </summary>
        public RawStationService JsonStations { get; }

        /// <summary>
        /// Provides access to the TAF services by directly accesing the JSON returned from the API
        /// </summary>
        public RawTafService JsonTafs { get; }

        /// <summary>
        /// Provides access to the METAR services by directly accesing the JSON returned from the API
        /// </summary>
        public RawMetarService JsonMetars { get; }

        /// <summary>
        /// Provides access to the station services by directly accesing the XML returned from the API
        /// </summary>
        public RawStationService XmlStations { get; }

        /// <summary>
        /// Provides access to the TAF services by directly accesing the XML returned from the API
        /// </summary>
        public RawTafService XmlTafs { get; }

        /// <summary>
        /// Provides access to the METAR services by directly accesing the XML returned from the API
        /// </summary>
        public RawMetarService XmlMetars { get; }
    }
}
