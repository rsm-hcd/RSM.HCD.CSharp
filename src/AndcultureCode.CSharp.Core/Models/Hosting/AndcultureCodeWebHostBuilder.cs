using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using AndcultureCode.CSharp.Core.Interfaces.Hosting;

namespace AndcultureCode.CSharp.Core.Models.Hosting
{
    public class AndcultureCodeWebHostBuilder : IAndcultureCodeWebHostBuilder
    {
        #region Properties

        public string[] Args { get; set; }

        #endregion Properties


        #region Constructors

        public AndcultureCodeWebHostBuilder() {}
        public AndcultureCodeWebHostBuilder(string[] args)
        {
            Args = args;
        }

        #endregion Constructors


        #region Public Methods

        public IWebHostBuilder CreateDefaultBuilder() => WebHost.CreateDefaultBuilder(Args);

        #endregion Public Methods
    }
}