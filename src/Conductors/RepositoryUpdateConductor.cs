using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    /// <summary>
    /// Ability to update an entity or a list of entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryUpdateConductor<T> : Conductor, IRepositoryUpdateConductor<T>
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

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public RepositoryUpdateConductor(
            IRepository<T> repository
            )
        {
            _repository = repository;
        }

        #endregion Constructor

        #region IRepositoryUpdateConductor Implementation

        /// <summary>
        /// Ability to update a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <returns></returns>
        public virtual IResult<bool> BulkUpdate(IEnumerable<T> items, long? updatedBy = default(long?))
        {
            return _repository.BulkUpdate(items, updatedBy);
        }

        /// <summary>
        /// Ability to update an entity
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <returns></returns>
        public virtual IResult<bool> Update(T item, long? updatedBy = default(long?))
        {
            return _repository.Update(item, updatedBy);
        }

        /// <summary>
        /// Ability to update a list of items but each item is updated individually.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <returns></returns>
        public virtual IResult<bool> Update(IEnumerable<T> items, long? updatedBy = default(long?))
        {
            return _repository.Update(items, updatedBy);
        }

        #endregion IRepositoryUpdateConductor Implementation
    }
}
