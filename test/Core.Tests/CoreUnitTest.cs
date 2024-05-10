using System.Reflection;
using RSM.HCD.CSharp.Testing.Tests;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Core.Tests.Unit
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
