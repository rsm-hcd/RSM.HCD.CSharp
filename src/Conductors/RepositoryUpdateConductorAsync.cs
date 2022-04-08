using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    public partial class RepositoryUpdateConductor<T> : Conductor, IRepositoryUpdateConductor<T>
    where T : class, IEntity
    {
        /// <summary>
        /// Ability to set and get the underlying DbContext's command timeout
        /// </summary>
        public int? CommandTimeout
        {
            get => _repository.CommandTimeout;
            set => _repository.CommandTimeout = value;
        }

        readonly IRepository<T> _repository;

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

        /// <summary>
        /// Ability to update a list of entities in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        public Task<IResult<bool>> BulkUpdateAsync(IEnumerable<T> items, long? updatedBy = default(long?), CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.BulkUpdateAsync(items, updatedBy, cancellationToken);
        }

        /// <summary>
        /// Ability to update an entity
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        public Task<IResult<bool>> UpdateAsync(T item, long? updatedBy = default(long?), CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.UpdateAsync(item, updatedBy, cancellationToken);
        }

        /// <summary>
        /// Ability to update a list of items but each item is updated individually.
        /// </summary>
        /// <param name="items">List of items to update</param>
        /// <param name="updatedBy">Id of user updating the entity</param>
        /// <param name="cancellationToken">a token allowing aborting of this request</param>
        /// <returns></returns>
        public Task<IResult<bool>> UpdateAsync(IEnumerable<T> items, long? updatedBy = default(long?), CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.UpdateAsync(items, updatedBy, cancellationToken);
        }
    }
}
