using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

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
        /// Attempts to retrieve requested header value
        /// </summary>
        /// <param name="request"></param>
        /// <param name="name">Header name/key</param>
        public static string GetHeader(this HttpRequest request, string name)
        {
            var headers = request?.Headers;
            if (headers == null || !headers.ContainsKey(name) || string.IsNullOrWhiteSpace(request.Headers[name]))
            {
                return null;
            }

            return request.Headers[name];
        }

        /// <summary>
        /// Retrieves the client's forwarded IP address, if present. Returns null otherwise.
        /// Ensure you have 'AddForwardedHeaders' enabled in startup.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetIpAddress(this HttpRequest request) => request.GetHeader(X_FORWARDED_FOR);

        /// <summary>
        /// Requesting user's agent
        /// </summary>
        public static string GetUserAgent(this HttpRequest request) => request.GetHeader(HeaderNames.UserAgent);

        #endregion Public Methods
    }
}
