using System;
using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Models.Stubs;
using AndcultureCode.CSharp.Testing.Tests;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class IEnumerableExtensionsTest : BaseUnitTest
    {
        #region Setup

        public IEnumerableExtensionsTest(ITestOutputHelper output) : base(output)
        {
        }

        #endregion Setup

        #region Except

        [Fact]
        public void Except_When_Source_Collection_Null_Returns_Empty_Collection()
        {
            // Arrange
            var source = (List<UserStub>)null;
            var exclusions = BuildList<UserStub>(1);
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(exclusions, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Except_When_Source_Collection_Empty_Returns_Empty_Collection()
        {
            // Arrange
            var source = new List<UserStub>();
            var exclusions = BuildList<UserStub>(1);
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(exclusions, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Except_When_Exclusion_Collection_Has_No_Matching_Elements_Returns_Source_Collection()
        {
            // Arrange
            var expected = Build<UserStub>();
            var source = new List<UserStub>
            {
                expected,
            };
            var exclusions = new List<UserStub>
            {
                // This should never match the source collection
                Build<UserStub>((e) => e.EmailAddress = $"not-{expected.EmailAddress}")
            };
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(exclusions, predicate);

            // Assert
            result.ShouldBe(source);
        }

        [Fact]
        public void Except_When_Exclusion_Collection_Empty_Returns_Source_Collection()
        {
            // Arrange
            var source = BuildList<UserStub>(1);
            var exclusions = new List<UserStub>();
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(exclusions, predicate);

            // Assert
            result.ShouldBe(source);
        }

        [Fact]
        public void Except_When_Exclusion_Collection_Null_Returns_Source_Collection()
        {
            // Arrange
            var source = BuildList<UserStub>(1);
            var exclusions = (List<UserStub>)null;
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(exclusions, predicate);

            // Assert
            result.ShouldBe(source);
        }

        [Fact]
        public void Except_When_Exclusion_Collection_Has_Matching_Elements_Returns_Collection_Without_Matching_Elements()
        {
            // Arrange
            var unexpected = Build<UserStub>();
            var source = new List<UserStub>
            {
                Build<UserStub>(),
                unexpected,
            };
            var exclusions = new List<UserStub>
            {
                // Based on matching email, this should be excluded from the result
                Build<UserStub>((e) => e.EmailAddress = unexpected.EmailAddress)
            };
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(exclusions, predicate);

            // Assert
            result.ShouldNotBeEmpty();
            result.ShouldNotContain(unexpected);
        }

        #endregion Except

        #region HasValues (No Arguments)

        [Fact]
        public void HasValues_Given_NoArguments_When_Null_Returns_False()
        {
            // Arrange
            IEnumerable<string> source = null;

            // Act
            var result = source.HasValues();

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void HasValues_Given_NoArguments_When_Empty_Returns_False()
        {
            // Arrange
            IEnumerable<string> source = new List<string>();

            // Act
            var result = source.HasValues();

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void HasValues_Given_NoArguments_When_NotEmpty_Returns_True()
        {
            // Arrange
            IEnumerable<string> source = Random.WordsArray(1, 3);

            // Act
            var result = source.HasValues();

            // Assert
            result.ShouldBeTrue();
        }

        #endregion HasValues (No Arguments)

        #region HasValues (Given Predicate)

        [Fact]
        public void HasValues_Given_Predicate_When_Null_Returns_False()
        {
            // Arrange
            IEnumerable<string> source = null;
            var unexpected = Random.Word();

            // Act
            var result = source.HasValues((e) => e == unexpected);

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void HasValues_Given_Predicate_When_Empty_Returns_False()
        {
            // Arrange
            IEnumerable<string> source = new List<string>();
            var unexpected = Random.Word();

            // Act
            var result = source.HasValues((e) => e == unexpected);

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void HasValues_Given_Predicate_When_NotEmpty_DoesNotContainMatches_Returns_False()
        {
            // Arrange
            IEnumerable<string> source = Random.WordsArray(1, 3);
            var unexpected = $"{source.PickRandom()}-nonmatching";

            // Act
            var result = source.HasValues((e) => e == unexpected);

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void HasValues_Given_Predicate_When_NotEmpty_ContainsMatch_Returns_True()
        {
            // Arrange
            IEnumerable<string> source = Random.WordsArray(1, 3);
            var expected = source.PickRandom();

            // Act
            var result = source.HasValues((e) => e == expected);

            // Assert
            result.ShouldBeTrue();
        }

        #endregion HasValues (Given Predicate)

        #region Intersect

        [Fact]
        public void Intersect_When_Source_Collection_Null_Returns_Empty_Collection()
        {
            // Arrange
            var source = (List<UserStub>)null;
            var inclusions = BuildList<UserStub>(1);
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(inclusions, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Source_Collection_Empty_Returns_Empty_Collection()
        {
            // Arrange
            var source = new List<UserStub>();
            var inclusions = BuildList<UserStub>(1);
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(inclusions, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Inclusion_Collection_Has_No_Matching_Elements_Returns_Empty_Collection()
        {
            // Arrange
            var expected = Build<UserStub>();
            var source = new List<UserStub>
            {
                expected,
            };
            var inclusions = new List<UserStub>
            {
                // This should never match the source collection
                Build<UserStub>((e) => e.EmailAddress = $"not-{expected.EmailAddress}")
            };
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(inclusions, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Inclusion_Collection_Empty_Returns_Empty_Collection()
        {
            // Arrange
            var source = BuildList<UserStub>(1);
            var inclusions = new List<UserStub>();
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(inclusions, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Inclusion_Collection_Null_Returns_Empty_Collection()
        {
            // Arrange
            var source = BuildList<UserStub>(1);
            var inclusions = (List<UserStub>)null;
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(inclusions, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Inclusion_Collection_Has_Matching_Elements_Returns_Collection_With_Matching_Elements()
        {
            // Arrange
            var expected = Build<UserStub>();
            var source = new List<UserStub>
            {
                Build<UserStub>(),
                expected,
            };
            var inclusions = new List<UserStub>
            {
                // Based on matching email, this should be only included result
                Build<UserStub>((e) => e.EmailAddress = expected.EmailAddress)
            };
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(inclusions, predicate);

            // Assert
            result.ShouldBeOfSize(1);
            result.ShouldContain(expected);
        }

        #endregion Intersect

        #region PickRandom

        [Fact]
        public void PickRandom_List_Is_Empty_Returns_Null()
        {
            new List<string>().PickRandom().ShouldBeNull();
        }

        [Fact]
        public void PickRandom_When_One_Item_Returns_That_Item()
        {
            new List<string> { "expected" }.PickRandom().ShouldBe("expected");
        }

        [Fact]
        public void PickRandom_When_Multiple_Items_Returns_Single_Item()
        {
            // Arrange
            var expected = "abcded90120423".Split("").ToList();

            for (var i = 0; i <= 100; i++)
            {
                // Act
                var result = expected.PickRandom();

                // Assert
                expected.ShouldContain(result);
            }
        }

        #endregion PickRandom

        #region PickRandom (count)

        [Fact]
        public void PickRandom_Overload_With_Count_List_Is_Empty_Returns_EmptyList()
        {
            new List<string>().PickRandom(count: 2).ShouldBeEmpty();
        }

        [Fact]
        public void PickRandom_Overload_With_Count_When_Count_LessThan_LengthOf_Enumeration_Returns_Records_Matching_LengthOf_Enumeration()
        {
            new List<string> { "expected" }.PickRandom(count: 2).Count().ShouldBe(1);
        }

        [Fact]
        public void PickRandom_Overload_With_Count_When_Multiple_Items_Returns_Requested_NumberOf_Items()
        {
            // Arrange
            var expected = "abcded90120423".Split("").ToList();

            for (var i = 0; i <= expected.Count; i++)
            {
                // Act
                var result = expected.PickRandom(count: i);

                // Assert
                result.Count().ShouldBe(i);
            }
        }

        #endregion PickRandom (count)
    }

}
