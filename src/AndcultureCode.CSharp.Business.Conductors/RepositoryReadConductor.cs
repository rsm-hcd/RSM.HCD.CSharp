using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Business.Conductors
{
    public class RepositoryReadConductor<T> : Conductor, IRepositoryReadConductor<T>
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

        public RepositoryReadConductor(IRepository<T> repository)
        {
            _repository = repository;
        }

        #endregion Constructor


        #region IRepositoryReadConductor Implementation

        #region FindAll

        public virtual IResult<IQueryable<T>> FindAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _repository.FindAll(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters, asNoTracking);

        /// <summary>
        /// </summary>
        /// <param name="nextLinkParams">Currently nothing is provided for NextLinkParams by this base class. Exists for overriding subclasses.</param>
        /// <returns></returns>
        public virtual IResult<IQueryable<T>> FindAll(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false,
            bool asNoTracking = false
        ) => _repository.FindAll(filter, orderBy, ignoreQueryFilters: ignoreQueryFilters, asNoTracking: asNoTracking);

        public virtual IResult<IList<T>> FindAllCommitted(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            bool? ignoreQueryFilters = false
        ) => _repository.FindAllCommitted(filter, orderBy, includeProperties, skip, take, ignoreQueryFilters);

        /// <summary>
        /// </summary>
        /// <param name="nextLinkParams">Currently nothing is provided for NextLinkParams by this base class. Exists for overriding subclasses.</param>
        /// <returns></returns>
        public virtual IResult<IList<T>> FindAllCommitted(
            Dictionary<string, string> nextLinkParams,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? ignoreQueryFilters = false
        ) => _repository.FindAllCommitted(filter, orderBy, ignoreQueryFilters: ignoreQueryFilters);

        #endregion FindAll


        #region FindById

        public virtual IResult<T> FindById(long id)
        {
            return _repository.FindById(id);
        }

        public virtual IResult<T> FindById(long id, bool ignoreQueryFilters, params Expression<Func<T, object>>[] includeProperties)
        {
            return _repository.FindById(id, ignoreQueryFilters, includeProperties);
        }

        public virtual IResult<T> FindById(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            return _repository.FindById(id, includeProperties);
        }

        public virtual IResult<T> FindById(long id, params string[] includeProperties)
        {
            return _repository.FindById(id, includeProperties);
        }

        #endregion FindById

        #endregion IRepositoryReadConductor Implementation
    }
}
