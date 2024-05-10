using RSM.HCD.CSharp.Core.Enumerations;
using RSM.HCD.CSharp.Core.Interfaces.Security;

namespace RSM.HCD.CSharp.Core.Models.Entities.Acls
{
    /// <summary>
    /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
    /// </summary>
    public class Acl : Auditable, IAcl
    {
        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        public Permission Permission { get; set; }

        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        public string Verb { get; set; }
    }
}
