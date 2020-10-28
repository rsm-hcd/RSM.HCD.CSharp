using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests.Unit.Tests
{
    public class BaseTestTest : ProjectUnitTest
    {
        #region Setup

        public BaseTestTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup

        #region Faker

        [Fact]
        public void Faker_When_Accessed_Multiple_Times_Returns_Same_Instance()
        {
            // Arrange & Act
            var previousInstance = Faker;

            // Transitively assert the same instance through 10 accesses of `Faker`
            for (var i = 0; i < 10; i++)
            {
                var currentInstance = Faker;

                // Assert
                currentInstance.ShouldBe(previousInstance);

                previousInstance = currentInstance;
            }
        }

        #endregion Faker

        #region Random

        [Fact]
        public void Random_When_Accessed_Multiple_Times_Returns_Same_Instance()
        {
            // Arrange & Act
            var previousInstance = Random;

            // Transitively assert the same instance through 10 accesses of `Random`
            for (var i = 0; i < 10; i++)
            {
                var currentInstance = Random;

                // Assert
                currentInstance.ShouldBe(previousInstance);

                previousInstance = currentInstance;
            }
        }

        #endregion Random
    }
}
