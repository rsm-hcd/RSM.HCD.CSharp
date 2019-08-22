using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace AndcultureCode.CSharp.Extensions
{
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
                case "true":  return true;
                case "t":     return true;
                case "1":     return true;
                case "0":     return false;
                case "false": return false;
                case "f":     return false;
                default:      return false;
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