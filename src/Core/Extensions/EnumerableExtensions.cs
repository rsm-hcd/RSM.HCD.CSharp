using System;
using System.Collections.Generic;
using System.Linq;

namespace RSM.HCD.CSharp.Core.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines if the source list is empty
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();

        /// <summary>
        /// Determines if the source list is null or empty
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) =>
            source == null || source.IsEmpty();

        /// <summary>
        /// Convenience method so joining strings reads better :)
        /// </summary>
        public static string Join(this IEnumerable<string> list, string delimiter = ", ") =>
            list == null
                ? null
                : string.Join(delimiter, list);
    }
}
