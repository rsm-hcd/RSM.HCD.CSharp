﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Data
{
    public partial interface IRepository<T>
        where T : class, IEntity
    {
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

    }
}
