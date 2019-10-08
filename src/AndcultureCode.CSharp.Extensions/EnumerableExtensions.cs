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

        /// <summary>
        /// Convenience method so joining strings reads better :)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> list, string delimiter = ", ") => list?.ToList().Join(delimiter);

        /// <summary>
        /// Convenience method so joining a list of strings
        /// </summary>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string Join(this List<string> list, string delimiter = ", ")
        {
            return list == null ? null : string.Join(delimiter, list);
        }

        /// <summary>
        /// Returns a random value in the related IEnumerable list
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        public static T PickRandom<T>(this IEnumerable<T> source) => source.PickRandom(1).SingleOrDefault();

        /// <summary>
        /// Returns X number of random values in the related IEnumerable list
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count) => source.Shuffle().Take(count);

        /// <summary>
        /// Returns source enumerable in randomized order
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.OrderBy(x => Guid.NewGuid());
    }
}
