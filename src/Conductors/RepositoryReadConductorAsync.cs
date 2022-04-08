using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    public partial class RepositoryReadConductor<T> : Conductor, IRepositoryReadConductor<T>
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

        /// <inheritdoc />
        public Task<IResult<IQueryable<T>>> FindAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindAllAsync(
            filter,
            orderBy,
            includeProperties,
            skip,
            take,
            ignoreQueryFilters,
            asNoTracking,
            cancellationToken);
        }
        

        /// <inheritdoc />
        public Task<IResult<IQueryable<IGrouping<TKey, T>>>> FindAllAsync<TKey>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TKey>> groupBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindAllAsync(
            filter,
            orderBy,
            groupBy,
            includeProperties,
            skip,
            take,
            ignoreQueryFilters,
            asNoTracking,
            cancellationToken);
        }
        

        /// <inheritdoc />
        public Task<IResult<IQueryable<TResult>>> FindAllAsync<TKey, TResult>(
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
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindAllAsync(
            filter,
            orderBy,
            groupBy,
            groupBySelector,
            includeProperties,
            skip,
            take,
            ignoreQueryFilters,
            asNoTracking,
            cancellationToken);
        }
        

        /// <inheritdoc />
        public Task<IResult<IQueryable<T>>> FindAllAsync(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindAllAsync(
            filter,
            orderBy,
            ignoreQueryFilters: ignoreQueryFilters,
            asNoTracking: asNoTracking,
            cancellationToken: cancellationToken);
        }


        /// <inheritdoc />
        public Task<IResult<IList<T>>> FindAllCommittedAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindAllCommittedAsync(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters, cancellationToken);
        }
        

        /// <inheritdoc />
        public Task<IResult<IList<T>>> FindAllCommittedAsync(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindAllCommittedAsync(
            filter,
            orderBy,
            ignoreQueryFilters: ignoreQueryFilters,
            cancellationToken: cancellationToken);
        }
        

        #endregion FindAll


        #region FindById

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(long id, bool ignoreQueryFilters = false, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindByIdAsync(id, ignoreQueryFilters, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(
            long id,
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindByIdAsync(id, filter, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(long id,
            bool ignoreQueryFilters,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[] includeProperties)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindByIdAsync(id, ignoreQueryFilters, cancellationToken, includeProperties);
        }

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(long id,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[] includeProperties)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindByIdAsync(id, cancellationToken, includeProperties);
        }

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(long id,
            CancellationToken cancellationToken = default,
            params string[] includeProperties)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.FindByIdAsync(id, cancellationToken, includeProperties);
        }

        #endregion FindById

        #endregion IRepositoryReadConductor Implementation
    }
}
