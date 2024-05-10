using RSM.HCD.CSharp.Core.Interfaces;
using RSM.HCD.CSharp.Core.Models.Localization;

namespace RSM.HCD.CSharp.Core.Tests.Unit.Stubs
{
    public class CultureStub : Culture, ICulture
    {
        public override string Code => "te-ST";
    }
}
