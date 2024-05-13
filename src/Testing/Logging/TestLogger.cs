using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Logging
{
    public class TestLogger : ILogger
    {
        #region Properties

        private readonly Func<string, LogLevel, bool> _filter;
        private readonly ITestOutputHelper _output;

        #endregion Properties


        #region Constructors

        public TestLogger(
            Func<string, LogLevel, bool> filter,
            ITestOutputHelper output
        )
        {
            _filter = filter;
            _output = output;
        }

        #endregion Constructors


        #region Public Methods

        public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            message = $"{logLevel}: {message}";

            if (exception != null)
            {
                message += Environment.NewLine + Environment.NewLine + exception.ToString();
            }

            _output.WriteLine(message);

        }

        #endregion Public Methods
    }
}
