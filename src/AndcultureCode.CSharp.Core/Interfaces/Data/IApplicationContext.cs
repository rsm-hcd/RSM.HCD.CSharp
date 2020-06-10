using System.Linq;
using AndcultureCode.CSharp.Core.Models.Entities;

namespace AndcultureCode.GB.Business.Core.Interfaces.Data
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
