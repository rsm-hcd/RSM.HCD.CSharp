using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    public partial class RepositoryDeleteConductor<T> : Conductor, IRepositoryDeleteConductor<T>
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
        public RepositoryDeleteConductor(IRepository<T> repository)
        {
            _repository = repository;
        }


        /// <inheritdoc />
        public Task<IResult<bool>> BulkDeleteAsync(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.BulkDeleteAsync(items, deletedById, soft, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IResult<bool>> DeleteAsync(long id, long? deletedById = default(long?), bool soft = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.DeleteAsync(id, deletedById, soft, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IResult<bool>> DeleteAsync(T o, long? deletedById = default(long?), bool soft = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.DeleteAsync(o, deletedById, soft, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IResult<bool>> DeleteAsync(IEnumerable<T> items, long? deletedById = default(long?), long batchSize = 100, bool soft = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.DeleteAsync(items, deletedById, batchSize, soft, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IResult<bool>> RestoreAsync(T o, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.RestoreAsync(o, cancellationToken);
        }

        /// <inheritdoc />
        public Task<IResult<bool>> RestoreAsync(long id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _repository.RestoreAsync(id, cancellationToken);
        }
    }
}
