using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Business.Conductors
{
    public class RepositoryUpdateConductor<T> : Conductor, IRepositoryUpdateConductor<T>
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

        public RepositoryUpdateConductor(
            IRepository<T> repository
            )
        {
            _repository = repository;
        }

        #endregion

        #region IRepositoryUpdateConductor Implementation

        public virtual IResult<bool> BulkUpdate(IEnumerable<T> items, long? updatedBy = default(long?))
        {
            return _repository.BulkUpdate(items, updatedBy);
        }

        public virtual IResult<bool> Update(T item, long? updatedBy = default(long?))
        {
            return _repository.Update(item, updatedBy);
        }

        public virtual IResult<bool> Update(IEnumerable<T> items, long? updatedBy = default(long?))
        {
            return _repository.Update(items, updatedBy);
        }

        #endregion

    }
}
