using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing
{
    [Trait("Category", "Unit")]
    public class UnitTestBase : TestBase
    {
        #region Constructors

        public UnitTestBase(ITestOutputHelper output) : base(output) {}

        #endregion Constructors
    }
}
