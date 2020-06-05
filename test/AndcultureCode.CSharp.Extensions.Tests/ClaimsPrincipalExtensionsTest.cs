using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing.Extensions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Net;
using System.Security.Claims;
using System;
using AndcultureCode.CSharp.Core.Constants;
using System.Collections.Generic;

namespace AndcultureCode.CSharp.Extensions.Tests.Unit.Extensions
{
    public class ClaimsPrincipalExtensionsTest : BaseExtensionsTest
    {
        #region Setup

        public ClaimsPrincipalExtensionsTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup

        #region IsAuthenticated

        [Fact]
        public void IsAuthenticated_Given_Principal_IsNull_Returns_False()
        {
            ClaimsPrincipalExtensions.IsAuthenticated(principal: null).ShouldBeFalse();
        }

        [Fact]
        public void IsAuthenticated_Given_Principal_Identity_IsNull_Returns_False()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity == null);

            // Act & Assert
            principal.IsAuthenticated().ShouldBeFalse();
        }

        [Fact]
        public void IsAuthenticated_Given_Principal_Identity_IsAuthenticated_IsFalse_Returns_False()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity.IsAuthenticated == false);

            // Act & Assert
            principal.IsAuthenticated().ShouldBeFalse();
        }

        [Fact]
        public void IsAuthenticated_Given_Principal_Identity_IsAuthenticated_IsTrue_Returns_True()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity.IsAuthenticated == true);

            // Act & Assert
            principal.IsAuthenticated().ShouldBeTrue();
        }

        #endregion IsAuthenticated

        #region IsSuperAdmin

        [Fact]
        public void IsSuperAdmin_Given_Principal_IsNull_Throws_Exception()
        {
            Should.Throw<ArgumentNullException>(() =>
            {
                ClaimsPrincipalExtensions.IsSuperAdmin(principal: null);
            });
        }

        [Fact]
        public void IsSuperAdmin_When_Unauthenticated_Returns_False()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity.IsAuthenticated == false);

            // Act & Assert
            principal.IsSuperAdmin().ShouldBeFalse();
        }

        [Fact]
        public void IsSuperAdmin_When_IsSuperAdmin_Claim_IsTrue_Returns_True()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.HasClaim(ApiClaimTypes.IS_SUPER_ADMIN, "true") == true
            );

            // Act & Assert
            principal.IsSuperAdmin().ShouldBeTrue();
        }

        [Fact]
        public void IsSuperAdmin_When_IsSuperAdmin_Claim_IsFalse_Returns_False()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.HasClaim(ApiClaimTypes.IS_SUPER_ADMIN, "true") == false
            );

            // Act & Assert
            principal.IsSuperAdmin().ShouldBeFalse();
        }

        #endregion IsSuperAdmin

        #region IsUnauthenticated

        [Fact]
        public void IsUnauthenticated_Given_Principal_IsNull_Returns_True()
        {
            ClaimsPrincipalExtensions.IsUnauthenticated(principal: null).ShouldBeTrue();
        }

        [Fact]
        public void IsUnauthenticated_Given_Principal_Identity_IsNull_Returns_True()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity == null);

            // Act & Assert
            principal.IsUnauthenticated().ShouldBeTrue();
        }

        [Fact]
        public void IsUnauthenticated_Given_Principal_Identity_IsAuthenticated_IsFalse_Returns_True()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity.IsAuthenticated == false);

            // Act & Assert
            principal.IsUnauthenticated().ShouldBeTrue();
        }

        [Fact]
        public void IsUnauthenticated_Given_Principal_Identity_IsAuthenticated_IsTrue_Returns_False()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity.IsAuthenticated == true);

            // Act & Assert
            principal.IsUnauthenticated().ShouldBeFalse();
        }

        #endregion IsUnauthenticated
    }
}