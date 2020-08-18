using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class IEnumerableExtensionsTest
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
            IEnumerableExtensions                         // Arrange
                .IsNullOrEmpty<string>(                  // Act
                        source: null,
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
            (new KeyValuePair<string,string>("key", "value")).Join(delimiter: ":").ShouldBe("key:value");
        }
        
        [Fact]
        public void Join_KeyValuePair_Given_Null_Value_Returns_Key()
        {
            (new KeyValuePair<string,string>("key", null)).Join(delimiter: ":").ShouldBe("key");
        }
        
        [Fact]
        public void Join_KeyValuePair_Given_Null_Key_Returns_Value()
        {
            (new KeyValuePair<string,string>(null, "value")).Join(delimiter: ":").ShouldBe("value");
        }
        
        [Fact]
        public void Join_KeyValuePair_Given_Null_Key_And_Value_Returns_Empty_String()
        {
            (new KeyValuePair<string,string>(null, null)).Join(delimiter: ":").ShouldBe(string.Empty);
        }
        
        [Fact]
        public void Join_KeyValuePair_Given_Empty_String_Key_And_Value_Returns_Empty_String()
        {
            (new KeyValuePair<string,string>(string.Empty, string.Empty)).Join(delimiter: ":").ShouldBe(string.Empty);
        }
        
        [Fact]
        public void Join_KeyValuePair_Given_Empty_String_Key_Returns_Value()
        {
            (new KeyValuePair<string,string>(string.Empty, "value")).Join(delimiter: ":").ShouldBe("value");
        }
        
        [Fact]
        public void Join_KeyValuePair_Given_Empty_String_Value_Returns_Key()
        {
            (new KeyValuePair<string,string>("key", string.Empty)).Join(delimiter: ":").ShouldBe("key");
        }
        
        [Fact]
        public void Join_KeyValuePair_Given_Null_Delimiter_Returns_Key_Value_Without_Delimiter()
        {
            (new KeyValuePair<string,string>("key", "value")).Join(delimiter: null).ShouldBe("keyvalue");
        }

        #endregion Join KeyValuePair (Delimiter)


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