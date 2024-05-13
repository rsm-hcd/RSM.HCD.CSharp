using Shouldly;
using Xunit;
using Xunit.Abstractions;
using RSM.HCD.CSharp.Testing.Extensions;
using Microsoft.AspNetCore.Http;
using Moq;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System;

namespace RSM.HCD.CSharp.Extensions.Tests.Unit.Extensions
{
    public class HttpRequestExtensionsTest : BaseExtensionsTest
    {
        #region Setup

        public HttpRequestExtensionsTest(ITestOutputHelper output) : base(output)
        {

        }

        #endregion Setup

        #region GetCookie

        [Fact]
        public void GetCookie_When_Request_Null_Retuns_Null()
        {
            // Arrange
            var sut = null as HttpRequest;

            // Act
            var result = sut.GetCookie(Random.Word());

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void GetCookie_When_Request_Does_Not_Contain_Cookie_Name_Returns_Null()
        {
            // Arrange
            var sut = Mock.Of<HttpRequest>();
            Mock.Get(sut).Setup((e) => e.Cookies.Keys).Returns(new List<String>());

            // Act
            var result = sut.GetCookie(Random.Word());

            // Assert
            result.ShouldBeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        public void GetCookie_When_Request_Cookie_Value_Null_Or_Whitespace_Returns_Null(string cookieValue)
        {
            // Arrange
            var key = Random.Word();
            var cookieCollection = Mock.Of<IRequestCookieCollection>();
            Mock.Get(cookieCollection).SetupGet((e) => e[It.IsAny<string>()]).Returns(cookieValue);
            Mock.Get(cookieCollection).Setup((e) => e.ContainsKey(It.IsAny<String>())).Returns(true);
            var sut = Mock.Of<HttpRequest>();
            Mock.Get(sut).Setup((e) => e.Cookies).Returns(cookieCollection);

            // Act
            var result = sut.GetCookie(key);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void GetCookie_When_Request_Cookie_Has_Value_Returns_Value()
        {
            // Arrange
            var key = Random.Word();
            var value = Random.Guid().ToString();
            var cookieCollection = Mock.Of<IRequestCookieCollection>();
            Mock.Get(cookieCollection).SetupGet((e) => e[key]).Returns(value);
            Mock.Get(cookieCollection).Setup((e) => e.ContainsKey(key)).Returns(true);
            var sut = Mock.Of<HttpRequest>();
            Mock.Get(sut).Setup((e) => e.Cookies).Returns(cookieCollection);

            // Act
            var result = sut.GetCookie(key);

            // Assert
            result.ShouldBe(value);
        }

        #endregion GetCookie

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

        #region HasCookie

        [Fact]
        public void HasCookie_When_Request_Cookies_Is_Null_Then_Returns_False()
        {
            // Arrange
            HttpRequest sut = null;

            // Act && Assert
            sut.HasCookie(name: Random.String2(1)).ShouldBeFalse();
        }

        [Fact]
        public void HasCookie_When_Name_Is_Null_Then_Returns_False()
        {
            // Arrange
            var sut = Mock.Of<HttpRequest>();
            string name = null;

            // Act && Assert
            sut.HasCookie(name).ShouldBeFalse();
        }

        [Fact]
        public void HasCookie_Given_Name_When_Request_Cookies_DoesNot_Contain_Matching_Cookie_Name_Then_Returns_False()
        {
            // Arrange
            var key = Random.Word();
            var value = Random.Guid().ToString();
            var cookieCollection = Mock.Of<IRequestCookieCollection>();
            Mock.Get(cookieCollection).Setup((e) => e.ContainsKey(key)).Returns(false);
            Mock.Get(cookieCollection).SetupGet((e) => e[key]).Returns(value);
            var sut = Mock.Of<HttpRequest>();
            Mock.Get(sut).Setup((e) => e.Cookies).Returns(cookieCollection);

            // Act && Assert
            sut.HasCookie(key).ShouldBeFalse();
        }

        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        public void HasCookie_Given_Name_When_CookieCollection_Is_NullOrWhitespace_At_Index_Name_Then_Returns_False(string cookieName)
        {
            // Arrange
            var cookieCollection = Mock.Of<IRequestCookieCollection>();
            Mock.Get(cookieCollection).Setup((e) => e.ContainsKey(cookieName)).Returns(true);
            Mock.Get(cookieCollection).SetupGet((e) => e[cookieName]).Returns(cookieName);
            var sut = Mock.Of<HttpRequest>();
            Mock.Get(sut).Setup((e) => e.Cookies).Returns(cookieCollection);

            // Act && Assert
            sut.HasCookie(cookieName).ShouldBeFalse();
        }

        [Fact]
        public void HasCookie_Given_Name_When_Exists_In_Collection_Then_Returns_True()
        {
            // Arrange
            var key = Random.Word();
            var value = Random.Guid().ToString();
            var cookieCollection = Mock.Of<IRequestCookieCollection>();
            Mock.Get(cookieCollection).Setup((e) => e.ContainsKey(key)).Returns(true);
            Mock.Get(cookieCollection).SetupGet((e) => e[key]).Returns(value);
            var sut = Mock.Of<HttpRequest>();
            Mock.Get(sut).Setup((e) => e.Cookies).Returns(cookieCollection);

            // Act && Assert
            sut.HasCookie(key).ShouldBeTrue();
        }

        #endregion HasCookie

    }
}
