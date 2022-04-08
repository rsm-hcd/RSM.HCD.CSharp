using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Conductors
{
    public partial interface IRepositoryReadConductor<T>
    where T : class, IEntity
    {
        #region Properties

        /// <summary>
        /// Ability to set and get the underlying DbContext's command timeout
        /// </summary>
        int? CommandTimeout { get; set; }

        #endregion Properties

        #region Methods

        #region FindAll

        /// <summary>
        /// Configure lazy loaded queryable, given provided parameters, to load a list of <typeparamref name="T"/>
        /// </summary>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <param name="skip">Number of entities that should be skipped.</param>
        /// <param name="take">Number of entities per page.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="asNoTracking">Ignore change tracking on the result. Set <code>true</code> for read-only operations.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<IQueryable<T>>> FindAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false, 
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Configure lazy loaded queryable, given provided parameters, to load a list of <typeparamref name="T"/> grouped by a <typeparamref name="TKey"/>
        /// </summary>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="groupBy">Filter to be used for grouping by <typeparamref name="TKey"/> of <typeparamref name="T"/> .</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <param name="skip">Number of entities that should be skipped.</param>
        /// <param name="take">Number of entities per page.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="asNoTracking">Ignore change tracking on the result. Set <code>true</code> for read-only operations.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<IQueryable<IGrouping<TKey, T>>>> FindAllAsync<TKey>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TKey>> groupBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false, 
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Configure lazy loaded queryable, given provided parameters, to load a list of <typeparamref name="T"/>
        /// grouped by a <typeparamref name="TKey"/> and selected by groupBySelector tranformed into <typeparamref name="TResult"/>
        /// ref to microsoft docs: https://shorturl.at/jptP3
        /// </summary>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="groupBy">Filter to be used for grouping by <typeparamref name="TKey"/> of <typeparamref name="T"/> .</param>
        /// <param name="groupBySelector">Selector to be used on groupBy used to create a result of <typeparamref name="TResult"/> value from each group.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <param name="skip">Number of entities that should be skipped.</param>
        /// <param name="take">Number of entities per page.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="asNoTracking">Ignore change tracking on the result. Set <code>true</code> for read-only operations.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<IQueryable<TResult>>> FindAllAsync<TKey, TResult>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TKey>> groupBy = null,
            Expression<Func<TKey, IEnumerable<T>, TResult>> groupBySelector = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Alternative FindAll for retrieving records using NextLinkParams in place of traditional
        /// determinate pagination mechanisms, such as; skip and take.
        /// </summary>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="nextLinkParams"></param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="asNoTracking">Ignore change tracking on the result. Set <code>true</code> for read-only operations.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<IQueryable<T>>> FindAllAsync(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false, 
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Similar to FindAll, this evaluates the parameters as given. The big difference here is that the query is executed
        /// inside the conductor and a List<typeparamref name="T"/> is returned and NOT Queryable<typeparamref name="T"/>.  This is primary used in cases where calculated
        /// fields need to be executed (committed) inside the conductor.
        /// </summary>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <param name="skip">Number of entities that should be skipped.</param>
        /// <param name="take">Number of entities per page.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<IList<T>>> FindAllCommittedAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Alternative FindAll for retrieving records using NextLinkParams in place of traditional
        /// determinate pagination mechanisms, such as; skip and take.
        /// </summary>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="nextLinkParams"></param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<IList<T>>> FindAllCommittedAsync(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false, 
            CancellationToken cancellationToken = default
        );

        #endregion FindAll

        #region FindById

        /// <summary>
        /// Finds an entity by its Id.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns>The entity with the provided identity value.</returns>
        Task<IResult<T>> FindByIdAsync(long id, bool ignoreQueryFilters = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds an entity by its Id that also matches a filter.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns>The entity witht he provided identity value and filter condition met.</returns>
        Task<IResult<T>> FindByIdAsync(long id, Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds an entity by its Id.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns>The entity with the provided identity value.</returns>
        Task<IResult<T>> FindByIdAsync(long id, CancellationToken cancellationToken = default,  params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Finds an entity by its Id.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns>The entity with the provided identity value.</returns>
        Task<IResult<T>> FindByIdAsync(long id, bool ignoreQueryFilters, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Finds an entity by its Id.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns>The entity with the provided identity value.</returns>
        Task<IResult<T>> FindByIdAsync(long id, CancellationToken cancellationToken = default, params string[] includeProperties);

        #endregion FindById

        #endregion Methods

    }
}
