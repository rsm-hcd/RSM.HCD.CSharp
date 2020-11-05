using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace AndcultureCode.CSharp.Core.Extensions
{
    /// <summary>
    /// Extensions of IDistributedCache
    /// </summary>
    public static class IDistributedCacheExtensions
    {
        /// <summary>
        /// Retrieve cached value as a desired type.
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        public static T Get<T>(this IDistributedCache cache, string key) where T : class
        {
            var result = cache.Get(key);
            if (result == null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(result.FromByteArray<string>());
        }

        /// <summary>
        /// Serialize and cache supplied key/value pair
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void Set<T>(
            this IDistributedCache cache,
            string key,
            T value,
            DistributedCacheEntryOptions options
        ) where T : class
        {
            var data = JsonConvert.SerializeObject(value).ToByteArray();
            cache.Set(key, data, options);
        }
    }
}
