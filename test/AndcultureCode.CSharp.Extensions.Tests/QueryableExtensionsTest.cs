using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class QueryableExtensionsTest
    {
        #region IsEmpty (No Arguments)

        [Fact]
        public void IsEmpty_Given_NoArguments_When_Empty_Returns_True()
        {
            // Arrange
            var queryable = new List<string>().AsQueryable();

            // Act
            var result = queryable.IsEmpty();

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsEmpty_Given_NoArguments_When_NotEmpty_Returns_False()
        {
            // Arrange
            var queryable = new List<string> { "something" }.AsQueryable();

            // Act
            var result = queryable.IsEmpty();

            // Assert
            result.ShouldBeFalse();
        }

        #endregion IsEmpty (No Arguments)

        #region IsEmpty (Given Predicate)

        [Fact]
        public void IsEmpty_Given_Predicate_When_Empty_Returns_True()
        {
            // Arrange
            var queryable = new List<string>().AsQueryable();

            // Act
            var result = queryable.IsEmpty((e) => true);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsEmpty_Given_Predicate_When_NotEmpty_When_DoesNotContain_Matches_Returns_True()
        {
            // Arrange
            var queryable = new List<string> { "something" }.AsQueryable();

            // Act
            var result = queryable.IsEmpty((e) => e == "no match");

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsEmpty_Given_Predicate_When_NotEmpty_When_Contains_Matches_Returns_False()
        {
            // Arrange
            var queryable = new List<string> { "something" }.AsQueryable();

            // Act
            var result = queryable.IsEmpty((e) => e == "something");

            // Assert
            result.ShouldBeFalse();
        }

        #endregion IsEmpty (Given Predicate)

        #region IsNullOrEmpty (No Arguments)

        [Fact]
        public void IsNullOrEmpty_Given_NoArguments_When_Null_Returns_True()
        {
            // Arrange
            var queryable = ((IQueryable<string>)null);

            // Act
            var result = queryable.IsNullOrEmpty();

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_Given_NoArguments_When_Empty_Returns_True()
        {
            // Arrange
            var queryable = new List<string>().AsQueryable();

            // Act
            var result = queryable.IsNullOrEmpty();

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_Given_NoArguments_When_NotEmpty_Returns_False()
        {
            // Arrange
            var queryable = new List<string> { "something" }.AsQueryable();

            // Act
            var result = queryable.IsNullOrEmpty();

            // Assert
            result.ShouldBeFalse();
        }

        #endregion IsNullOrEmpty (No Arguments)

        #region IsNullOrEmpty (Given Predicate)

        [Fact]
        public void IsNullOrEmpty_Given_Predicate_When_Null_Returns_True()
        {
            // Arrange
            var queryable = ((IQueryable<string>)null);

            // Act
            var result = queryable.IsNullOrEmpty((e) => true);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_Given_Predicate_When_Empty_Returns_True()
        {
            // Arrange
            var queryable = new List<string>().AsQueryable();

            // Act
            var result = queryable.IsNullOrEmpty();

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_Given_Predicate_When_NotEmpty_When_DoesNotContain_Matches_Returns_True()
        {
            // Arrange
            var queryable = new List<string> { "something" }.AsQueryable();

            // Act
            var result = queryable.IsNullOrEmpty((e) => e == "no match");

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsNullOrEmpty_Given_Predicate_When_NotEmpty_When_Contains_Matches_Returns_False()
        {
            // Arrange
            var queryable = new List<string> { "something" }.AsQueryable();

            // Act
            var result = queryable.IsEmpty((e) => e == "something");

            // Assert
            result.ShouldBeFalse();
        }

        #endregion IsNullOrEmpty (Given Predicate)

        #region PickRandom

        [Fact]
        public void PickRandom_List_Is_Empty_Returns_Null()
        {
            // Arrange
            var queryable = new List<string>().AsQueryable();

            // Act
            var result = queryable.PickRandom();

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void PickRandom_When_One_Item_Returns_That_Item()
        {
            // Arrange
            var queryable = new List<string> { "expected" }.AsQueryable();

            // Act
            var result = queryable.PickRandom();

            // Assert
            result.ShouldBe("expected");
        }

        [Fact]
        public void PickRandom_When_Multiple_Items_Returns_Single_Item()
        {
            // Arrange
            var queryable = "abcded90120423".Split("").AsQueryable();

            for (var i = 0; i <= 100; i++)
            {
                // Act
                var result = queryable.PickRandom();

                // Assert
                queryable.ShouldContain(result);
            }
        }

        #endregion PickRandom

        #region PickRandom (count)

        [Fact]
        public void PickRandom_Overload_With_Count_List_Is_Empty_Returns_EmptyList()
        {
            // Arrange
            var queryable = new List<string>().AsQueryable();

            // Act
            var result = queryable.PickRandom(count: 2);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void PickRandom_Overload_With_Count_When_Count_LessThan_LengthOf_Queryable_Returns_Records_Matching_LengthOf_Queryable()
        {
            // Arrange
            var queryable = new List<string> { "expected" }.AsQueryable();

            // Act
            var result = queryable.PickRandom(count: 2);

            // Assert
            result.Count().ShouldBe(queryable.Count());
        }

        [Fact]
        public void PickRandom_Overload_With_Count_When_Multiple_Items_Returns_Requested_NumberOf_Items()
        {
            // Arrange
            var queryable = "abcded90120423".Split("").AsQueryable();

            for (var i = 0; i <= queryable.Count(); i++)
            {
                // Act
                var result = queryable.PickRandom(count: i);

                // Assert
                result.Count().ShouldBe(i);
            }
        }

        #endregion PickRandom (count)
    }
}