using System;
using AndcultureCode.CSharp.Core.Utilities.Security;
using AndcultureCode.CSharp.Testing;
using AndcultureCode.CSharp.Testing.Tests;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Utilities.Security
{
    public class GuidUtilsTest : CoreUnitTest
    {
        #region Setup

        public GuidUtilsTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup

        #region IsInvalid

        [Fact]
        public void IsInvalid_With_Valid_Guid_Returns_False()
        {
            GuidUtils.IsInvalid(Guid.NewGuid().ToString()).ShouldBeFalse();
        }

        [Fact]
        public void IsInvalid_With_Invalid_Guide_Returns_True()
        {
            GuidUtils.IsInvalid("not a guid").ShouldBeTrue();
        }

        #endregion IsInvalid

        #region IsValid

        [Fact]
        public void IsValid_With_Valid_Guid_Returns_True()
        {
            GuidUtils.IsValid(Guid.NewGuid().ToString()).ShouldBeTrue();
        }

        [Fact]
        public void IsValid_With_Invaid_Guid_Returns_False()
        {
            GuidUtils.IsValid("not a guid").ShouldBeFalse();
        }

        [Fact]
        public void IsValid_With_Null_Guid_Returns_False()
        {
            GuidUtils.IsValid(null).ShouldBeFalse();
        }

        [Fact]
        public void IsValid_With_Empty_String_Guid_Returns_False()
        {
            GuidUtils.IsValid(string.Empty).ShouldBeFalse();
        }

        #endregion IsValid
    }
}
