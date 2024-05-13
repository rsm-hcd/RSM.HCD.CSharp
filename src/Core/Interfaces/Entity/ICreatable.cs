using System;

namespace RSM.HCD.CSharp.Core.Interfaces.Entity
{
    public interface ICreatable
    {
        long? CreatedById { get; set; }
        DateTimeOffset? CreatedOn { get; set; }
    }
}
