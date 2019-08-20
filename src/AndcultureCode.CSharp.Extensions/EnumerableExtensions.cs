using System;
using System.Collections.Generic;
using System.Linq;

namespace AndcultureCode.CSharp.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines if the source list is empty
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)                          => !source.Any();
        public static bool IsEmpty<T>(this IEnumerable<T> source, Func<T, bool> predicate) => !source.Any(predicate);

        /// <summary>
        /// Determines if the source list is null or empty
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)                          => source == null || source.IsEmpty();
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source, Func<T, bool> predicate) => source == null || source.IsEmpty(predicate);
    }
}
