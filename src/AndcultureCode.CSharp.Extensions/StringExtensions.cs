using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AndcultureCode.CSharp.Extensions
{
    /// <summary>
    /// String extension methods
    /// </summary>
    public static class StringExtensions
    {
        #region Public Methods

        /// <summary>
        /// Formats string for pretty printing of a JSON string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AsIndentedJson(this string str)
        {
            if (str == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return "";
            }

            dynamic resultObject = JsonConvert.DeserializeObject(str);
            return JsonConvert.SerializeObject(resultObject, Formatting.Indented);
        }

        /// <summary>
        /// Determines if the supplied string is not a valid HTTP or HTTPS Url
        ///
        /// Uses the native Uri class
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsInvalidHttpUrl(this string source) => !source.IsValidHttpUrl();

        /// <summary>
        /// Determines if the supplied string is an email address
        /// </summary>
        /// <param name="email"></param>
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (ArgumentException)
            {
                return false;
            }

            return Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

        }

        /// <summary>
        /// Determine if supplied string is a valid Guid
        /// </summary>
        /// <param name="guidString"></param>
        /// <returns></returns>
        public static bool IsValidGuid(this string guidString)
        {
            try
            {
                new Guid(guidString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determine if supplied string is not a valid Guid
        /// </summary>
        /// <param name="guidString"></param>
        /// <returns></returns>
        public static bool IsNotValidGuid(this string guidString)
        {
            return !guidString.IsValidGuid();
        }

        /// <summary>
        /// Determines if the supplied string is a valid HTTP or HTTPS url
        ///
        /// Uses the native Uri class
        /// </summary>
        /// <param name="source"></param>
        public static bool IsValidHttpUrl(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }

            var validUriSchemes = new[]
            {
                Uri.UriSchemeHttp,
                Uri.UriSchemeHttps
            };

            return Uri.TryCreate(source, UriKind.Absolute, out var uriResult) && validUriSchemes.Contains(uriResult.Scheme);
        }

        /// <summary>
        /// Converts a string representation of a boolean into an actual boolean
        /// </summary>
        public static bool ToBoolean(this string booleanAsString)
        {
            if (string.IsNullOrWhiteSpace(booleanAsString))
            {
                return false;
            }

            switch (booleanAsString.Trim().ToLower())
            {
                case "true": return true;
                case "t": return true;
                case "1": return true;
                case "0": return false;
                case "false": return false;
                case "f": return false;
                default: return false;
            }
        }

        /// <summary>
        /// Converts a string of ints into an enumerable
        /// </summary>
        /// <param name="input"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this string input, char separator = ',')
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return input.Split(separator).Where(e =>
            {
                return TryChangeType(e, typeof(T));
            }).Select(e => (T)Convert.ChangeType(e, typeof(T)));
        }


        /// <summary>
        /// Convert a string to integer, otherwise default the value
        /// </summary>
        /// <param name="number">String that should be a number</param>
        /// <param name="defaultValue">Default value used if the number cannot be parse (0 is default)</param>
        /// <returns>Converted string as an integer value</returns>
        public static int ToInt(this string number, int defaultValue = 0)
        {
            int result;

            if (int.TryParse(number, out result))
            {
                return result;
            }

            return defaultValue;
        }

        #endregion Public Methods


        #region Private Methods

        /// <summary>
        /// Returns true or false if the value can be converted
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        private static bool TryChangeType(object value, Type conversionType)
        {
            try
            {
                Convert.ChangeType(value, conversionType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion Private Methods
    }
}
