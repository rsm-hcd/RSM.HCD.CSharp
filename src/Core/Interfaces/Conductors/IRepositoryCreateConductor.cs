using System;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Conductors
{
    public partial interface IRepositoryCreateConductor<T>
        where T : class, IEntity
    {
         #region Properties

        /// <summary>
        /// Ability to set and get the underlying DbContext's command timeout
        /// </summary>
        int? CommandTimeout { get; set; }

        #endregion Properties


        #region Methods

        /// <summary>
        /// Ability to create entities using a list in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to create</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<List<T>> BulkCreate(IEnumerable<T> items, long? createdById = null);

        /// <summary>
        /// Calls BulkCreate() with a de-duped list of objects as determined by the
        /// property (or properties) of the object for the 'property' argument
        /// NOTE: Bulking is generally faster than batching, but locks the table.
        /// </summary>
        /// <param name="items">List of items to attempt to create</param>
        /// <param name="property">Property or properties of the typed object to determine distinctness</param>
        /// <param name="createdById">Id of the user creating the entity</param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<List<T>> BulkCreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null);

        /// <summary>
        /// Ability to create an entity 
        /// </summary>
        /// <param name="item">Item to be created</param>
        /// <param name="createdById">Id of user creating the item</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<T> Create(T item, long? createdById = null);

        /// <summary>
        /// Ability to create entities individually using a list 
        /// </summary>
        /// <param name="items">List of items to be created</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<List<T>> Create(IEnumerable<T> items, long? createdById = null);

        /// <summary>
        /// Calls batched overload of Create() with a de-duped list of objects as determined by the
        /// property (or properties) of the object for the 'property' argument.
        /// NOTE: Batching is generally slower than bulking, but does not lock the table.
        /// </summary>
        /// <param name="items">List of items to attempt to create</param>
        /// <param name="property">Property or properties of the typed object to determine distinctness</param>
        /// <param name="createdById">Id of the user creating the entity</param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        IResult<List<T>> CreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null);

        #endregion Methods
    }
}
