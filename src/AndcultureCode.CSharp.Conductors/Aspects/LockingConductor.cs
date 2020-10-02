using System;
using AndcultureCode.CSharp.Core;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using Microsoft.Extensions.Logging;

namespace AndcultureCode.CSharp.Conductors.Aspects
{
    /// <summary>
    /// Repository implementation for handling ILockable entiteis
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LockingConductor<T> : Conductor, ILockingConductor<T>
        where T : class, ILockable, IEntity
    {
        #region Properties

        private readonly ILogger<LockingConductor<T>> _logger;
        private readonly IRepositoryReadConductor<T> _repositoryReadConductor;
        private readonly IRepositoryUpdateConductor<T> _repositoryUpdateConductor;

        #endregion Properties

        #region Constants

        /// <summary>
        /// Error key indicating lock cannot be extended because the lock has expired
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_EXTEND_LOCK_LOCK_TIME_IN_PAST = $"{nameof(LockingConductor<T>)}.LockTimeInPast";

        /// <summary>
        /// Error key indicating the lock cannot be extended because it was locked by a different user
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_EXTEND_LOCK_LOCKED_BY_DIFFERENT_USER = $"{nameof(LockingConductor<T>)}.ExtendLock.RecordLockedByDifferentUser";

        /// <summary>
        /// Error key indicating the lock cannot be extended because the record to be locked could not
        /// be found. It may have been deleted or is otherwise unavailable.
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_EXTEND_LOCK_RECORD_NOT_FOUND = $"{nameof(LockingConductor<T>)}.ExtendLock.ReadResultIsNull";

        /// <summary>
        /// Error key indicating the lock cannot be extended because the record is not locked
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_EXTEND_LOCK_RECORD_NOT_LOCKED = $"{nameof(LockingConductor<T>)}.ExtendLock.RecordIsNotLocked";

        /// <summary>
        /// Error key indicating the record cannot be locked because it is already in a locked state
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_LOCK_RECORD_ALREADY_LOCKED = $"{nameof(LockingConductor<T>)}.{typeof(T).Name}.IsLocked";

        /// <summary>
        /// Error key indicating the record cannot be locked because the record to be locked could not
        /// be found. It may have been deleted or is otherwise unavailable.
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_LOCK_RECORD_NOT_FOUND = $"{nameof(LockingConductor<T>)}.Lock.ReadResult.ResultObjectIsNull";

        /// <summary>
        /// Error key indicating the record cannot be locked because the desired lockTime is in the past
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_LOCK_TIME_IN_PAST = $"{nameof(LockingConductor<T>)}.LockTimeInPast";

        /// <summary>
        /// Error key indicating the record cannot be unlocked because the record to be unlocked could not
        /// be found. It may have been deleted or is otherwise unavailable.
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_UNLOCK_RECORD_NOT_FOUND = $"{nameof(LockingConductor<T>)}.Unlock.ReadResultIsNull";

        /// <summary>
        /// Error key indicating the lock could not be validated because the item to be validated is null
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_VALIDATE_LOCK_ITEM_IS_NULL = $"{nameof(LockingConductor<T>)}.ValidateLock.{typeof(T).Name}.IsNull";

        /// <summary>
        /// Error key indicating the lock could not be validated because the item is not in a locked state
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_VALIDATE_LOCK_ITEM_NOT_LOCKED = $"{nameof(LockingConductor<T>)}.ValidateLock.{typeof(T).Name}.IsNotLocked";

        /// <summary>
        /// Error key indicating the lock could not be validated because the resource was locked by a different user
        /// </summary>
        /// <returns></returns>
        public static readonly string ERROR_VALIDATE_LOCK_LOCKED_BY_DIFFERENT_USER = $"{nameof(LockingConductor<T>)}.ValidateLock.{typeof(T).Name}.LockedByDifferentUser";

        #endregion Constants

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repositoryReadConductor"></param>
        /// <param name="repositoryUpdateConductor"></param>
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

        /// <summary>
        /// Updates the locking fields to be set, which denotes that the user locking the record should
        /// have exclusive access to modifying it for the lock's duration. This, however, does
        /// not prohibit the record from being modified by others. When a record is locked, the
        /// ValidateLock method below should be used to determine if the record can be modified. This will
        /// ensure that only the user that locked the record is actually able to modify its contents.
        /// </summary>
        /// <param name="id">The record id</param>
        /// <param name="lockUntil">The time the record should be locked until</param>
        /// <param name="lockedById">The id of the user locking the record</param>
        /// <returns>the updated record if it is successfully locked, null otherwise</returns>
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
                r.AddErrorAndLog(
                    _logger,
                    ERROR_LOCK_RECORD_NOT_FOUND,
                    $"Read Result of {typeof(T).Name} id: {id} was null",
                    id
                );
                return null;
            }

            var record = readResult.ResultObject;

            if (record.IsLocked)
            {
                r.AddErrorAndLog(
                    _logger,
                    ERROR_LOCK_RECORD_ALREADY_LOCKED,
                    $"{typeof(T).Name} id: {id} is already locked",
                    id
                );
                return null;
            }

            var now = DateTimeOffset.Now;

            if (lockUntil < now)
            {
                r.AddErrorAndLog(
                    _logger,
                    ERROR_LOCK_TIME_IN_PAST,
                    $"LockedUntil time is in the past",
                    id
                );
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

        /// <summary>
        /// Updates the locking fields back to null, meaning any user will be able to acquire a lock
        /// so they have exclusive access to editing it.
        /// </summary>
        /// <param name="id">The record id</param>
        /// <param name="unlockedById">The id of the user unlocking the record</param>
        /// <returns>the updated record if it is successfully unlocked, null otherwise</returns>
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
                r.AddErrorAndLog(
                    _logger,
                    ERROR_UNLOCK_RECORD_NOT_FOUND,
                    $"Read Result of {typeof(T).Name} id: {id} was null",
                    id
                );
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

        /// <summary>
        /// Updates the LockedUntil field for the record, allowing the user that locked
        /// it to have the lock for a longer amount of time.
        /// </summary>
        /// <param name="id">The record id</param>
        /// <param name="lockUntil">The time the record should be locked until</param>
        /// <param name="updatedById">The id of the user updating the record's lock time</param>
        /// <returns>the updated record if the lock is successfully extended, null otherwise</returns>
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
                r.AddErrorAndLog(
                    _logger,
                    ERROR_EXTEND_LOCK_RECORD_NOT_FOUND,
                    $"Read Result of {typeof(T).Name} id: {id} was null",
                    id
                );
                return null;
            }

            var record = readResult.ResultObject;

            if (!record.IsLocked)
            {
                r.AddErrorAndLog(
                    _logger,
                    ERROR_EXTEND_LOCK_RECORD_NOT_LOCKED,
                    $"{typeof(T).Name} id: {id} is not currently locked",
                    id
                );
                return null;
            }

            if (!updatedById.HasValue || record.LockedById != updatedById)
            {
                r.AddErrorAndLog(
                    _logger,
                    ERROR_EXTEND_LOCK_LOCKED_BY_DIFFERENT_USER,
                    $"{typeof(T).Name} id: {id} is locked by a different user",
                    id
                );
                return null;
            }

            var now = DateTimeOffset.Now;

            if (lockUntil < now)
            {
                r.AddErrorAndLog(
                    _logger,
                    ERROR_EXTEND_LOCK_LOCK_TIME_IN_PAST,
                    "LockedUntil time is in the past",
                    id
                );
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

        /// <summary>
        /// Used to determine whether or not the user attempting to update the record is the
        /// user that has the lock, AND that the lock is still valid (i.e. not expired).
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="currentUserId">The current user id</param>
        /// <returns>true if the lock is still active and is locked by the current user, false otherwise</returns>
        public virtual IResult<bool> ValidateLock(T item, long? currentUserId = null) => Do<bool>.Try(r =>
        {
            if (item == null)
            {
                r.AddErrorAndLog(
                    _logger,
                    ERROR_VALIDATE_LOCK_ITEM_IS_NULL,
                    $"{typeof(T).Name} was null"
                );
                return false;
            }

            if (!item.IsLocked)
            {
                r.AddValidationError(
                    ERROR_VALIDATE_LOCK_ITEM_NOT_LOCKED,
                    $"{typeof(T).Name} no longer has a valid lock"
                );
                return false;
            }

            if (!currentUserId.HasValue || item.LockedById != currentUserId)
            {
                r.AddValidationError(
                    ERROR_VALIDATE_LOCK_LOCKED_BY_DIFFERENT_USER,
                    $"{typeof(T).Name} is locked by another user"
                );
                return false;
            }

            return true;
        }).Result;

        #endregion ILockingConductor

    }
}