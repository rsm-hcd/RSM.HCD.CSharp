using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Core.Models.Errors;
using AndcultureCode.CSharp.Extensions;
using AndcultureCode.CSharp.Logging;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Factories;
using Bogus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests
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

        protected T Build<T>() => FactoryExtensions.Build<T>();
        protected T Build<T>(string name) => FactoryExtensions.Build<T>(name);
        protected T Build<T>(List<string> names) => FactoryExtensions.Build<T>(names);
        protected T Build<T>(Action<T> property) => FactoryExtensions.Build<T>(property);
        protected T Build<T>(string name, Action<T> property) => FactoryExtensions.Build<T>(name, property);
        protected T Build<T>(List<Action<T>> properties) => FactoryExtensions.Build<T>(properties);
        protected T Build<T>(params Action<T>[] properties) => FactoryExtensions.Build<T>(properties.ToList());
        protected T Build<T>(string name, List<Action<T>> properties) => FactoryExtensions.Build<T>(name, properties);
        protected T Build<T>(string name, params Action<T>[] properties) => FactoryExtensions.Build<T>(name, properties.ToList());

        protected List<T> BuildList<T>(int count)
        {
            var result = new List<T>();

            for (var i = 1; i <= count; i++)
            {
                result.Add(Build<T>());
            }

            return result;
        }

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
