using System.Collections.Generic;
using System.Linq;
using RSM.HCD.CSharp.Core.Extensions;
using RSM.HCD.CSharp.Testing.Tests;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Core.Tests.Unit.Extensions
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
            EnumerableExtensions.Join(list: null, delimiter: "test").ShouldBeNull();
        }

        [Fact]
        public void Join_IEnumerable_Given_Delimiter_When_Empty_Returns_Empty_String()
        {
            new List<string>().Join(delimiter: "test").ShouldBeEmpty();
        }

        [Fact]
        public void Join_IEnumerable_Given_Delimiter_When_Single_Value_Returns_Value_Without_Delimiter()
        {
            new List<string> { "value1" }.Join(delimiter: "test").ShouldBe("value1");
        }

        [Fact]
        public void Join_IEnumerable_Given_Delimiter_When_Multiple_Values_Returns_Values_With_Delimiter()
        {
            new List<string> { "value1", "value2" }.Join(delimiter: ":").ShouldBe("value1:value2");
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

        #region Join KeyValuePair (Delimiter)

        [Fact]
        public void Join_KeyValuePair_Given_Key_And_Value_Returns_Key_And_Value_With_Delimiter()
        {
            (new KeyValuePair<string, string>("key", "value")).Join(delimiter: ":").ShouldBe("key:value");
        }

        [Fact]
        public void Join_KeyValuePair_Given_Null_Value_Returns_Key()
        {
            new KeyValuePair<string, string>("key", null).Join(delimiter: ":").ShouldBe("key");
        }

        [Fact]
        public void Join_KeyValuePair_Given_Null_Key_Returns_Value()
        {
            new KeyValuePair<string, string>(null, "value").Join(delimiter: ":").ShouldBe("value");
        }

        [Fact]
        public void Join_KeyValuePair_Given_Null_Key_And_Value_Returns_Empty_String()
        {
            new KeyValuePair<string, string>(null, null).Join(delimiter: ":").ShouldBe(string.Empty);
        }

        [Fact]
        public void Join_KeyValuePair_Given_Empty_String_Key_And_Value_Returns_Empty_String()
        {
            new KeyValuePair<string, string>(string.Empty, string.Empty).Join(delimiter: ":").ShouldBe(string.Empty);
        }

        [Fact]
        public void Join_KeyValuePair_Given_Empty_String_Key_Returns_Value()
        {
            new KeyValuePair<string, string>(string.Empty, "value").Join(delimiter: ":").ShouldBe("value");
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
    }

}
