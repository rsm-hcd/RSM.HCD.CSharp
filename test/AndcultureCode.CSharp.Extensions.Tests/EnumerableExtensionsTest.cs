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
            EnumerableExtensions                         // Arrange
                .IsNullOrEmpty<string>(                  // Act
                        source:    null,
                        predicate: e => true
                    )
                    .ShouldBeTrue();                     // Assert
        }

        [Fact]
        public void IsNullOrEmpty_Given_Predicate_When_Empty_Returns_True()
        {
            new List<string>()            // Arrange
                .IsNullOrEmpty(e => true) // Act
                    .ShouldBeTrue();      // Assert
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


        #region Join IEnumerable (Delimiter)

        [Fact]
        public void Join_IEnumerable_Given_Delimiter_When_Null_Returns_Null()
        {
            EnumerableExtensions.Join(list: (IEnumerable<string>)null, delimiter: "test").ShouldBeNull();
        }

        [Fact]
        public void Join_IEnumerable_Given_Delimiter_When_Empty_Returns_Empty_String()
        {
            ((IEnumerable<string>)new List<string>()).Join(delimiter: "test").ShouldBeEmpty();
        }

        [Fact]
        public void Join_IEnumerable_Given_Delimiter_When_Single_Value_Returns_Value_Without_Delimiter()
        {
            ((IEnumerable<string>)new List<string> { "value1" }).Join(delimiter: "test").ShouldBe("value1");
        }

        [Fact]
        public void Join_IEnumerable_Given_Delimiter_When_Multiple_Values_Returns_Values_With_Delimiter()
        {
            ((IEnumerable<string>)new List<string> { "value1", "value2" }).Join(delimiter: ":").ShouldBe("value1:value2");
        }

        #endregion Join IEnumerable (Delimiter)


        #region Join List of Strings (Delimiter)

        [Fact]
        public void Join_List_Of_Strings_Given_Delimiter_When_Null_Returns_Null()
        {
            EnumerableExtensions.Join(list: null, delimiter: "test").ShouldBeNull();
        }

        [Fact]
        public void Join_List_Of_Strings_Given_Delimiter_When_Empty_Returns_Empty_String()
        {
            new List<string>().Join(delimiter: "test").ShouldBeEmpty();
        }

        [Fact]
        public void Join_List_Of_Strings_Given_Delimiter_When_Single_Value_Returns_Value_Without_Delimiter()
        {
            new List<string> { "value1" }.Join(delimiter: "test").ShouldBe("value1");
        }

        [Fact]
        public void Join_List_Of_Strings_Given_Delimiter_When_Multiple_Values_Returns_Values_With_Delimiter()
        {
            new List<string> { "value1", "value2" }.Join(delimiter: ":").ShouldBe("value1:value2");
        }

        #endregion Join List of Strings (Delimiter)
    }

}