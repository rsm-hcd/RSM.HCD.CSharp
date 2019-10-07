using System;
using System.Linq;
using Newtonsoft.Json;
using Shouldly;
using Xunit;
using Xunit.Sdk;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class StringExtensionsTests
    {
        #region AsIndentedJson

        [Fact]
        public void AsIndentedJson_When_String_Is_Null_Then_Returns_Null()
        {
            // Arrange
            var jsonString = null as string;
            // Assert
            var result = jsonString.AsIndentedJson();
            // Act
            result.ShouldBe(null);
        }

        [Fact]
        public void AsIndentedJson_When_String_Is_Empty_Then_Returns_Empty_String()
        {
            // Arrange
            var jsonString = "";
            // Assert
            var result = jsonString.AsIndentedJson();
            // Act
            result.ShouldBe("");
        }

        [Fact]
        public void AsIndentedJson_When_String_Is_Not_Valid_Json_Then_Throws()
        {
            // Arrange
            var jsonString = @"{ ""property"": }";
            // Assert & Act
            Should.Throw<JsonReaderException>(() => jsonString.AsIndentedJson());
        }

        [Fact]
        public void AsIndentedJson_When_String_Is_Compact_Then_Returns_Indented_Json()
        {
            // Arrange
            var jsonString = @"{""property"":""value"",""index"":1,""child"":{""prop"":13}}";
            var expected = @"{
  ""property"": ""value"",
  ""index"": 1,
  ""child"": {
    ""prop"": 13
  }
}";
            // Assert
            var result = jsonString.AsIndentedJson();
            // Act            
            result.ShouldBe(expected);
        }

        #endregion

        #region ToBoolean

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("\r\n")]
        public void ToBoolean_When_String_Is_Null_Or_WhiteSpace_Then_Returns_False(string input)
        {
            // Arrange
            // Assert
            var result = input.ToBoolean();
            // Act
            result.ShouldBe(false);
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData("t", true)]
        [InlineData("1", true)]
        [InlineData("0", false)]
        [InlineData("false", false)]
        [InlineData("f", false)]
        public void ToBoolean_When_String_Is_Explicit_Boolean_Then_Returns_Expected_Value(string input, bool expected)
        {
            // Arrange
            // Assert
            var result = input.ToBoolean();
            // Act
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToBoolean_When_String_Is_Not_Explicitly_Matched_Then_Returns_False()
        {
            // Arrange
            var input = "lorem ipsum";
            // Assert
            var result = input.ToBoolean();
            // Act         
            result.ShouldBe(false);
        }

        #endregion

        #region ToEnumerable

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("\r\n")]
        public void ToEnumerable_When_String_Is_Null_Or_WhiteSpace_Then_Returns_Null(string input)
        {
            // Arrange
            // Assert
            var result = input.ToEnumerable<int>();
            // Act
            result.ShouldBe(null);
        }

        [Fact]
        public void ToEnumerable_When_String_Is_Single_Integer_Then_Returns_Collection_Of_Single_Integer()
        {
            // Arrange
            var input = "42";
            var expected = new[] { 42 };
            // Assert
            var result = input.ToEnumerable<int>();
            // Act
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToEnumerable_When_String_Contains_Multiple_Integers_Then_Returns_Collection_Of_All_Values()
        {
            // Arrange
            var input = "1,2,3";
            var expected = new[] { 1, 2, 3 };
            // Assert
            var result = input.ToEnumerable<int>();
            // Act
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToEnumerable_When_Given_Separator_Then_Returns_Collection_Split_On_That_Separator()
        {
            // Arrange
            var input = "4;5;6";
            var expected = new[] { 4, 5, 6 };
            // Assert
            var result = input.ToEnumerable<int>(';');
            // Act
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToEnumerable_When_Given_Invalid_Items_In_List_Then_Returns_List_Without_Those_Items()
        {
            // Arrange
            var input = "7,a,8,9";
            var expected = new[] { 7, 8, 9 };
            // Assert
            var result = input.ToEnumerable<int>();
            // Act
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToEnumerable_When_Given_Boolean_Generic_Type_Then_Returns_Boolean_Values()
        {
            // Arrange
            var input = "true,false,true";
            var expected = new[] { true, false, true };
            // Assert
            var result = input.ToEnumerable<bool>();
            // Act            
            result.ShouldBe(expected);
        }

        #endregion
        
        #region ToInt

        [Fact]
        public void ToInt_When_Given_Valid_Integer_Value_Then_Returns_That_Value()
        {
            // Arrange
            var input = "123";
            // Assert
            var result = input.ToInt();
            // Act
            result.ShouldBe(123);
        }

        [Fact]
        public void ToInt_When_Given_Invalid_Integer_Value_And_No_Default_Then_Returns_Zero()
        {
            // Arrange
            var input = "abc";
            // Assert
            var result = input.ToInt();
            // Act
            result.ShouldBe(0);
        }

        [Fact]
        public void ToInt_When_Given_Invalid_Integer_Value__Default_Then_Returns_Default()
        {
            // Arrange
            var input = "abc";
            var defaultValue = 1024;
            // Assert
            var result = input.ToInt(1024);
            // Act
            result.ShouldBe(defaultValue);
        }

        #endregion
    }
}