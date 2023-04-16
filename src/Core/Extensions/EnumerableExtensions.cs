using System;
using System.Collections.Generic;
using System.Linq;

namespace AndcultureCode.CSharp.Core.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines if the source list is empty
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();

        /// <summary>
        /// Determines if the source list is empty
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> source, Func<T, bool> predicate) =>
            !source.Any(predicate);

        /// <summary>
        /// Determines if the source list is null or empty
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) =>
            source == null || source.IsEmpty();

        /// <summary>
        /// Determines if the source list is null or empty
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source, Func<T, bool> predicate) =>
            source == null || source.IsEmpty(predicate);

        /// <summary>
        /// Convenience method so joining strings reads better :)
        /// </summary>
        public static string Join(this IEnumerable<string> list, string delimiter = ", ") =>
            list == null
                ? null
                : string.Join(delimiter, list);

        /// <summary>
        /// Convenience method for joining dictionary key values into a string
        /// </summary>
        public static string Join(
            this IEnumerable<KeyValuePair<string, string>> list,
            string keyValueDelimiter,
            string delimiter = ", "
        ) => list?.Select(e => e.Join(keyValueDelimiter)).Where(e => !string.IsNullOrEmpty(e)).Join(delimiter);

        /// <summary>
        /// Convenience method for joining key value pairs
        /// </summary>
        public static string Join(this KeyValuePair<string, string> pair, string delimiter) =>
            new List<string> { pair.Key, pair.Value }
                .Where(e => !string.IsNullOrEmpty(e))
                .Join(delimiter);
    }
}
