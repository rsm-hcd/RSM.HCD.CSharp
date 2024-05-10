using System;
using System.Diagnostics;
using Bogus;

namespace RSM.HCD.CSharp.Testing.Factories
{
    /// <summary>
    /// Base factory class for building out entity configurations
    /// </summary>
    public abstract class Factory
    {
        #region Public Methods

        /// <summary>
        /// Define your factory
        /// </summary>
        public abstract void Define();

        #endregion Public Methods

        #region Public Properties

        /// <summary>
        /// Cached instance of 'Faker' to use for specific data generation functions not available
        /// from Randomizer (such as email addresses, ip addresses, names, etc.)
        /// </summary>
        public Faker Faker => _faker = _faker ?? new Faker();

        /// <summary>
        /// Returns the current time in unix milliseconds.
        ///
        /// NOTE: Not guaranteed to be unique. If you require a unique value for a factory value,
        /// use `UniqueNumber` instead.
        /// </summary>
        /// <returns></returns>
        public long Milliseconds => DateTimeOffset.Now.ToUnixTimeMilliseconds();

        /// <summary>
        /// Returns a cached `Randomizer` instance for generating random data as factory values.
        /// </summary>
        public Randomizer Random => Faker.Random;

        /// <summary>
        /// Returns a unique number for use in factory values.
        /// </summary>
        /// <value></value>
        public long UniqueNumber
        {
            get
            {
                long nano = 10000L * Stopwatch.GetTimestamp();
                nano /= TimeSpan.TicksPerMillisecond;
                nano *= 100L;
                return nano;
            }
        }

        #endregion Public Properties

        #region Private Properties

        private Faker _faker;

        #endregion Private Properties
    }
}
