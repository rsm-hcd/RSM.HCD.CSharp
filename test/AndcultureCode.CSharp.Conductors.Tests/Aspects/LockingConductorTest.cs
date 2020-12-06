using System;
using AndcultureCode.CSharp.Conductors.Aspects;
using AndcultureCode.CSharp.Conductors.Tests.Stubs;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Testing.Constants;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Tests;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Conductors.Tests.Aspects
{
    public class LockingConductorTest : BaseUnitTest
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
            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsGivenResult(true);

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, new LockableEntity()).Object;

            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            // Act
            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
            );

            var result = sut.Lock(
                id: 1,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeNull();
            result.ResultObject.LockedById.ShouldBe(1);
            result.ResultObject.LockedUntil.ShouldNotBeNull();
        }

        [Fact]
        public void Lock_When_FindById_Returns_Errors_Then_Returns_Errors()
        {
            // Arrange
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsBasicErrorResult(1).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
            );

            // Act
            var result = sut.Lock(
                id: 1,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY);
        }

        [Fact]
        public void Lock_When_FindById_Returns_Null_ResultObject_Then_Returns_Errors()
        {
            // Arrange
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, null).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.Lock(
                id: 1,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<Lockable>.ERROR_LOCK_RECORD_NOT_FOUND);
        }

        [Fact]
        public void Lock_When_Record_Is_Already_Locked_Then_Returns_Errors()
        {
            // Arrange
            var record = new LockableEntity() { LockedUntil = GetFifteenMinutesInTheFuture() };

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, record).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.Lock(
                id: 1,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_LOCK_RECORD_ALREADY_LOCKED);
        }

        [Fact]
        public void Lock_When_LockUntil_Is_In_The_Past_Then_Returns_Errors()
        {
            // Arrange
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, new LockableEntity()).Object;

            var sut = new LockingConductor<LockableEntity>(
               logger: _logger,
               repositoryReadConductor: repositoryReadConductor,
               repositoryUpdateConductor: null
           );

            // Act
            var result = sut.Lock(
                id: 1,
                lockUntil: DateTimeOffset.Now.AddMinutes(-15),
                lockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_LOCK_TIME_IN_PAST);
        }

        [Fact]
        public void Lock_When_Update_Returns_Errors_Then_Returns_Errors()
        {
            // Arrange
            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsBasicErrorResult();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, new LockableEntity()).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
           );

            // Act
            var result = sut.Lock(
                id: 1,
                lockUntil: GetFifteenMinutesInTheFuture(),
                lockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveBasicError();
        }

        #endregion Lock

        #region Unlock

        [Fact]
        public void Unlock_When_Record_Is_Unlocked_Then_Returns_Updated_Record()
        {
            // Arrange
            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsGivenResult(true);

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, new LockableEntity()).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
           );

            // Act
            var result = sut.Unlock(
                id: 1,
                unlockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
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
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsBasicErrorResult(1).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.Unlock(
                id: 1,
                unlockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveBasicError();
        }

        [Fact]
        public void Unlock_When_FindById_Returns_Null_ResultObject_Then_Returns_Errors()
        {
            // Arrange
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, null).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.Unlock(
                id: 1,
                unlockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<Lockable>.ERROR_UNLOCK_RECORD_NOT_FOUND);
        }

        [Fact]
        public void Unlock_When_Update_Returns_Errors_Then_Returns_Errors()
        {
            // Arrange
            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsBasicErrorResult();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, new LockableEntity()).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
               logger: _logger,
               repositoryReadConductor: repositoryReadConductor,
               repositoryUpdateConductor: repositoryUpdateConductor
           );

            // Act
            var result = sut.Unlock(
                id: 1,
                unlockedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveBasicError();
        }

        #endregion Unlock

        #region ExtendLock

        [Fact]
        public void ExtendLock_When_Lock_Time_Is_Extended_Then_Returns_Updated_Record()
        {
            // Arrange
            var lockedUntil = DateTimeOffset.Now.AddMinutes(5);
            var record = new LockableEntity()
            {
                LockedById = 1,
                LockedOn = DateTimeOffset.Now,
                LockedUntil = lockedUntil
            };

            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsGivenResult(true);

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, record).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
           );

            // Act
            var result = sut.ExtendLock(
                id: 1,
                lockUntil: GetFifteenMinutesInTheFuture(),
                updatedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeNull();
            result.ResultObject.LockedUntil.ShouldNotBeNull();
            result.ResultObject.LockedUntil.Value.ShouldBeGreaterThan(lockedUntil);
        }

        [Fact]
        public void ExtendLock_When_FindById_Returns_Errors_Then_Returns_Errors()
        {
            // Arrange
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsBasicErrorResult(1).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.ExtendLock(1, GetFifteenMinutesInTheFuture(), 1);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveBasicError();
        }

        [Fact]
        public void ExtendLock_When_FindById_Returns_Null_ResultObject_Then_Returns_Errors()
        {
            // Arrange
            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, null).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.ExtendLock(
                id: 1,
                lockUntil: GetFifteenMinutesInTheFuture(),
                updatedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_EXTEND_LOCK_RECORD_NOT_FOUND);
        }

        [Fact]
        public void ExtendLock_When_Record_Is_Not_Locked_Then_Returns_Errors()
        {
            // Arrange
            var record = new LockableEntity() { LockedUntil = null };

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, record).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.ExtendLock(
                id: 1,
                lockUntil: GetFifteenMinutesInTheFuture(),
                updatedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_EXTEND_LOCK_RECORD_NOT_LOCKED);
        }

        [Fact]
        public void ExtendLock_When_Record_Is_Locked_By_Another_User_Then_Returns_Errors()
        {
            // Arrange
            var record = new LockableEntity()
            {
                LockedById = 2,
                LockedUntil = DateTimeOffset.Now.AddMinutes(15)
            };

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, record).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.ExtendLock(
                id: 1,
                lockUntil: GetFifteenMinutesInTheFuture(),
                updatedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_EXTEND_LOCK_LOCKED_BY_DIFFERENT_USER);
        }

        [Fact]
        public void ExtendLock_When_Lock_Time_Is_In_Past_Then_Returns_Errors()
        {
            // Arrange
            var record = new LockableEntity()
            {
                LockedById = 1,
                LockedUntil = DateTimeOffset.Now.AddMinutes(10)
            };

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, record).Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.ExtendLock(
                id: 1,
                lockUntil: DateTimeOffset.Now.AddMinutes(-15),
                updatedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_EXTEND_LOCK_LOCK_TIME_IN_PAST);
        }

        [Fact]
        public void ExtendLock_When_Update_Returns_Errors_Then_Returns_Errors()
        {
            var record = new LockableEntity()
            {
                LockedById = 1,
                LockedOn = DateTimeOffset.Now,
                LockedUntil = DateTimeOffset.Now.AddMinutes(5)
            };

            var repositoryUpdateConductorMock = new Mock<IRepositoryUpdateConductor<LockableEntity>>();
            repositoryUpdateConductorMock
                .Setup(m => m.Update(It.IsAny<LockableEntity>(), It.IsAny<long?>()))
                .ReturnsBasicErrorResult();

            var repositoryReadConductor = new Mock<IRepositoryReadConductor<LockableEntity>>()
                .SetupFindByIdReturnsGivenResult(1, record).Object;
            var repositoryUpdateConductor = repositoryUpdateConductorMock.Object;

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: repositoryReadConductor,
                repositoryUpdateConductor: repositoryUpdateConductor
           );

            // Act
            var result = sut.ExtendLock(
                id: 1,
                lockUntil: DateTimeOffset.Now.AddMinutes(15),
                updatedById: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveBasicError();
        }

        #endregion ExtendLock

        #region ValidateLock

        [Fact]
        public void ValidateLock_When_Lock_Is_Valid_Then_Returns_True()
        {
            // Arrange
            var record = new LockableEntity()
            {
                LockedById = 1,
                LockedUntil = DateTimeOffset.Now.AddMinutes(15)
            };

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: null,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.ValidateLock(
                item: record,
                currentUserId: 1
            );

            // Assert
            result.ShouldNotBeNull();
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
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_VALIDATE_LOCK_ITEM_IS_NULL);
            result.ResultObject.ShouldBeFalse();
        }

        [Fact]
        public void ValidateLock_When_Record_Lock_Is_Expired_Then_Returns_False()
        {
            // Arrange
            var record = new LockableEntity()
            {
                LockedById = 1,
                LockedUntil = DateTimeOffset.Now.AddMinutes(-15)
            };

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: null,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.ValidateLock(
                item: record,
                currentUserId: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_VALIDATE_LOCK_ITEM_NOT_LOCKED);
        }

        [Fact]
        public void ValidateLock_When_Record_Is_Locked_By_A_Different_User_Then_Returns_False()
        {
            // Arrange
            var record = new LockableEntity()
            {
                LockedById = 2,
                LockedUntil = DateTimeOffset.Now.AddMinutes(15)
            };

            var sut = new LockingConductor<LockableEntity>(
                logger: _logger,
                repositoryReadConductor: null,
                repositoryUpdateConductor: null
           );

            // Act
            var result = sut.ValidateLock(
                item: record,
                currentUserId: 1
            );

            // Assert
            result.ShouldNotBeNull();
            result.ShouldHaveErrorsFor(LockingConductor<LockableEntity>.ERROR_VALIDATE_LOCK_LOCKED_BY_DIFFERENT_USER);
        }

        #endregion ValidateLock
    }
}
