using System;
using System.Diagnostics;
using Bogus;

namespace AndcultureCode.CSharp.Testing.Factories
{
    public abstract class Factory
    {
        #region Public Methods

        /// <summary>
        /// Define your factory
        /// </summary>
        public abstract void Define();

        /// <summary>
        /// Returns the current time in unix milliseconds.
        ///
        /// NOTE: Not guaranteed to be unique. If you require a unique value for a factory value,
        /// use `UniqueNumber` instead.
        /// </summary>
        /// <returns></returns>
        public long Milliseconds => DateTimeOffset.Now.ToUnixTimeMilliseconds();

        /// <summary>
        /// Returns a new `Randomizer` instance for generating random data as factory values.
        /// </summary>
        /// <returns></returns>
        public Randomizer Random => new Faker().Random;

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

        #endregion
    }
}