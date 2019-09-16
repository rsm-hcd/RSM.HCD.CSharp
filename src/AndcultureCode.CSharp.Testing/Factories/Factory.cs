using System;
using System.Diagnostics;

namespace AndcultureCode.CSharp.Testing.Factories
{
    public abstract class Factory
    {
        #region Public Methods

        /// <summary>
        /// Define your factory
        /// </summary>
        public abstract void Define();

        public long Milliseconds => DateTimeOffset.Now.ToUnixTimeMilliseconds();

        public long UniqueNumber
        {
            get
            {
                long nano  = 10000L * Stopwatch.GetTimestamp();
                     nano /= TimeSpan.TicksPerMillisecond;
                     nano *= 100L;
                return nano;
            }
        }

        #endregion
    }
}