using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Testing.Tests;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Extensions
{
    public class EnumerableExtensionsTest : BaseUnitTest
    {
        #region Setup

        public EnumerableExtensionsTest(ITestOutputHelper output) : base(output)
        {
        }

        #endregion Setup

        #region IsEmpty (No Arguments)

        [Fact]
        public void IsEmpty_Given_NoArguments_When_Empty_Returns_True()
        {
            new List<string>()       // Arrange
                .IsEmpty()           // Act
                    .ShouldBeTrue(); // Assert
        }

        [Fact]
        public void IsEmpty_Given_NoArguments_When_NotEmpty_Returns_False()
        {
            new List<string> { "something" } // Arrange
                .IsEmpty()                   // Act
                    .ShouldBeFalse();        // Assert
        }

        #endregion IsEmpty (No Arguments)

        #region IsEmpty (Given Predicate)

        [Fact]
        public void IsEmpty_Given_Predicate_When_Empty_Returns_True()
        {
            // Arrange
            var source = new List<string>();
            var unexpected = Random.Word();

            // Act
            var result = source.IsEmpty((e) => e == unexpected);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsEmpty_Given_Predicate_When_NotEmpty_When_DoesNotContain_Matches_Returns_True()
        {

            // Arrange
            var source = Random.WordsArray(1, 3);
            var unexpected = $"{source.FirstOrDefault()}-nonmatching";

            // Act
            var result = source.IsEmpty((e) => e == unexpected);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsEmpty_Given_Predicate_When_NotEmpty_When_Contains_Matches_Returns_False()
        {
            // Arrange
            var source = Random.WordsArray(1, 3);
            var expected = source.FirstOrDefault();

            // Act
            var result = source.IsEmpty((e) => e == expected);

            // Assert
            result.ShouldBeFalse();
        }

        #endregion IsEmpty (Given Predicate)
    }

}
