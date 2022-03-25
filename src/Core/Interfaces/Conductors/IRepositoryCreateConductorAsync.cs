using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Conductors
{
    public partial interface IRepositoryCreateConductor<T>
        where T : class, IEntity
    {
        /// <summary>
        /// Ability to asynchronously create entities using a list in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to create</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns>A collection of the created items</returns>
        Task<IResult<List<T>>> BulkCreateAsync(IEnumerable<T> items, long? createdById = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Calls BulkCreate() with a de-duped list of objects as determined by the
        /// property (or properties) of the object for the 'property' argument
        /// NOTE: Bulking is generally faster than batching, but locks the table.
        /// </summary>
        /// <param name="items">List of items to attempt to create</param>
        /// <param name="property">Property or properties of the typed object to determine distinctness</param>
        /// <param name="createdById">Id of the user creating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        Task<IResult<List<T>>> BulkCreateDistinctAsync<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null, CancellationToken cancellationToken = default);

    }
}
