using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AndcultureCode.CSharp.Extensions.Tests.Stubs;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Extensions.Tests.Factories;

namespace AndcultureCode.CSharp.Extensions.Tests
{
    public class ExpressionExtensionsTest : BaseExtensionsTest
    {
        #region Constants

        public const string AT_GMAIL_DOT_COM = "@gmail.com";
        public const string AT_YAHOO_DOT_COM = "@yahoo.com";
        public const string DOE              = "Doe";
        public const string JANE             = "Jane";
        public const string JOHN             = "John";
        public const string SMITH            = "Smith";

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
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<UserStub>();

            // Act
            var filter = smithNameFilter.AndAlso(yahooEmailFilter);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void AndAlso_When_Both_Expressions_Evaluate_As_True_Returns_True()
        {
            // Arrange
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var janeSmith = Build<UserStub>(
                // This is the important setup - entity should have 'Smith' in the name
                // as well as an '@yahoo.com' email
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JANE}{SMITH}"
            );
            var johnSmith = Build<UserStub>(
                // Same setup as above
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{SMITH}"
            );
            var entities = new List<UserStub>
            {
                janeSmith,
                johnSmith,
            };

            // Act
            var filter = smithNameFilter.AndAlso(yahooEmailFilter);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(janeSmith);
            result.ShouldContain(johnSmith);
        }

        [Fact]
        public void AndAlso_When_One_Expression_Evaluates_As_False_Returns_False()
        {
            // Arrange
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var janeDoe = Build<UserStub>(
                // This is the important setup - entity does NOT have 'Smith' in the name and
                // should not be returned even though it has an '@yahoo.com' email
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            var johnSmith = Build<UserStub>(
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{SMITH}"
            );
            var entities = new List<UserStub>
            {
                janeDoe,
                johnSmith,
            };

            // Act
            var filter = smithNameFilter.AndAlso(yahooEmailFilter);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotContain(janeDoe);
            result.ShouldContain(johnSmith);
        }

        #endregion AndAlso

        #region AndAlso (With Navigation Property)

        [Fact]
        public void AndAlso_WithNavigationProperty_Returns_Expression()
        {
            // Arrange
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<UserStub>();

            // Act
            var filter = smithNameFilter.AndAlso(yahooEmailFilter, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void AndAlso_WithNavigationProperty_Returns_True_When_Both_Expressions_Evaluate_As_True()
        {
            // Arrange
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var janeSmith = Build<UserStub>(
                // This is the important setup - main entity should have 'Smith' in the name
                // and the RelatedUserStub should have an '@yahoo.com' email
                (e) => e.Name = $"{JANE}{SMITH}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var johnSmith = Build<UserStub>(
                // Same setup as above
                (e) => e.Name = $"{JOHN}{SMITH}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<UserStub>
            {
                janeSmith,
                johnSmith,
            };

            // Act
            var filter = smithNameFilter.AndAlso(yahooEmailFilter, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(janeSmith);
            result.ShouldContain(johnSmith);
        }

        [Fact]
        public void AndAlso_WithNavigationProperty_Returns_False_When_One_Expression_Evaluates_As_False()
        {
            // Arrange
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var janeDoe = Build<UserStub>(
                // This is the important setup - main entity does NOT have 'Smith' in the name and
                // should not be returned even though the RelatedUserStub has an '@yahoo.com' email
                (e) => e.Name = $"{JANE}{DOE}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var johnSmith = Build<UserStub>(
                (e) => e.Name = $"{JOHN}{SMITH}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<UserStub>
            {
                janeDoe,
                johnSmith,
            };

            // Act
            var filter = smithNameFilter.AndAlso(yahooEmailFilter, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotContain(janeDoe);
            result.ShouldContain(johnSmith);
        }

        #endregion AndAlso (With Navigation Property)

        #region Or

        [Fact]
        public void Or_Returns_Expression()
        {
            // Arrange
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<UserStub>();

            // Act
            var filter = smithNameFilter.Or(yahooEmailFilter);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Or_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            Expression<Func<UserStub, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
            var janeDoe = Build<UserStub>(
                UserStubFactory.WITH_GMAIL_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
            var johnSmith = Build<UserStub>(
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{SMITH}"
            );
            var entities = new List<UserStub>
            {
                janeDoe,
                johnSmith,
            };

            // Act
            var filter = smithNameFilter.Or(gmailEmailFilter);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(janeDoe);
            result.ShouldContain(johnSmith);
        }

        [Fact]
        public void Or_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            Expression<Func<UserStub, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This is the important setup: neither entity satisfies the email or name filter
            var janeDoe = Build<UserStub>(
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            var johnDoe = Build<UserStub>(
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{DOE}"
            );
            var entities = new List<UserStub>
            {
                janeDoe,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.Or(gmailEmailFilter);
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
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<UserStub>();

            // Act
            var filter = smithNameFilter.Or(yahooEmailFilter, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Or_WithNavigationProperty_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            Expression<Func<UserStub, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
            var janeSmith = Build<UserStub>(
                (e) => e.Name = $"{JANE}{SMITH}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
            var johnDoe = Build<UserStub>(
                (e) => e.Name = $"{JOHN}{DOE}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_GMAIL_EMAIL)
            );
            var entities = new List<UserStub>
            {
                janeSmith,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.Or(gmailEmailFilter, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(janeSmith);
            result.ShouldContain(johnDoe);
        }

        [Fact]
        public void Or_WithNavigationProperty_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            Expression<Func<UserStub, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This is the important setup: neither entity satisfies the email or name filter
            var janeDoe = Build<UserStub>(
                (e) => e.Name = $"{JANE}{DOE}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var johnDoe = Build<UserStub>(
                (e) => e.Name = $"{JOHN}{DOE}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<UserStub>
            {
                janeDoe,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.Or(gmailEmailFilter, (e) => e.RelatedUserStub);
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
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<UserStub>();

            // Act
            var filter = smithNameFilter.OrElse(yahooEmailFilter);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void OrElse_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            Expression<Func<UserStub, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
            var janeDoe = Build<UserStub>(
                UserStubFactory.WITH_GMAIL_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
            var johnSmith = Build<UserStub>(
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{SMITH}"
            );
            var entities = new List<UserStub>
            {
                janeDoe,
                johnSmith,
            };

            // Act
            var filter = smithNameFilter.OrElse(gmailEmailFilter);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(janeDoe);
            result.ShouldContain(johnSmith);
        }

        [Fact]
        public void OrElse_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            Expression<Func<UserStub, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This is the important setup: neither entity satisfies the email or name filter
            var janeDoe = Build<UserStub>(
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            var johnDoe = Build<UserStub>(
                UserStubFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{DOE}"
            );
            var entities = new List<UserStub>
            {
                janeDoe,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.OrElse(gmailEmailFilter);
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
            Expression<Func<UserStub, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<UserStub>();

            // Act
            var filter = smithNameFilter.OrElse(yahooEmailFilter, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void OrElse_WithNavigationProperty_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            Expression<Func<UserStub, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
            var janeSmith = Build<UserStub>(
                (e) => e.Name = $"{JANE}{SMITH}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
            var johnDoe = Build<UserStub>(
                (e) => e.Name = $"{JOHN}{DOE}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_GMAIL_EMAIL)
            );
            var entities = new List<UserStub>
            {
                janeSmith,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.OrElse(gmailEmailFilter, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(janeSmith);
            result.ShouldContain(johnDoe);
        }

        [Fact]
        public void OrElse_WithNavigationProperty_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            Expression<Func<UserStub, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<UserStub, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This is the important setup: neither entity satisfies the email or name filter
            var janeDoe = Build<UserStub>(
                (e) => e.Name = $"{JANE}{DOE}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var johnDoe = Build<UserStub>(
                (e) => e.Name = $"{JOHN}{DOE}",
                (e) => e.RelatedUserStub = Build<UserStub>(UserStubFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<UserStub>
            {
                janeDoe,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.OrElse(gmailEmailFilter, (e) => e.RelatedUserStub);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBeEmpty();
        }

        #endregion OrElse (With Navigation Property)
    }
}