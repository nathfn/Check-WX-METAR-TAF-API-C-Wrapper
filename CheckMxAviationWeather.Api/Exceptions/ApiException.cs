using System;

namespace CheckMxAviationWeather.Api.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// A custom exception used when the API returns an error. This exception provides you with direct access to the return HTTP status code and the raw JSON with the error description
    /// </summary>
    /// <seealso cref="T:System.Exception" />
    public class ApiException : Exception
    {
        /// <summary>
        /// Gets or sets the raw JSON response from the Streak API endpoint. 
        /// </summary>
        /// <value>
        /// The raw json response.
        /// </value>
        public string RawJsonResponse { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code returned from the API call
        /// </summary>
        /// <value>
        /// The HTTP status code.
        /// </value>
        public int HttpStatusCode { get; set; }

        public ApiException(string message, Exception innerException, string rawJsonResponse, int httpStatusCode) : base(message, innerException)
        {
            RawJsonResponse = rawJsonResponse;
            HttpStatusCode = httpStatusCode;
        }
    }
}
