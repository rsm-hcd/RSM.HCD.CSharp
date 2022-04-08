using System;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Conductors
{
    /// <summary>
    /// Ability to delete an entity or list of entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class RepositoryDeleteConductor<T> : Conductor, IRepositoryDeleteConductor<T>
        where T : class, IEntity
    {

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> BulkDelete(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true) => _repository.BulkDelete(items, deletedById, soft);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Delete(long id, long? deletedById = default(long?), bool soft = true) => _repository.Delete(id, deletedById, soft);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Delete(T o, long? deletedById = default(long?), bool soft = true) => _repository.Delete(o,  deletedById, soft);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Delete(IEnumerable<T> items, long? deletedById = default(long?), long batchSize = 100, bool soft = true) => _repository.Delete(items, deletedById, batchSize, soft);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Restore(T o) => _repository.Restore(o);

        /// <inheritdoc />
        [Obsolete("This method is deprecated in favor of its async counter part", false)]
        public virtual IResult<bool> Restore(long id) => _repository.Restore(id);
    }
}
