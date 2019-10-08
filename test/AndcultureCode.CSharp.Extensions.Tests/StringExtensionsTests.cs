using Newtonsoft.Json;
using Shouldly;
using Xunit;

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
            
            // Act
            var result = jsonString.AsIndentedJson();
            
            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void AsIndentedJson_When_String_Is_Empty_Then_Returns_Empty_String()
        {
            // Arrange
            var jsonString = "";
            
            // Act
            var result = jsonString.AsIndentedJson();
            
            // Assert
            result.ShouldBeEmpty();
        }

        [Fact]
        public void AsIndentedJson_When_String_Is_Not_Valid_Json_Then_Throws()
        {
            // Arrange
            var jsonString = @"{ ""property"": }";
            
            // Act & Assert
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
            
            // Act
            var result = jsonString.AsIndentedJson();
            
            // Assert            
            result.ShouldBe(expected);
        }

        #endregion AsIndentedJson

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
            
            // Act
            var result = input.ToBoolean();
            // Assert
            result.ShouldBeFalse();
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
            // Act
            var result = input.ToBoolean();
            // Assert
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToBoolean_When_String_Is_Not_Explicitly_Matched_Then_Returns_False()
        {
            // Arrange
            var input = "lorem ipsum";
            
            // Act
            var result = input.ToBoolean();
            
            // Assert         
            result.ShouldBeFalse();
        }

        #endregion ToBoolean

        #region ToEnumerable

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("\r\n")]
        public void ToEnumerable_When_String_Is_Null_Or_WhiteSpace_Then_Returns_Null(string input)
        {
           // Act
            var result = input.ToEnumerable<int>();
            
            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void ToEnumerable_When_String_Is_Single_Integer_Then_Returns_Collection_Of_Single_Integer()
        {
            // Arrange
            var input = "42";
            var expected = new[] { 42 };
            
            // Act
            var result = input.ToEnumerable<int>();
            
            // Assert
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToEnumerable_When_String_Contains_Multiple_Integers_Then_Returns_Collection_Of_All_Values()
        {
            // Arrange
            var input = "1,2,3";
            var expected = new[] { 1, 2, 3 };
            
            // Act
            var result = input.ToEnumerable<int>();
            
            // Assert
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToEnumerable_When_Given_Separator_Then_Returns_Collection_Split_On_That_Separator()
        {
            // Arrange
            var input = "4;5;6";
            var expected = new[] { 4, 5, 6 };
            
            // Act
            var result = input.ToEnumerable<int>(';');
            
            // Assert
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToEnumerable_When_Given_Invalid_Items_In_List_Then_Returns_List_Without_Those_Items()
        {
            // Arrange
            var input = "7,a,8,9";
            var expected = new[] { 7, 8, 9 };
            
            // Act
            var result = input.ToEnumerable<int>();
            
            // Assert
            result.ShouldBe(expected);
        }

        [Fact]
        public void ToEnumerable_When_Given_Boolean_Generic_Type_Then_Returns_Boolean_Values()
        {
            // Arrange
            var input = "true,false,true";
            var expected = new[] { true, false, true };
            
            // Act
            var result = input.ToEnumerable<bool>();
            
            // Assert            
            result.ShouldBe(expected);
        }

        #endregion ToEnumerable
        
        #region ToInt

        [Fact]
        public void ToInt_When_Given_Valid_Integer_Value_Then_Returns_That_Value()
        {
            // Arrange
            var input = "123";
            
            // Act
            var result = input.ToInt();
            
            // Assert
            result.ShouldBe(123);
        }

        [Fact]
        public void ToInt_When_Given_Invalid_Integer_Value_And_No_Default_Then_Returns_Zero()
        {
            // Arrange
            var input = "abc";
            
            // Act
            var result = input.ToInt();
            
            // Assert
            result.ShouldBe(0);
        }

        [Fact]
        public void ToInt_When_Given_Invalid_Integer_Value__Default_Then_Returns_Default()
        {
            // Arrange
            var input = "abc";
            var defaultValue = 1024;
            
            // Act
            var result = input.ToInt(1024);
            
            // Assert
            result.ShouldBe(defaultValue);
        }

        #endregion ToInt
    }
}