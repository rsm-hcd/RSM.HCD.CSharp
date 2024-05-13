using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RSM.HCD.CSharp.Core.Extensions;

namespace RSM.HCD.CSharp.Core.Utilities.Caching
{
    /// <summary>
    /// Eased creation of cache keys
    /// </summary>
    public static class CacheKeys
    {
        #region Properties

        /// <summary>
        /// Default delimiter used for creating cache keys
        /// </summary>
        public const string DEFAULT_DELIMITER = "-";

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Construct standardized cache keys for entities with optional include properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        public static string GetKey<T>(long id, List<Expression<Func<T, object>>> includeProperties)
            => GetKey<T, T>(id, DEFAULT_DELIMITER, includeProperties);

        /// <summary>
        /// Construct standardized cache keys for entities with optional include properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        public static string GetKey<T, TProperties>(long id, List<Expression<Func<TProperties, object>>> includeProperties)
            => GetKey<T, TProperties>(id, DEFAULT_DELIMITER, includeProperties);

        /// <summary>
        /// Construct standardized cache keys for entities with optional include properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="delimiter"></param>
        /// <param name="includeProperties"></param>
        public static string GetKey<T>(
            long id,
            string delimiter = DEFAULT_DELIMITER,
            List<Expression<Func<T, object>>> includeProperties = null
        ) => GetKey<T, T>(id, delimiter, includeProperties);

        /// <summary>
        /// Construct standardized cache keys for entities with optional include properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="delimiter"></param>
        /// <param name="includeProperties"></param>
        public static string GetKey<T, TProperties>(
            long id,
            string delimiter = DEFAULT_DELIMITER,
            List<Expression<Func<TProperties, object>>> includeProperties = null
        ) => AppendIncludeProperties($"{typeof(T).Name}{delimiter}{id}", delimiter, includeProperties);

        #endregion Public Methods

        #region Private Methods

        private static string AppendIncludeProperties<T>(string key, string delimiter, List<Expression<Func<T, object>>> includeProperties = null)
        {
            if (includeProperties.IsNullOrEmpty())
            {
                return key;
            }

            var names = includeProperties
                .Select(GetPropertyName)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            return $"{key}{delimiter}{string.Join(delimiter, names)}";
        }

        private static string GetPropertyName<T>(Expression<Func<T, Object>> expression)
        {
            if (expression.Body is MemberExpression)
            {
                return ((MemberExpression)expression.Body).Member.Name;
            }

            var op = ((UnaryExpression)expression.Body).Operand;
            return ((MemberExpression)op).Member.Name;
        }

        #endregion Private Methods
    }
}
