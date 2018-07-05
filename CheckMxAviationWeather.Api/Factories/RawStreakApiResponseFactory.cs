using CheckMxAviationWeather.Api.Models;

namespace CheckMxAviationWeather.Api.Factories
{
    public class RawStreakApiResponseFactory
    {
        public RawApiResponse BuildRawStreakApiResponse(string json, int httpStatusCode)
        {
            return new RawApiResponse(json, httpStatusCode);
        }
    }
}
