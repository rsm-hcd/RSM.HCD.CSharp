using RSM.HCD.CSharp.Core.Interfaces.Entity;

namespace RSM.HCD.CSharp.Core.Models.Entities
{
    /// <summary>
    /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        public long Id { get; set; }
    }
}
