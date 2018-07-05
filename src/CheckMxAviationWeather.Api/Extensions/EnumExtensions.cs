using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CheckMxAviationWeather.Api.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this System.Enum value, string defaultValue = null)
        {
            return value.GetEnumAttribute<DescriptionAttribute>(a => a.Description, defaultValue);
        }

        private static string GetEnumAttribute<TAttr>(this System.Enum value, Func<TAttr, string> expr, string defaultValue = null) where TAttr : Attribute
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = fi.GetCustomAttributes<TAttr>(false).ToArray();
            return (attributes.Length > 0) ? expr(attributes.First()) : (defaultValue ?? value.ToString());
        }
    }
}
