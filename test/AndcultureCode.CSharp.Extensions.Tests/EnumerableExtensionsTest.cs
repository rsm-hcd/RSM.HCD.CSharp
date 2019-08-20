using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class EnumerableExtensionsTest
    {
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
            new List<string>()       // Arrange
                .IsEmpty()           // Act
                    .ShouldBeTrue(); // Assert
        }

        [Fact]
        public void IsEmpty_Given_Predicate_When_NotEmpty_When_DoesNotContain_Matches_Returns_True()
        {
            new List<string> { "something" }   // Arrange
                .IsEmpty(e => e == "no match") // Act
                    .ShouldBeTrue();           // Assert
        }

        [Fact]
        public void IsEmpty_Given_Predicate_When_NotEmpty_When_Contains_Matches_Returns_False()
        {
            new List<string> { "something" }    // Arrange
                .IsEmpty(e => e == "something") // Act
                    .ShouldBeFalse();           // Assert
        }

        #endregion IsEmpty (Given Predicate)


        #region IsNullOrEmpty (No Arguments)

        [Fact]
        public void IsNullOrEmpty_Given_NoArguments_When_Null_Returns_True()
        {
            ((IEnumerable<string>)null) // Arrange
                .IsNullOrEmpty()        // Act
                    .ShouldBeTrue();    // Assert
        }

        [Fact]
        public void IsNullOrEmpty_Given_NoArguments_When_Empty_Returns_True()
        {
            new List<string>()       // Arrange
                .IsNullOrEmpty()     // Act
                    .ShouldBeTrue(); // Assert
        }

        [Fact]
        public void IsNullOrEmpty_Given_NoArguments_When_NotEmpty_Returns_False()
        {
            new List<string> { "something" } // Arrange
                .IsNullOrEmpty()             // Act
                    .ShouldBeFalse();        // Assert
        }

        #endregion IsNullOrEmpty (No Arguments)


        #region IsNullOrEmpty (Given Predicate)

        [Fact]
        public void IsNullOrEmpty_Given_Predicate_When_Null_Returns_True()
        {
            EnumerableExtensions             // Arrange
                .IsNullOrEmpty<string>(null) // Act
                    .ShouldBeTrue();         // Assert
        }

        [Fact]
        public void IsNullOrEmpty_Given_Predicate_When_Empty_Returns_True()
        {
            new List<string>()       // Arrange
                .IsNullOrEmpty()     // Act
                    .ShouldBeTrue(); // Assert
        }

        [Fact]
        public void IsNullOrEmpty_Given_Predicate_When_NotEmpty_When_DoesNotContain_Matches_Returns_True()
        {
            new List<string> { "something" }         // Arrange
                .IsNullOrEmpty(e => e == "no match") // Act
                    .ShouldBeTrue();                 // Assert
        }

        [Fact]
        public void IsNullOrEmpty_Given_Predicate_When_NotEmpty_When_Contains_Matches_Returns_False()
        {
            new List<string> { "something" }          // Arrange
                .IsNullOrEmpty(e => e == "something") // Act
                    .ShouldBeFalse();                 // Assert
        }

        #endregion IsNullOrEmpty (Given Predicate)
    }

}