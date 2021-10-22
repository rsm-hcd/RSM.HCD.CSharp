using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Models.Localization;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Stubs
{
    public class CultureStub : Culture, ICulture
    {
        public override string Code => "te-ST";
    }
}
