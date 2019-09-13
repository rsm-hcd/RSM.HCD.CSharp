using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using AndcultureCode.CSharp.Core.Models;
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
    public class AndcultureCodeTest : IDisposable
    {
        #region Properties

        protected ILoggerFactory LoggerFactory {
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

        protected ITestOutputHelper Output { get; private set; }

        private   Randomizer _randomizer;
        protected Randomizer Random => _randomizer = _randomizer ?? new Randomizer();

        #endregion Properties


        #region Constructors

        /// <summary>
        /// Static constructor to set up suite-level actors
        ///
        /// Most recent performance test: .04 milliseconds / ~47 microseconds
        /// </summary>
        static AndcultureCodeTest()
        {
            // Clear all factories
            AndcultureCodeFactory.ClearFactoryDefinitions();

            // Load factories
            LoadFactories(typeof(AndcultureCodeTest).GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Instance constructor to set up common test-level actors
        /// </summary>
        /// <param name="output"></param>
        public AndcultureCodeTest(
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


        #region Member Variables

        private ILoggerFactory _loggerFactory;

        #endregion Member Variables


        #region Protected Methods

        protected T Build<T>()                                           => AndcultureCodeFactory.Build<T>();
        protected T Build<T>(string name)                                => AndcultureCodeFactory.Build<T>(name);
        protected T Build<T>(List<string> names)                         => AndcultureCodeFactory.Build<T>(names);
        protected T Build<T>(Action<T> property)                         => AndcultureCodeFactory.Build<T>(property);
        protected T Build<T>(string name, Action<T> property)            => AndcultureCodeFactory.Build<T>(name, property);
        protected T Build<T>(List<Action<T>> properties)                 => AndcultureCodeFactory.Build<T>(properties);
        protected T Build<T>(params Action<T>[] properties)              => AndcultureCodeFactory.Build<T>(properties.ToList());
        protected T Build<T>(string name, List<Action<T>> properties)    => AndcultureCodeFactory.Build<T>(name, properties);
        protected T Build<T>(string name, params Action<T>[] properties) => AndcultureCodeFactory.Build<T>(name, properties.ToList());

        protected List<T> BuildList<T>(int count)
        {
            var result = new List<T>();

            for (var i = 1; i <= count; i ++)
            {
                result.Add(Build<T>());
            }

            return result;
        }

        protected Result<T> BuildResult<T>()                                           => new Result<T> { ResultObject = AndcultureCodeFactory.Build<T>() };
        protected Result<T> BuildResult<T>(string name)                                => new Result<T> { ResultObject = AndcultureCodeFactory.Build<T>(name) };
        protected Result<T> BuildResult<T>(Action<T> property)                         => new Result<T> { ResultObject = AndcultureCodeFactory.Build<T>(property) };
        protected Result<T> BuildResult<T>(string name, Action<T> property)            => new Result<T> { ResultObject = AndcultureCodeFactory.Build<T>(name, property) };
        protected Result<T> BuildResult<T>(List<Action<T>> properties)                 => new Result<T> { ResultObject = AndcultureCodeFactory.Build<T>(properties) };
        protected Result<T> BuildResult<T>(params Action<T>[] properties)              => new Result<T> { ResultObject = AndcultureCodeFactory.Build<T>(properties.ToList()) };
        protected Result<T> BuildResult<T>(string name, List<Action<T>> properties)    => new Result<T> { ResultObject = AndcultureCodeFactory.Build<T>(name, properties) };
        protected Result<T> BuildResult<T>(string name, params Action<T>[] properties) => new Result<T> { ResultObject = AndcultureCodeFactory.Build<T>(name, properties.ToList()) };

        protected T FromJson<T>(string value)                 => JsonConvert.DeserializeObject<T>(value);
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