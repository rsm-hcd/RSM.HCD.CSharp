using System.Reflection;
using AndcultureCode.CSharp.Testing.Tests;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Conductors.Tests
{
    public class ProjectUnitTest : BaseUnitTest
    {
        #region Constructors

        public ProjectUnitTest(ITestOutputHelper output) : base(output)
        {

        }

        static ProjectUnitTest()
        {
            LoadFactories(typeof(ProjectUnitTest).GetTypeInfo().Assembly);
        }

        #endregion Constructors
    }
}
