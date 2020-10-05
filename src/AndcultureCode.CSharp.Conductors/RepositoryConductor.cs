using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Core;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models.Entities;

namespace AndcultureCode.CSharp.Conductors
{
    /// <summary>
    /// Provides CRUD operations on a given repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryConductor<T> : Conductor, IRepositoryConductor<T>
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
                _readConductor.CommandTimeout   = value;
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
        protected readonly IRepositoryReadConductor<T>   _readConductor;

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
            IRepositoryReadConductor<T>   readConductor,
            IRepositoryUpdateConductor<T> updateConductor,
            IRepositoryDeleteConductor<T> deleteConductor)
        {
            _createConductor = createConductor;
            _readConductor   = readConductor;
            _updateConductor = updateConductor;
            _deleteConductor = deleteConductor;
        }

        #endregion Constructor

        #region Public Methods

        #region Create

        /// <summary>
        /// Ability to create entities using a list in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to create</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        public virtual IResult<List<T>> BulkCreate(IEnumerable<T> items, long? createdById = default(long?)) => _createConductor.BulkCreate(items, createdById);

        /// <summary>
        /// Ability to create entities using a list in a single bulk operation without duplicates.
        /// </summary>
        /// <param name="items">List of items to create</param>
        /// <param name="property">Property used to remove duplicates</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        public virtual IResult<List<T>> BulkCreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null) => _createConductor.BulkCreateDistinct(items, property, createdById);

        /// <summary>
        /// Ability to create an entity 
        /// </summary>
        /// <param name="item">Item to be created</param>
        /// <param name="createdById">Id of user creating the item</param>
        /// <returns></returns>
        public virtual IResult<T> Create(T item, long? createdById = default(long?)) => _createConductor.Create(item, createdById);

        /// <summary>
        /// Ability to create entities individually using a list 
        /// </summary>
        /// <param name="items">List of items to be created</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        public virtual IResult<List<T>> Create(IEnumerable<T> items, long? createdById = default(long?)) => _createConductor.Create(items, createdById);

        /// <summary>
        /// Ability to create entities individually without duplicates
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="items">List of items to create</param>
        /// <param name="property">Property used to remove duplicates</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        public virtual IResult<List<T>> CreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null) => _createConductor.CreateDistinct(items, property, createdById);

        #endregion Create

        #region CreateOrUpdate

        /// <summary>
        /// Ability to create or update a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to create or update</param>
        /// <param name="createdOrUpdatedById">Id of user creating or updating the entity</param>
        /// <returns></returns>
        public virtual IResult<IEnumerable<T>> BulkCreateOrUpdate(IEnumerable<T> items, long? createdOrUpdatedById = default(long?)) => Do<IEnumerable<T>>.Try((r) =>
        {
            if (items == null || !items.Any())
            {
                return items;
            }

            // Update first in case item Ids get updated in cache -- we don't want to update just-created items.
            var updateResult = BulkUpdate(items.Where(e => e.Id > 0), createdOrUpdatedById);
            if (updateResult.HasErrors || !updateResult.ResultObject)
            {
                r.AddErrors(updateResult.Errors);
            }

            var enumerableList = new List<T>();

            var createResult = BulkCreate(items.Where(e => e.Id <= 0), createdOrUpdatedById);
            if (createResult.HasErrors || createResult.ResultObject == null)
            {
                r.AddErrors(createResult.Errors);
            }

            if (createResult.ResultObject != null)
            {
                enumerableList.AddRange(createResult.ResultObject);
            }

            return enumerableList;
        })
        .Result;

        /// <summary>
        /// Ability to create or update an entity
        /// </summary>
        /// <param name="item">Item to create or update</param>
        /// <param name="createdOrUpdatedById">Id of user creating or updating the entity</param>
        /// <returns></returns>
        public virtual IResult<T> CreateOrUpdate(T item, long? createdOrUpdatedById = default(long?)) => Do<T>.Try((r) =>
        {
            // Create
            if (item.Id <= 0)
            {
                var createResult = Create(item, createdOrUpdatedById);
                if (createResult.HasErrors || createResult.ResultObject == null)
                {
                    r.AddErrors(createResult.Errors);
                    return null;
                }
                return createResult.ResultObject;
            }

            // Update
            var updateResult = Update(item, createdOrUpdatedById);
            if (updateResult.HasErrors || !updateResult.ResultObject)
            {
                r.AddErrors(updateResult.Errors);
                return null;
            }
            return item;
        })
        .Result;

        /// <summary>
        /// Ability to create or update a list of items but each item is created or updated individually.
        /// </summary>
        /// <param name="items">List of items to create or update</param>
        /// <param name="createdOrUpdatedById">Id of user creating or updating the entities</param>
        /// <returns></returns>
        public virtual IResult<IEnumerable<T>> CreateOrUpdate(IEnumerable<T> items, long? createdOrUpdatedById = default(long?)) => Do<IEnumerable<T>>.Try((r) =>
        {
            var enumerableList = new List<T>();
            // Update
            var updateResult = Update(items.Where(e => e.Id > 0), createdOrUpdatedById);
            if (updateResult.HasErrorsOrResultIsFalse())
            {
                r.AddErrors(updateResult.Errors);
            }

            // Create
            var createResult = Create(items.Where(e => e.Id <= 0), createdOrUpdatedById);
            if (createResult.HasErrorsOrResultIsNull())
            {
                r.AddErrors(createResult.Errors);
            }

            if (createResult.ResultObject != null)
            {
                enumerableList.AddRange(createResult.ResultObject);
            }

            return enumerableList;
        })
        .Result;

        #endregion CreateOrUpdate

        #region Delete

        /// <summary>
        /// Ability to delete a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to delete</param>
        /// <param name="deletedById">Id of user deleting the items</param>
        /// <param name="soft">Boolean flag for soft-deleting items</param>
        /// <returns></returns>
        public virtual IResult<bool> BulkDelete(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true) => _deleteConductor.BulkDelete(items, deletedById, soft);

        /// <summary>
        /// Ability to delete an entity using an Id
        /// </summary>
        /// <param name="id">Id of item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <returns></returns>
        public virtual IResult<bool> Delete(long id, long? deletedById = default(long?), bool soft = true) => _deleteConductor.Delete(id, deletedById, soft);

        /// <summary>
        /// Ability to delete an entity using the entity itself
        /// </summary>
        /// <param name="o">Item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <returns></returns>
        public virtual IResult<bool> Delete(T o, long? deletedById = default(long?), bool soft = true) => _deleteConductor.Delete(o, deletedById, soft);

        /// <summary>
        /// Ability to delete a list of entities by batch size.
        /// </summary>
        /// <param name="items">List of items to delete</param>
        /// <param name="deletedById">Id of user deleting the items</param>
        /// <param name="batchSize">Number of items to include in a batch, defaults to 100</param>
        /// <param name="soft">Boolean flag for soft-deleting the items</param>
        /// <returns></returns>
        public virtual IResult<bool> Delete(IEnumerable<T> items, long? deletedById = default(long?), long batchSize = 100, bool soft = true) => _deleteConductor.Delete(items, deletedById, batchSize, soft);

        /// <summary>
        /// Ability to restore a soft-deleted entity using the entity itself. 
        /// </summary>
        /// <param name="o">Entity to be restored</param>
        /// <returns></returns>
        public virtual IResult<bool> Restore(T o) => _deleteConductor.Restore(o);

        /// <summary>
        /// Ability to restore a soft-deleted entity using the entity id.
        /// </summary>
        /// <param name="id">Id of entity to be restored</param>
        /// <returns></returns>
        public virtual IResult<bool> Restore(long id) => _deleteConductor.Restore(id);

        #endregion Delete

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
        ) => _readConductor.FindAll(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);

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
        ) => _readConductor.FindAll(nextLinkParams, filter, orderBy, ignoreQueryFilters, asNoTracking);

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
        ) => _readConductor.FindAllCommitted(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters);

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
        ) => _readConductor.FindAllCommitted(nextLinkParams, filter, orderBy, ignoreQueryFilters);

        #endregion FindAll

        #region FindById

        /// <summary>
        /// Finds an entity by its Id.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public virtual IResult<T> FindById(long id) => _readConductor.FindById(id);

        /// <summary>
        /// Finds an entity by its Id.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public virtual IResult<T> FindById(long id, params Expression<Func<T, object>>[] includeProperties) => _readConductor.FindById(id, includeProperties);

        /// <summary>
        /// Finds an entity by its Id.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="ignoreQueryFilters">If true, global query filters will be ignored for this query.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public virtual IResult<T> FindById(long id, bool ignoreQueryFilters, params Expression<Func<T, object>>[] includeProperties) => _readConductor.FindById(id, ignoreQueryFilters, includeProperties);

        /// <summary>
        /// Finds an entity by its Id.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="includeProperties">Navigation properties that should be included.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public IResult<T> FindById(long id, params string[] includeProperties) => _readConductor.FindById(id, includeProperties);

        /// <summary>
        /// Finds an entity by its Id.
        /// </summary>
        /// <param name="id">The entity identity value.</param>
        /// <param name="includeProperties">Navigation property that should be included.</param>
        /// <returns>The entity with the provided identity value.</returns>
        public IResult<T> FindById(long id, string includeProperties) => _readConductor.FindById(id, includeProperties);

        #endregion FindById

        #region Update

        /// <summary>
        /// Ability to update a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <returns></returns>
        public virtual IResult<bool> BulkUpdate(IEnumerable<T> items, long? updatedBy = default(long?)) => _updateConductor.BulkUpdate(items, updatedBy);

        /// <summary>
        /// Ability to update an entity
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <returns></returns>
        public virtual IResult<bool> Update(T item, long? updatedBy = default(long?)) => _updateConductor.Update(item, updatedBy);

        /// <summary>
        /// Ability to update a list of items but each item is updated individually.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <returns></returns>
        public virtual IResult<bool> Update(IEnumerable<T> items, long? updatedBy = default(long?)) => _updateConductor.Update(items, updatedBy);

        #endregion Update

        #endregion Public Methods
    }
}
