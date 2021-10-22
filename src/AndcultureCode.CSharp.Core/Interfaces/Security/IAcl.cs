using AndcultureCode.CSharp.Core.Enumerations;
using AndcultureCode.CSharp.Core.Interfaces.Entity;

namespace AndcultureCode.CSharp.Core.Interfaces.Security
{
    public interface IAcl : IAuditable
    {
        Permission Permission { get; set; }
        string Resource { get; set; }
        string Subject { get; set; }
        string Verb { get; set; }
    }
}