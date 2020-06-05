using Microsoft.AspNetCore.Http;

namespace AndcultureCode.CSharp.Extensions
{
    /// <summary>
    /// Extension methods for HttpRequest
    /// </summary>
    public static class HttpRequestExtensions
    {
        #region Constants

        /// <summary>
        /// Standard X-Header for forwarding IP addresses in varying infrastructures
        /// </summary>
        public const string X_FORWARDED_FOR = "X-Forwarded-For";

        #endregion Constants

        #region Public Methods

        /// <summary>
        /// Retrieves the client's forwarded IP address, if present. Returns null otherwise.
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public static string GetForwardedIpAddress(this HttpRequest httpRequest)
        {
            if (httpRequest == null ||
                httpRequest.Headers == null ||
                !httpRequest.Headers.ContainsKey(X_FORWARDED_FOR) ||
                string.IsNullOrWhiteSpace(httpRequest.Headers[X_FORWARDED_FOR])
            )
            {
                return null;
            }

            return httpRequest.Headers[X_FORWARDED_FOR];
        }

        #endregion Public Methods
    }
}
