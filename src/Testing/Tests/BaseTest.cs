using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using RSM.HCD.CSharp.Core.Interfaces;
using RSM.HCD.CSharp.Core.Models;
using RSM.HCD.CSharp.Core.Models.Errors;
using RSM.HCD.CSharp.Extensions;
using RSM.HCD.CSharp.Logging;
using RSM.HCD.CSharp.Testing.Extensions;
using RSM.HCD.CSharp.Testing.Factories;
using Bogus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Testing.Tests
{
    public class BaseTest : IDisposable
    {
        #region Protected Properties

        protected ILoggerFactory LoggerFactory
        {
            get
            {
                if (_loggerFactory == null)
                {
                    _loggerFactory = new LoggerFactory();
                    _loggerFactory.AddTesting(Output);
                }

                return _loggerFactory;
            }
        }

        /// <summary>
        /// Cached instance of 'Faker' to use for specific data generation functions not available
        /// from Randomizer (such as email addresses, ip addresses, names, etc.)
        /// </summary>
        /// <returns></returns>
        protected Faker Faker => _faker = _faker ?? new Faker();

        protected ITestOutputHelper Output { get; private set; }

        /// <summary>
        /// Wrapper property for accessing the 'Randomizer' instance of 'Faker' directly. This field
        /// will instantiate a new Faker instance if it has not yet been accessed directly.
        /// </summary>
        /// <value></value>
        protected Randomizer Random => Faker.Random;

        #endregion Protected Properties

        #region Private Properties

        private Faker _faker;
        private ILoggerFactory _loggerFactory;

        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Static constructor to set up suite-level actors
        ///
        /// Most recent performance test: .04 milliseconds / ~47 microseconds
        /// </summary>
        static BaseTest()
        {
            // Clear all factories
            FactoryExtensions.ClearFactoryDefinitions();

            // Load factories
            LoadFactories(typeof(BaseTest).GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Instance constructor to set up common test-level actors
        /// </summary>
        /// <param name="output"></param>
        public BaseTest(
            ITestOutputHelper output
        )
        {
            Output = output;
            var converter = new XUnitTestOutputConverter(output);
            Console.SetOut(converter);
        }

        #endregion Constructors

        #region Teardown

        public virtual void Dispose()
        {

        }

        #endregion Teardown

        #region Protected Methods

        #region Build

        /// <summary>
        /// Builds entity of type T.
        /// </summary>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Build<T>() => FactoryExtensions.Build<T>();

        /// <summary>
        /// Builds entity of type T.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Build<T>(string name) => FactoryExtensions.Build<T>(name);

        protected T Build<T>(List<string> names) => FactoryExtensions.Build<T>(names);

        /// <summary>
        /// Builds entity of type T.
        /// </summary>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Build<T>(Action<T> property) => FactoryExtensions.Build<T>(property);

        /// <summary>
        /// Builds entity of type T.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="property">Function to set a specific property on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Build<T>(string name, Action<T> property) => FactoryExtensions.Build<T>(name, property);

        /// <summary>
        /// Builds entity of type T.
        /// </summary>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Build<T>(List<Action<T>> properties) => FactoryExtensions.Build<T>(properties);

        /// <summary>
        /// Builds entity of type T.
        /// </summary>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Build<T>(params Action<T>[] properties) => FactoryExtensions.Build<T>(properties.ToList());

        /// <summary>
        /// Builds entity of type T.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Build<T>(string name, List<Action<T>> properties) => FactoryExtensions.Build<T>(name, properties);

        /// <summary>
        /// Builds entity of type T.
        /// </summary>
        /// <param name="name">Named factory to be used for creation</param>
        /// <param name="properties">Functions to set properties on the created entity</param>
        /// <typeparam name="T">Type of entity to create</typeparam>
        /// <returns>Created entity</returns>
        protected T Build<T>(string name, params Action<T>[] properties) => FactoryExtensions.Build<T>(name, properties.ToList());

        #endregion Build

        #region BuildList

        /// <summary>
        /// Builds a list of entity type T. A factory for type T must be defined.
        /// </summary>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected List<T> BuildList<T>(int count)
        {
            var result = new List<T>();

            for (var i = 1; i <= count; i++)
            {
                result.Add(Build<T>());
            }

            return result;
        }

        #endregion BuildList

        #region BuildResult

        protected Result<T> BuildResult<T>() => new Result<T> { ResultObject = FactoryExtensions.Build<T>() };
        protected Result<T> BuildResult<T>(string name) => new Result<T> { ResultObject = FactoryExtensions.Build<T>(name) };
        protected Result<T> BuildResult<T>(Action<T> property) => new Result<T> { ResultObject = FactoryExtensions.Build<T>(property) };
        protected Result<T> BuildResult<T>(string name, Action<T> property) => new Result<T> { ResultObject = FactoryExtensions.Build<T>(name, property) };
        protected Result<T> BuildResult<T>(List<Action<T>> properties) => new Result<T> { ResultObject = FactoryExtensions.Build<T>(properties) };

        /// <summary>
        /// Factory method for setting properties directly on a new Result. Sets the `ResultObject`
        /// to the default value of T, but can be nested with other factory methods if a specific
        /// configuration of `T` is required.
        /// </summary>
        /// <param name="properties"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected Result<T> BuildResult<T>(params Action<Result<T>>[] properties)
        {
            var result = new Result<T>
            {
                Errors = new List<IError>(),
                ResultObject = default(T),
            };

            foreach (var property in properties)
            {
                property.Invoke(result);
            }

            return result;
        }

        protected Result<T> BuildResult<T>(params Action<T>[] properties) => new Result<T> { ResultObject = FactoryExtensions.Build<T>(properties.ToList()) };
        protected Result<T> BuildResult<T>(string name, List<Action<T>> properties) => new Result<T> { ResultObject = FactoryExtensions.Build<T>(name, properties) };
        protected Result<T> BuildResult<T>(string name, params Action<T>[] properties) => new Result<T> { ResultObject = FactoryExtensions.Build<T>(name, properties.ToList()) };

        #endregion BuildResult

        protected T FromJson<T>(string value) => JsonConvert.DeserializeObject<T>(value);
        protected T FromJson<T>(HttpResponseMessage response) => response.FromJson<T>();

        protected byte[] GetBytes(string value) => Encoding.UTF8.GetBytes(value);

        protected ILogger<T> GetLogger<T>() => LoggerFactory.CreateLogger<T>();

        protected string GetString(byte[] value) => Encoding.UTF8.GetString(value);

        protected static void LoadFactories(Assembly assembly)
        {
            Console.WriteLine($"Loading factories for assembly '{assembly.FullName}'...");
            var factoryTypes = assembly.GetTypes().Where(t => !t.GetTypeInfo().IsAbstract && t.GetTypeInfo().IsSubclassOf(typeof(Factory)));

            foreach (var factoryType in factoryTypes)
            {
                var factory = (Factory)Activator.CreateInstance(factoryType);
                factory.Define();
                Console.WriteLine($"- Factory: {factoryType.Name}");
            }
        }

        protected string ToJson(object value) => JsonConvert.SerializeObject(value, new VersionConverter());

        #endregion Protected Methods
    }
}
