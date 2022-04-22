using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    /// <summary>
    /// Provides read operations on a given repository.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public partial class RepositoryReadConductor<T> : Conductor, IRepositoryReadConductor<T>
        where T : class, IEntity
    {
        #region IRepositoryReadConductor Implementation

        #region FindAll

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<IQueryable<T>> FindAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _repository.FindAll(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public IResult<IQueryable<IGrouping<TKey, T>>> FindAll<TKey>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TKey>> groupBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _repository.FindAll(filter, orderBy, groupBy, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public IResult<IQueryable<TResult>> FindAll<TKey, TResult>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TKey>> groupBy = null,
            Expression<Func<TKey, IEnumerable<T>, TResult>> groupBySelector = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _repository.FindAll(filter, orderBy, groupBy, groupBySelector, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<IQueryable<T>> FindAll(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _repository.FindAll(filter, orderBy, ignoreQueryFilters: ignoreQueryFilters, asNoTracking: asNoTracking);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<IList<T>> FindAllCommitted(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false
        ) => _repository.FindAllCommitted(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<IList<T>> FindAllCommitted(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false
        ) => _repository.FindAllCommitted(filter, orderBy, ignoreQueryFilters: ignoreQueryFilters);

        #endregion FindAll


        #region FindById

        /// <summary>
        /// Finds an entity by its ID.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public virtual IResult<T> FindById(long id)
        {
            return _repository.FindById(id);
        }

        /// <summary>
        /// Finds an entity by its Id that also matches a filter.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public virtual IResult<T> FindById(long id, Expression<Func<T, bool>> filter) => _repository.FindById(id, filter);

        /// <summary>
        /// Finds an entity by its ID.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public virtual IResult<T> FindById(long id, bool ignoreQueryFilters, params Expression<Func<T, object>>[] includeProperties)
        {
            return _repository.FindById(id, ignoreQueryFilters, includeProperties);
        }

        /// <summary>
        /// Finds an entity by its ID.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public virtual IResult<T> FindById(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            return _repository.FindById(id, includeProperties);
        }

        /// <summary>
        /// Finds an entity by its ID.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public virtual IResult<T> FindById(long id, params string[] includeProperties)
        {
            return _repository.FindById(id, includeProperties);
        }

        #endregion FindById

        #endregion IRepositoryReadConductor Implementation
    }
}
