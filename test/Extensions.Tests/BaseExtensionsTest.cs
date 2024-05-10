using System.Reflection;
using RSM.HCD.CSharp.Testing.Tests;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Extensions.Tests
{
    public class BaseExtensionsTest : BaseUnitTest
    {
        // Static constructor to load suite-level actors
        static BaseExtensionsTest()
        {
            // Load factories
            LoadFactories(typeof(BaseExtensionsTest).GetTypeInfo().Assembly);
        }

        public BaseExtensionsTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}
