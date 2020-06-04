using AndcultureCode.CSharp.Core.Enumerations;

namespace AndcultureCode.CSharp.Core.Models.Security
{
    public class Allow : AccessRule
    {
        #region Properties

        public override Permission Permission => Permission.Allow;

        #endregion Proeprties

        #region Constructor

        public Allow(string resource, string verb, string subject) : base(resource, verb, subject) { }

        #endregion Constructor
    }
}
