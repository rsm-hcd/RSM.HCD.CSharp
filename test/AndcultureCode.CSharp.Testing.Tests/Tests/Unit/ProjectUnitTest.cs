using System.Reflection;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests.Unit
{
    /// <summary>
    /// Base class wrapper around BaseUnitTest to facilitate loading of factories specific to this
    /// assembly.
    /// </summary>
    public class ProjectUnitTest : BaseUnitTest
    {
        #region Constructors

        public ProjectUnitTest(ITestOutputHelper output) : base(output)
        {

        }

        /// <summary>
        /// Static constructor to load suite-level actors (such as Factories)
        /// </summary>
        static ProjectUnitTest()
        {
            LoadFactories(typeof(ProjectUnitTest).GetTypeInfo().Assembly);
        }

        #endregion Constructors
    }
}
