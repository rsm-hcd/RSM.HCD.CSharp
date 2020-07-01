using AndcultureCode.CSharp.Testing.Factories;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests.Unit.Factories
{
    public class FactorySettingsTest : ProjectUnitTest
    {
        #region Setup

        public FactorySettingsTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup


        #region Instance

        [Fact]
        public void Instance_When_Accessed_MultipleTimes_Returns_Same_Instance()
        {
            // Transitively assert the same instance through 10 accesses of `Instance`
            var previousInstance = FactorySettings.Instance;

            for (var i = 0; i < 10; i++)
            {
                var currentInstance = FactorySettings.Instance;

                currentInstance.ShouldBe(previousInstance); // Assert

                previousInstance = currentInstance;
            }
        }

        #endregion Instance
    }
}