using Shouldly;
using Xunit;
using Xunit.Abstractions;
using RSM.HCD.CSharp.Testing.Extensions;
using RSM.HCD.CSharp.Testing.Constants;
using RSM.HCD.CSharp.Core.Interfaces.Entity;
using RSM.HCD.CSharp.Testing.Models.Stubs;

namespace RSM.HCD.CSharp.Testing.Tests.Unit.Extensions
{
    public class IUpdatableMatcherExtensionsTest : ProjectUnitTest
    {
        #region Setup

        public IUpdatableMatcherExtensionsTest(ITestOutputHelper output) : base(output)
        {

        }

        #endregion Setup

        #region ShouldBeUpdated

        [Fact]
        public void ShouldBeUpdated_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IUpdatable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeUpdated());
        }

        [Fact]
        public void ShouldBeUpdated_When_UpdatedOn_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.UpdatedOn = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeUpdated());
        }

        [Fact]
        public void ShouldBeUpdated_When_UpdatedOn_HasValue_Passes_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.UpdatedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.NotThrow(() => entity.ShouldBeUpdated());
        }

        #endregion ShouldBeUpdated

        #region ShouldBeUpdatedBy(long updatedById)

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedById_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IUpdatable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeUpdatedBy(updatedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedById_When_UpdatedById_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.UpdatedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeUpdatedBy(updatedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedById_When_UpdatedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var updatedById = Random.Long(min: 1, max: 100);
            var unexpected = updatedById + 1;
            var entity = Build<UserStub>((e) => e.UpdatedById = updatedById);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeUpdatedBy(updatedById: unexpected));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedById_When_UpdatedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var entity = Build<UserStub>((e) => e.UpdatedById = expected);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldBeUpdatedBy(updatedById: expected));
        }

        #endregion ShouldBeUpdatedBy(long updatedById)

        #region ShouldBeUpdatedBy(IEntity updatedBy)

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>();

            // Act
            var exception = Record.Exception(() => entity.ShouldBeUpdatedBy(updatedBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IUpdatable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeUpdatedBy(updatedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_UpdatedById_Null_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.UpdatedById = Random.Long());
            var entity = Build<UserStub>((e) => e.UpdatedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeUpdatedBy(updatedBy: unexpected));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_UpdatedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.UpdatedById = Random.Long(min: 1, max: 100));
            var entity = Build<UserStub>((e) => e.UpdatedById = unexpected.Id + 1);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldBeUpdatedBy(updatedBy: unexpected));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_UpdatedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.UpdatedById = Random.Long());
            var entity = Build<UserStub>((e) => e.UpdatedById = expected.Id);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldBeUpdatedBy(updatedBy: expected));
        }

        #endregion ShouldBeUpdatedBy(IEntity updatedBy)

        #region ShouldNotBeUpdated

        [Fact]
        public void ShouldNotBeUpdated_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IUpdatable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeUpdated());
        }

        [Fact]
        public void ShouldNotBeUpdated_When_UpdatedOn_HasValue_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.UpdatedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeUpdated());
        }

        [Fact]
        public void ShouldNotBeUpdated_When_UpdatedOn_Null_Passes_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.UpdatedOn = null);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeUpdated());
        }

        #endregion ShouldNotBeUpdated

        #region ShouldNotBeUpdatedBy(long updatedById)

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedById_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IUpdatable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeUpdatedBy(updatedById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedById_When_UpdatedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var entity = Build<UserStub>((e) => e.UpdatedById = expected);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeUpdatedBy(updatedById: expected));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedById_When_UpdatedById_Null_Passes_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>((e) => e.UpdatedById = null);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeUpdatedBy(updatedById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedById_When_UpdatedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var updatedById = Random.Long(min: 1, max: 100);
            var unexpected = updatedById + 1;
            var entity = Build<UserStub>((e) => e.UpdatedById = updatedById);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeUpdatedBy(updatedById: unexpected));
        }

        #endregion ShouldNotBeUpdatedBy(long updatedById)

        #region ShouldNotBeUpdatedBy(IEntity updatedBy)

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var entity = Build<UserStub>();

            // Act
            var exception = Record.Exception(() => entity.ShouldNotBeUpdatedBy(updatedBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_Entity_Null_Fails_Assertion()
        {
            // Arrange
            IUpdatable entity = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeUpdatedBy(updatedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_UpdatedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.UpdatedById = Random.Long());
            var entity = Build<UserStub>((e) => e.UpdatedById = expected.Id);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => entity.ShouldNotBeUpdatedBy(updatedBy: expected));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_UpdatedById_Null_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.UpdatedById = Random.Long());
            var entity = Build<UserStub>((e) => e.UpdatedById = null);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeUpdatedBy(updatedBy: unexpected));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_UpdatedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.UpdatedById = Random.Long(min: 1, max: 100));
            var entity = Build<UserStub>((e) => e.UpdatedById = unexpected.Id + 1);

            // Act & Assert
            Should.NotThrow(() => entity.ShouldNotBeUpdatedBy(updatedBy: unexpected));
        }

        #endregion ShouldNotBeUpdatedBy(IEntity updatedBy)
    }
}
