using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace RSM.HCD.CSharp.Extensions
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
        /// Returns the specified cookie by name
        ///
        /// If no cookie is found, returns null
        /// </summary>
        /// <param name="request">The request to pull the cookie from</param>
        /// <param name="name">The name of the cookie to be returned</param>
        /// <returns></returns>
        public static string GetCookie(this HttpRequest request, string name) => request.HasCookie(name) ? request.Cookies[name] : null;

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

        /// <summary>
        /// Returns whether or not the specified cookie is found in the request
        ///
        /// If the cookie is found but its value is null/whitespace, it will return false.
        /// </summary>
        /// <param name="request">The request to check for the cookie</param>
        /// <param name="name">The name of the cookie to check for</param>
        /// <returns></returns>
        public static bool HasCookie(this HttpRequest request, string name)
        {
            var cookieCollection = request?.Cookies;
            if (cookieCollection == null || !cookieCollection.ContainsKey(name) || string.IsNullOrWhiteSpace(cookieCollection[name]))
            {
                return false;
            }
            return true;
        }

        #endregion Public Methods
    }
}
