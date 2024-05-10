using System.Collections.Generic;
using System.IO;
using RSM.HCD.CSharp.Core.Models.Localization;
using Newtonsoft.Json;

namespace RSM.HCD.CSharp.Core.Extensions
{
    /// <summary>
    /// String extension methods
    /// </summary>
    public static class StringExtensions
    {
        #region Public Methods

        /// <summary>
        /// Loads a given translation .json file and maps contents to CultureTranslation objects
        /// </summary>
        public static List<CultureTranslation> LoadTranslations(this string filePath, string cultureCode, JsonSerializerSettings serializerSettings)
        {
            var fileContents = File.ReadAllText(filePath);
            var translations = JsonConvert.DeserializeObject<List<CultureTranslation>>(fileContents, serializerSettings);

            translations.ForEach(t =>
            {
                t.CultureCode = cultureCode;
                t.FilePath = filePath;
            });

            return translations;
        }

        #endregion Public Methods
    }
}
