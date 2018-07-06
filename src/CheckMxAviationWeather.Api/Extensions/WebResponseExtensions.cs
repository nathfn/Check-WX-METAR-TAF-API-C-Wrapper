using System.Net;

namespace CheckMxAviationWeather.Api.Extensions
{
    public static class WebResponseExtensions
    {
        internal static int GetHttpStatusCode(this WebResponse r)
        {
            return (int)((HttpWebResponse)r).StatusCode;
        }
    }
}
