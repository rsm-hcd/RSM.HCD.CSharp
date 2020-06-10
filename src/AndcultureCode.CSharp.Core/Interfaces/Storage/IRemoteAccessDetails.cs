using AndcultureCode.CSharp.Core.Interfaces;

namespace AndcultureCode.CSharp.Core.Interfaces.Providers.Storage
{
    /// <summary>
    /// Access details to access a given storage resource
    /// </summary>
    public interface IRemoteAccessDetails
    {
        /// <summary>
        /// Url for accessing the given resource
        /// </summary>
        /// <value></value>
        string Url { get; set; }
    }
}