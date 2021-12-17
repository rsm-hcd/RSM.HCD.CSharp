using System.Reflection;
using AndcultureCode.CSharp.Testing.Tests;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Core.Tests.Unit
{
    public class CoreUnitTest : BaseUnitTest
    {
        #region Constructors

        public CoreUnitTest(ITestOutputHelper output) : base(output) { }

        static CoreUnitTest()
        {
            LoadFactories(typeof(CoreUnitTest).GetTypeInfo().Assembly);
        }

        #endregion Constructors
    }
}
