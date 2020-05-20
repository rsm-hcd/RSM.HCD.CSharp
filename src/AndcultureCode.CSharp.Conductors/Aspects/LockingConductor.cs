using System;
using AndcultureCode.CSharp.Core;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using Microsoft.Extensions.Logging;

namespace AndcultureCode.CSharp.Conductors.Aspects
{
    public class LockingConductor<T> : Conductor, ILockingConductor<T>
        where T : class, ILockable, IEntity
    {
        #region Properties

        private readonly ILogger<LockingConductor<T>> _logger;
        private readonly IRepositoryReadConductor<T> _repositoryReadConductor;
        private readonly IRepositoryUpdateConductor<T> _repositoryUpdateConductor;

        #endregion Properties

        #region Constants

        public static readonly string ERROR_EXTEND_LOCK_LOCK_TIME_IN_PAST = $"{nameof(LockingConductor<T>)}.LockTimeInPast";
        public static readonly string ERROR_EXTEND_LOCK_LOCKED_BY_DIFFERENT_USER = $"{nameof(LockingConductor<T>)}.ExtendLock.RecordLockedByDifferentUser";
        public static readonly string ERROR_EXTEND_LOCK_RECORD_NOT_FOUND = $"{nameof(LockingConductor<T>)}.ExtendLock.ReadResultIsNull";
        public static readonly string ERROR_EXTEND_LOCK_RECORD_NOT_LOCKED = $"{nameof(LockingConductor<T>)}.ExtendLock.RecordIsNotLocked";
        public static readonly string ERROR_LOCK_RECORD_ALREADY_LOCKED = $"{nameof(LockingConductor<T>)}.{typeof(T).Name}.IsLocked";
        public static readonly string ERROR_LOCK_RECORD_NOT_FOUND = $"{nameof(LockingConductor<T>)}.Lock.ReadResult.ResultObjectIsNull";
        public static readonly string ERROR_LOCK_TIME_IN_PAST = $"{nameof(LockingConductor<T>)}.LockTimeInPast";
        public static readonly string ERROR_UNLOCK_RECORD_NOT_FOUND = $"{nameof(LockingConductor<T>)}.Unlock.ReadResultIsNull";
        public static readonly string ERROR_VALIDATE_LOCK_ITEM_IS_NULL = $"{nameof(LockingConductor<T>)}.ValidateLock.{typeof(T).Name}.IsNull";
        public static readonly string ERROR_VALIDATE_LOCK_ITEM_NOT_LOCKED = $"{nameof(LockingConductor<T>)}.ValidateLock.{typeof(T).Name}.IsNotLocked";
        public static readonly string ERROR_VALIDATE_LOCK_LOCKED_BY_DIFFERENT_USER = $"{nameof(LockingConductor<T>)}.ValidateLock.{typeof(T).Name}.LockedByDifferentUser";

        #endregion Constants

        #region Constructor

        public LockingConductor(
            ILogger<LockingConductor<T>> logger,
            IRepositoryReadConductor<T> repositoryReadConductor,
            IRepositoryUpdateConductor<T> repositoryUpdateConductor
        )
        {
            _logger = logger;
            _repositoryReadConductor = repositoryReadConductor;
            _repositoryUpdateConductor = repositoryUpdateConductor;
        }

        #endregion Constructor

        #region ILockingConductor

        public virtual IResult<T> Lock(long id, DateTimeOffset lockUntil, long? lockedById) => Do<T>.Try(r =>
        {
            var readResult = _repositoryReadConductor.FindById(id);

            if (readResult.HasErrors)
            {
                r.AddErrors(readResult.Errors);
                return null;
            }

            if (readResult.ResultObject == null)
            {
                r.AddErrorAndLog(_logger,
                                 ERROR_LOCK_RECORD_NOT_FOUND,
                                 $"Read Result of {typeof(T).Name} id: {id} was null",
                                 id);
                return null;
            }

            var record = readResult.ResultObject;

            if (record.IsLocked)
            {
                r.AddErrorAndLog(_logger,
                                 ERROR_LOCK_RECORD_ALREADY_LOCKED,
                                 $"{typeof(T).Name} id: {id} is already locked",
                                 id);
                return null;
            }

            var now = DateTimeOffset.Now;

            if (lockUntil < now)
            {
                r.AddErrorAndLog(_logger,
                                 ERROR_LOCK_TIME_IN_PAST,
                                 $"LockedUntil time is in the past",
                                 id);
                return null;
            }

            record.LockedById = lockedById;
            record.LockedOn = DateTimeOffset.Now;
            record.LockedUntil = lockUntil;

            var updateResult = _repositoryUpdateConductor.Update(record, lockedById);

            if (updateResult.HasErrors)
            {
                r.AddErrors(updateResult.Errors);
                return null;
            }

            return record;
        }).Result;

        public virtual IResult<T> Unlock(long id, long? unlockedById = null) => Do<T>.Try(r =>
        {
            var readResult = _repositoryReadConductor.FindById(id);

            if (readResult.HasErrors)
            {
                r.AddErrors(readResult.Errors);
                return null;
            }

            if (readResult.ResultObject == null)
            {
                r.AddErrorAndLog(_logger,
                                 ERROR_UNLOCK_RECORD_NOT_FOUND,
                                 $"Read Result of {typeof(T).Name} id: {id} was null",
                                 id);
                return null;
            }

            var record = readResult.ResultObject;

            record.LockedById = null;
            record.LockedUntil = null;
            record.LockedOn = null;

            var updateResult = _repositoryUpdateConductor.Update(record, unlockedById);

            if (updateResult.HasErrors)
            {
                r.AddErrors(updateResult.Errors);
                return null;
            }

            return record;
        }).Result;

        public virtual IResult<T> ExtendLock(long id, DateTimeOffset lockUntil, long? updatedById) => Do<T>.Try(r =>
        {
            var readResult = _repositoryReadConductor.FindById(id);

            if (readResult.HasErrors)
            {
                r.AddErrors(readResult.Errors);
                return null;
            }

            if (readResult.ResultObject == null)
            {
                r.AddErrorAndLog(_logger,
                                 ERROR_EXTEND_LOCK_RECORD_NOT_FOUND,
                                 $"Read Result of {typeof(T).Name} id: {id} was null",
                                 id);
                return null;
            }

            var record = readResult.ResultObject;

            if (!record.IsLocked)
            {
                r.AddErrorAndLog(_logger,
                                 ERROR_EXTEND_LOCK_RECORD_NOT_LOCKED,
                                 $"{typeof(T).Name} id: {id} is not currently locked",
                                 id);
                return null;
            }

            if (!updatedById.HasValue || record.LockedById != updatedById)
            {
                r.AddErrorAndLog(_logger,
                                 ERROR_EXTEND_LOCK_LOCKED_BY_DIFFERENT_USER,
                                 $"{typeof(T).Name} id: {id} is locked by a different user",
                                 id);
                return null;
            }

            var now = DateTimeOffset.Now;

            if (lockUntil < now)
            {
                r.AddErrorAndLog(_logger,
                                 ERROR_EXTEND_LOCK_LOCK_TIME_IN_PAST,
                                 "LockedUntil time is in the past",
                                 id);
                return null;
            }

            record.LockedUntil = lockUntil;

            var updateResult = _repositoryUpdateConductor.Update(record, updatedById);

            if (updateResult.HasErrors)
            {
                r.AddErrors(updateResult.Errors);
                return null;
            }

            return record;
        }).Result;

        public virtual IResult<bool> ValidateLock(T item, long? currentUserId = null) => Do<bool>.Try(r =>
        {
            if (item == null)
            {
                r.AddErrorAndLog(_logger,
                    ERROR_VALIDATE_LOCK_ITEM_IS_NULL,
                    $"{typeof(T).Name} was null");
                return false;
            }

            if (!item.IsLocked)
            {
                r.AddValidationError(ERROR_VALIDATE_LOCK_ITEM_NOT_LOCKED,
                    $"{typeof(T).Name} no longer has a valid lock");
                return false;
            }

            if (!currentUserId.HasValue || item.LockedById != currentUserId)
            {
                r.AddValidationError(ERROR_VALIDATE_LOCK_LOCKED_BY_DIFFERENT_USER,
                    $"{typeof(T).Name} is locked by another user");
                return false;
            }

            return true;
        }).Result;

        #endregion ILockingConductor

    }
}