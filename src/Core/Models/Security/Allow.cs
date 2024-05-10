using RSM.HCD.CSharp.Core.Enumerations;

namespace RSM.HCD.CSharp.Core.Models.Security
{
    /// <summary>
    /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
    /// </summary>
    public class Allow : AccessRule
    {
        #region Properties

        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        public override Permission Permission => Permission.Allow;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/38
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="verb"></param>
        /// <param name="subject"></param>
        public Allow(string resource, string verb, string subject) : base(resource, verb, subject) { }

        #endregion Constructor
    }
}
