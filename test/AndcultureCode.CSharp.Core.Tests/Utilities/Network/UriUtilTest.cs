using AndcultureCode.CSharp.Core.Utilities.Network;
using AndcultureCode.CSharp.Testing;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Utilities.Network
{
    public class UriUtilsTest : UnitTestBase
    {
        #region Setup

        public UriUtilsTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup

        #region IsInValidHttpUrl

        [Fact]
        public void IsInValidHttpUrl_With_Invalid_Url_Returns_True()
        {
            UriUtils.IsInvalidHttpUrl("www.google.com").ShouldBeTrue();
        }

        [Fact]
        public void IsInValidHttpUrl_With_Valid_Url_Returns_False()
        {
            UriUtils.IsInvalidHttpUrl("http://www.google.com").ShouldBeFalse();
        }

        #endregion IsInValidHttpUrl

        #region IsValidHttpUrl

        [Fact]
        public void IsValidHttpUrl_With_Valid_Url_Returns_True()
        {
            UriUtils.IsValidHttpUrl("http://www.google.com").ShouldBeTrue();
        }

        [Fact]
        public void IsValidHttpUrl_With_Https_Url_Returns_True()
        {
            UriUtils.IsValidHttpUrl("https://www.google.com").ShouldBeTrue();
        }

        [Fact]
        public void IsValidHttpUrl_With_Null_Returns_False()
        {
            UriUtils.IsValidHttpUrl(null).ShouldBeFalse();
        }

        [Fact]
        public void IsValidHttpUrl_With_Empty_String_Returns_False()
        {
            UriUtils.IsValidHttpUrl(string.Empty).ShouldBeFalse();
        }

        [Fact]
        public void IsValidHttpUrl_With_Incomplete_Url_Returns_False()
        {
            UriUtils.IsValidHttpUrl("www.google.com").ShouldBeFalse();
        }

        #endregion IsValidHttpUrl


    }
}
