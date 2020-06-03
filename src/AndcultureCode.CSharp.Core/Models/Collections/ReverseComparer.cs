using System.Collections.Generic;

namespace AndcultureCode.CSharp.Core.Models.Collections
{
    public class ReverseComparer<TKey> : IComparer<TKey>
    {
        #region Private Properties

        private IComparer<TKey> comparer;

        #endregion Private Properties

        #region Constructors

        public ReverseComparer() : this(Comparer<TKey>.Default) { }

        public ReverseComparer(IComparer<TKey> comparer)
        {
            this.comparer = comparer;
        }

        #endregion Constructors

        #region IComparer<TKey> Members

        public int Compare(TKey x, TKey y) => comparer.Compare(y, x);

        #endregion IComparer<TKey> Members
    }
}
