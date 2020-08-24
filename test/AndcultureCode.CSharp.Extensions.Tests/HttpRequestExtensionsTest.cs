using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing.Extensions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Net;
using Microsoft.Net.Http.Headers;

namespace AndcultureCode.CSharp.Extensions.Tests.Unit.Extensions
{
    public class HttpRequestExtensionsTest : BaseExtensionsTest
    {
        #region Setup

        public HttpRequestExtensionsTest(ITestOutputHelper output) : base(output)
        {

        }

        #endregion Setup

        #region GetHeader

        [Fact]
        public void GetHeader_When_HttpRequest_Null_Returns_Null()
        {
            // Arrange
            HttpRequest sut = null;

            // Act
            var result = sut.GetHeader(HeaderNames.Upgrade);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void GetHeader_When_Headers_Null_Returns_Null()
        {
            // Arrange
            var mockSut = new Mock<HttpRequest>();
            mockSut.Setup((e) => e.Headers).Returns(value: null);
            var sut = mockSut.Object;

            // Act
            var result = sut.GetHeader(HeaderNames.Vary);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void GetHeader_When_Headers_Does_Not_Contain_Requested_Key_Returns_Null()
        {
            // Arrange
            var mockSut = new Mock<HttpRequest>();
            mockSut.Setup((e) => e.Headers).Returns(value: new HeaderDictionary());
            var sut = mockSut.Object;

            // Act
            var result = sut.GetHeader(HeaderNames.Warning);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void GetHeader_When_Headers_Contains_Requested_Key_With_Empty_Value_Returns_Null()
        {
            // Arrange
            var expectedHeader = HeaderNames.TransferEncoding;
            var headerDictionary = new HeaderDictionary { { expectedHeader, string.Empty } };
            var mockSut = new Mock<HttpRequest>();
            mockSut.Setup((e) => e.Headers).Returns(value: headerDictionary);
            var sut = mockSut.Object;

            // Act
            var result = sut.GetHeader(HeaderNames.TransferEncoding);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void GetHeader_When_Headers_Contains_Requested_Key_With_Whitespace_Value_Returns_Null()
        {
            // Arrange
            var expectedHeader = HeaderNames.StrictTransportSecurity;
            var headerDictionary = new HeaderDictionary { { expectedHeader, "  " } };
            var mockSut = new Mock<HttpRequest>();
            mockSut.Setup((e) => e.Headers).Returns(value: headerDictionary);
            var sut = mockSut.Object;

            // Act
            var result = sut.GetHeader(expectedHeader);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void GetHeader_When_Headers_Contains_Requested_Key_With_Value_Returns_Value()
        {
            // Arrange
            var expectedHeader = HeaderNames.TE;
            var expectedValue = Random.String();
            var headerDictionary = new HeaderDictionary { { expectedHeader, expectedValue } };
            var mockSut = new Mock<HttpRequest>();
            mockSut.Setup((e) => e.Headers).Returns(value: headerDictionary);
            var sut = mockSut.Object;

            // Act
            var result = sut.GetHeader(expectedHeader);

            // Assert
            result.ShouldBe(expectedValue);
        }

        #endregion GetHeader

        #region GetIpAddress

        [Fact]
        public void GetIpAddress_When_Headers_Contains_Requested_Key_With_Value_Returns_Value()
        {
            // Arrange
            var expectedHeader = HttpRequestExtensions.X_FORWARDED_FOR;
            var expectedValue = Random.String();
            var headerDictionary = new HeaderDictionary { { expectedHeader, expectedValue } };
            var mockSut = new Mock<HttpRequest>();
            mockSut.Setup((e) => e.Headers).Returns(value: headerDictionary);
            var sut = mockSut.Object;

            // Act
            var result = sut.GetIpAddress();

            // Assert
            result.ShouldBe(expectedValue);
        }

        #endregion GetIpAddress

        #region GetUserAgent

        [Fact]
        public void GetUserAgent_When_Headers_Contains_Requested_Key_With_Value_Returns_Value()
        {
            // Arrange
            var expectedHeader = HeaderNames.UserAgent;
            var expectedValue = Random.String();
            var headerDictionary = new HeaderDictionary { { expectedHeader, expectedValue } };
            var mockSut = new Mock<HttpRequest>();
            mockSut.Setup((e) => e.Headers).Returns(value: headerDictionary);
            var sut = mockSut.Object;

            // Act
            var result = sut.GetUserAgent();

            // Assert
            result.ShouldBe(expectedValue);
        }

        #endregion GetUserAgent
    }
}
