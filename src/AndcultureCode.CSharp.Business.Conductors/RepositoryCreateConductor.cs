using System;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Business.Conductors
{
    public class RepositoryCreateConductor<T> : Conductor, IRepositoryCreateConductor<T>
        where T : class, IEntity
    {
        #region Properties

        public int? CommandTimeout
        {
            get => _repository.CommandTimeout;
            set => _repository.CommandTimeout = value;
        }

        readonly IRepository<T> _repository;

        #endregion

        #region Constructor

        public RepositoryCreateConductor(
            IRepository<T> repository
            )
        {
            _repository = repository;
        }

        #endregion

        #region IRepositoryCreateConductor

        public virtual IResult<List<T>> BulkCreate(IEnumerable<T> items, long? createdById = default(long?))
        {
            return _repository.BulkCreate(items, createdById);
        }

        public IResult<List<T>> BulkCreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null)
        {
            return _repository.BulkCreateDistinct(items, property, createdById);
        }

        public virtual IResult<T> Create(T item, long? createdById = default(long?))
        {
            return _repository.Create(item, createdById);
        }

        public virtual IResult<List<T>> Create(IEnumerable<T> items, long? createdById = default(long?))
        {
            return _repository.Create(items, createdById);
        }

        public IResult<List<T>> CreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null)
        {
            return _repository.CreateDistinct(items, property, createdById);
        }

        #endregion
    }
}