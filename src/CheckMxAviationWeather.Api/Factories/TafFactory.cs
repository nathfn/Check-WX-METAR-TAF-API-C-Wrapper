using System;
using System.Collections.Generic;
using CheckMxAviationWeather.Api.Models;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Factories
{
    internal class TafFactory
    {
        /// <summary>
        /// Building multiple objects based on a JSON string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        internal List<Taf> BuildMultiple(string json)
        {
            var returnValue = new List<Taf>();

            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<object>>>(json);

            if (asObj == null || asObj.Results == 0)
                return returnValue;

            foreach (var o in asObj.Data)
            {
                // Try to convert it!
                try
                {
                    returnValue.Add(JsonConvert.DeserializeObject<Taf>(Convert.ToString(o)));
                }
                catch (Exception)
                {
                    // IGNORED!
                }

                // IF THE API FAILS TO RETRIEVE DATA
                // IT WILL JUST RETURN A STRING WITH ERROR MESSAGE
                var asString = o as string;
                if (!string.IsNullOrEmpty(asString))
                    returnValue.Add(new Taf
                    {
                        Error = true,
                        ErrorText = asString
                    });
            }

            return returnValue;
        }
    }
}
