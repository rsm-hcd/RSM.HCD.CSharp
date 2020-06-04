using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Core.Models.Security;

namespace AndcultureCode.CSharp.Core.Extensions
{
    public static class ResourceVerbExtensions
    {
        public static ResourceVerb ToResourceVerb(this string resourceVerbString)
            => new ResourceVerb(resourceVerbString);

        public static List<ResourceVerb> ToResourceVerbs(this IEnumerable<string> resourceVerbStrings)
            => resourceVerbStrings?.Select(rv => rv.ToResourceVerb()).ToList();
    }
}
