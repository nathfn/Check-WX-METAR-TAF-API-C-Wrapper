namespace CheckMxAviationWeather.Api.Config
{
    public class ApiHandles
    {
        public string StationSingle => "/station/{icao}";
        public string StationMultiple => "/station/{icaos}";
        public string StationRadius => "/station/{icao}/radius/{radius}/?type={type}";
        public string StationLatLon => "/station/lat/{latitude}/lon/{longitude}?type={type}";
        public string StationLatLonRadius => "/station/lat/{latitude}/lon/{longitude}/radius/{radius}?type={type}";
    }
}
