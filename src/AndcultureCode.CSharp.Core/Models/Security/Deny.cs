using AndcultureCode.CSharp.Core.Enumerations;

namespace AndcultureCode.CSharp.Core.Models.Security
{
    public class Deny : AccessRule
    {
        #region Properties

        public override Permission Permission => Permission.Deny;

        #endregion Properties

        #region Constructor

        public Deny(string resource, string verb, string subject) : base(resource, verb, subject) { }

        #endregion Constructor
    }
}
