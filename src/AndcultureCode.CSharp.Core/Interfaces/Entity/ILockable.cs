using System;

namespace AndcultureCode.CSharp.Core.Interfaces.Entity
{
    public interface ILockable
    {
        bool IsLocked { get; }
        long? LockedById { get; set; }
        DateTimeOffset? LockedOn { get; set; }
        DateTimeOffset? LockedUntil { get; set; }
    }
}