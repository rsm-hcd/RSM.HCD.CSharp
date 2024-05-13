using Xunit;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Testing.Tests
{
    [Trait("Category", "Routing")]
    public class BaseRoutingTest : BaseTest
    {
        #region Constructor

        public BaseRoutingTest(ITestOutputHelper output) : base(output)
        {
        }

        #endregion

    }
}
