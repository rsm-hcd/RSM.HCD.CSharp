using System.Text.RegularExpressions;
using RSM.HCD.CSharp.Core.Interfaces.Providers;

namespace RSM.HCD.CSharp.Core.Providers
{
    /// <summary>
    /// Base implementation for Providers
    /// </summary>
    public abstract class Provider : IProvider
    {
        #region Properties

        /// <summary>
        /// Specify whether the provider has been implemented
        /// </summary>
        public virtual bool Implemented => false;

        /// <summary>
        /// Name of the provider
        /// </summary>
        public virtual string Name => Regex.Replace(GetType().Name, "([A-Z])", " $1", RegexOptions.Compiled).Trim();

        #endregion
    }
}
