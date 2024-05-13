using System.Collections.Generic;
using RSM.HCD.CSharp.Core.Models.Localization;

namespace RSM.HCD.CSharp.Core.Interfaces
{
    public interface ICulture
    {
        #region Properties

        /// <summary>
        /// RFC-4646 5-character Culture code (xx-XX)
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Is this the default locale in the application? There can only be one
        /// </summary>
        bool IsDefault { get; }

        #endregion Properties


        #region Navigation Properties

        List<CultureTranslation> CultureTranslations { get; }

        #endregion Navigation Properties
    }
}
