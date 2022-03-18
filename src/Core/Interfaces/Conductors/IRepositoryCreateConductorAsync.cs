using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Conductors
{
    public partial interface IRepositoryCreateConductor<T>
        where T : class, IEntity
    {
        /// <summary>
        /// Ability to asynchronously create entities using a list in a single bulk operation.
        /// </summary>
        /// <param name="items">List of items to create</param>
        /// <param name="createdById">Id of user creating the items</param>
        /// <returns>A collection of the created items</returns>
        Task<IResult<List<T>>> BulkCreateAsync(IEnumerable<T> items, long? createdById = null);
    }
}
