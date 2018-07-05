using System.Collections.Generic;

namespace CheckMxAviationWeather.Api.Extensions
{
    public static class ListExtensions
    {
        public static bool AnyNullSafe<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return false;
            using (var enumerator = list.GetEnumerator())
            {
                if (enumerator.MoveNext())
                    return true;
            }
            return false;
        }
    }
}
