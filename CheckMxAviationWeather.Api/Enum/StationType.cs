using System.ComponentModel;

namespace CheckMxAviationWeather.Api.Enum
{
    public enum StationType
    {
        [Description("A")]
        Airport = 1,
        [Description("H")]
        Heliport = 2,
        [Description("G")]
        Gliderport = 3,
        [Description("S")]
        SeaplaneBase = 4
    }
}
