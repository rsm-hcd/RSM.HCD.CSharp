using System;

namespace AndcultureCode.CSharp.Core.Interfaces.Entity
{
    public interface ILockable
    {
        bool IsLocked { get; }
        DateTimeOffset? LockedOn { get; set; }
        DateTimeOffset? LockedUntil { get; set; }
        long? LockedById { get; set; }
    }
}