using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RSM.HCD.CSharp.Core.Interfaces.Entity;

namespace RSM.HCD.CSharp.Core.Interfaces.Conductors
{
    public partial interface IRepositoryUpdateConductor<T>
        where T : class, IEntity
    {
        /// <summary>
        /// Ability to set and get the underlying DbContext's command timeout
        /// </summary>
        int? CommandTimeout { get; set; }

        /// <summary>
        /// Ability to update a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> BulkUpdateAsync(IEnumerable<T> items, long? updatedBy = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Ability to update an entity
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> UpdateAsync(T item, long? updatedBy = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Ability to update a list of items but each item is updated individually.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        Task<IResult<bool>> UpdateAsync(IEnumerable<T> items, long? updatedBy = default(long?), CancellationToken cancellationToken = default);
    }
}
