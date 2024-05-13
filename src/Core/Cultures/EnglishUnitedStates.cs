using RSM.HCD.CSharp.Core.Constants;
using RSM.HCD.CSharp.Core.Models.Localization;

namespace RSM.HCD.CSharp.Core.Cultures
{
    /// <summary>
    /// Localization Culture for United States English (en-US)
    /// </summary>
    public class EnglishUnitedStates : Culture
    {
        /// <inheritdoc/>
        public override string Code { get => Rfc4646LanguageCodes.EN_US; }
        /// <inheritdoc/>
        public override bool IsDefault => true;
    }
}
