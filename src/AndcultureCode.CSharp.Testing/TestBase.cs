using AndcultureCode.CSharp.Logging;
using Bogus;
using AndcultureCode.CSharp.Testing.Extensions;
using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing
{
    public class TestBase : IDisposable
    {
        #region Properties

        private ILoggerFactory _loggerFactory;
        private Randomizer     _randomizer;

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

        protected ITestOutputHelper Output { get; private set; }

        protected Randomizer Random => _randomizer = _randomizer ?? new Randomizer();

        #endregion Properties


        #region Constructors

        /// <summary>
        /// Static constructor to set up suite-level actors
        ///
        /// Most recent performance test: .04 milliseconds / ~47 microseconds
        /// </summary>
        static TestBase()
        {

        }

        /// <summary>
        /// Instance constructor to set up common test-level actors
        /// </summary>
        /// <param name="output"></param>
        public TestBase(ITestOutputHelper output)
        {
            Output = output;

            Console.SetOut(new XUnitTestOutputConverter(output));
        }

        #endregion Constructors


        #region Teardown

        public virtual void Dispose() {}

        #endregion Teardown


        #region Protected Methods

        protected ILogger<T> GetLogger<T>() => LoggerFactory.CreateLogger<T>();

        #endregion Protected Methods
    }
}
