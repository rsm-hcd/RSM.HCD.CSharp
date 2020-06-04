using AndcultureCode.CSharp.Core.Constants;
using AndcultureCode.CSharp.Core.Models.Localization;

namespace AndcultureCode.CSharp.Core.Cultures
{
    public class EnglishUnitedStates : Culture
    {
        public override string Code { get => Rfc4646LanguageCodes.EN_US; }
        public override bool IsDefault => true;
    }
}
