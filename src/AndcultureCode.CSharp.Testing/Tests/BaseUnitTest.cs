using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests
{
    [Trait("Category", "Unit")]
    public class BaseUnitTest : BaseTest
    {
        #region Constructor

        public BaseUnitTest(
            ITestOutputHelper output
        ) : base(output)
        {

        }

        #endregion
        
    }
}