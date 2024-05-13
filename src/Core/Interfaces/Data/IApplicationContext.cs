using RSM.HCD.CSharp.Core.Models.Entities.Acls;
using System.Linq;

namespace RSM.HCD.CSharp.Core.Interfaces.Data
{
    /// <summary>
    /// Base application context containing commonly leveraged system-level entities
    /// </summary>
    public interface IApplicationContext
    {
        /// <summary>
        /// Access control lists
        /// </summary>
        IQueryable<Acl> Acls { get; }
    }
}
