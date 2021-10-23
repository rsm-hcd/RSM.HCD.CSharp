using System;
using System.Collections.Generic;

namespace AndcultureCode.CSharp.Extensions.Models
{
    /// <summary>
    /// Generic comparator class for ease of use with comparison functions
    /// </summary>
    public class LambdaComparer<T> : IEqualityComparer<T>
    {
        #region Private Members

        private readonly Func<T, T, bool> _predicate;

        #endregion Private Members

        #region Constructor

        /// <summary>
        /// Constructor for new comparator based on predicate
        /// </summary>
        /// <param name="predicate">Predicate to be used for equality comparison</param>
        public LambdaComparer(Func<T, T, bool> predicate)
        {
            _predicate = predicate;
        }

        #endregion Constructor

        #region Public Methods

        /// <inheritdoc />
        public bool Equals(T x, T y) => _predicate(x, y);

        /// <inheritdoc />
        public int GetHashCode(T obj) => 0; // Returning the same hash will force Equals() evaluation

        #endregion Public Methods
    }
}
