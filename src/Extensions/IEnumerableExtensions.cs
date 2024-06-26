using System;
using System.Collections.Generic;
using System.Linq;
using RSM.HCD.CSharp.Core.Extensions;
using RSM.HCD.CSharp.Extensions.Models;
using CoreExtensions = RSM.HCD.CSharp.Core.Extensions;

namespace RSM.HCD.CSharp.Extensions
{
    /// <summary>
    /// IEnumerable extension methods
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Returns items in source collection that do not exist in exclusion collection based on predicate
        /// </summary>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, IEnumerable<T> exclusions, Func<T, T, bool> predicate)
        {
            if (source.IsNullOrEmpty())
            {
                return Enumerable.Empty<T>();
            }

            if (exclusions.IsNullOrEmpty())
            {
                return source;
            }

            return source.Except(exclusions, new LambdaComparer<T>(predicate));
        }

        /// <summary>
        /// Determines if the source collection is non-null and has values
        /// </summary>
        public static bool HasValues<T>(this IEnumerable<T> source) => !source.IsNullOrEmpty();

        /// <summary>
        /// Determines if the source collection is non-null and has values
        /// </summary>
        public static bool HasValues<T>(this IEnumerable<T> source, Func<T, bool> predicate) =>
            !source.IsNullOrEmpty(predicate);

        /// <summary>
        /// Returns items in source collection that exist in inclusion collection based on the predicate
        /// </summary>
        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> source, IEnumerable<T> inclusions, Func<T, T, bool> predicate)
        {
            if (source.IsNullOrEmpty() || inclusions.IsNullOrEmpty())
            {
                return Enumerable.Empty<T>();
            }

            return source.Intersect(inclusions, new LambdaComparer<T>(predicate));
        }

        /// <summary>
        /// Returns a random value in the related IEnumerable list
        /// </summary>
        public static T PickRandom<T>(this IEnumerable<T> source) => source.PickRandom(1).SingleOrDefault();

        /// <summary>
        /// Returns X number of random values in the related IEnumerable list
        /// </summary>
        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count) => source.Shuffle().Take(count);

        /// <summary>
        /// Returns source enumerable in randomized order
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.OrderBy(x => Guid.NewGuid());
    }
}
