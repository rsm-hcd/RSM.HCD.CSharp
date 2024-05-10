using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RSM.HCD.CSharp.Core.Interfaces.Entity;

namespace RSM.HCD.CSharp.Core.Interfaces.Conductors
{
    public partial interface IRepositoryDeleteConductor<T>
        where T : class, IEntity
    {
        /// <summary>
        /// Ability to set and get the underlying DbContext's command timeout
        /// </summary>
        int? CommandTimeout { get; set; }

        /// <summary>
        /// Ability to delete a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to delete</param>
        /// <param name="deletedById">Id of user deleting the items</param>
        /// <param name="soft">Boolean flag for soft-deleting items</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> BulkDeleteAsync(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true, CancellationToken cancellationToken = default);

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
    }
}
