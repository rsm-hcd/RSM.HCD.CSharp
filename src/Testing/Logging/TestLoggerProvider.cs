using System;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Logging
{
    public class TestLoggerProvider : ILoggerProvider
    {
        #region Properties

        private readonly Func<string, LogLevel, bool> _filter;
        private readonly ITestOutputHelper _output;

        #endregion Properties


        #region Constructors

        public TestLoggerProvider(
            Func<string, LogLevel, bool> filter,
            ITestOutputHelper output
        )
        {
            _filter = filter;
            _output = output;
        }

        #endregion Constructors


        #region Public Methods

        public ILogger CreateLogger(string categoryName) => new TestLogger(_filter, _output);

        public void Dispose() { }

        #endregion Public Methods
    }
}
