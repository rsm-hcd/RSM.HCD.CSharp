namespace RSM.HCD.CSharp.Core.Interfaces.Providers
{
    /// <summary>
    /// Foundation configuration for providers
    /// </summary>
    public interface IProvider
    {
        #region Properties

        /// <summary>
        /// Specify whether the provider has been implemented
        /// </summary>
        bool Implemented { get; }

        /// <summary>
        /// Name of the provider
        /// </summary>
        string Name { get; }

        #endregion Properties
    }
}
