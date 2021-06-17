using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Constants;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Testing.Models.Stubs;

namespace AndcultureCode.CSharp.Testing.Tests.Unit.Extensions
{
    public class ICreatableMatcherExtensionsTest : ProjectUnitTest
    {
        #region Setup

        public ICreatableMatcherExtensionsTest(ITestOutputHelper output) : base(output)
        {

        }

        #endregion Setup

        #region ShouldBeCreated

        [Fact]
        public void ShouldBeCreated_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            ICreatable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeCreated());
        }

        [Fact]
        public void ShouldBeCreated_When_CreatedOn_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.CreatedOn = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeCreated());
        }

        [Fact]
        public void ShouldBeCreated_When_CreatedOn_HasValue_Passes_Assertion()
        {
            // Arrange
            var result = Build<UserStub>((e) => e.CreatedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeCreated());
        }

        #endregion ShouldBeCreated

        #region ShouldBeCreatedBy(long createdById)

        [Fact]
        public void ShouldBeCreatedBy_CreatedById_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            ICreatable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeCreatedBy(createdById: Random.Long()));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedById_When_CreatedById_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.CreatedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeCreatedBy(createdById: Random.Long()));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedById_When_CreatedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var createdById = Random.Long(min: 1, max: 100);
            var unexpected = createdById + 1;
            var entity = Build<UserStub>((e) => e.CreatedById = createdById);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeCreatedBy(createdById: unexpected));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedById_When_CreatedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var entity = Build<UserStub>((e) => e.CreatedById = expected);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldBeCreatedBy(createdById: expected));
        }

        #endregion ShouldBeCreatedBy(long createdById)

        #region ShouldBeCreatedBy(IEntity createdBy)

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>();

            // Act
            var exception = Record.Exception(() => entity.ShouldBeCreatedBy(createdBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            ICreatable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeCreatedBy(createdBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_CreatedById_Null_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.CreatedById = Random.Long());
            var entity = Build<UserStub>((e) => e.CreatedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeCreatedBy(createdBy: unexpected));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_CreatedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.CreatedById = Random.Long(min: 1, max: 100));
            var entity = Build<UserStub>((e) => e.CreatedById = unexpected.Id + 1);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeCreatedBy(createdBy: unexpected));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_CreatedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.CreatedById = Random.Long());
            var entity = Build<UserStub>((e) => e.CreatedById = expected.Id);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldBeCreatedBy(createdBy: expected));
        }

        #endregion ShouldBeCreatedBy(IEntity createdBy)
    }
}
