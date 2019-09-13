using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests
{
    [Trait("Category", "Routing")]
    public class BaseRoutingTest : AndcultureCodeTest
    {
        #region Constructor

        public BaseRoutingTest(ITestOutputHelper output) : base(output)
        {
        }

        #endregion

    }
}