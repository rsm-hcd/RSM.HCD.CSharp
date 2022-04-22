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

        /// <inheritdoc />
        public Task<IResult<bool>> BulkUpdateAsync(IEnumerable<T> items, long? updatedBy = default(long?), CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.BulkUpdateAsync(items, updatedBy, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IResult<bool>> UpdateAsync(T item, long? updatedBy = default(long?), CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.UpdateAsync(item, updatedBy, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IResult<bool>> UpdateAsync(IEnumerable<T> items, long? updatedBy = default(long?), CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.UpdateAsync(items, updatedBy, cancellationToken);
        }
    }
}
