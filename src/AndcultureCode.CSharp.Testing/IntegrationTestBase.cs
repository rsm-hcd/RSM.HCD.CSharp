using AutoMapper;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing
{
    [Trait("Category", "Integration")]
    public class LMSIntegrationTest : TestBase
    {
        #region Properties

        // protected          IContext Context         { get; set; }
        protected          string   EnvironmentName = "Testing";
        protected virtual  IMapper  Mapper          { get; set; }

        #endregion Properties


        #region Constructors

        public LMSIntegrationTest(
            ITestOutputHelper output
            // IContext context = null
        ) : base(output)
        {
            // Context = context;
        }

        #endregion Constructors
    }
}
