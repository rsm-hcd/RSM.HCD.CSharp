using System;
using System.Collections.Generic;
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

        protected TTarget BuildTo<T, TTarget>() => Mapper.Map<T, TTarget>(Build<T>());
        protected TTarget BuildTo<T, TTarget>(string name) => Mapper.Map<T, TTarget>(Build<T>(name));
        protected TTarget BuildTo<T, TTarget>(Action<T> property) => Mapper.Map<T, TTarget>(Build<T>(property));
        protected TTarget BuildTo<T, TTarget>(string name, Action<T> property) => Mapper.Map<T, TTarget>(Build<T>(name, property));
        protected TTarget BuildTo<T, TTarget>(List<Action<T>> properties) => Mapper.Map<T, TTarget>(Build<T>(properties));
        protected TTarget BuildTo<T, TTarget>(params Action<T>[] properties) => Mapper.Map<T, TTarget>(Build<T>(properties));
        protected TTarget BuildTo<T, TTarget>(string name, List<Action<T>> properties) => Mapper.Map<T, TTarget>(Build<T>(name, properties));

        #endregion BuildTo

        #region Create

        protected T Create<T>() where T : Entity => Create(Context, Build<T>());
        protected T Create<T>(string name) where T : Entity => Create(Context, Build<T>(name));
        protected T Create<T>(Action<T> property) where T : Entity => Create(Context, Build<T>(property));
        protected T Create<T>(string name, Action<T> property) where T : Entity => Create(Context, Build<T>(name, property));
        protected T Create<T>(List<Action<T>> properties) where T : Entity => Create(Context, Build<T>(properties));
        protected T Create<T>(params Action<T>[] properties) where T : Entity => Create(Context, Build<T>(properties));
        protected T Create<T>(string name, List<Action<T>> properties) where T : Entity => Create(Context, Build<T>(name, properties));
        protected T Create<T>(string name, params Action<T>[] properties) where T : Entity => Create(Context, Build<T>(name, properties));

        #endregion Create

        #region CreateList

        /// <summary>
        /// Creates a list of entity type T. A factory for type T must be defined.
        /// </summary>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected List<T> CreateList<T>(int count) where T : Entity
        {
            var entities = new List<T>();
            for (var i = 0; i < count; i++)
            {
                entities.Add(Create(Context, Build<T>()));
            }

            return entities;
        }

        #endregion CreateList

        #region CreateTo

        protected TTarget CreateTo<T, TTarget>() where T : Entity => Mapper.Map<T, TTarget>(Create<T>());
        protected TTarget CreateTo<T, TTarget>(string name) where T : Entity => Mapper.Map<T, TTarget>(Create<T>(name));
        protected TTarget CreateTo<T, TTarget>(Action<T> property) where T : Entity => Mapper.Map<T, TTarget>(Create<T>(property));
        protected TTarget CreateTo<T, TTarget>(string name, Action<T> property) where T : Entity => Mapper.Map<T, TTarget>(Create<T>(name, property));
        protected TTarget CreateTo<T, TTarget>(List<Action<T>> properties) where T : Entity => Mapper.Map<T, TTarget>(Create<T>(properties));
        protected TTarget CreateTo<T, TTarget>(params Action<T>[] properties) where T : Entity => Mapper.Map<T, TTarget>(Create<T>(properties));
        protected TTarget CreateTo<T, TTarget>(string name, List<Action<T>> properties) where T : Entity => Mapper.Map<T, TTarget>(Create<T>(name, properties));

        #endregion CreateTo

        protected TTarget Map<T, TTarget>(T entity) => Mapper.Map<T, TTarget>(entity);

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

    }
}
