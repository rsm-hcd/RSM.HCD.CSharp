using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;

namespace AndcultureCode.CSharp.Core.Utilities.Localization
{
    public static class LocalizationUtils
    {
        #region Private Properties

        private static List<string> _assemblyExclusions = new List<string> { "Microsoft", "Serilog", "System", "Windows", "xunit" };
        private static List<ICulture> _cultures;

        #endregion Private Properties

        #region Public Properties

        /// <summary>
        /// Current cultures supported by the application
        /// </summary>
        public static List<ICulture> Cultures
        {
            get
            {
                if (_cultures != null)
                {
                    return _cultures;
                }

                _cultures = AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .Where(x => _assemblyExclusions.All(e => !x.GetName().FullName.StartsWith(e))) // Avoid loading types for common assemblies out of our control
                    .SelectMany(x =>
                    {
                        // TODO: Provided the method gets added, update this to be a convenience method
                        // see https://github.com/AndcultureCode/AndcultureCode.CSharp.Extensions/issues/38
                        try
                        {
                            return x.GetTypes();
                        }
                        catch (ReflectionTypeLoadException e)
                        {
                            return e.Types.Where(t => t != null);
                        }
                    })
                    .Where(x => typeof(ICulture).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                    .Select(e => Activator.CreateInstance(e))
                    .Cast<ICulture>()
                    .ToList();

                return _cultures;
            }
        }

        public static List<CultureInfo> CultureInfos { get => Cultures?.ToCultureInfos(); }

        public static ICulture DefaultCulture { get => Cultures?.Default(); }

        public static string DefaultCultureCode { get => DefaultCulture?.Code; }

        public static CultureInfo DefaultCultureInfo { get => DefaultCulture?.ToCultureInfo(); }

        #endregion Public Properties


        #region Public Methods

        public static ICulture CultureByCode(string cultureCode)
        {
            if (cultureCode == CultureInfo.InvariantCulture.Name)
            {
                return DefaultCulture;
            }

            return Cultures.FirstOrDefault(e => e.Code.ToLower() == cultureCode.ToLower());
        }

        public static string CultureCodes(string delimiter = ", ")
            => Cultures.ToCultureCodes(delimiter);

        public static bool CultureExists(string cultureCode) => Cultures.Exists(cultureCode);

        #endregion Public Methods
    }
}
