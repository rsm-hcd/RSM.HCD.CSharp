using System.Collections.Generic;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Data
{
    public partial interface IRepository<T>
        where T : class, IEntity
    {
        /// <summary>
        /// Perform a DbContext.BulkInsert on an enumeration of T within a single transaction
        /// </summary>
        /// <param name="items"></param>
        /// <param name="createdById"></param>
        /// <returns></returns>
        Task<IResult<List<T>>> BulkCreateAsync(IEnumerable<T> items, long? createdById = null);

    }
}
