using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Models.Entities
{
    public abstract class Entity : IEntity
    {
        public long Id { get; set; }
    }
}
