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
using System.Linq;

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

        #region RoleId

        [Fact]
        public void RoleId_Given_Principal_IsNull_Throws_Exception()
        {
            Should.Throw<ArgumentNullException>(() =>
            {
                ClaimsPrincipalExtensions.RoleId(principal: null);
            });
        }

        [Fact]
        public void RoleId_When_Unauthenticated_Returns_Null()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity.IsAuthenticated == false);

            // Act & Assert
            principal.RoleId().ShouldBeNull();
        }

        [Fact]
        public void RoleId_When_Claims_IsNull_Returns_Null()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == null // <-----------------
            );

            // Act & Assert
            principal.RoleId().ShouldBeNull();
        }

        [Fact]
        public void RoleId_When_Claims_Empty_Returns_Null()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == new List<Claim>() // <------------------
            );

            // Act & Assert
            principal.RoleId().ShouldBeNull();
        }

        [Fact]
        public void RoleId_When_Claims_Contains_RoleId_Claim_Returns_Value()
        {
            // Arrange
            var expected = Random.Long();
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == new List<Claim>
                {
                    new Claim(ApiClaimTypes.ROLE_ID, expected.ToString()) // <--------------
                }
            );

            // Act & Assert
            principal.RoleId().ShouldBe(expected);
        }

        #endregion RoleId

        #region RoleIds

        [Fact]
        public void RoleIds_Given_Principal_IsNull_Throws_Exception()
        {
            Should.Throw<ArgumentNullException>(() =>
            {
                ClaimsPrincipalExtensions.RoleIds(principal: null);
            });
        }

        [Fact]
        public void RoleIds_When_Unauthenticated_Returns_Empty_Array()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity.IsAuthenticated == false);

            // Act
            var result = principal.RoleIds();

            // Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBe(0);
            result.ShouldBeEmpty();
        }

        [Fact]
        public void RoleIds_When_Claims_IsNull_Returns_Empty_Array()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == null // <-----------------
            );

            // Act
            var result = principal.RoleIds();

            // Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBe(1);
            result.ShouldContain("");
        }

        [Fact]
        public void RoleIds_When_Claims_Empty_Returns_Empty_Array()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == new List<Claim>() // <------------------
            );

            // Act
            var result = principal.RoleIds();

            // Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBe(1);
            result.ShouldContain("");
        }

        [Fact]
        public void RoleIds_When_Claims_Contains_RoleIds_Claim_With_SingleValue_Returns_Value()
        {
            // Arrange
            var expected = Random.Long();
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == new List<Claim>
                {
                    new Claim(ApiClaimTypes.ROLE_IDS, expected.ToString()) // <--------------
                }
            );

            // Act
            var result = principal.RoleIds();

            // Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBe(1);
            result.ShouldContain(expected.ToString());
        }

        [Fact]
        public void RoleIds_When_Claims_Contains_RoleIds_Claim_With_MultipleValues_Returns_Values()
        {
            // Arrange
            var expected = Random.Long();
            var expected2 = Random.Long();
            var expectedValues = $"{expected},{expected2}";
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == new List<Claim>
                {
                    new Claim(ApiClaimTypes.ROLE_IDS, expectedValues) // <--------------
                }
            );

            // Act
            var result = principal.RoleIds();

            // Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBe(2);
            result.ShouldContain(expected.ToString());
            result.ShouldContain(expected2.ToString());
        }

        #endregion RoleIds

        #region UserId

        [Fact]
        public void UserId_Given_Principal_IsNull_Throws_Exception()
        {
            Should.Throw<ArgumentNullException>(() =>
            {
                ClaimsPrincipalExtensions.UserId(principal: null);
            });
        }

        [Fact]
        public void UserId_When_Unauthenticated_Returns_Null()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e => e.Identity.IsAuthenticated == false);

            // Act & Assert
            principal.UserId().ShouldBeNull();
        }

        [Fact]
        public void UserId_When_Claims_IsNull_Returns_Null()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == null // <-----------------
            );

            // Act & Assert
            principal.UserId().ShouldBeNull();
        }

        [Fact]
        public void UserId_When_Claims_Empty_Returns_Null()
        {
            // Arrange
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == new List<Claim>() // <------------------
            );

            // Act & Assert
            principal.UserId().ShouldBeNull();
        }

        [Fact]
        public void UserId_When_Claims_Contains_RoleId_Claim_Returns_Value()
        {
            // Arrange
            var expected = Random.Long();
            var principal = Mock.Of<ClaimsPrincipal>(e =>
                e.Identity.IsAuthenticated == true &&
                e.Claims == new List<Claim>
                {
                    new Claim(ApiClaimTypes.USER_ID, expected.ToString()) // <--------------
                }
            );

            // Act & Assert
            principal.UserId().ShouldBe(expected);
        }

        #endregion UserId
    }
}