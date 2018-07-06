using System;
using System.Collections.Generic;
using System.Linq;
using CheckMxAviationWeather.Api.Models;
using Newtonsoft.Json;

namespace CheckMxAviationWeather.Api.Factories
{
    internal class MetarFactory
    {
        /// <summary>
        /// Building multiple objects based on a JSON string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        internal List<Metar> BuildMultiple(string json)
        {
            var returnValue = new List<Metar>();

            var asObj = JsonConvert.DeserializeObject<ApiResponseObject<List<object>>>(json);

            if (asObj == null || asObj.Results == 0)
                return returnValue;

            foreach (var o in asObj.Data)
            {
                // Try to convert it!
                try
                {
                    returnValue.Add(JsonConvert.DeserializeObject<Metar>(Convert.ToString(o)));
                }
                catch (Exception)
                {
                    // IGNORED!
                }

                // IF THE API FAILS TO RETRIEVE DATA
                // IT WILL JUST RETURN A STRING WITH ERROR MESSAGE
                var asString = o as string;
                if (!string.IsNullOrEmpty(asString))
                    returnValue.Add(new Metar
                    {
                        Error = true,
                        ErrorText = asString
                    });
            }

            return returnValue;
        }
    }
}
