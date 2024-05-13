using System;
using System.Collections.Generic;
using RSM.HCD.CSharp.Core.Interfaces.Entity;

namespace RSM.HCD.CSharp.Core.Interfaces.Conductors
{
    public partial interface IRepositoryUpdateConductor<T>
        where T : class, IEntity
    {
        /// <summary>
        /// Ability to update a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<bool> BulkUpdate(IEnumerable<T> items, long? updatedBy = null);

        /// <summary>
        /// Ability to update an entity
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<bool> Update(T item, long? updatedBy = null);

        /// <summary>
        /// Ability to update a list of items but each item is updated individually.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<bool> Update(IEnumerable<T> items, long? updatedBy = default(long?));
    }
}
