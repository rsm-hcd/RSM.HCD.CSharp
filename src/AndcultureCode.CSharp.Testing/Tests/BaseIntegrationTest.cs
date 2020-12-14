using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Conductors;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Models.Entities;
using AndcultureCode.CSharp.Testing.Models.Setup;
using AutoMapper;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests
{
    [Trait("Category", "Integration")]
    public abstract class BaseIntegrationTest : BaseTest
    {
        #region Member Variables

        protected IContext Context { get; set; }
        protected string EnvironmentName = "Testing";
        protected virtual IMapper Mapper { get; set; }
        protected virtual IRepository<Entity> Repository { get; set; }

        #endregion Member Variables

        #region Constructor

        public BaseIntegrationTest(
            ITestOutputHelper output,
            IContext context = null,
            IRepository<Entity> repository = null
        ) : base(output)
        {
            Context = context;
            Repository = repository;
        }

        #endregion Constructor

        #region Protected Methods

        #region BuildTo

        /// <summary>
        /// Builds and maps an entity to the target type.
        /// </summary>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget BuildTo<T, TTarget>() => Mapper.Map<T, TTarget>(Build<T>());

        /// <summary>
        /// Builds and maps an entity to the target type.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget BuildTo<T, TTarget>(string name) => Mapper.Map<T, TTarget>(Build<T>(name));

        /// <summary>
        /// Builds and maps an entity to the target type.
        /// </summary>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget BuildTo<T, TTarget>(Action<T> property) =>
            Mapper.Map<T, TTarget>(Build<T>(property));

        /// <summary>
        /// Builds and maps an entity to the target type.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget BuildTo<T, TTarget>(string name, Action<T> property) =>
            Mapper.Map<T, TTarget>(Build<T>(name, property));

        /// <summary>
        /// Builds and maps an entity to the target type.
        /// </summary>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget BuildTo<T, TTarget>(List<Action<T>> properties) =>
            Mapper.Map<T, TTarget>(Build<T>(properties));

        /// <summary>
        /// Builds and maps an entity to the target type.
        /// </summary>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget BuildTo<T, TTarget>(params Action<T>[] properties) =>
            Mapper.Map<T, TTarget>(Build<T>(properties));

        /// <summary>
        /// Builds and maps an entity to the target type.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget BuildTo<T, TTarget>(string name, List<Action<T>> properties) =>
            Mapper.Map<T, TTarget>(Build<T>(name, properties));

        #endregion BuildTo

        #region Create

        /// <summary>
        /// Creates entity of type T.
        /// </summary>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Create<T>() where T : Entity => Create(Context, Build<T>());

        /// <summary>
        /// Creates entity of type T.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Create<T>(string name) where T : Entity => Create(Context, Build<T>(name));

        /// <summary>
        /// Creates entity of type T.
        /// </summary>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Create<T>(Action<T> property) where T : Entity => Create(Context, Build<T>(property));

        /// <summary>
        /// Creates entity of type T.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Create<T>(string name, Action<T> property) where T : Entity => Create(Context, Build<T>(name, property));

        /// <summary>
        /// Creates entity of type T.
        /// </summary>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Create<T>(List<Action<T>> properties) where T : Entity => Create(Context, Build<T>(properties));

        /// <summary>
        /// Creates entity of type T.
        /// </summary>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Create<T>(params Action<T>[] properties) where T : Entity => Create(Context, Build<T>(properties));

        /// <summary>
        /// Creates entity of type T.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Create<T>(string name, List<Action<T>> properties) where T : Entity => Create(Context, Build<T>(name, properties));

        /// <summary>
        /// Creates entity of type T.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Create<T>(string name, params Action<T>[] properties) where T : Entity => Create(Context, Build<T>(name, properties));

        #endregion Create

        #region CreateList

        /// <summary>
        /// Creates a list of entities of type T.
        /// </summary>
        /// <param name="count">Number of entities to be created</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>List of created entities</returns>
        protected List<T> CreateList<T>(int count) where T : Entity =>
            CreateList<T>(count, () => Create<T>());

        /// <summary>
        /// Creates a list of entities of type T.
        /// </summary>
        /// <param name="count">Number of entities to be created</param>
        /// <param name="name">Named factory to be used for creation</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>List of created entities</returns>
        protected List<T> CreateList<T>(int count, string name) where T : Entity =>
            CreateList<T>(count, () => Create<T>(name));

        /// <summary>
        /// Creates a list of entities of type T.
        /// </summary>
        /// <param name="count">Number of entities to be created</param>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>List of created entities</returns>
        protected List<T> CreateList<T>(int count, Action<T> property) where T : Entity =>
            CreateList<T>(count, () => Create<T>(property));

        /// <summary>
        /// Creates a list of entities of type T.
        /// </summary>
        /// <param name="count">Number of entities to be created</param>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>List of created entities</returns>
        protected List<T> CreateList<T>(int count, string name, Action<T> property) where T : Entity =>
            CreateList<T>(count, () => Create<T>(name, property));

        /// <summary>
        /// Creates a list of entities of type T.
        /// </summary>
        /// <param name="count">Number of entities to be created</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>List of created entities</returns>
        protected List<T> CreateList<T>(int count, List<Action<T>> properties) where T : Entity =>
            CreateList<T>(count, () => Create<T>(properties));

        /// <summary>
        /// Creates a list of entities of type T.
        /// </summary>
        /// <param name="count">Number of entities to be created</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>List of created entities</returns>
        protected List<T> CreateList<T>(int count, params Action<T>[] properties) where T : Entity =>
            CreateList<T>(count, () => Create<T>(properties));

        /// <summary>
        /// Creates a list of entities of type T.
        /// </summary>
        /// <param name="count">Number of entities to be created</param>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>List of created entities</returns>
        protected List<T> CreateList<T>(int count, string name, List<Action<T>> properties) where T : Entity =>
            CreateList<T>(count, () => Create<T>(name, properties));

        /// <summary>
        /// Creates a list of entities of type T.
        /// </summary>
        /// <param name="count">Number of entities to be created</param>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>List of created entities</returns>
        protected List<T> CreateList<T>(int count, string name, params Action<T>[] properties) where T : Entity =>
            CreateList<T>(count, () => Create<T>(name, properties));

        #endregion CreateList

        #region CreateTo

        /// <summary>
        /// Creates and maps an entity to the target type.
        /// </summary>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget CreateTo<T, TTarget>() where T : Entity => Mapper.Map<T, TTarget>(Create<T>());

        /// <summary>
        /// Creates and maps an entity to the target type.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget CreateTo<T, TTarget>(string name) where T : Entity =>
            Mapper.Map<T, TTarget>(Create<T>(name));

        /// <summary>
        /// Creates and maps an entity to the target type.
        /// </summary>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget CreateTo<T, TTarget>(Action<T> property) where T : Entity =>
            Mapper.Map<T, TTarget>(Create<T>(property));

        /// <summary>
        /// Creates and maps an entity to the target type.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget CreateTo<T, TTarget>(string name, Action<T> property) where T : Entity =>
            Mapper.Map<T, TTarget>(Create<T>(name, property));

        /// <summary>
        /// Creates and maps an entity to the target type.
        /// </summary>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget CreateTo<T, TTarget>(List<Action<T>> properties) where T : Entity =>
            Mapper.Map<T, TTarget>(Create<T>(properties));

        /// <summary>
        /// Creates and maps an entity to the target type.
        /// </summary>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget CreateTo<T, TTarget>(params Action<T>[] properties) where T : Entity =>
            Mapper.Map<T, TTarget>(Create<T>(properties));

        /// <summary>
        /// Creates and maps an entity to the target type.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <typeparam name="TTarget">Type to map entity to</typeparam>
        /// <returns>Created entity</returns>
        protected TTarget CreateTo<T, TTarget>(string name, List<Action<T>> properties) where T : Entity =>
            Mapper.Map<T, TTarget>(Create<T>(name, properties));

        #endregion CreateTo

        /// <summary>
        /// Maps an entity to the target type
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T">Source type of entity</typeparam>
        /// <typeparam name="TTarget">Destination type to map entity to</typeparam>
        /// <returns>Mapped entity</returns>
        protected TTarget Map<T, TTarget>(T entity) => Mapper.Map<T, TTarget>(entity);

        #endregion Protected Methods

        #region Virtual Methods

        /// <summary>
        /// Defines generic creation of T Entity using repository conductors. Must be overridden by inheriting classes.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>NotImplementedException when not overridden</returns>
        public virtual T Create<T>(IContext context, T item) where T : Entity => throw new NotImplementedException();

        #endregion Virtual Methods

        #region Conductors

        /// <summary>
        /// Sets up an object containing conductor dependencies for a given Entity T returned as a composed model.
        /// </summary>
        /// <param name="repository"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected IntegrationTestConductors<T> GetRepositoryConductorDeps<T>(IRepository<T> repository) where T : Entity
        {
            var create = new RepositoryCreateConductor<T>(repository);
            var delete = new RepositoryDeleteConductor<T>(repository);
            var read = new RepositoryReadConductor<T>(repository);
            var update = new RepositoryUpdateConductor<T>(repository);
            var conductor = new RepositoryConductor<T>(create, read, update, delete);

            return new IntegrationTestConductors<T>
            {
                Conductor = conductor,
                Create = create,
                Delete = delete,
                Read = read,
                Repository = repository,
                Update = update
            };
        }

        /// <summary>
        /// Helper method to return Conductor property of IntegrationTestConductors<T>
        /// </summary>
        /// <param name="customContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected IRepositoryConductor<T> SetupRepositoryConductor<T>(
            IRepository<T> customRepository = null
        ) where T : Entity => GetRepositoryConductorDeps<T>(customRepository).Conductor;

        #endregion Conductors

        #region Private Methods

        /// <summary>
        /// Helper function for the various CreateList method overloads
        /// </summary>
        /// <param name="count"></param>
        /// <param name="builderFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private List<T> CreateList<T>(int count, Func<T> builderFunc)
        {
            var entities = new List<T>();

            for (var i = 0; i < count; i++)
            {
                entities.Add(builderFunc());
            }

            return entities;
        }

        #endregion Private Methods
    }
}
