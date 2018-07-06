namespace CheckMxAviationWeather.Api.Config
{
    public class ApiHandles
    {
        #region Station

        public string StationSingle => "/station/{icao}";
        public string StationMultiple => "/station/{icaos}";
        public string StationRadius => "/station/{icao}/radius/{radius}/?type={type}";
        public string StationLatLon => "/station/lat/{latitude}/lon/{longitude}?type={type}";
        public string StationLatLonRadius => "/station/lat/{latitude}/lon/{longitude}/radius/{radius}?type={type}";

        #endregion

        #region Metar

        public string MetarSingleRaw => "/metar/{icao}";
        public string MetarMultipleRaw => "/metar/{icaos}";
        public string MetarRadiusRaw => "/metar/{icao}/radius/{radius}/?include=1";
        public string MetarLatLonRaw => "/metar/lat/{latitude}/lon/{longitude}";

        #endregion
    }
}
