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
    public partial class RepositoryConductor<T> : Conductor, IRepositoryConductor<T>
    where T : Entity
    {
        #region Public Methods

        #region Create

        /// <summary>
        /// Ability to create entities using a list in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to create</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns>A collection of the created items</returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<List<T>> BulkCreate(IEnumerable<T> items, long? createdById = default(long?)) => _createConductor.BulkCreate(items, createdById);

        /// <summary>
        /// Ability to create entities using a list in a single bulk operation without duplicates.
        /// </summary>
        /// <param name="items">List of items to create</param>
        /// <param name="property">Property used to remove duplicates</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<List<T>> BulkCreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null) => _createConductor.BulkCreateDistinct(items, property, createdById);

        /// <summary>
        /// Ability to create an entity 
        /// </summary>
        /// <param name="item">Item to be created</param>
        /// <param name="createdById">Id of user creating the item</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<T> Create(T item, long? createdById = default(long?)) => _createConductor.Create(item, createdById);

        /// <summary>
        /// Ability to create entities individually using a list 
        /// </summary>
        /// <param name="items">List of items to be created</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<List<T>> Create(IEnumerable<T> items, long? createdById = default(long?)) => _createConductor.Create(items, createdById);

        /// <summary>
        /// Ability to create entities individually without duplicates
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="items">List of items to create</param>
        /// <param name="property">Property used to remove duplicates</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
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
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> BulkDelete(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true) => _deleteConductor.BulkDelete(items, deletedById, soft);

        /// <summary>
        /// Ability to delete an entity using an Id
        /// </summary>
        /// <param name="id">Id of item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Delete(long id, long? deletedById = default(long?), bool soft = true) => _deleteConductor.Delete(id, deletedById, soft);

        /// <summary>
        /// Ability to delete an entity using the entity itself
        /// </summary>
        /// <param name="o">Item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Delete(T o, long? deletedById = default(long?), bool soft = true) => _deleteConductor.Delete(o, deletedById, soft);

        /// <summary>
        /// Ability to delete a list of entities by batch size.
        /// </summary>
        /// <param name="items">List of items to delete</param>
        /// <param name="deletedById">Id of user deleting the items</param>
        /// <param name="batchSize">Number of items to include in a batch, defaults to 100</param>
        /// <param name="soft">Boolean flag for soft-deleting the items</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Delete(IEnumerable<T> items, long? deletedById = default(long?), long batchSize = 100, bool soft = true) => _deleteConductor.Delete(items, deletedById, batchSize, soft);

        /// <summary>
        /// Ability to restore a soft-deleted entity using the entity itself. 
        /// </summary>
        /// <param name="o">Entity to be restored</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Restore(T o) => _deleteConductor.Restore(o);

        /// <summary>
        /// Ability to restore a soft-deleted entity using the entity id.
        /// </summary>
        /// <param name="id">Id of entity to be restored</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Restore(long id) => _deleteConductor.Restore(id);

        #endregion Delete

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
        ) => _readConductor.FindAll(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);

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
        ) => _readConductor.FindAll(filter, orderBy, groupBy, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);

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
        ) => _readConductor.FindAll(filter, orderBy, groupBy, groupBySelector, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);


        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<IQueryable<T>> FindAll(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _readConductor.FindAll(nextLinkParams, filter, orderBy, ignoreQueryFilters, asNoTracking);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<IList<T>> FindAllCommitted(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false
        ) => _readConductor.FindAllCommitted(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<IList<T>> FindAllCommitted(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false
        ) => _readConductor.FindAllCommitted(nextLinkParams, filter, orderBy, ignoreQueryFilters);

        #endregion FindAll

        #region FindById

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<T> FindById(long id) => _readConductor.FindById(id);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<T> FindById(long id, Expression<Func<T, bool>> filter) => _readConductor.FindById(id, filter);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<T> FindById(long id, params Expression<Func<T, object>>[] includeProperties) => _readConductor.FindById(id, includeProperties);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<T> FindById(long id, bool ignoreQueryFilters, params Expression<Func<T, object>>[] includeProperties) => _readConductor.FindById(id, ignoreQueryFilters, includeProperties);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public IResult<T> FindById(long id, params string[] includeProperties) => _readConductor.FindById(id, includeProperties);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public IResult<T> FindById(long id, string includeProperties) => _readConductor.FindById(id, includeProperties);

        #endregion FindById

        #region Update

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> BulkUpdate(IEnumerable<T> items, long? updatedBy = default(long?)) => 
            _updateConductor.BulkUpdate(items, updatedBy);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Update(T item, long? updatedBy = default(long?)) => 
            _updateConductor.Update(item, updatedBy);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Update(IEnumerable<T> items, long? updatedBy = default(long?)) => 
            _updateConductor.Update(items, updatedBy);

        #endregion Update

        #endregion Public Methods
    }
}
