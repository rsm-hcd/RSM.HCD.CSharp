using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Conductors
{
    public interface IRepositoryDeleteConductor<T>
        where T : class, IEntity
    {
        #region Properties

        /// <summary>
        /// Ability to set and get the underlying DbContext's command timeout
        /// </summary>
        int? CommandTimeout { get; set; }

        #endregion Properties


        #region Methods

        IResult<bool> BulkDelete(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true);
        IResult<bool> Delete(long id, long? deletedById = null, bool soft = true);
        IResult<bool> Delete(T o, long? deletedById = null, bool soft = true);
        IResult<bool> Restore(T o);
        IResult<bool> Restore(long id);

        #endregion Methods

    }
}