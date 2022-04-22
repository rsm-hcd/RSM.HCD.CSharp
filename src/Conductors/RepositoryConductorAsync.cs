using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models.Entities;

namespace AndcultureCode.CSharp.Conductors
{
    public partial class RepositoryConductor<T> : Conductor, IRepositoryConductor<T>
    where T : Entity
    {
        #region Properties

        /// <summary>
        /// Ability to set and get the underlying repository's command timeout
        /// </summary>
        public int? CommandTimeout
        {
            get => _readConductor.CommandTimeout;
            set
            {
                _createConductor.CommandTimeout = value;
                _deleteConductor.CommandTimeout = value;
                _readConductor.CommandTimeout = value;
                _updateConductor.CommandTimeout = value;
            }
        }

        /// <summary>
        /// Conductor property to create an entity or entities
        /// </summary>
        protected readonly IRepositoryCreateConductor<T> _createConductor;

        /// <summary>
        /// Conductor property to get an entity or entities
        /// </summary>
        protected readonly IRepositoryReadConductor<T> _readConductor;

        /// <summary>
        /// Conductor property to update an entity or entities
        /// </summary>
        protected readonly IRepositoryUpdateConductor<T> _updateConductor;

        /// <summary>
        /// Conductor property to delete an entity or entities
        /// </summary>
        protected readonly IRepositoryDeleteConductor<T> _deleteConductor;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="createConductor">The conductor instance that should be used to perform create operations</param>
        /// <param name="readConductor">The conductor instance that should be used to perform read operations</param>
        /// <param name="updateConductor">The conductor instance that should be used to perform update operations</param>
        /// <param name="deleteConductor">The conductor instance that should be used to perform delete operations</param>
        public RepositoryConductor(
            IRepositoryCreateConductor<T> createConductor,
            IRepositoryReadConductor<T> readConductor,
            IRepositoryUpdateConductor<T> updateConductor,
            IRepositoryDeleteConductor<T> deleteConductor)
        {
            _createConductor = createConductor;
            _readConductor = readConductor;
            _updateConductor = updateConductor;
            _deleteConductor = deleteConductor;
        }

        #endregion Constructor

        #region Create
        /// <inheritdoc />
        public Task<IResult<List<T>>> BulkCreateAsync(IEnumerable<T> items, long? createdById = null, CancellationToken cancellationToken = default) => 
            _createConductor.BulkCreateAsync(items, createdById, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<List<T>>> BulkCreateDistinctAsync<TKey>(IEnumerable<T> items, System.Func<T, TKey> property, long? createdById = null, CancellationToken cancellationToken = default) =>
            _createConductor.BulkCreateDistinctAsync(items, property, createdById, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<T>> CreateAsync(T item, long? createdById = null, CancellationToken cancellationToken = default) => 
            _createConductor.CreateAsync(item, createdById, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<List<T>>> CreateAsync(IEnumerable<T> items, long? createdById = null, CancellationToken cancellationToken = default) =>
            _createConductor.CreateAsync(items, createdById, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<List<T>>> CreateDistinctAsync<TKey>(IEnumerable<T> items, System.Func<T, TKey> property, long? createdById = null, CancellationToken cancellationToken = default) => 
            _createConductor.CreateDistinctAsync(items, property, createdById, cancellationToken);

        #endregion Create

        #region Delete

        /// <inheritdoc />
        public Task<IResult<bool>> BulkDeleteAsync(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true, CancellationToken cancellationToken = default) => 
            _deleteConductor.BulkDeleteAsync(items, deletedById, soft, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<bool>> DeleteAsync(long id, long? deletedById = default(long?), bool soft = true, CancellationToken cancellationToken = default) => 
            _deleteConductor.DeleteAsync(id, deletedById, soft, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<bool>> DeleteAsync(T o, long? deletedById = default(long?), bool soft = true, CancellationToken cancellationToken = default) => 
            _deleteConductor.DeleteAsync(o, deletedById, soft, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<bool>> DeleteAsync(IEnumerable<T> items, long? deletedById = default(long?), long batchSize = 100, bool soft = true, CancellationToken cancellationToken = default) => 
            _deleteConductor.DeleteAsync(items, deletedById, batchSize, soft, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<bool>> RestoreAsync(T o, CancellationToken cancellationToken = default) => 
            _deleteConductor.RestoreAsync(o, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<bool>> RestoreAsync(long id, CancellationToken cancellationToken = default) => 
            _deleteConductor.RestoreAsync(id, cancellationToken);

        #endregion Delete

        #region Update

        /// <inheritdoc />
        public Task<IResult<bool>> BulkUpdateAsync(IEnumerable<T> items, long? updatedBy = default(long?), CancellationToken cancellationToken = default) => 
            _updateConductor.BulkUpdateAsync(items, updatedBy, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<bool>> UpdateAsync(T item, long? updatedBy = default(long?), CancellationToken cancellationToken = default) => 
            _updateConductor.UpdateAsync(item, updatedBy, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<bool>> UpdateAsync(IEnumerable<T> items, long? updatedBy = default(long?), CancellationToken cancellationToken = default) => 
            _updateConductor.UpdateAsync(items, updatedBy, cancellationToken);

        #endregion Update

        #region Read

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
        ) => _readConductor.FindAllAsync(
            filter,
            orderBy,
            includeProperties,
            skip,
            take,
            ignoreQueryFilters,
            asNoTracking,
            cancellationToken);

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
        ) => _readConductor.FindAllAsync(
            filter,
            orderBy,
            groupBy,
            includeProperties,
            skip,
            take,
            ignoreQueryFilters,
            asNoTracking,
            cancellationToken);

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
        ) => _readConductor.FindAllAsync(
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


        /// <inheritdoc />
        public Task<IResult<IQueryable<T>>> FindAllAsync(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false,
            CancellationToken cancellationToken = default
        ) => _readConductor.FindAllAsync(
            nextLinkParams,
            filter,
            orderBy,
            ignoreQueryFilters,
            asNoTracking,
            cancellationToken);

        /// <inheritdoc />
        public Task<IResult<IList<T>>> FindAllCommittedAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            CancellationToken cancellationToken = default
        ) => _readConductor.FindAllCommittedAsync(
            filter,
            orderBy,
            includeProperties,
            skip,
            take,
            ignoreQueryFilters,
            cancellationToken);

        /// <inheritdoc />
        public Task<IResult<IList<T>>> FindAllCommittedAsync(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            CancellationToken cancellationToken = default
        ) => _readConductor.FindAllCommittedAsync(
            nextLinkParams,
            filter,
            orderBy,
            ignoreQueryFilters,
            cancellationToken);

        #endregion FindAll

        #region FindById

        /// <inheritdoc />
        public Task<IResult<T>>FindByIdAsync(long id, bool ignoreQueryFilters = false, CancellationToken cancellationToken = default) => 
            _readConductor.FindByIdAsync(id, ignoreQueryFilters, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(long id, Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default) => 
            _readConductor.FindByIdAsync(id, filter, cancellationToken);

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(long id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includeProperties) => 
            _readConductor.FindByIdAsync(id, cancellationToken, includeProperties);

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(long id, bool ignoreQueryFilters, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includeProperties) => 
            _readConductor.FindByIdAsync(id, ignoreQueryFilters, cancellationToken, includeProperties);

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(long id, CancellationToken cancellationToken = default, params string[] includeProperties) => 
            _readConductor.FindByIdAsync(id, cancellationToken, includeProperties);

        /// <inheritdoc />
        public Task<IResult<T>> FindByIdAsync(long id, string includeProperties, CancellationToken cancellationToken = default) => 
            _readConductor.FindByIdAsync(id, cancellationToken, includeProperties);

        #endregion FindById

        #endregion Read
    }
}
