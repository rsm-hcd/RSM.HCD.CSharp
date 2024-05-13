namespace RSM.HCD.CSharp.Core.Interfaces.Entity
{
    /// <summary>
    /// Unique reponsibility (typically of a user) in the system
    /// </summary>
    public interface IRole : IEntity
    {
        /// <summary>
        /// Brief description around the purpose of this role in the system
        /// </summary>
        /// <value></value>
        string Description { get; set; }

        /// <summary>
        /// Human readable name for this role in the system
        /// /// </summary>
        /// <value></value>
        string Name { get; set; }
    }
}
