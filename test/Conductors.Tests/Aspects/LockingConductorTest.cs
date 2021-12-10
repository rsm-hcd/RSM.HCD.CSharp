using System;
using AndcultureCode.CSharp.Conductors.Aspects;
using AndcultureCode.CSharp.Conductors.Tests.Stubs;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Testing.Extensions;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Conductors.Tests.Factories;

namespace AndcultureCode.CSharp.Conductors.Tests.Aspects
{
    public class LockingConductorTest : ProjectUnitTest
    {
        #region Setup

        private static ILogger<LockingConductor<LockableEntity>> _logger => Mock.Of<ILogger<LockingConductor<LockableEntity>>>();

        public LockingConductorTest(ITestOutputHelper output) : base(output)
        {
        }

        private DateTimeOffset GetFifteenMinutesInTheFuture()
        {
            DateTimeOffset now = DateTimeOffset.Now;

            return now.AddMinutes(15);
        }

        #endregion Setup

        #region Lock

        [Fact]
        public void Lock_When_Record_Is_Successfully_Locked_Then_Returns_Updated_Result()
        {
            // Arrange
            var entity = Build<LockableEntity>();
            var lockedById = Random.Long();

            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>())).ReturnsGivenResult(true);

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: entity.Id, resultObject: entity).Object;

            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            // Act
            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
            );

            var result = sut.Lock(
                id: entity.Id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: lockedById
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeNull();
            result.ResultObject.LockedById.ShouldBe(lockedById);
            result.ResultObject.LockedUntil.ShouldNotBeNull();
        }

        [Fact]
        public void Lock_When_FindById_Returns_Errors_Then_Returns_Errors()
        {
            // Arrange
            var id = Random.Long();
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsBasicErrorResult(id: id).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.Lock(
                id: id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: Random.Long()
            );

            // Assert
            result.ShouldHaveBasicError();
        }

        [Fact]
        public void Lock_When_FindById_Returns_Null_ResultObject_Then_Returns_Errors()
        {
            // Arrange
            var id = Random.Long();
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: id, resultObject: null).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.Lock(
                id: id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: Random.Long()
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<Lockable>.ERROR_LOCK_RECORD_NOT_FOUND);
        }

        [Fact]
        public void Lock_When_Record_Is_Already_Locked_Then_Returns_Errors()
        {
            // Arrange
            var entity = Build<LockableEntity>(LockableEntityFactory.LOCKED);

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: entity.Id, resultObject: entity).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.Lock(
                id: entity.Id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: Random.Long()
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_LOCK_RECORD_ALREADY_LOCKED);
        }

        [Fact]
        public void Lock_When_LockUntil_Is_In_The_Past_Then_Returns_Errors()
        {
            // Arrange
            var id = Random.Long();
            var entity = Build<LockableEntity>();
            var lockUntil = DateTimeOffset.UtcNow.AddMinutes(-15); // This is the important setup
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: id, resultObject: entity).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.Lock(
                id: id,
                lockUntil: lockUntil,
                lockedById: Random.Long()
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_LOCK_TIME_IN_PAST);
        }

        [Fact]
        public void Lock_When_Update_Returns_Errors_Then_Returns_Errors()
        {
            // Arrange
            var id = Random.Long();
            var entity = Build<LockableEntity>();

            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsBasicErrorResult();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: id, resultObject: entity).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
            );

            // Act
            var result = sut.Lock(
                id: id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: Random.Long()
            );

            // Assert
            result.ShouldHaveBasicError();
        }

        #endregion Lock

        #region Unlock

        [Fact]
        public void Unlock_When_Record_Is_Unlocked_Then_Returns_Updated_Record()
        {
            // Arrange
            var id = Random.Long();
            var entity = Build<LockableEntity>();

            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsGivenResult(true);

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: id, resultObject: entity).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
            );

            // Act
            var result = sut.Unlock(
                id: id,
                unlockedById: Random.Long()
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeNull();
            result.ResultObject.IsLocked.ShouldBeFalse();
            result.ResultObject.LockedOn.ShouldBeNull();
            result.ResultObject.LockedUntil.ShouldBeNull();
            result.ResultObject.LockedById.ShouldBeNull();
        }

        [Fact]
        public void Unlock_When_FindById_Returns_Errors_Then_Returns_Errors()
        {
            // Arrange
            var id = Random.Long();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsBasicErrorResult(id: id).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.Unlock(
                id: id,
                unlockedById: Random.Long()
            );

            // Assert
            result.ShouldHaveBasicError();
        }

        [Fact]
        public void Unlock_When_FindById_Returns_Null_ResultObject_Then_Returns_Errors()
        {
            // Arrange
            var id = Random.Long();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: id, resultObject: null).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.Unlock(
                id: id,
                unlockedById: Random.Long()
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<Lockable>.ERROR_UNLOCK_RECORD_NOT_FOUND);
        }

        [Fact]
        public void Unlock_When_Update_Returns_Errors_Then_Returns_Errors()
        {
            // Arrange
            var id = Random.Long();
            var entity = Build<LockableEntity>();

            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsBasicErrorResult();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: id, resultObject: entity).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
            );

            // Act
            var result = sut.Unlock(
                id: id,
                unlockedById: Random.Long()
            );

            // Assert
            result.ShouldHaveBasicError();
        }

        #endregion Unlock

        #region ExtendLock

        [Fact]
        public void ExtendLock_When_Lock_Time_Is_Extended_Then_Returns_Updated_Record()
        {
            // Arrange
            var entity = Build<LockableEntity>(LockableEntityFactory.LOCKED);
            var lockUntil = entity.LockedUntil?.AddMinutes(5);

            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsGivenResult(true);

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: entity.Id, resultObject: entity).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
            );

            // Act
            var result = sut.ExtendLock(
                id: entity.Id,
                lockUntil: lockUntil.Value,
                updatedById: entity.LockedById
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeNull();
            result.ResultObject.LockedUntil.ShouldNotBeNull();
            result.ResultObject.LockedUntil.ShouldBe(lockUntil);
        }

        [Fact]
        public void ExtendLock_When_FindById_Returns_Errors_Then_Returns_Errors()
        {
            // Arrange
            var id = Random.Long();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsBasicErrorResult(id: id).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.ExtendLock(
                id: id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                updatedById: Random.Long()
            );

            // Assert
            result.ShouldHaveBasicError();
        }

        [Fact]
        public void ExtendLock_When_FindById_Returns_Null_ResultObject_Then_Returns_Errors()
        {
            // Arrange
            var id = Random.Long();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: id, resultObject: null).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.ExtendLock(
                id: id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                updatedById: Random.Long()
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_EXTEND_LOCK_RECORD_NOT_FOUND);
        }

        [Fact]
        public void ExtendLock_When_Record_Is_Not_Locked_Then_Returns_Errors()
        {
            // Arrange
            var entity = Build<LockableEntity>(LockableEntityFactory.UNLOCKED);

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: entity.Id, resultObject: entity).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.ExtendLock(
                id: entity.Id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                updatedById: Random.Long()
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_EXTEND_LOCK_RECORD_NOT_LOCKED);
        }

        [Fact]
        public void ExtendLock_When_Record_Is_Locked_By_Different_User_Then_Returns_Errors()
        {
            // Arrange
            var entity = Build<LockableEntity>(LockableEntityFactory.LOCKED);
            var unauthorizedUserId = entity.LockedById + 1; // This is the important setup

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: entity.Id, resultObject: entity).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.ExtendLock(
                id: entity.Id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                updatedById: unauthorizedUserId
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_EXTEND_LOCK_LOCKED_BY_DIFFERENT_USER);
        }

        [Fact]
        public void ExtendLock_When_Lock_Time_Is_In_Past_Then_Returns_Errors()
        {
            // Arrange
            var entity = Build<LockableEntity>(LockableEntityFactory.LOCKED);
            var lockUntil = DateTimeOffset.UtcNow.AddMinutes(-15); // This is the important setup

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: entity.Id, resultObject: entity).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.ExtendLock(
                id: entity.Id,
                lockUntil: lockUntil,
                updatedById: entity.LockedById
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_EXTEND_LOCK_LOCK_TIME_IN_PAST);
        }

        [Fact]
        public void ExtendLock_When_Update_Returns_Errors_Then_Returns_Errors()
        {
            var entity = Build<LockableEntity>(LockableEntityFactory.LOCKED);

            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsBasicErrorResult();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(id: entity.Id, resultObject: entity).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
            );

            // Act
            var result = sut.ExtendLock(
                id: entity.Id,
                lockUntil: GetFifteenMinutesInTheFuture(),
                updatedById: entity.LockedById
            );

            // Assert
            result.ShouldHaveBasicError();
        }

        #endregion ExtendLock

        #region ValidateLock

        [Fact]
        public void ValidateLock_When_Lock_Is_Valid_Then_Returns_True()
        {
            // Arrange
            var entity = Build<LockableEntity>(LockableEntityFactory.LOCKED);

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: null,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.ValidateLock(
                currentUserId: entity.LockedById,
                item: entity
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBeTrue();
        }

        [Fact]
        public void ValidateLock_When_Record_Is_Null_Then_Returns_False()
        {
            // Arrange & Act
            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: null,
                repositoryUpdateConductor: null
            );

            var result = sut.ValidateLock(null);

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_VALIDATE_LOCK_ITEM_IS_NULL);
            result.ResultObject.ShouldBeFalse();
        }

        [Fact]
        public void ValidateLock_When_Record_Lock_Is_Expired_Then_Returns_False()
        {
            // Arrange
            var entity = Build<LockableEntity>(LockableEntityFactory.EXPIRED);

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: null,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.ValidateLock(
                currentUserId: entity.LockedById,
                item: entity
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_VALIDATE_LOCK_ITEM_NOT_LOCKED);
        }

        [Fact]
        public void ValidateLock_When_Record_Is_Locked_By_A_Different_User_Then_Returns_False()
        {
            // Arrange
            var entity = Build<LockableEntity>(LockableEntityFactory.LOCKED);
            var unauthorizedUserId = entity.LockedById + 1; // This is the important setup

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: null,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.ValidateLock(
                currentUserId: unauthorizedUserId,
                item: entity
            );

            // Assert
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_VALIDATE_LOCK_LOCKED_BY_DIFFERENT_USER);
        }

        #endregion ValidateLock
    }
}
