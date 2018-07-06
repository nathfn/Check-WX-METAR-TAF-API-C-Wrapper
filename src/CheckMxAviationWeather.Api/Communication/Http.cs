using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using CheckMxAviationWeather.Api.Exceptions;
using CheckMxAviationWeather.Api.Extensions;
using CheckMxAviationWeather.Api.Helpers;
using CheckMxAviationWeather.Api.Models;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Communication
{
    public class Http
    {
        private readonly string _apiKey;
        private readonly string _apiBaseUrl;
        private readonly int _metarTafCacheTimeInMinutes;
        private readonly int _stationCacheTimeInMinutes;
        private readonly string _acceptHeader;

        internal Http(string apiKey, string apiBaseUrl, int metarTafCacheTimeInMinutes, int stationCacheTimeInMinutes, string acceptHeader)
        {
            _apiKey = apiKey;
            _apiBaseUrl = apiBaseUrl;
            _metarTafCacheTimeInMinutes = metarTafCacheTimeInMinutes;
            _stationCacheTimeInMinutes = stationCacheTimeInMinutes;
            _acceptHeader = acceptHeader;
        }

        public string Get(string apiHandle, out int httpStatusCode)
        {
            return CallApi(apiHandle, HttpMethod.Get, out httpStatusCode);
        }
        
        private string CallApi(string apiHandle, HttpMethod method, out int httpStatusCode, string requestPayload = null, string requestContentType = "application/x-www-form-urlencoded")
        {
            try
            {
                var cacheKey = ("CheckMx-" + apiHandle).ToLower();
                var fromCache = CacheWrapper<string>.Get(cacheKey);
                if (!string.IsNullOrWhiteSpace(fromCache))
                {
                    httpStatusCode = 304; // Not modified
                    return fromCache;
                }

                var request =
                    WebRequest.Create(_apiBaseUrl + apiHandle) as
                        HttpWebRequest;
                request.Method = method.Method;
                request.ContentType = requestContentType;
                request.Headers["X-API-Key"] = _apiKey;
                request.Accept = _acceptHeader;
                request.Expect = "application/json";

                // Optional payload
                if (!string.IsNullOrEmpty(requestPayload))
                {
                    var encoder = new UTF8Encoding();
                    var data = encoder.GetBytes(requestPayload);
                    request.ContentLength = data.Length;
                    request.GetRequestStream().Write(data, 0, data.Length);
                }

                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var responseData = reader.ReadToEnd();
                httpStatusCode = response.GetHttpStatusCode();

                CacheWrapper<string>.Insert(cacheKey, responseData,
                    cacheKey.Contains("/station") ? _stationCacheTimeInMinutes : _metarTafCacheTimeInMinutes);

                return responseData;
            }
            catch (WebException e)
            {
                using (var response = e.Response)
                {
                    using (var data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        var responseData = reader.ReadToEnd();
                        var statusCode = response.GetHttpStatusCode();
                        var asResponse = JsonConvert.DeserializeObject<ApiResponseObject<object>>(responseData);
                        if (asResponse == null || !asResponse.Errors.AnyNullSafe())
                            throw new ApiException("Error in communication with the API", e, responseData, statusCode);
                        var error = asResponse.Errors.First();
                        throw new ApiException(error.Message + " " + error.Help, null, responseData, statusCode);
                    }
                }
            }
        }
    }
}
