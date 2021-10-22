using System;

namespace AndcultureCode.CSharp.Core.Interfaces.Entity
{
    public interface IUpdatable
    {
        long?           UpdatedById { get; set; }
        DateTimeOffset? UpdatedOn   { get; set; }
    }
}
