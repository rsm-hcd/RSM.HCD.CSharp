using RSM.HCD.CSharp.Core.Enumerations;
using RSM.HCD.CSharp.Core.Interfaces.Entity;

namespace RSM.HCD.CSharp.Core.Interfaces.Security
{
    public interface IAcl : IAuditable
    {
        Permission Permission { get; set; }
        string Resource { get; set; }
        string Subject { get; set; }
        string Verb { get; set; }
    }
}
