using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Conductors
{
    public interface IRepositoryReadConductor<T>
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
        /// Configure lazy loaded queryable, given provided parameters, to load a list of <T>
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="ignoreQueryFilters"></param>
        /// <returns></returns>
        IResult<IQueryable<T>> FindAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
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
        /// <returns></returns>
        IResult<IQueryable<IGrouping<TKey, T>>> FindAll<TKey>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TKey>> groupBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        );

        /// <summary>
        /// Altenative FindAll for retrieving records using NextLinkParams in place of tranditonal
        /// determinate pagination mechanisms, such as; skip and take.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="nextLinkParams"></param>
        /// <returns></returns>
        IResult<IQueryable<T>> FindAll(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        );


        /// <summary>
        /// Similar to FindAll, this evaluates the parameters as given. The big difference here is that the query is executed
        /// inside the conductor and a List<T> is returned and NOT Queryable<T>.  This is primary used in cases where calculated
        /// fields need to be executed (committed) inside the conductor.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="ignoreQueryFilters"></param>
        /// <returns></returns>
        IResult<IList<T>> FindAllCommitted(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false
        );

        /// <summary>
        /// Altenative FindAll for retrieving records using NextLinkParams in place of tranditonal
        /// determinate pagination mechanisms, such as; skip and take.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="nextLinkParams"></param>
        /// <returns></returns>
        IResult<IList<T>> FindAllCommitted(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false
        );

        #endregion FindAll


        #region FindById

        IResult<T> FindById(long id);
        IResult<T> FindById(long id, params Expression<Func<T, object>>[] includeProperties);
        IResult<T> FindById(long id, bool ignoreQueryFilters, params Expression<Func<T, object>>[] includeProperties);
        IResult<T> FindById(long id, params string[] includeProperties);

        #endregion FindById

        #endregion Methods

    }
}