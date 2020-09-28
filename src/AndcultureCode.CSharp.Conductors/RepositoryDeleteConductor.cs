using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    /// <summary>
    /// Ability to delete an entity or list of entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryDeleteConductor<T> : Conductor, IRepositoryDeleteConductor<T>
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
        public RepositoryDeleteConductor(IRepository<T> repository)
        {
            _repository = repository;
        }

        #endregion Constructor


        #region IRepositoryDeleteConductor Implementation
        /// <summary>
        /// Ability to delete a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to delete</param>
        /// <param name="deletedById">Id of user deleting the items</param>
        /// <param name="soft">Boolean flag for soft-deleting items</param>
        /// <returns></returns>
        public virtual IResult<bool> BulkDelete(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true) => _repository.BulkDelete(items, deletedById, soft);

        /// <summary>
        /// Ability to delete an entity using an Id
        /// </summary>
        /// <param name="id">Id of item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <returns></returns>
        public virtual IResult<bool> Delete(long id, long? deletedById = default(long?), bool soft = true) => _repository.Delete(id, deletedById, soft);

        /// <summary>
        /// Ability to delete an entity using the entity itself
        /// </summary>
        /// <param name="o">Item to be deleted</param>
        /// <param name="deletedById">Id of user deleting the item</param>
        /// <param name="soft">Boolean flag for soft-deleting the item</param>
        /// <returns></returns>
        public virtual IResult<bool> Delete(T o,     long? deletedById = default(long?), bool soft = true) => _repository.Delete(o,  deletedById, soft);

        /// <summary>
        /// Ability to delete a list of entities by batch size.
        /// </summary>
        /// <param name="items">List of items to delete</param>
        /// <param name="deletedById">Id of user deleting the items</param>
        /// <param name="batchSize">Number of items to include in a batch, defaults to 100</param>
        /// <param name="soft">Boolean flag for soft-deleting the items</param>
        /// <returns></returns>
        public virtual IResult<bool> Delete(IEnumerable<T> items ,long? deletedById = default(long?), long batchSize = 100, bool soft = true) => _repository.Delete(items, deletedById, batchSize, soft);

        /// <summary>
        /// Ability to restore a soft-deleted entity using the entity itself. 
        /// </summary>
        /// <param name="o">Entity to be restored</param>
        /// <returns></returns>
        public virtual IResult<bool> Restore(T o)     => _repository.Restore(o);

        /// <summary>
        /// Ability to restore a soft-deleted entity using the entity id.
        /// </summary>
        /// <param name="id">Id of entity to be restored</param>
        /// <returns></returns>
        public virtual IResult<bool> Restore(long id) => _repository.Restore(id);

        #endregion IRepositoryDeleteConductor Implementation
    }
}
