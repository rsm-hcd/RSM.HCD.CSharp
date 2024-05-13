using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace RSM.HCD.CSharp.Core.Extensions
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
            if (string.IsNullOrWhiteSpace(key))
            {
                return default(T);
            }

            var result = cache.Get(key);
            if (result == null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(result.FromByteArray<string>());
        }

        /// <summary>
        /// Serialize data to be cached
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(this IDistributedCache cache, T value) => JsonConvert.SerializeObject(value);

        /// <summary>
        /// Serialize and cache supplied key/value pair
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static string Set<T>(
            this IDistributedCache cache,
            string key,
            T value,
            DistributedCacheEntryOptions options
        ) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            var serializedValue = cache.Serialize<T>(value);
            var data = serializedValue.ToByteArray();
            cache.Set(key, data, options);

            return serializedValue;
        }
    }
}
