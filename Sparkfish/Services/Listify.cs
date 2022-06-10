using System.Collections;

namespace Sparkfish.Services
{
    /// <summary>
    /// "Implement an IList that makes random access to a just-in-time return of the value.."
    /// </summary>
    public class Listify : IListify
    {
        private IEnumerable<int> items;
        public Listify()
        {
            items = Enumerable.Empty<int>();
        }

        /// <summary>
        /// Initialize Enumerable when instantiating this class.
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        public Listify(int begin = 1, int end = 100)
        {
            items = Enumerable.Range(begin, (end - begin) + 1);
        }

        /// <summary>
        /// Initialize Enumerable after this class has been instantiated.
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Listify Create(int begin, int end)
        {
            if (items != null)
                items = null;

            items = Enumerable.Range(begin, (end - begin) + 1);
            return this;
        }

        /// <summary>
        /// "Just-in-time access"
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int this[int index]
        {
            get
            {
                return items.ElementAt(index);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #region Not Implemented

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(int item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(int item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(int item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, int item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
