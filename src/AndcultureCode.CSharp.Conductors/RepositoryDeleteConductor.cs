using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    public class RepositoryDeleteConductor<T> : Conductor, IRepositoryDeleteConductor<T>
        where T : class, IEntity
    {
        #region Properties

        public int? CommandTimeout
        {
            get => _repository.CommandTimeout;
            set => _repository.CommandTimeout = value;
        }

        readonly IRepository<T> _repository;

        #endregion Properties


        #region Constructor

        public RepositoryDeleteConductor(IRepository<T> repository)
        {
            _repository = repository;
        }

        #endregion Constructor


        #region IRepositoryDeleteConductor Implementation

        public virtual IResult<bool> BulkDelete(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true) => _repository.BulkDelete(items, deletedById, soft);

        public virtual IResult<bool> Delete(long id, long? deletedById = default(long?), bool soft = true) => _repository.Delete(id, deletedById, soft);
        public virtual IResult<bool> Delete(T o,     long? deletedById = default(long?), bool soft = true) => _repository.Delete(o,  deletedById, soft);
        public virtual IResult<bool> Delete(IEnumerable<T> items ,long? deletedById = default(long?), long batchSize = 100, bool soft = true) => _repository.Delete(items, deletedById, batchSize, soft);

        public virtual IResult<bool> Restore(T o)     => _repository.Restore(o);
        public virtual IResult<bool> Restore(long id) => _repository.Restore(id);

        #endregion IRepositoryDeleteConductor Implementation
    }
}
