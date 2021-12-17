using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Constants;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Testing.Models.Stubs;

namespace AndcultureCode.CSharp.Testing.Tests.Unit.Extensions
{
    public class IDeletableMatcherExtensionsTest : ProjectUnitTest
    {
        #region Setup

        public IDeletableMatcherExtensionsTest(ITestOutputHelper output) : base(output)
        {

        }

        #endregion Setup

        #region ShouldBeDeleted

        [Fact]
        public void ShouldBeDeleted_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IDeletable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeDeleted());
        }

        [Fact]
        public void ShouldBeDeleted_When_DeletedOn_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.DeletedOn = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeDeleted());
        }

        [Fact]
        public void ShouldBeDeleted_When_DeletedOn_HasValue_Passes_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.DeletedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.NotThrow(() => entity.ShouldBeDeleted());
        }

        #endregion ShouldBeDeleted

        #region ShouldBeDeletedBy(long deletedById)

        [Fact]
        public void ShouldBeDeletedBy_DeletedById_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IDeletable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeDeletedBy(deletedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedById_When_DeletedById_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.DeletedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeDeletedBy(deletedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedById_When_DeletedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var deletedById = Random.Long(min: 1, max: 100);
            var unexpected = deletedById + 1;
            var entity = Build<UserStub>((e) => e.DeletedById = deletedById);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeDeletedBy(deletedById: unexpected));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedById_When_DeletedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var entity = Build<UserStub>((e) => e.DeletedById = expected);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldBeDeletedBy(deletedById: expected));
        }

        #endregion ShouldBeDeletedBy(long deletedById)

        #region ShouldBeDeletedBy(IEntity deletedBy)

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>();

            // Act
            var exception = Record.Exception(() => entity.ShouldBeDeletedBy(deletedBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IDeletable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeDeletedBy(deletedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_DeletedById_Null_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.DeletedById = Random.Long());
            var entity = Build<UserStub>((e) => e.DeletedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeDeletedBy(deletedBy: unexpected));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_DeletedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.DeletedById = Random.Long(min: 1, max: 100));
            var entity = Build<UserStub>((e) => e.DeletedById = unexpected.Id + 1);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeDeletedBy(deletedBy: unexpected));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_DeletedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.DeletedById = Random.Long());
            var entity = Build<UserStub>((e) => e.DeletedById = expected.Id);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldBeDeletedBy(deletedBy: expected));
        }

        #endregion ShouldBeDeletedBy(IEntity deletedBy)

        #region ShouldNotBeDeleted

        [Fact]
        public void ShouldNotBeDeleted_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IDeletable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeDeleted());
        }

        [Fact]
        public void ShouldNotBeDeleted_When_DeletedOn_HasValue_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.DeletedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeDeleted());
        }

        [Fact]
        public void ShouldNotBeDeleted_When_DeletedOn_Null_Passes_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.DeletedOn = null);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeDeleted());
        }

        #endregion ShouldNotBeDeleted

        #region ShouldNotBeDeletedBy(long deletedById)

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedById_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IDeletable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeDeletedBy(deletedById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedById_When_DeletedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var entity = Build<UserStub>((e) => e.DeletedById = expected);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeDeletedBy(deletedById: expected));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedById_When_DeletedById_Null_Passes_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.DeletedById = null);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeDeletedBy(deletedById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedById_When_DeletedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var deletedById = Random.Long(min: 1, max: 100);
            var unexpected = deletedById + 1;
            var entity = Build<UserStub>((e) => e.DeletedById = deletedById);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeDeletedBy(deletedById: unexpected));
        }

        #endregion ShouldNotBeDeletedBy(long deletedById)

        #region ShouldNotBeDeletedBy(IEntity deletedBy)

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>();

            // Act
            var exception = Record.Exception(() => entity.ShouldNotBeDeletedBy(deletedBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IDeletable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeDeletedBy(deletedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_DeletedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.DeletedById = Random.Long());
            var entity = Build<UserStub>((e) => e.DeletedById = expected.Id);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeDeletedBy(deletedBy: expected));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_DeletedById_Null_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.DeletedById = Random.Long());
            var entity = Build<UserStub>((e) => e.DeletedById = null);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeDeletedBy(deletedBy: unexpected));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_DeletedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.DeletedById = Random.Long(min: 1, max: 100));
            var entity = Build<UserStub>((e) => e.DeletedById = unexpected.Id + 1);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeDeletedBy(deletedBy: unexpected));
        }

        #endregion ShouldNotBeDeletedBy(IEntity deletedBy)
    }
}
