using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests
{
    [Trait("Category", "Unit")]
    public class AndcultureCodeUnitTest : AndcultureCodeTest
    {
        #region Constructor

        public AndcultureCodeUnitTest(
            ITestOutputHelper output
        ) : base(output)
        {

        }

        #endregion
        
    }
}