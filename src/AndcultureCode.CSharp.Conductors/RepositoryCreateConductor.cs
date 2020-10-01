using System;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    /// <summary>
    /// Ability to create an entity or list of entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryCreateConductor<T> : Conductor, IRepositoryCreateConductor<T>
        where T : class, IEntity
    {
        #region Properties

        /// <summary>
        /// Ability to set and get the underlying DbContext's command timeout
        /// </summary>
        public int? CommandTimeout
        {
            get => _repository.CommandTimeout;
            set => _repository.CommandTimeout = value;
        }

        readonly IRepository<T> _repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public RepositoryCreateConductor(
            IRepository<T> repository
            )
        {
            _repository = repository;
        }

        #endregion

        #region IRepositoryCreateConductor

        /// <summary>
        /// Ability to create entities using a list in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to create</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        public virtual IResult<List<T>> BulkCreate(IEnumerable<T> items, long? createdById = default(long?))
        {
            return _repository.BulkCreate(items, createdById);
        }

        /// <summary>
        /// Ability to create entities using a list in a single bulk operation without duplicates.
        /// </summary>
        /// <param name="items">List of items to create</param>
        /// <param name="property">Property used to remove duplicates</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        public IResult<List<T>> BulkCreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null)
        {
            return _repository.BulkCreateDistinct(items, property, createdById);
        }

        /// <summary>
        /// Ability to create an entity 
        /// </summary>
        /// <param name="item">Item to be created</param>
        /// <param name="createdById">Id of user creating the item</param>
        /// <returns></returns>
        public virtual IResult<T> Create(T item, long? createdById = default(long?))
        {
            return _repository.Create(item, createdById);
        }

        /// <summary>
        /// Ability to create entities individually using a list 
        /// </summary>
        /// <param name="items">List of items to be created</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        public virtual IResult<List<T>> Create(IEnumerable<T> items, long? createdById = default(long?))
        {
            return _repository.Create(items, createdById);
        }

        /// <summary>
        /// Ability to create entities individually without duplicates
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="items">List of items to create</param>
        /// <param name="property">Property used to remove duplicates</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns></returns>
        public IResult<List<T>> CreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null)
        {
            return _repository.CreateDistinct(items, property, createdById);
        }

        #endregion
    }
}
