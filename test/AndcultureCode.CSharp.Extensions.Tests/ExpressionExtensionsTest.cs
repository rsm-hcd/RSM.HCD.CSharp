using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing.Models.Stubs;
using AndcultureCode.CSharp.Testing.Factories;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class ExpressionExtensionsTest : BaseExtensionsTest
    {
        #region Constants

        public const string AT_GMAIL_DOT_COM = "@gmail.com";
        public const string AT_YAHOO_DOT_COM = "@yahoo.com";
        public const string DOE = "Doe";
        Expression<Func<UserStub, bool>> GMAIL_EMAIL_FILTER = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
        Expression<Func<UserStub, bool>> LASTNAME_SMITH_FILTER = (e) => e.LastName == SMITH;
        public const string SMITH = "Smith";
        Expression<Func<UserStub, bool>> YAHOO_EMAIL_FILTER = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);

        #endregion Constants

        #region Constructor

        public ExpressionExtensionsTest(ITestOutputHelper output) : base(output)
        {
        }

        #endregion Constructor

        #region AndAlso

        [Fact]
        public void AndAlso_Returns_Expression()
        {
            // Arrange
            var entities = new List<UserStub>();

            // Act
            var filter = LASTNAME_SMITH_FILTER.AndAlso(YAHOO_EMAIL_FILTER);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void AndAlso_When_Both_Expressions_Evaluate_As_True_Returns_True()
        {
            // Arrange
            var expected = Build<UserStub>(
                // This is the important setup - entity should have 'Smith' in the name
                // as well as an '@yahoo.com' email
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.LastName = SMITH
            );
            var entities = new List<UserStub>
            {
                expected
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.AndAlso(YAHOO_EMAIL_FILTER);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(expected);
        }

        [Fact]
        public void AndAlso_When_One_Expression_Evaluates_As_False_Returns_False()
        {
            // Arrange
            var unexpected = Build<UserStub>(
                // This is the important setup - entity does NOT have 'Smith' in the name and
                // should not be returned even though it has an '@yahoo.com' email
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.LastName = DOE
            );
            var expected = Build<UserStub>(
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.LastName = SMITH
            );
            var entities = new List<UserStub>
            {
                unexpected,
                expected,
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.AndAlso(YAHOO_EMAIL_FILTER);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotContain(unexpected);
            result.ShouldContain(expected);
        }

        #endregion AndAlso

        #region AndAlso (With Navigation Property)

        [Fact]
        public void AndAlso_WithNavigationProperty_Returns_Expression()
        {
            // Arrange
            var entities = new List<UserStub>();

            // Act
            var filter = LASTNAME_SMITH_FILTER.AndAlso(YAHOO_EMAIL_FILTER, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void AndAlso_WithNavigationProperty_Returns_True_When_Both_Expressions_Evaluate_As_True()
        {
            // Arrange
            var expected = Build<UserStub>(
                // This is the important setup - main entity should have 'Smith' in the name
                // and the RelatedUserStub should have an '@yahoo.com' email
                (e) => e.LastName = SMITH,
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<UserStub>
            {
                expected,
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.AndAlso(YAHOO_EMAIL_FILTER, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(expected);
        }

        [Fact]
        public void AndAlso_WithNavigationProperty_Returns_False_When_One_Expression_Evaluates_As_False()
        {
            // Arrange
            var unexpected = Build<UserStub>(
                // This is the important setup - main entity does NOT have 'Smith' in the name and
                // should not be returned even though the RelatedUserStub has an '@yahoo.com' email
                (e) => e.LastName = DOE,
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var expected = Build<UserStub>(
                (e) => e.LastName = SMITH,
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<UserStub>
            {
                unexpected,
                expected,
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.AndAlso(YAHOO_EMAIL_FILTER, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotContain(unexpected);
            result.ShouldContain(expected);
        }

        #endregion AndAlso (With Navigation Property)

        #region Or

        [Fact]
        public void Or_Returns_Expression()
        {
            // Arrange
            var entities = new List<UserStub>();

            // Act
            var filter = LASTNAME_SMITH_FILTER.Or(YAHOO_EMAIL_FILTER);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Or_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            var entities = new List<UserStub>
            {
                // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
                Build<UserStub>(
                    UserStubFactory.WITH_GMAIL_EMAIL,
                    (e) => e.LastName = DOE
                ),
                // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
                Build<UserStub>(
                    UserStubFactory.WITH_YAHOO_EMAIL,
                    (e) => e.LastName = SMITH
                )
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.Or(GMAIL_EMAIL_FILTER);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBe(entities);
        }

        [Fact]
        public void Or_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            var entities = new List<UserStub>
            {
                // This is the important setup: entity does not satisfy the email or name filter
                Build<UserStub>(
                    UserStubFactory.WITH_YAHOO_EMAIL,
                    (e) => e.LastName = DOE
                ),
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.Or(GMAIL_EMAIL_FILTER);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBeEmpty();
        }

        #endregion Or

        #region Or (With Navigation Property)

        [Fact]
        public void Or_WithNavigationProperty_Returns_Expression()
        {
            // Arrange
            var entities = new List<UserStub>();

            // Act
            var filter = LASTNAME_SMITH_FILTER.Or(YAHOO_EMAIL_FILTER, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Or_WithNavigationProperty_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            var entities = new List<UserStub>
            {
                // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
                Build<UserStub>(
                    (e) => e.LastName = SMITH,
                    (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
                ),
                // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
                Build<UserStub>(
                    (e) => e.LastName = DOE,
                    (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_GMAIL_EMAIL)
                ),
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.Or(GMAIL_EMAIL_FILTER, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBe(entities);
        }

        [Fact]
        public void Or_WithNavigationProperty_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            var entities = new List<UserStub>
            {
                // This is the important setup: entity does not satisfy the email or name filter
                Build<UserStub>(
                    (e) => e.LastName = DOE,
                    (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
                ),
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.Or(GMAIL_EMAIL_FILTER, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBeEmpty();
        }

        #endregion Or (With Navigation Property)

        #region OrElse

        [Fact]
        public void OrElse_Returns_Expression()
        {
            // Arrange
            var entities = new List<UserStub>();

            // Act
            var filter = LASTNAME_SMITH_FILTER.OrElse(YAHOO_EMAIL_FILTER);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void OrElse_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            var entities = new List<UserStub>
            {
                // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
                Build<UserStub>(
                    UserStubFactory.WITH_GMAIL_EMAIL,
                    (e) => e.LastName = DOE
                ),
                // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
                Build<UserStub>(
                    UserStubFactory.WITH_YAHOO_EMAIL,
                    (e) => e.LastName = SMITH
                ),
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.OrElse(GMAIL_EMAIL_FILTER);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBe(entities);
        }

        [Fact]
        public void OrElse_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            var entities = new List<UserStub>
            {
                // This is the important setup: entity does not satisfy the email or name filter
                Build<UserStub>(
                    UserStubFactory.WITH_YAHOO_EMAIL,
                    (e) => e.LastName = DOE
                ),
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.OrElse(GMAIL_EMAIL_FILTER);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBeEmpty();
        }

        #endregion OrElse

        #region OrElse (With Navigation Property)

        [Fact]
        public void OrElse_WithNavigationProperty_Returns_Expression()
        {
            // Arrange
            var entities = new List<UserStub>();

            // Act
            var filter = LASTNAME_SMITH_FILTER.OrElse(YAHOO_EMAIL_FILTER, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void OrElse_WithNavigationProperty_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            var entities = new List<UserStub>
            {
                // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
                Build<UserStub>(
                    (e) => e.LastName = SMITH,
                    (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
                ),
                // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
                Build<UserStub>(
                    (e) => e.LastName = DOE,
                    (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_GMAIL_EMAIL)
                ),
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.OrElse(GMAIL_EMAIL_FILTER, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBe(entities);
        }

        [Fact]
        public void OrElse_WithNavigationProperty_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            var entities = new List<UserStub>
            {
                // This is the important setup: entity does not satisfy the email or name filter
                Build<UserStub>(
                    UserStubFactory.WITH_YAHOO_EMAIL,
                    (e) => e.LastName = DOE,
                    (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
                ),
            };

            // Act
            var filter = LASTNAME_SMITH_FILTER.OrElse(GMAIL_EMAIL_FILTER, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBeEmpty();
        }

        #endregion OrElse (With Navigation Property)
    }
}