using System;
using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Extensions.Enumerations;
using Shouldly;
using Xunit;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class IQueryableExtensionsTest
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

        #region OrderBy

        [Fact]
        public void OrderBy_When_Property_DoesNotExist_Throws_ArgumentException()
        {
            // Arrange
            var queryable = new List<string>().AsQueryable();
            string badPropertyName = "test"; // <-- This property does not exist on the string type.

            // Act & Assert
            Assert.Throws<ArgumentException>(() => queryable.OrderBy<string>(badPropertyName));
        }

        [Fact]
        public void OrderBy_When_List_IsEmpty_Returns_Empty_List()
        {
            // Arrange
            var queryable = new List<DateTime>().AsQueryable();

            // Act
            var result = queryable.OrderBy<DateTime>("Day");

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void OrderBy_When_Sorted_In_Ascending_Order_Returns_List_Ordered_Ascending()
        {
            // Arrange
            var olderDate = DateTime.MinValue;
            var newerDate = DateTime.MaxValue;
            var queryable = new List<DateTime> { newerDate, olderDate }.AsQueryable();

            // Act
            var result = queryable.OrderBy<DateTime>("Year", OrderByDirection.Ascending);

            // Assert
            result.First().ShouldBe(olderDate);
        }

        [Fact]
        public void OrderBy_When_Sorted_In_Descending_Order_Returns_List_Ordered_Descending()
        {
            // Arrange
            var olderDate = DateTime.MinValue;
            var newerDate = DateTime.MaxValue;
            var queryable = new List<DateTime> { olderDate, newerDate }.AsQueryable();

            // Act
            var result = queryable.OrderBy<DateTime>("Year", OrderByDirection.Descending);

            // Assert
            result.First().ShouldBe(newerDate);
        }

        [Fact]
        public void OrderBy_When_Not_Only_OrderBy_Should_Replace_Existing_OrderBy()
        {
            // Arrange
            var olderDate = DateTime.MinValue;
            var newerDate = DateTime.MaxValue;
            var queryable = new List<DateTime> { newerDate, olderDate }.AsQueryable();
            queryable.OrderByDescending(date => date.Year); // <-- This is the expression that should be replaced.

            // Act
            var result = queryable.OrderBy<DateTime>("Year", OrderByDirection.Ascending);

            // Assert
            result.First().ShouldBe(olderDate);
        }

        [Fact]
        public void OrderBy_When_OrderByProperty_IsEmpty_Returns_Unsorted_List()
        {
            // Arrange
            var queryable = new List<string> { "Test1", "Test2" }.AsQueryable();
            string orderByProperty = string.Empty;

            // Act
            var result = queryable.OrderBy<string>(orderByProperty);

            // Assert
            result.ShouldBeSameAs(queryable);
        }

        [Fact]
        public void OrderBy_When_OrderedAscending_With_Nested_Property_Returns_List_Ordered_Ascending()
        {
            // Arrange
            var olderDate = DateTime.MinValue;
            var newerDate = DateTime.MaxValue;
            var queryable = new List<DateTime> { newerDate, olderDate }.AsQueryable();
            string nestedProperty = "TimeOfDay.Ticks";

            // Act
            var result = queryable.OrderBy<DateTime>(nestedProperty, OrderByDirection.Ascending);

            // Assert
            result.First().ShouldBe(olderDate);
        }

        [Fact]
        public void OrderBy_When_OrderedDescending_With_Nested_Property_Returns_List_Ordered_Descending()
        {
            // Arrange
            var olderDate = DateTime.MinValue;
            var newerDate = DateTime.MaxValue;
            var queryable = new List<DateTime> { olderDate, newerDate }.AsQueryable();
            string nestedProperty = "TimeOfDay.Ticks";

            // Act
            var result = queryable.OrderBy<DateTime>(nestedProperty, OrderByDirection.Descending);

            // Assert
            result.First().ShouldBe(newerDate);
        }

        #endregion OrderBy

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

        #region ThenBy

        [Fact]
        public void ThenBy_When_Property_DoesNotExist_Throws_ArgumentException()
        {
            // Arrange
            var queryable = new List<DateTime> { DateTime.MinValue, DateTime.MaxValue }.AsQueryable();
            var orderedQueryable = queryable.OrderBy(s => s.Day);
            string badPropertyName = "test"; // <-- This property does not exist on the string type.

            // Act & Assert
            Assert.Throws<ArgumentException>(() => orderedQueryable.ThenBy<DateTime>(badPropertyName));
        }

        [Fact]
        public void ThenBy_When_List_IsEmpty_Returns_Empty_List()
        {
            // Arrange
            var queryable = new List<DateTime>().AsQueryable();
            var orderedQueryable = queryable.OrderBy(s => s.Day);

            // Act
            var result = orderedQueryable.ThenBy<DateTime>("Day");

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void ThenBy_When_Sorted_In_Ascending_Order_Returns_List_Ordered_Ascending()
        {
            // Arrange
            var minDate = DateTime.Now.AddHours(-1);
            var midDate = DateTime.Now;
            var maxDate = DateTime.Now.AddDays(1);
            var queryable = new List<DateTime> { midDate, maxDate, minDate }.AsQueryable();
            var orderedQueryable = queryable.OrderBy(date => date.Day);

            // Act
            var result = orderedQueryable.ThenBy<DateTime>("Hour", OrderByDirection.Ascending);

            // Assert
            result.First().ShouldBe(minDate);
            result.Last().ShouldBe(maxDate);
        }

        [Fact]
        public void ThenBy_When_Sorted_In_Descending_Order_Returns_List_Ordered_Descending()
        {
            // Arrange
            var minDate = DateTime.Now.AddHours(-1);
            var midDate = DateTime.Now;
            var maxDate = DateTime.Now.AddDays(1);
            var queryable = new List<DateTime> { midDate, minDate, maxDate }.AsQueryable();
            var orderedQueryable = queryable.OrderByDescending(date => date.Day);

            // Act
            var result = orderedQueryable.ThenBy<DateTime>("Hour", OrderByDirection.Descending);

            // Assert
            result.First().ShouldBe(maxDate);
            result.Last().ShouldBe(minDate);
        }

        [Fact]
        public void ThenBy_When_ThenByProperty_IsEmpty_Returns_List_Sorted_Only_By_OrderBy()
        {
            // Arrange
            var minDate = DateTime.MinValue;
            var maxDate = DateTime.MaxValue;
            var queryable = new List<DateTime> { maxDate, minDate }.AsQueryable();
            var orderedQueryable = queryable.OrderBy(date => date.Day);
            string thenByProperty = string.Empty;

            // Act
            var result = orderedQueryable.ThenBy<DateTime>(thenByProperty);

            // Assert
            result.ShouldBeSameAs(orderedQueryable);
        }

        [Fact]
        public void ThenBy_When_OrderedAscending_With_Nested_Property_Returns_List_Ordered_Ascending()
        {
            // Arrange
            var minDate = DateTime.Now.AddHours(-1);
            var midDate = DateTime.Now;
            var maxDate = DateTime.Now.AddDays(1);
            var queryable = new List<DateTime> { midDate, minDate, maxDate }.AsQueryable();
            var orderedQueryable = queryable.OrderBy(date => date.Day);
            string nestedProperty = "TimeOfDay.Ticks";

            // Act
            var result = orderedQueryable.ThenBy<DateTime>(nestedProperty, OrderByDirection.Ascending);

            // Assert
            result.First().ShouldBe(minDate);
            result.Last().ShouldBe(maxDate);
        }

        [Fact]
        public void ThenBy_When_OrderedDescending_With_Nested_Property_Returns_List_Ordered_Descending()
        {
            // Arrange
            var minDate = DateTime.Now.AddHours(-1);
            var midDate = DateTime.Now;
            var maxDate = DateTime.Now.AddDays(1);
            var queryable = new List<DateTime> { midDate, minDate, maxDate }.AsQueryable();
            var orderedQueryable = queryable.OrderByDescending(date => date.Day);
            string nestedProperty = "Date.Hour";

            // Act
            var result = orderedQueryable.ThenBy<DateTime>(nestedProperty, OrderByDirection.Descending);

            // Assert
            result.First().ShouldBe(maxDate);
            result.Last().ShouldBe(minDate);
        }

        #endregion ThenBy
    }
}