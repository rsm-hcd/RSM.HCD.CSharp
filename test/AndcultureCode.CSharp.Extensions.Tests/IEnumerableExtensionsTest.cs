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
            var second = BuildList<UserStub>(1);
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(second, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Except_When_Source_Collection_Empty_Returns_Empty_Collection()
        {
            // Arrange
            var source = new List<UserStub>();
            var second = BuildList<UserStub>(1);
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(second, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Except_When_Second_Collection_Has_No_Matching_Elements_Returns_Source_Collection()
        {
            // Arrange
            var expected = Build<UserStub>();
            var source = new List<UserStub>
            {
                expected,
            };
            var second = new List<UserStub>
            {
                // This should never match the source collection
                Build<UserStub>((e) => e.EmailAddress = $"not-{expected.EmailAddress}")
            };
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(second, predicate);

            // Assert
            result.ShouldBe(source);
        }

        [Fact]
        public void Except_When_Second_Collection_Empty_Returns_Source_Collection()
        {
            // Arrange
            var source = BuildList<UserStub>(1);
            var second = new List<UserStub>();
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(second, predicate);

            // Assert
            result.ShouldBe(source);
        }

        [Fact]
        public void Except_When_Second_Collection_Null_Returns_Source_Collection()
        {
            // Arrange
            var source = BuildList<UserStub>(1);
            var second = (List<UserStub>)null;
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(second, predicate);

            // Assert
            result.ShouldBe(source);
        }

        [Fact]
        public void Except_When_Second_Collection_Has_Matching_Elements_Returns_Collection_Without_Matching_Elements()
        {
            // Arrange
            var unexpected = Build<UserStub>();
            var source = new List<UserStub>
            {
                Build<UserStub>(),
                unexpected,
            };
            var second = new List<UserStub>
            {
                // Based on matching email, this should be excluded from the result
                Build<UserStub>((e) => e.EmailAddress = unexpected.EmailAddress)
            };
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Except(second, predicate);

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
            var second = BuildList<UserStub>(1);
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(second, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Source_Collection_Empty_Returns_Empty_Collection()
        {
            // Arrange
            var source = new List<UserStub>();
            var second = BuildList<UserStub>(1);
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(second, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Second_Collection_Has_No_Matching_Elements_Returns_Empty_Collection()
        {
            // Arrange
            var expected = Build<UserStub>();
            var source = new List<UserStub>
            {
                expected,
            };
            var second = new List<UserStub>
            {
                // This should never match the source collection
                Build<UserStub>((e) => e.EmailAddress = $"not-{expected.EmailAddress}")
            };
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(second, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Second_Collection_Empty_Returns_Empty_Collection()
        {
            // Arrange
            var source = BuildList<UserStub>(1);
            var second = new List<UserStub>();
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(second, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Second_Collection_Null_Returns_Empty_Collection()
        {
            // Arrange
            var source = BuildList<UserStub>(1);
            var second = (List<UserStub>)null;
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(second, predicate);

            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void Intersect_When_Second_Collection_Has_Matching_Elements_Returns_Collection_With_Matching_Elements()
        {
            // Arrange
            var expected = Build<UserStub>();
            var source = new List<UserStub>
            {
                Build<UserStub>(),
                expected,
            };
            var second = new List<UserStub>
            {
                // Based on matching email, this should be only included result
                Build<UserStub>((e) => e.EmailAddress = expected.EmailAddress)
            };
            Func<UserStub, UserStub, bool> predicate = (a, b) => a.EmailAddress == b.EmailAddress;

            // Act
            var result = source.Intersect(second, predicate);

            // Assert
            result.ShouldBeOfSize(1);
            result.ShouldContain(expected);
        }

        #endregion Intersect

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
            var unexpected = $"{source.PickRandom()}-nonmatching";

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
            var expected = source.PickRandom();

            // Act
            var result = source.IsEmpty((e) => e == expected);

            // Assert
            result.ShouldBeFalse();
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
            ((IEnumerable<string>)null)     // Arrange
                .IsNullOrEmpty((e) => true) // Act
                    .ShouldBeTrue();        // Assert
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
            IEnumerableExtensions.Join(list: (IEnumerable<string>)null, delimiter: "test").ShouldBeNull();
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
            IEnumerableExtensions.Join(list: null, delimiter: "test").ShouldBeNull();
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

        #region Join KeyValuePair (Delimiter)

        [Fact]
        public void Join_KeyValuePair_Given_Key_And_Value_Returns_Key_And_Value_With_Delimiter()
        {
            (new KeyValuePair<string, string>("key", "value")).Join(delimiter: ":").ShouldBe("key:value");
        }

        [Fact]
        public void Join_KeyValuePair_Given_Null_Value_Returns_Key()
        {
            (new KeyValuePair<string, string>("key", null)).Join(delimiter: ":").ShouldBe("key");
        }

        [Fact]
        public void Join_KeyValuePair_Given_Null_Key_Returns_Value()
        {
            (new KeyValuePair<string, string>(null, "value")).Join(delimiter: ":").ShouldBe("value");
        }

        [Fact]
        public void Join_KeyValuePair_Given_Null_Key_And_Value_Returns_Empty_String()
        {
            (new KeyValuePair<string, string>(null, null)).Join(delimiter: ":").ShouldBe(string.Empty);
        }

        [Fact]
        public void Join_KeyValuePair_Given_Empty_String_Key_And_Value_Returns_Empty_String()
        {
            (new KeyValuePair<string, string>(string.Empty, string.Empty)).Join(delimiter: ":").ShouldBe(string.Empty);
        }

        [Fact]
        public void Join_KeyValuePair_Given_Empty_String_Key_Returns_Value()
        {
            (new KeyValuePair<string, string>(string.Empty, "value")).Join(delimiter: ":").ShouldBe("value");
        }

        [Fact]
        public void Join_KeyValuePair_Given_Empty_String_Value_Returns_Key()
        {
            (new KeyValuePair<string, string>("key", string.Empty)).Join(delimiter: ":").ShouldBe("key");
        }

        [Fact]
        public void Join_KeyValuePair_Given_Null_Delimiter_Returns_Key_Value_Without_Delimiter()
        {
            (new KeyValuePair<string, string>("key", "value")).Join(delimiter: null).ShouldBe("keyvalue");
        }

        #endregion Join KeyValuePair (Delimiter)

        #region Join List of KeyValuePair (Delimiter)

        [Fact]
        public void Join_Given_List_Of_KeyValuePairs_And_Delimiter_Returns_String_Of_Key_Values_With_Delimiter()
        {
            var keyValue1 = new KeyValuePair<string, string>("key1", "value1");
            var keyValue2 = new KeyValuePair<string, string>("key2", "value2");
            new List<KeyValuePair<string, string>> { keyValue1, keyValue2 }.Join(keyValueDelimiter: ":", delimiter: "; ").ShouldBe("key1:value1; key2:value2");
        }

        [Fact]
        public void Join_Given_List_Of_KeyValuePairs_And_No_Delimiter_Returns_String_Of_Key_Values()
        {
            var keyValue1 = new KeyValuePair<string, string>("key1", "value1");
            var keyValue2 = new KeyValuePair<string, string>("key2", "value2");
            new List<KeyValuePair<string, string>> { keyValue1, keyValue2 }.Join(keyValueDelimiter: ":").ShouldBe("key1:value1, key2:value2");
        }

        [Fact]
        public void Join_Given_List_Of_KeyValuePairs_With_Null_Value_Returns_String_Of_Key_Values()
        {
            var keyValue1 = new KeyValuePair<string, string>("key1", "value1");
            var keyValue2 = new KeyValuePair<string, string>("key2", null);
            new List<KeyValuePair<string, string>> { keyValue1, keyValue2 }.Join(keyValueDelimiter: ":").ShouldBe("key1:value1, key2");
        }

        [Fact]
        public void Join_Given_List_Of_KeyValuePairs_With_Null_Key_Returns_String_Of_Key_Values()
        {
            var keyValue1 = new KeyValuePair<string, string>("key1", "value1");
            var keyValue2 = new KeyValuePair<string, string>(null, "value2");
            new List<KeyValuePair<string, string>> { keyValue1, keyValue2 }.Join(keyValueDelimiter: ":").ShouldBe("key1:value1, value2");
        }

        [Fact]
        public void Join_Given_List_Of_KeyValuePairs_With_Empty_KeyValuePair_Returns_String_Of_Key_Values()
        {
            var keyValue1 = new KeyValuePair<string, string>("key1", "value1");
            var keyValue2 = new KeyValuePair<string, string>(string.Empty, string.Empty);
            new List<KeyValuePair<string, string>> { keyValue1, keyValue2 }.Join(keyValueDelimiter: ":").ShouldBe("key1:value1");
        }

        [Fact]
        public void Join_Given_List_Of_KeyValuePairs_With_Empty_KeyValuePairs_Returns_Empty_String()
        {
            var keyValue1 = new KeyValuePair<string, string>(string.Empty, string.Empty);
            var keyValue2 = new KeyValuePair<string, string>(string.Empty, string.Empty);
            new List<KeyValuePair<string, string>> { keyValue1, keyValue2 }.Join(keyValueDelimiter: ":").ShouldBe(string.Empty);
        }

        [Fact]
        public void Join_Given_List_Of_KeyValuePairs_With_Null_KeyValuePair_Returns_String_Of_Key_Values()
        {
            var keyValue1 = new KeyValuePair<string, string>("key1", "value1");
            var keyValue2 = new KeyValuePair<string, string>(null, null);
            new List<KeyValuePair<string, string>> { keyValue1, keyValue2 }.Join(keyValueDelimiter: ":").ShouldBe("key1:value1");
        }

        [Fact]
        public void Join_Given_List_Of_KeyValuePairs_With_Null_KeyValuePairs_Returns_Empty_String()
        {
            var keyValue1 = new KeyValuePair<string, string>(null, null);
            var keyValue2 = new KeyValuePair<string, string>(null, null);
            new List<KeyValuePair<string, string>> { keyValue1, keyValue2 }.Join(keyValueDelimiter: ":").ShouldBe(string.Empty);
        }

        #endregion Join List of KeyValuePair (Delimiter)

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