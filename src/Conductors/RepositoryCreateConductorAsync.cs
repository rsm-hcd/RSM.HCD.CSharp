using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    public partial class RepositoryCreateConductor<T> : Conductor, IRepositoryCreateConductor<T>
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
        public RepositoryCreateConductor(
            IRepository<T> repository
            )
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public virtual Task<IResult<List<T>>> BulkCreateAsync(IEnumerable<T> items, long? createdById = null, CancellationToken cancellationToken = default) 
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (items == null) throw new ArgumentNullException(nameof(items));
            if(!items.Any()) throw new ArgumentException("An empty collection was provided", nameof(items));
            return _repository.BulkCreateAsync(items, createdById);
        }

        /// <inheritdoc />
        public Task<IResult<List<T>>> BulkCreateDistinctAsync<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (!items.Any()) throw new ArgumentException("An empty collection was provided", nameof(items));
            return _repository.BulkCreateDistinctAsync(items, property, createdById, cancellationToken);
        }
    }
}
