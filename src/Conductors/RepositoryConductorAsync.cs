using System.Collections.Generic;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models.Entities;

namespace AndcultureCode.CSharp.Conductors
{
    public partial class RepositoryConductor<T> : Conductor, IRepositoryConductor<T>
    where T : Entity
    {
        #region Properties

        /// <summary>
        /// Ability to set and get the underlying repository's command timeout
        /// </summary>
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

        /// <summary>
        /// Conductor property to create an entity or entities
        /// </summary>
        protected readonly IRepositoryCreateConductor<T> _createConductor;

        /// <summary>
        /// Conductor property to get an entity or entities
        /// </summary>
        protected readonly IRepositoryReadConductor<T> _readConductor;

        /// <summary>
        /// Conductor property to update an entity or entities
        /// </summary>
        protected readonly IRepositoryUpdateConductor<T> _updateConductor;

        /// <summary>
        /// Conductor property to delete an entity or entities
        /// </summary>
        protected readonly IRepositoryDeleteConductor<T> _deleteConductor;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="createConductor">The conductor instance that should be used to perform create operations</param>
        /// <param name="readConductor">The conductor instance that should be used to perform read operations</param>
        /// <param name="updateConductor">The conductor instance that should be used to perform update operations</param>
        /// <param name="deleteConductor">The conductor instance that should be used to perform delete operations</param>
        public RepositoryConductor(
            IRepositoryCreateConductor<T> createConductor,
            IRepositoryReadConductor<T> readConductor,
            IRepositoryUpdateConductor<T> updateConductor,
            IRepositoryDeleteConductor<T> deleteConductor)
        {
            _createConductor = createConductor;
            _readConductor = readConductor;
            _updateConductor = updateConductor;
            _deleteConductor = deleteConductor;
        }

        #endregion Constructor


        public Task<IResult<List<T>>> BulkCreateAsync(IEnumerable<T> items, long? createdById = null) => 
            _createConductor.BulkCreateAsync(items, createdById);
    }
}
