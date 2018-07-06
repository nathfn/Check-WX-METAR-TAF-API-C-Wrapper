using CheckMxAviationWeather.Api.Models;

namespace CheckMxAviationWeather.Api.Factories
{
    public class ApiResponseFactory
    {
        internal ApiResponse BuildApiResponse(string json, int httpStatusCode)
        {
            return new ApiResponse(json, httpStatusCode);
        }
    }
}
