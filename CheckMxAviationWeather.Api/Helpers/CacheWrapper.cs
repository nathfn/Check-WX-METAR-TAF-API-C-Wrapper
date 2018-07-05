using System;
using System.Web;
using System.Web.Caching;

namespace CheckMxAviationWeather.Api.Helpers
{
    public static class CacheWrapper<T> where T : class
    {
        public static T Get(string cacheKey)
        {
            if (HttpRuntime.Cache[cacheKey] != null)
                return HttpRuntime.Cache[cacheKey] as T;
            return null;
        }

        public static void Insert(string cacheKey, T toBeInsert, int cacheTimeInMinutes)
        {
            HttpRuntime.Cache.Insert(cacheKey, toBeInsert, null, DateTime.Now.AddMinutes(cacheTimeInMinutes), Cache.NoSlidingExpiration);
        }

        public static void Remove(string cacheKey)
        {
            HttpRuntime.Cache.Remove(cacheKey);
        }
    }
}
