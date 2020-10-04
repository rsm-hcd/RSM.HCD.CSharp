using System;
using System.Linq;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Extensions.Enumerations;

namespace AndcultureCode.CSharp.Extensions
{
    /// <summary>
    /// IQueryable extension methods
    /// </summary>
    public static class IQueryableExtensions
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
        /// Order by the string expression provided.
        /// </summary>
        /// <param name="query">The IOrderedQueryable to add additional sorting to.</param>
        /// <param name="propertyName">The path to the property to order by (e.g. Path.To.Property).</param>
        /// <param name="direction">Order by which to sort items.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query,
            string propertyName, OrderByDirection direction = OrderByDirection.Ascending) => query.AppendOrderByExpression(propertyName, direction, false);

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
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        public static IQueryable<T> PickRandom<T>(this IQueryable<T> source, int count) => source.Shuffle().Take(count);

        /// <summary>
        /// Returns source enumerable in randomized order
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        public static IQueryable<T> Shuffle<T>(this IQueryable<T> source) => source.OrderBy(x => Guid.NewGuid());

        /// <summary>
        /// Order then by the string expression provided.
        /// </summary>
        /// <param name="query">The IOrderedQueryable to add additional sorting to.</param>
        /// <param name="propertyName">The path to the property to order by (e.g. Path.To.Property).</param>
        /// <param name="direction">Order by which to sort items.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> query,
            string propertyName, OrderByDirection direction = OrderByDirection.Ascending) => query.AppendOrderByExpression(propertyName, direction, true);

        #region Private Methods

        /// <summary>
        /// Adds an additional sorting expression to the supplied IQueryable.
        /// </summary>
        /// <param name="query">The IQueryable to add additional sorting to.</param>
        /// <param name="propertyName">The path to the property to order by (e.g. Path.To.Property).</param>
        /// <param name="direction">Order by which to sort items.</param>
        /// <param name="isAdditionalOrderBy">Whether the order by is an addition to an existing OrderBy statement.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static IOrderedQueryable<T> AppendOrderByExpression<T>(this IQueryable<T> query, string propertyName, OrderByDirection direction, bool isAdditionalOrderBy)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return (IOrderedQueryable<T>)query;
            }

            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            Expression body = param;

            foreach (var member in propertyName.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }

            bool isDescending = direction == OrderByDirection.Descending;
            LambdaExpression sort = Expression.Lambda(body, param);
            MethodCallExpression call = Expression.Call(
                typeof(Queryable),
                (!isAdditionalOrderBy ? "OrderBy" : "ThenBy") + (isDescending ? "Descending" : string.Empty),
                new[] { typeof(T), body.Type },
                query.Expression,
                Expression.Quote(sort));

            return (IOrderedQueryable<T>)query.Provider.CreateQuery<T>(call);
        }

        #endregion Private Methods
    }
}
