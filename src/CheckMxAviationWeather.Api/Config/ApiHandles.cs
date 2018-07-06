namespace CheckMxAviationWeather.Api.Config
{
    public class ApiHandles
    {
        #region Station

        internal string StationSingle => "/station/{icao}";
        internal string StationMultiple => "/station/{icaos}";
        internal string StationRadius => "/station/{icao}/radius/{radius}/?type={type}";
        internal string StationLatLon => "/station/lat/{latitude}/lon/{longitude}?type={type}";
        internal string StationLatLonRadius => "/station/lat/{latitude}/lon/{longitude}/radius/{radius}?type={type}";

        #endregion

        #region METAR

        internal string MetarSingleRaw => "/metar/{icao}";
        internal string MetarMultipleRaw => "/metar/{icaos}";
        internal string MetarRadiusRaw => "/metar/{icao}/radius/{radius}/?include=1";
        internal string MetarLatLonRaw => "/metar/lat/{latitude}/lon/{longitude}";

        internal string MetarSingleDecoded => "/metar/{icao}/decoded";
        internal string MetarMultipleDecoded => "/metar/{icaos}/decoded";
        internal string MetarRadiusDecoded => "/metar/{icao}/radius/{radius}/decoded/?include=1";
        internal string MetarLatLonDecoded => "/metar/lat/{latitude}/lon/{longitude}/decoded";

        #endregion

        #region TAF

        internal string TafSingleRaw => "/taf/{icao}";
        internal string TafMultipleRaw => "/taf/{icaos}";

        internal string TafSingleDecoded => "/taf/{icao}/decoded";
        internal string TafMultipleDecoded => "/taf/{icaos}/decoded";

        #endregion
    }
}
