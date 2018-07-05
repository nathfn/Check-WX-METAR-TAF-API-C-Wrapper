using System.Net;

namespace CheckMxAviationWeather.Api.Extensions
{
    internal static class WebResponseExtensions
    {
        public static int GetHttpStatusCode(this WebResponse r)
        {
            return (int)((HttpWebResponse)r).StatusCode;
        }
    }
}
