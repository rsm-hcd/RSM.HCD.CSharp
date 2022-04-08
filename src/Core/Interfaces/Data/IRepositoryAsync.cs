using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Data
{
    public partial interface IRepository<T>
        where T : class, IEntity
    {
        #region Create

        /// <summary>
        /// Perform a DbContext.BulkInsert on an enumeration of T within a single transaction
        /// </summary>
        /// <param name="items">that items of type <see cref="IEnumerable{T}" to be inserted</param>
        /// <param name="createdById">Audit field for who did this task</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<List<T>>> BulkCreateAsync(IEnumerable<T> items, long? createdById = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Calls BulkCreate() after selecting a subset of 'items' based on the distinct value of 'property'
        /// </summary>
        /// <param name="items">that items of type <see cref="IEnumerable{T}" to be inserted</param>
        /// <param name="property">that determines distinct records</param>
        /// <param name="createdById">Audit field for who did this task</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        Task<IResult<List<T>>> BulkCreateDistinctAsync<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Ability to create an entity 
        /// </summary>
        /// <param name="item">Item to be created</param>
        /// <param name="createdById">Id of user creating the item</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<T>> CreateAsync(T item, long? createdById = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Ability to create entities individually using a list 
        /// </summary>
        /// <param name="items">List of items to be created</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<List<T>>> CreateAsync(IEnumerable<T> items, long? createdById = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Calls batched overload of Create() with a de-duped list of objects as determined by the
        /// property (or properties) of the object for the 'property' argument.
        /// NOTE: Batching is generally slower than bulking, but does not lock the table.
        /// </summary>
        /// <param name="items">List of items to attempt to create</param>
        /// <param name="property">Property or properties of the typed object to determine distinctness</param>
        /// <param name="createdById">Id of the user creating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        Task<IResult<List<T>>> CreateDistinctAsync<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null, CancellationToken cancellationToken = default);

        #endregion Create

        #region Delete

        /// <summary>
        /// Ability to delete an entity using an Id
        /// </summary>
        /// <param name="id">Id of item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> DeleteAsync(long id, long? deletedById = null, bool soft = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Ability to delete an entity using the entity itself
        /// </summary>
        /// <param name="o">Item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> DeleteAsync(T o, long? deletedById = null, bool soft = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Ability to delete a list of entities by batch size.
        /// </summary>
        /// <param name="items">List of items to delete</param>
        /// <param name="deletedById">Id of user deleting the items</param>
        /// <param name="batchSize">Number of items to include in a batch, defaults to 100</param>
        /// <param name="soft">Boolean flag for soft-deleting the items</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> DeleteAsync(IEnumerable<T> items, long? deletedById = null, long batchSize = 100, bool soft = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Calls BulkDelete() with a de-duped list of objects as determined by the
        /// property (or properties) of the object for the 'property' argument
        /// NOTE: Bulking is generally faster than batching, but locks the table.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="deletedById"></param>
        /// <param name="soft"></param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> BulkDeleteAsync(IEnumerable<T> items, long? deletedById = null, bool soft = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Ability to restore a soft-deleted entity using the entity itself. 
        /// </summary>
        /// <param name="o">Entity to be restored</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> RestoreAsync(T o, CancellationToken cancellationToken = default);

        /// <summary>
        /// Ability to restore a soft-deleted entity using the entity id.
        /// </summary>
        /// <param name="id">Id of entity to be restored</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> RestoreAsync(long id, CancellationToken cancellationToken = default);

        #endregion Delete

        #region Update

        /// <summary>
        /// Ability to update a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="entities">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> BulkUpdateAsync(IEnumerable<T> entities, long? updatedBy = default(long?), CancellationToken cancellationToken = default);

        /// <summary>
        /// Ability to create or update an entity
        /// </summary>
        /// <param name="item">Item to create or update</param>
        /// <param name="updatedBy">Id of user creating or updating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> UpdateAsync(T item, long? updatedBy = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Calls Update one-by-one for each item in the enumerated entities.
        /// For large operations, BulkUpdate() is more efficient.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="updatedBy"></param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns>True if entities updated without any exceptions. False if an exception was thrown.</returns>
        Task<IResult<bool>> UpdateAsync(IEnumerable<T> entities, long? updatedBy = default(long?), CancellationToken cancellationToken = default);

        #endregion Update

    }
}
