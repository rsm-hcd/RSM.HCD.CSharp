using System;

namespace RSM.HCD.CSharp.Core.Interfaces.Entity
{
    public interface IDeletable
    {
        long? DeletedById { get; set; }
        DateTimeOffset? DeletedOn { get; set; }
    }
}
