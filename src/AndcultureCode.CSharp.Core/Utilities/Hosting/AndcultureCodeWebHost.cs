using AndcultureCode.CSharp.Core.Interfaces.Hosting;
using AndcultureCode.CSharp.Core.Models.Hosting;

namespace AndcultureCode.CSharp.Core.Utilities.Hosting
{
    public static class AndcultureCodeWebHost
    {
        /// <summary>
        /// Entry point to our custom WebHost builder pattern.
        /// From here extensions methods can but hung off of IAndcultureCodeWebHostBuilder
        /// </summary>
        /// <returns></returns>
        public static IAndcultureCodeWebHostBuilder Preload(string[] args) => new AndcultureCodeWebHostBuilder(args);
    }
}
