namespace CheckMxAviationWeather.Api.Models
{
    public class AviationWeatherBaseObject
    {
        /// <summary>
        /// Indicates that there was an error retrieving the data
        /// </summary>
        public bool Error { get; set; }
        /// <summary>
        /// The error text from the API
        /// </summary>
        public string ErrorText { get; set; }
    }
}
