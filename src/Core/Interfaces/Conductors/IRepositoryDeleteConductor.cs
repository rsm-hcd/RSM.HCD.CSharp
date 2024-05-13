using System;
using System.Collections.Generic;
using RSM.HCD.CSharp.Core.Interfaces.Entity;

namespace RSM.HCD.CSharp.Core.Interfaces.Conductors
{
    public partial interface IRepositoryDeleteConductor<T>
        where T : class, IEntity
    {

        #region Methods

        /// <summary>
        /// Ability to delete a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to delete</param>
        /// <param name="deletedById">Id of user deleting the items</param>
        /// <param name="soft">Boolean flag for soft-deleting items</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<bool> BulkDelete(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true);

        /// <summary>
        /// Ability to delete an entity using an Id
        /// </summary>
        /// <param name="id">Id of item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <returns></returns>
        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<bool> Delete(long id, long? deletedById = null, bool soft = true);

        /// <summary>
        /// Ability to delete an entity using the entity itself
        /// </summary>
        /// <param name="o">Item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<bool> Delete(T o, long? deletedById = null, bool soft = true);

        /// <summary>
        /// Ability to delete a list of entities by batch size.
        /// </summary>
        /// <param name="items">List of items to delete</param>
        /// <param name="deletedById">Id of user deleting the items</param>
        /// <param name="batchSize">Number of items to include in a batch, defaults to 100</param>
        /// <param name="soft">Boolean flag for soft-deleting the items</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<bool> Delete(IEnumerable<T> items, long? deletedById = null, long batchSize = 100, bool soft = true);

        /// <summary>
        /// Ability to restore a soft-deleted entity using the entity itself.
        /// </summary>
        /// <param name="o">Entity to be restored</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<bool> Restore(T o);

        /// <inheritdoc />
        /// /// <summary>
        /// Ability to restore a soft-deleted entity using the entity id.
        /// </summary>
        /// <param name="id">Id of entity to be restored</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<bool> Restore(long id);

        #endregion Methods

    }
}
