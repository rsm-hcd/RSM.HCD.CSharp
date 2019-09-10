using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Core;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models.Entities;

namespace AndcultureCode.CSharp.Business.Conductors
{
    public class RepositoryConductor<T> : Conductor, IRepositoryConductor<T>
    where T : Entity
    {
        #region Properties

        public int? CommandTimeout
        {
            get => _readConductor.CommandTimeout;
            set
            {
                _createConductor.CommandTimeout = value;
                _deleteConductor.CommandTimeout = value;
                _readConductor.CommandTimeout = value;
                _updateConductor.CommandTimeout = value;
            }
        }

        protected readonly IRepositoryCreateConductor<T> _createConductor;
        protected readonly IRepositoryReadConductor<T> _readConductor;
        protected readonly IRepositoryUpdateConductor<T> _updateConductor;
        protected readonly IRepositoryDeleteConductor<T> _deleteConductor;

        #endregion Properties


        #region Constructor

        public RepositoryConductor(
            IRepositoryCreateConductor<T> createConductor,
            IRepositoryReadConductor<T>   readConductor,
            IRepositoryUpdateConductor<T> updateConductor,
            IRepositoryDeleteConductor<T> deleteConductor)
        {
            _createConductor = createConductor;
            _readConductor   = readConductor;
            _updateConductor = updateConductor;
            _deleteConductor = deleteConductor;
        }

        #endregion Constructor


        #region Public Methods

        #region Create

        public virtual IResult<List<T>> BulkCreate(IEnumerable<T> items, long? createdById = default(long?)) => _createConductor.BulkCreate(items, createdById);
        public virtual IResult<List<T>> BulkCreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null) => _createConductor.BulkCreateDistinct(items, property, createdById);
        public virtual IResult<T> Create(T item, long? createdById = default(long?)) => _createConductor.Create(item, createdById);
        public virtual IResult<List<T>> Create(IEnumerable<T> items, long? createdById = default(long?)) => _createConductor.Create(items, createdById);
        public virtual IResult<List<T>> CreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null) => _createConductor.CreateDistinct(items, property, createdById);

        #endregion Create


        #region CreateOrUpdate

        public virtual IResult<IEnumerable<T>> BulkCreateOrUpdate(IEnumerable<T> items, long? createdOrUpdatedById = default(long?)) => Do<IEnumerable<T>>.Try((r) =>
        {
            if (items == null || !items.Any())
            {
                return items;
            }

            // Update first in case item Ids get updated in cache -- we don't want to update just-created items.
            var updateResult = BulkUpdate(items.Where(e => e.Id > 0), createdOrUpdatedById);
            if (updateResult.HasErrors || !updateResult.ResultObject)
            {
                r.AddErrors(updateResult.Errors);
            }

            var enumerableList = new List<T>();

            var createResult = BulkCreate(items.Where(e => e.Id <= 0), createdOrUpdatedById);
            if (createResult.HasErrors || createResult.ResultObject == null)
            {
                r.AddErrors(createResult.Errors);
            }

            if (createResult.ResultObject != null)
            {
                enumerableList.AddRange(createResult.ResultObject);
            }

            return enumerableList;
        })
        .Result;

        public virtual IResult<T> CreateOrUpdate(T item, long? createdOrUpdatedById = default(long?)) => Do<T>.Try((r) =>
        {
            // Create
            if (item.Id <= 0)
            {
                var createResult = Create(item, createdOrUpdatedById);
                if (createResult.HasErrors || createResult.ResultObject == null)
                {
                    r.AddErrors(createResult.Errors);
                    return null;
                }
                return createResult.ResultObject;
            }

            // Update
            var updateResult = Update(item, createdOrUpdatedById);
            if (updateResult.HasErrors || !updateResult.ResultObject)
            {
                r.AddErrors(updateResult.Errors);
                return null;
            }
            return item;
        })
        .Result;

        public virtual IResult<IEnumerable<T>> CreateOrUpdate(IEnumerable<T> items, long? createdOrUpdatedById = default(long?)) => Do<IEnumerable<T>>.Try((r) =>
        {
            var enumerableList = new List<T>();
            // Update
            var updateResult = Update(items.Where(e => e.Id > 0), createdOrUpdatedById);
            if (updateResult.HasErrorsOrResultIsFalse())
            {
                r.AddErrors(updateResult.Errors);
            }

            // Create
            var createResult = Create(items.Where(e => e.Id <= 0), createdOrUpdatedById);
            if (createResult.HasErrorsOrResultIsNull())
            {
                r.AddErrors(createResult.Errors);
            }

            if (createResult.ResultObject != null)
            {
                enumerableList.AddRange(createResult.ResultObject);
            }

            return enumerableList;
        })
        .Result;

        #endregion CreateOrUpdate


        #region FindAll

        public virtual IResult<IQueryable<T>> FindAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _readConductor.FindAll(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);

        public virtual IResult<IQueryable<T>> FindAll(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _readConductor.FindAll(nextLinkParams, filter, orderBy, ignoreQueryFilters, asNoTracking);

        public virtual IResult<IList<T>> FindAllCommitted(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false
        ) => _readConductor.FindAllCommitted(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters);

        public virtual IResult<IList<T>> FindAllCommitted(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false
        ) => _readConductor.FindAllCommitted(nextLinkParams, filter, orderBy, ignoreQueryFilters);

        #endregion FindAll


        #region FindById

        public virtual IResult<T> FindById(long id) => _readConductor.FindById(id);
        public virtual IResult<T> FindById(long id, params Expression<Func<T, object>>[] includeProperties) => _readConductor.FindById(id, includeProperties);
        public virtual IResult<T> FindById(long id, bool ignoreQueryFilters, params Expression<Func<T, object>>[] includeProperties) => _readConductor.FindById(id, ignoreQueryFilters, includeProperties);
        public IResult<T> FindById(long id, params string[] includeProperties) => _readConductor.FindById(id, includeProperties);
        public IResult<T> FindById(long id, string includeProperties) => _readConductor.FindById(id, includeProperties);

        #endregion FindById


        #region Update

        public virtual IResult<bool> BulkUpdate(IEnumerable<T> items, long? updatedBy = default(long?)) => _updateConductor.BulkUpdate(items, updatedBy);
        public virtual IResult<bool> Update(T item, long? updatedBy = default(long?)) => _updateConductor.Update(item, updatedBy);
        public virtual IResult<bool> Update(IEnumerable<T> items, long? updatedBy = default(long?)) => _updateConductor.Update(items, updatedBy);

        #endregion Update


        #region Delete

        public virtual IResult<bool> BulkDelete(IEnumerable<T> items, long? deletedById = default(long?), bool soft = true) => _deleteConductor.BulkDelete(items, deletedById, soft);
        public virtual IResult<bool> Delete(long id, long? deletedById = default(long?), bool soft = true) => _deleteConductor.Delete(id, deletedById, soft);
        public virtual IResult<bool> Delete(T o, long? deletedById = default(long?), bool soft = true) => _deleteConductor.Delete(o, deletedById, soft);

        public virtual IResult<bool> Restore(T o) => _deleteConductor.Restore(o);
        public virtual IResult<bool> Restore(long id) => _deleteConductor.Restore(id);

        #endregion Delete

        #endregion Public Methods
    }
}
