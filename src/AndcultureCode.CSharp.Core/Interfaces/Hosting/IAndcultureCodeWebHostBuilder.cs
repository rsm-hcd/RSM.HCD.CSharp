using Microsoft.AspNetCore.Hosting;

namespace AndcultureCode.CSharp.Core.Interfaces.Hosting
{
    public interface IAndcultureCodeWebHostBuilder
    {
        #region Properties

        string[] Args { get; set; }

        #endregion Properties


        #region Methods

        /// <summary>
        /// Simple wrapper around AspNetCore WebHost.CreateDefaultBuilder
        /// to support our own extensibility model
        /// </summary>
        /// <returns></returns>
        IWebHostBuilder CreateDefaultBuilder();

        #endregion Methods
    }
}