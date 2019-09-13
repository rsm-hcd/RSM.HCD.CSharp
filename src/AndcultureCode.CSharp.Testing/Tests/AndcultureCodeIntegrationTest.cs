using System;
using System.Collections.Generic;
using AndcultureCode.CSharp.Conductors;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Models.Entities;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Models.Setup;
using AutoMapper;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests
{
    [Trait("Category", "Integration")]
    public abstract class AndcultureCodeIntegrationTest : AndcultureCodeTest
    {
        #region Member Variables

        protected IContext Context { get; set; }
        protected string EnvironmentName = "Testing";
        protected virtual IMapper Mapper { get; set; }
        protected virtual IRepository<Entity> Repository { get; set; }


        #endregion


        #region Constructor

        public AndcultureCodeIntegrationTest(
            ITestOutputHelper output,
            IContext context = null,
            IRepository<Entity> repository = null
        ) : base(output)
        {
            Context    = context;
            Repository = repository;
        }

        #endregion


        #region Protected Methods

        #region Factories

        protected TTarget BuildTo<T, TTarget>()                                        => Mapper.Map<T, TTarget>(Build<T>());
        protected TTarget BuildTo<T, TTarget>(string name)                             => Mapper.Map<T, TTarget>(Build<T>(name));
        protected TTarget BuildTo<T, TTarget>(Action<T> property)                      => Mapper.Map<T, TTarget>(Build<T>(property));
        protected TTarget BuildTo<T, TTarget>(string name, Action<T> property)         => Mapper.Map<T, TTarget>(Build<T>(name, property));
        protected TTarget BuildTo<T, TTarget>(List<Action<T>> properties)              => Mapper.Map<T, TTarget>(Build<T>(properties));
        protected TTarget BuildTo<T, TTarget>(params Action<T>[] properties)           => Mapper.Map<T, TTarget>(Build<T>(properties));
        protected TTarget BuildTo<T, TTarget>(string name, List<Action<T>> properties) => Mapper.Map<T, TTarget>(Build<T>(name, properties));

        protected T Create<T>()                                           where T : Entity => Create(Context, Build<T>());
        protected T Create<T>(string name)                                where T : Entity => Create(Context, Build<T>(name));
        protected T Create<T>(Action<T> property)                         where T : Entity => Create(Context, Build<T>(property));
        protected T Create<T>(string name, Action<T> property)            where T : Entity => Create(Context, Build<T>(name, property));
        protected T Create<T>(List<Action<T>> properties)                 where T : Entity => Create(Context, Build<T>(properties));
        protected T Create<T>(params Action<T>[] properties)              where T : Entity => Create(Context, Build<T>(properties));
        protected T Create<T>(string name, List<Action<T>> properties)    where T : Entity => Create(Context, Build<T>(name, properties));
        protected T Create<T>(string name, params Action<T>[] properties) where T : Entity => Create(Context, Build<T>(name, properties));

        protected TTarget CreateTo<T, TTarget>()                                         where T : Entity => Mapper.Map<T, TTarget>(Create<T>());
        protected TTarget CreateTo<T, TTarget>(string name)                              where T : Entity => Mapper.Map<T, TTarget>(Create<T>(name));
        protected TTarget CreateTo<T, TTarget>(Action<T> property)                       where T : Entity => Mapper.Map<T, TTarget>(Create<T>(property));
        protected TTarget CreateTo<T, TTarget>(string name, Action<T> property)          where T : Entity => Mapper.Map<T, TTarget>(Create<T>(name, property));
        protected TTarget CreateTo<T, TTarget>(List<Action<T>> properties)               where T : Entity => Mapper.Map<T, TTarget>(Create<T>(properties));
        protected TTarget CreateTo<T, TTarget>(params Action<T>[] properties)            where T : Entity => Mapper.Map<T, TTarget>(Create<T>(properties));
        protected TTarget CreateTo<T, TTarget>(string name, List<Action<T>> properties)  where T : Entity => Mapper.Map<T, TTarget>(Create<T>(name, properties));

        protected TTarget Map<T, TTarget>(T entity) => Mapper.Map<T, TTarget>(entity);

        #endregion Factories

        #region Create

        public virtual T Create<T>(IContext context, T item) where T : Entity => throw new NotImplementedException();

        #endregion

        #region Conductors

        public virtual IntegrationTestConductors<T> GetRepositoryConductorDeps<T>(IContext customContext = null) where T : Entity => throw new NotImplementedException();

        protected IRepositoryConductor<T> SetupRepositoryConductor<T>(IContext customContext = null) where T : Entity => GetRepositoryConductorDeps<T>(customContext).Conductor;

        #endregion Conductors

        #endregion
    }
}
