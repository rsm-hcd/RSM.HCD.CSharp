using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Core.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Extensions
{
    public class IDistributedCacheExtensionsTest : CoreUnitTest
    {
        #region Setup

        public IDistributedCacheExtensionsTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup

        #region Get<T>

        public class GetTestStub
        {
            public string Name { get; set; }
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Get_When_Key_IsNullOrWhitespace_Returns_Null(string key)
        {
            Mock.Of<IDistributedCache>().Get<GetTestStub>(key).ShouldBeNull();
        }

        [Fact]
        public void Get_When_Key_DoesNotExist_Returns_Null()
        {
            // Arrange
            var key = Random.String();
            var sut = Mock.Of<IDistributedCache>(e => e.Get(key) == null);

            // Act & Assert
            sut.Get<GetTestStub>(key).ShouldBeNull();
        }

        [Fact]
        public void Get_When_Key_Exists_Returns_Deserialized_Result()
        {
            // Arrange
            var key = Random.String();
            var expected = new GetTestStub { Name = Random.Words() };
            var data = JsonConvert.SerializeObject(expected).ToByteArray();
            var sut = Mock.Of<IDistributedCache>(e => e.Get(key) == data);

            // Act
            var result = sut.Get<GetTestStub>(key);

            // Assert
            result.ShouldNotBeNull();
            result.Name.ShouldBe(expected.Name);
        }

        #endregion Get<T>

        #region Set<T>

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Set_When_Key_IsNullOrWhitespace_Returns_Null(string key)
        {
            // Arrange
            var sut = Mock.Of<IDistributedCache>();

            // Act
            var result = sut.Set<string>(key: key, value: Random.String(), options: null);

            // Assert
            result.ShouldBeNull();
        }

        public static IEnumerable<object[]> GetSetCacheData(int numTests) => new List<object[]>
        {
            new object[] { "test" },
            new object[] { 50 },
            new object[] { new GetTestStub() },
        };

        [Theory]
        [MemberData(nameof(GetSetCacheData), parameters: 1)]
        public void Set_Caches_Value(object value)
        {
            // Arrange
            var key = Random.String();
            var sut = new Mock<IDistributedCache>();
            var expected = sut.Object.Serialize(value);

            // Act
            sut.Object.Set<object>(key: key, value: value, options: null);

            // Assert
            sut.Verify(x => x.Set(key, It.IsAny<byte[]>(), null), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetSetCacheData), parameters: 1)]
        public void Set_Returns_Serialized_Value(object value)
        {
            // Arrange
            var key = Random.String();
            var sut = new Mock<IDistributedCache>();
            var expected = sut.Object.Serialize(value);

            // Act
            var result = sut.Object.Set<object>(key: key, value: value, options: null);

            // Assert
            result.ShouldBe(expected);
        }

        #endregion Set<T>
    }
}
