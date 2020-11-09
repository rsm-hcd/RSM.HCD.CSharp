using System;
using Microsoft.Extensions.Caching.Distributed;

namespace AndcultureCode.CSharp.Core.Constants
{
    /// <summary>
    /// Common cache configuration options
    /// </summary>
    public static class CacheOptions
    {
        #region Properties

        /// <summary>
        /// Sliding cache expiration of a day (24 hours)
        /// </summary>
        public static DistributedCacheEntryOptions DAY = new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromDays(1) };

        #endregion Properties

        #region Methods

        /// <summary>
        /// Configure options for X minutes sliding scale expiration
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static DistributedCacheEntryOptions Minutes(double minutes)
            => new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(minutes) };

        #endregion Methods
    }
}
