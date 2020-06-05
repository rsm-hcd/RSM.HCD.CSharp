using System;
using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Extensions.Tests.Stubs;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class TypeExtensionsTests
    {
        #region GetPublicConstantValues<T>

        private class GetPublicConstantValuesTestStub
        {
            public const string TEST_CONST_STRING_PROPERTY1 = "TEST_CONST_STRING_PROPERTY1";
            public const string TEST_CONST_STRING_PROPERTY2 = "TEST_CONST_STRING_PROPERTY2";
            private const string TEST_PRIVATE_CONST_STRING_PROPERTY = "TEST_PRIVATE_CONST_STRING_PROPERTY";
            public const long TEST_CONST_LONG_PROPERTY = 20;

            public static long TEST_STATIC_LONG_PROPERTY = 10;
            public static string TEST_STATIC_STRING_PROPERTY = "TEST_STATIC_STRING_PROPERTY";
            private static string TEST_PRIVATE_STATIC_STRING_PROPERTY = "TEST_PRIVATE_STATIC_STRING_PROPERTY";

            private string _privateTestProperty = "privateTestProperty";
        }

        [Fact]
        public void GetPublicConstantValues_Given_TypeOf_String_Returns_Public_Static_String_Properties()
        {
            // Arrange & Act
            var results = typeof(GetPublicConstantValuesTestStub).GetPublicConstantValues<string>();

            // Assert
            results.ShouldNotBeNull();
            results.Count().ShouldBe(2);
            results.ShouldContain(GetPublicConstantValuesTestStub.TEST_CONST_STRING_PROPERTY1);
            results.ShouldContain(GetPublicConstantValuesTestStub.TEST_CONST_STRING_PROPERTY2);
        }

        [Fact]
        public void GetPublicConstantValues_Given_TypeOf_Long_Returns_Public_Static_Long_Properties()
        {
            // Arrange & Act
            var results = typeof(GetPublicConstantValuesTestStub).GetPublicConstantValues<long>();

            // Assert
            results.ShouldNotBeNull();
            results.Count().ShouldBe(1);
            results.ShouldContain(GetPublicConstantValuesTestStub.TEST_CONST_LONG_PROPERTY);
        }

        #endregion GetPublicConstantValues<T>

        #region GetTypeName(object obj)

        private class GetTypeNameTestStub { }

        [Fact]
        public void GetTypeName_Object_Overload_Given_Null_Returns_Null()
        {
            TypeExtensions.GetTypeName(null).ShouldBeNull();
        }

        [Fact]
        public void GetTypeName_Object_Overload_Given_InstaceOf_Object_Returns_FullName()
        {
            // Arrange
            var type = new GetTypeNameTestStub();

            // Act
            var result = type.GetTypeName();

            // Assert
            result.ShouldContain(typeof(GetTypeNameTestStub).FullName);
        }

        [Fact]
        public void GetTypeName_Object_Overload_Given_InstaceOf_Object_Returns_AssemblyQualifiedName()
        {
            // Arrange
            var type = new GetTypeNameTestStub();

            // Act
            var result = type.GetTypeName();

            // Assert
            result.ShouldContain(typeof(GetTypeNameTestStub).AssemblyQualifiedName);
        }

        #endregion GetTypeName(object obj)

        #region GetTypeName(Type type)

        [Fact]
        public void GetTypeName_Type_Overload_Given_Null_Returns_Null()
        {
            TypeExtensions.GetTypeName(type: null).ShouldBeNull();
        }

        [Fact]
        public void GetTypeName_Type_Overload_Given_InstaceOf_Object_Returns_FullName()
        {
            // Arrange
            var type = typeof(GetTypeNameTestStub);

            // Act
            var result = type.GetTypeName();

            // Assert
            result.ShouldContain(typeof(GetTypeNameTestStub).FullName);
        }

        [Fact]
        public void GetTypeName_Type_Overload_Given_InstaceOf_Object_Returns_AssemblyQualifiedName()
        {
            // Arrange
            var type = typeof(GetTypeNameTestStub);

            // Act
            var result = type.GetTypeName();

            // Assert
            result.ShouldContain(typeof(GetTypeNameTestStub).AssemblyQualifiedName);
        }

        #endregion GetTypeName(Type type)

        #region WhereWithAttribute

        [Fact]
        public void WhereWithAttribute_Given_Types_IsNull_Returns_Null()
        {
            TypeExtensions.WhereWithAttribute<AttributeUsageAttribute>(null).ShouldBeNull();
        }

        [Fact]
        public void WhereWithAttribute_Given_Types_IsEmpty_Returns_EmptyList()
        {
            // Arrange
            var sut = new List<Type>();

            // Act
            var result = sut.WhereWithAttribute<AttributeUsageAttribute>();


            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        [Fact]
        public void WhereWithAttribute_Given_Mixed_Types_With_Attribute_Returns_Decorated_Types()
        {
            // Arrange
            var expected = typeof(ClassWithClassAttributeTestStub);
            var sut = new List<Type>
            {
                expected,
                typeof(ClassWithoutClassAttributeTestStub),
            };

            // Act
            var result = sut.WhereWithAttribute<AttributeUsageAttribute>();

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.ShouldContain(expected);
        }

        [Fact]
        public void WhereWithAttribute_Given_Mixed_Types_With_Attribute_Returns_Decorated_Types_Without_Duplicates()
        {
            // Arrange
            var expected = typeof(ClassWithClassAttributeTestStub);
            var sut = new List<Type>
            {
                expected,
                expected, // <----------------- duplicate
                typeof(ClassWithoutClassAttributeTestStub),
            };

            // Act
            var result = sut.WhereWithAttribute<AttributeUsageAttribute>();

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.ShouldContain(expected);
        }

        #endregion WhereWithAttribute

        #region WhereWithoutAttribute

        [Fact]
        public void WhereWithoutAttribute_Given_Types_IsNull_Returns_Null()
        {
            TypeExtensions.WhereWithoutAttribute<AttributeUsageAttribute>(null).ShouldBeNull();
        }

        [Fact]
        public void WhereWithoutAttribute_Given_Types_IsEmpty_Returns_EmptyList()
        {
            // Arrange
            var sut = new List<Type>();

            // Act
            var result = sut.WhereWithoutAttribute<AttributeUsageAttribute>();

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        [Fact]
        public void WhereWithoutAttribute_Given_Mixed_Types_With_Attribute_Returns_Undecorated_Types()
        {
            // Arrange
            var expected = typeof(ClassWithoutClassAttributeTestStub);
            var sut = new List<Type>
            {
                expected,
                typeof(ClassWithClassAttributeTestStub),
            };

            // Act
            var result = sut.WhereWithoutAttribute<AttributeUsageAttribute>();

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.ShouldContain(expected);
        }

        [Fact]
        public void WhereWithoutAttribute_Given_Mixed_Types_With_Attribute_Returns_Undecorated_Types_Without_Duplicates()
        {
            // Arrange
            var expected = typeof(ClassWithoutClassAttributeTestStub);
            var sut = new List<Type>
            {
                expected,
                expected, // <------------- duplicates
                typeof(ClassWithClassAttributeTestStub),
            };

            // Act
            var result = sut.WhereWithoutAttribute<AttributeUsageAttribute>();

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.ShouldContain(expected);
        }

        #endregion WhereWithoutAttribute
    }
}