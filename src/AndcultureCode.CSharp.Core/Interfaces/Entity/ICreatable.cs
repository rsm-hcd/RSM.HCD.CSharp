using System;

namespace AndcultureCode.CSharp.Core.Interfaces.Entity
{
    public interface ICreatable
    {
        long?           CreatedById { get; set; }
        DateTimeOffset? CreatedOn { get; set; }
    }
}
