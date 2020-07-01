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

        #endregion Public Methods

        #region Public Properties

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
        /// <returns></returns>
        public Randomizer Random => _Random = _Random ?? new Randomizer();

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

        private Randomizer _Random;

        #endregion Private Properties
    }
}