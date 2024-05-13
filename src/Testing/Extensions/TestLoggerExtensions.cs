using RSM.HCD.CSharp.Logging;
using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Testing.Extensions
{
    public static class TestLoggerExtensions
    {
        public static ILoggerFactory AddTesting(
            this ILoggerFactory factory,
            ITestOutputHelper output,
            Func<string, LogLevel, bool> filter = null
        )
        {
            factory.AddProvider(new TestLoggerProvider(filter, output));
            return factory;
        }
    }
}
