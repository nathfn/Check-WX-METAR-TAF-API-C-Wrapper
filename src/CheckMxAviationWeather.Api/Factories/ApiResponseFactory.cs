using CheckMxAviationWeather.Api.Models;

namespace CheckMxAviationWeather.Api.Factories
{
    public class ApiResponseFactory
    {
        public ApiResponse BuildApiResponse(string json, int httpStatusCode)
        {
            return new ApiResponse(json, httpStatusCode);
        }
    }
}
