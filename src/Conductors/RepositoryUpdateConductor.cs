using System;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    /// <summary>
    /// Ability to update an entity or a list of entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class RepositoryUpdateConductor<T> : Conductor, IRepositoryUpdateConductor<T>
        where T : class, IEntity
    {
        #region IRepositoryUpdateConductor Implementation

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> BulkUpdate(IEnumerable<T> items, long? updatedBy = default(long?))
        {
            return _repository.BulkUpdate(items, updatedBy);
        }

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Update(T item, long? updatedBy = default(long?))
        {
            return _repository.Update(item, updatedBy);
        }

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Update(IEnumerable<T> items, long? updatedBy = default(long?))
        {
            return _repository.Update(items, updatedBy);
        }

        #endregion IRepositoryUpdateConductor Implementation
    }
}
