using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Data
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
        where T : class, IEntity
    {
        #region Properties

        /// <summary>
        /// Ability to set and get the underlying DbContext's command timeout
        /// </summary>
        int? CommandTimeout { get; set; }

        #endregion Properties


        #region Methods

        IResult<List<T>> BulkCreate(IEnumerable<T> items, long? createdById = null);

        /// <summary>
        /// Calls BulkCreate() with a de-duped list of objects as determined by the
        /// property (or properties) of the object for the 'property' argument
        /// NOTE: Bulking is generally faster than batching, but locks the table.
        /// </summary>
        /// <param name="items">List of items to attempt to create</param>
        /// <param name="property">Property or properties of the typed object to determine distinctness</param>
        /// <param name="createdById">Id of the user creating the entity</param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        IResult<List<T>> BulkCreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null);
        IResult<bool>    BulkDelete(IEnumerable<T> items, long? deletedById = null, bool soft = true);
        IResult<bool>    BulkUpdate(IEnumerable<T> entities, long? updatedBy = default(long?));
        IResult<T>       Create(T item, long? createdById = null);
        IResult<List<T>> Create(IEnumerable<T> items, long? createdById = null);

        /// <summary>
        /// Calls batched overload of Create() with a de-duped list of objects as determined by the
        /// property (or properties) of the object for the 'property' argument.
        /// NOTE: Batching is generally slower than bulking, but does not lock the table.
        /// </summary>
        /// <param name="items">List of items to attempt to create</param>
        /// <param name="property">Property or properties of the typed object to determine distinctness</param>
        /// <param name="createdById">Id of the user creating the entity</param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        IResult<List<T>>       CreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null);
        IResult<bool>          Delete(long id, long? deletedById = null, bool soft = true);
        IResult<bool>          Delete(T o, long? deletedById = null, bool soft = true);
        IResult<IQueryable<T>> FindAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null, bool? ignoreQueryFilters = false, bool asNoTracking = false);
        IResult<IList<T>>      FindAllCommitted(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null, bool? ignoreQueryFilters = false);
        IResult<T>             FindById(long id, bool? ignoreQueryFilters = false);
        IResult<T>             FindById(long id, params Expression<Func<T, object>>[] includeProperties);
        IResult<T>             FindById(long id, bool? ignoreQueryFilters = false, params Expression<Func<T, object>>[] includeProperties);
        IResult<T>             FindById(long id, params string[] includeProperties);
        IResult<bool>          Restore(T o);
        IResult<bool>          Restore(long id);
        IResult<bool>          Update(T item, long? updatedBy = null);
        IResult<bool>          Update(IEnumerable<T> entities, long? updatedBy = default(long?));

        #endregion Methods
    }
}