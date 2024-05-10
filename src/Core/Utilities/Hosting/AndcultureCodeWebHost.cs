using RSM.HCD.CSharp.Core.Interfaces.Hosting;
using RSM.HCD.CSharp.Core.Models.Hosting;
using Microsoft.AspNetCore;

namespace RSM.HCD.CSharp.Core.Utilities.Hosting
{
    /// <summary>
    /// Static class related to our custom <see cref="WebHost"/> builder pattern
    /// </summary>
    public static class RSMWebHost
    {
        /// <summary>
        /// Entry point to our custom WebHost builder pattern.
        /// From here extensions methods can but hung off of IRSMWebHostBuilder
        /// </summary>
        /// <returns></returns>
        public static IRSMWebHostBuilder Preload(string[] args) => new RSMWebHostBuilder(args);
    }
}
