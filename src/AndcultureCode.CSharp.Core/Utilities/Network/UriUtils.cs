using System;

namespace AndcultureCode.CSharp.Core.Utilities.Network
{
    /// <summary>
    /// URI related helper functions
    /// </summary>
    public static class UriUtils
    {
        /// <summary>
        /// Is the supplied source url an invalid HTTP URL?
        /// </summary>
        /// <returns></returns>
        public static bool IsInvalidHttpUrl(string source) => !IsValidHttpUrl(source);

        /// <summary>
        /// Is the supplied source url a valid HTTP URL?
        /// </summary>
        /// <returns></returns>
        public static bool IsValidHttpUrl(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }

            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
