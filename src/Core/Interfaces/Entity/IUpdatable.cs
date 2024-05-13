using System;

namespace RSM.HCD.CSharp.Core.Interfaces.Entity
{
    public interface IUpdatable
    {
        long? UpdatedById { get; set; }
        DateTimeOffset? UpdatedOn { get; set; }
    }
}
