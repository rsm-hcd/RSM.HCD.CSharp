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
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<TestEntity>();

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
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var janeSmith = Build<TestEntity>(
                // This is the important setup - entity should have 'Smith' in the name
                // as well as an '@yahoo.com' email
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JANE}{SMITH}"
            );
            var johnSmith = Build<TestEntity>(
                // Same setup as above
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{SMITH}"
            );
            var entities = new List<TestEntity>
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
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var janeDoe = Build<TestEntity>(
                // This is the important setup - entity does NOT have 'Smith' in the name and
                // should not be returned even though it has an '@yahoo.com' email
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            var johnSmith = Build<TestEntity>(
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{SMITH}"
            );
            var entities = new List<TestEntity>
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
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<TestEntity>();

            // Act
            var filter = smithNameFilter.AndAlso(yahooEmailFilter, (e) => e.RelatedTestEntity);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void AndAlso_WithNavigationProperty_Returns_True_When_Both_Expressions_Evaluate_As_True()
        {
            // Arrange
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var janeSmith = Build<TestEntity>(
                // This is the important setup - main entity should have 'Smith' in the name
                // and the RelatedTestEntity should have an '@yahoo.com' email
                (e) => e.Name = $"{JANE}{SMITH}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            var johnSmith = Build<TestEntity>(
                // Same setup as above
                (e) => e.Name = $"{JOHN}{SMITH}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<TestEntity>
            {
                janeSmith,
                johnSmith,
            };

            // Act
            var filter = smithNameFilter.AndAlso(yahooEmailFilter, (e) => e.RelatedTestEntity);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(janeSmith);
            result.ShouldContain(johnSmith);
        }

        [Fact]
        public void AndAlso_WithNavigationProperty_Returns_False_When_One_Expression_Evaluates_As_False()
        {
            // Arrange
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var janeDoe = Build<TestEntity>(
                // This is the important setup - main entity does NOT have 'Smith' in the name and
                // should not be returned even though the RelatedTestEntity has an '@yahoo.com' email
                (e) => e.Name = $"{JANE}{DOE}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            var johnSmith = Build<TestEntity>(
                (e) => e.Name = $"{JOHN}{SMITH}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<TestEntity>
            {
                janeDoe,
                johnSmith,
            };

            // Act
            var filter = smithNameFilter.AndAlso(yahooEmailFilter, (e) => e.RelatedTestEntity);
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
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<TestEntity>();

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
            Expression<Func<TestEntity, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
            var janeDoe = Build<TestEntity>(
                TestEntityFactory.WITH_GMAIL_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
            var johnSmith = Build<TestEntity>(
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{SMITH}"
            );
            var entities = new List<TestEntity>
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
            Expression<Func<TestEntity, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This is the important setup: neither entity satisfies the email or name filter
            var janeDoe = Build<TestEntity>(
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            var johnDoe = Build<TestEntity>(
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{DOE}"
            );
            var entities = new List<TestEntity>
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
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<TestEntity>();

            // Act
            var filter = smithNameFilter.Or(yahooEmailFilter, (e) => e.RelatedTestEntity);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Or_WithNavigationProperty_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            Expression<Func<TestEntity, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
            var janeSmith = Build<TestEntity>(
                (e) => e.Name = $"{JANE}{SMITH}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
            var johnDoe = Build<TestEntity>(
                (e) => e.Name = $"{JOHN}{DOE}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_GMAIL_EMAIL)
            );
            var entities = new List<TestEntity>
            {
                janeSmith,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.Or(gmailEmailFilter, (e) => e.RelatedTestEntity);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(janeSmith);
            result.ShouldContain(johnDoe);
        }

        [Fact]
        public void Or_WithNavigationProperty_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            Expression<Func<TestEntity, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This is the important setup: neither entity satisfies the email or name filter
            var janeDoe = Build<TestEntity>(
                (e) => e.Name = $"{JANE}{DOE}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            var johnDoe = Build<TestEntity>(
                (e) => e.Name = $"{JOHN}{DOE}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<TestEntity>
            {
                janeDoe,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.Or(gmailEmailFilter, (e) => e.RelatedTestEntity);
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
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<TestEntity>();

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
            Expression<Func<TestEntity, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
            var janeDoe = Build<TestEntity>(
                TestEntityFactory.WITH_GMAIL_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
            var johnSmith = Build<TestEntity>(
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{SMITH}"
            );
            var entities = new List<TestEntity>
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
            Expression<Func<TestEntity, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This is the important setup: neither entity satisfies the email or name filter
            var janeDoe = Build<TestEntity>(
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JANE}{DOE}"
            );
            var johnDoe = Build<TestEntity>(
                TestEntityFactory.WITH_YAHOO_EMAIL,
                (e) => e.Name = $"{JOHN}{DOE}"
            );
            var entities = new List<TestEntity>
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
            Expression<Func<TestEntity, bool>> yahooEmailFilter = (e) => e.EmailAddress.Contains(AT_YAHOO_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            var entities = new List<TestEntity>();

            // Act
            var filter = smithNameFilter.OrElse(yahooEmailFilter, (e) => e.RelatedTestEntity);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void OrElse_WithNavigationProperty_When_Either_Expression_Evaluates_As_True_Returns_True()
        {
            // Arrange
            Expression<Func<TestEntity, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This entity satisfies the 'Smith' name filter but not the '@gmail.com' email filter
            var janeSmith = Build<TestEntity>(
                (e) => e.Name = $"{JANE}{SMITH}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            // This entity satisfies the '@gmail.com' email filter but not the 'Smith' name filter
            var johnDoe = Build<TestEntity>(
                (e) => e.Name = $"{JOHN}{DOE}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_GMAIL_EMAIL)
            );
            var entities = new List<TestEntity>
            {
                janeSmith,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.OrElse(gmailEmailFilter, (e) => e.RelatedTestEntity);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldContain(janeSmith);
            result.ShouldContain(johnDoe);
        }

        [Fact]
        public void OrElse_WithNavigationProperty_When_Neither_Expression_Evaluates_As_True_Returns_False()
        {
            // Arrange
            Expression<Func<TestEntity, bool>> gmailEmailFilter = (e) => e.EmailAddress.Contains(AT_GMAIL_DOT_COM);
            Expression<Func<TestEntity, bool>> smithNameFilter  = (e) => e.Name.Contains(SMITH);
            // This is the important setup: neither entity satisfies the email or name filter
            var janeDoe = Build<TestEntity>(
                (e) => e.Name = $"{JANE}{DOE}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            var johnDoe = Build<TestEntity>(
                (e) => e.Name = $"{JOHN}{DOE}",
                (e) => e.RelatedTestEntity = Build<TestEntity>(TestEntityFactory.WITH_YAHOO_EMAIL)
            );
            var entities = new List<TestEntity>
            {
                janeDoe,
                johnDoe,
            };

            // Act
            var filter = smithNameFilter.OrElse(gmailEmailFilter, (e) => e.RelatedTestEntity);
            var result = entities.Where(filter.Compile());

            // Assert
            result.ShouldBeEmpty();
        }

        #endregion OrElse (With Navigation Property)
    }
}