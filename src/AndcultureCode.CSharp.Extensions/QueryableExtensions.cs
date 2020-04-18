using System;
using System.Linq;
using System.Linq.Expressions;

namespace AndcultureCode.CSharp.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Determines if the source list is empty
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IQueryable<T> source) => !source.Any();

        /// <summary>
        /// Determines if the source list is empty (based on the given predicate)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate) => !source.Any(predicate);

        /// <summary>
        /// Determines if the source list is null or empty
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IQueryable<T> source) => source == null || source.IsEmpty();

        /// <summary>
        /// Determines if the source list is null or empty (based on the given predicate)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate) => source == null || source.IsEmpty(predicate);

        /// <summary>
        /// Returns a random value in the related IQueryable list
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        public static T PickRandom<T>(this IQueryable<T> source) => source.PickRandom(1).SingleOrDefault();

        /// <summary>
        /// Returns X number of random values in the related IQueryable list
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        public static IQueryable<T> PickRandom<T>(this IQueryable<T> source, int count) => source.Shuffle().Take(count);

        /// <summary>
        /// Returns source enumerable in randomized order
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        public static IQueryable<T> Shuffle<T>(this IQueryable<T> source) => source.OrderBy(x => Guid.NewGuid());
    }
}
