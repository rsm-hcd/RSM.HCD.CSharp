using System.Reflection;
using AndcultureCode.CSharp.Testing.Tests;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Extensions.Tests
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