using System.Collections.Generic;

namespace AndcultureCode.CSharp.Core.Models.Collections
{
    public class OrderedList<TKey, TValue> : IDictionary<TKey, ICollection<TValue>>, IEnumerable<TValue>
    {
        #region Private Properties

        private IDictionary<TKey, ICollection<TValue>> items;

        #endregion Private Properties

        #region Constructors

        public OrderedList()
        {
            items = new SortedDictionary<TKey, ICollection<TValue>>();
        }

        public OrderedList(IComparer<TKey> comparer)
        {
            items = new SortedDictionary<TKey, ICollection<TValue>>(comparer);
        }

        #endregion Constructors

        #region Public Methods

        public void Add(TKey key, TValue value)
        {
            ICollection<TValue> values;
            if (!items.TryGetValue(key, out values))
            {
                items.Add(key, values = new List<TValue>());
            }

            values.Add(value);
        }

        public void Remove(TKey key, TValue value)
        {
            if (EqualityComparer<TKey>.Default.Equals(key, default(TKey)))
            {
                foreach (var item in items)
                {
                    if (item.Value.Remove(value))
                    {
                        break;
                    }
                }

                return;
            }

            if (EqualityComparer<TValue>.Default.Equals(value, default(TValue)))
            {
                items.Remove(key);
                return;
            }

            ICollection<TValue> values;
            if (items.TryGetValue(key, out values))
            {
                values.Remove(value);
                if (values.Count == 0)
                {
                    items.Remove(key);
                }
            }

        }

        public IEnumerator<TValue> GetEnumerator()
        {
            foreach (KeyValuePair<TKey, ICollection<TValue>> values in items)
            {
                foreach (TValue value in values.Value)
                {
                    yield return value;
                }
            }
        }

        #region IDictionary<TKey,IEnumerable<TValue>> Members

        void IDictionary<TKey, ICollection<TValue>>.Add(TKey key, ICollection<TValue> value) => items.Add(key, value);

        public bool ContainsKey(TKey key) => items.ContainsKey(key);

        public ICollection<TKey> Keys { get => items.Keys; }

        bool IDictionary<TKey, ICollection<TValue>>.Remove(TKey key) => items.Remove(key);

        public bool TryGetValue(TKey key, out ICollection<TValue> value) => items.TryGetValue(key, out value);

        ICollection<ICollection<TValue>> IDictionary<TKey, ICollection<TValue>>.Values { get => items.Values; }

        public ICollection<TValue> this[TKey key]
        {
            get => items[key];
            set => items[key] = value;
        }

        #endregion IDictionary<TKey,IEnumerable<TValue>> Members

        #region ICollection<KeyValuePair<TKey,IEnumerable<TValue>>> Members

        void ICollection<KeyValuePair<TKey, ICollection<TValue>>>.Add(KeyValuePair<TKey, ICollection<TValue>> item) => items.Add(item);

        public void Clear() => items.Clear();

        bool ICollection<KeyValuePair<TKey, ICollection<TValue>>>.Contains(KeyValuePair<TKey, ICollection<TValue>> item) => items.Contains(item);

        void ICollection<KeyValuePair<TKey, ICollection<TValue>>>.CopyTo(KeyValuePair<TKey, ICollection<TValue>>[] array, int arrayIndex)
            => items.CopyTo(array, arrayIndex);

        public int Count { get => items.Count; }

        public bool IsReadOnly { get => items.IsReadOnly; }

        bool ICollection<KeyValuePair<TKey, ICollection<TValue>>>.Remove(KeyValuePair<TKey, ICollection<TValue>> item) => items.Remove(item);

        #endregion ICollection<KeyValuePair<TKey,IEnumerable<TValue>>> Members

        #region IEnumerable<KeyValuePair<TKey,IEnumerable<TValue>>> Members

        IEnumerator<KeyValuePair<TKey, ICollection<TValue>>> IEnumerable<KeyValuePair<TKey, ICollection<TValue>>>.GetEnumerator()
            => items.GetEnumerator();

        #endregion IEnumerable<KeyValuePair<TKey,IEnumerable<TValue>>> Members

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => items.GetEnumerator();

        #endregion IEnumerable Members

        #endregion Public Methods
    }
}
