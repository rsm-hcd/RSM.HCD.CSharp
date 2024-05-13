using System.Collections.Generic;
using System.Linq;
using RSM.HCD.CSharp.Core.Models.Security;

namespace RSM.HCD.CSharp.Core.Extensions
{
    /// <summary>
    /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/37
    /// </summary>
    public static class ResourceVerbExtensions
    {
        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/37
        /// </summary>
        /// <param name="resourceVerbString"></param>
        /// <returns></returns>
        public static ResourceVerb ToResourceVerb(this string resourceVerbString)
            => new ResourceVerb(resourceVerbString);

        /// <summary>
        /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/37
        /// </summary>
        /// <param name="resourceVerbStrings"></param>
        /// <returns></returns>
        public static List<ResourceVerb> ToResourceVerbs(this IEnumerable<string> resourceVerbStrings)
            => resourceVerbStrings?.Select(rv => rv.ToResourceVerb()).ToList();
    }
}
