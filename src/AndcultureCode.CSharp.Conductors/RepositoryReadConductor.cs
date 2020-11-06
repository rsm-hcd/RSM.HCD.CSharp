using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    /// <summary>
    /// Provides read operations on a given repository.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public class RepositoryReadConductor<T> : Conductor, IRepositoryReadConductor<T>
        where T : class, IEntity
    {
        #region Properties

        /// <summary>
        /// Ability to set and get the underlying Repository's command timeout.
        /// </summary>
        public int? CommandTimeout
        {
            get => _repository.CommandTimeout;
            set => _repository.CommandTimeout = value;
        }

        readonly IRepository<T> _repository;

        #endregion Properties


        #region Constructor

        /// <summary>
        /// Creates an instance of RepositoryReadConductor for an <see cref="IRepository{T}"/> instance.
        /// </summary>
        /// <param name="repository">The Repository instance that should be used to perform read operations.</param>
        public RepositoryReadConductor(IRepository<T> repository)
        {
            _repository = repository;
        }

        #endregion Constructor


        #region IRepositoryReadConductor Implementation

        #region FindAll

        /// <summary>
        /// Find all filtered, sorted and paged.
        /// </summary>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <param name="skip">Number of entities that should be skipped.</param>
        /// <param name="take">Number of entities per page.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="asNoTracking">Ignore change tracking on the result. Set <code>true</code> for read-only operations.</param>
        /// <returns>A queryable collection of entities for the given criteria.</returns>
        public virtual IResult<IQueryable<T>> FindAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _repository.FindAll(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);

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
        /// <returns></returns>
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

        /// <summary>
        /// Configure lazy loaded queryable, given provided parameters, to load a list of <typeparamref name="T"/>
        /// grouped by a <typeparamref name="TKey"/> and selected by groupBySelector tranformed into <typeparamref name="TResult"/>
        /// ref to: https://docs.microsoft.com/en-us/dotnet/api/system.linq.queryable.groupby?view=netcore-3.1#System_Linq_Queryable_GroupBy__3_System_Linq_IQueryable___0__System_Linq_Expressions_Expression_System_Func___0___1___System_Linq_Expressions_Expression_System_Func___1_System_Collections_Generic_IEnumerable___0____2___
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
        /// <returns></returns>
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

        /// <summary>
        /// Alternative FindAll for retrieving records using NextLinkParams in place of traditional
        /// determinate pagination mechanisms, such as; skip and take.
        /// </summary>
        /// <param name="nextLinkParams">Currently nothing is provided for NextLinkParams by this base class. Exists for overriding subclasses.</param>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="asNoTracking">Ignore change tracking on the result. Set <code>true</code> for read-only operations.</param>
        /// <returns>A queryable collection of entities for the given criteria.</returns>
        public virtual IResult<IQueryable<T>> FindAll(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _repository.FindAll(filter, orderBy, ignoreQueryFilters: ignoreQueryFilters, asNoTracking: asNoTracking);

        /// <summary>
        /// Similar to FindAll but loading the result into memory.
        /// </summary>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <param name="skip">Number of entities that should be skipped.</param>
        /// <param name="take">Number of entities per page.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <returns>An in-memory collection of entities for the given criteria.</returns>
        public virtual IResult<IList<T>> FindAllCommitted(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false
        ) => _repository.FindAllCommitted(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters);

        /// <summary>
        /// Similar to FindAll but loading the result into memory.
        /// </summary>
        /// <param name="nextLinkParams">Currently nothing is provided for NextLinkParams by this base class. Exists for overriding subclasses.</param>
        /// <param name="filter">Filter to be used for querying.</param>
        /// <param name="orderBy">Properties that should be used for sorting.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <returns>An in-memory collection of entities for the given criteria.</returns>
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
        public virtual IResult<T> FindById(long id, Expression<Func<T, bool>> filter)
        {
            return _repository.FindById(id, filter);
        }

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
