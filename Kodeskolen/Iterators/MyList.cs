using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kodeskolen.Iterators
{
    class MyList<T> : IEnumerable<T>
    {
        private readonly List<T> _items = new List<T>();
        public MyList() 
        {
            UpperLimit = 3;
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            return Collection().GetEnumerator();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public int UpperLimit { get; private set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> Collection()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if ((i + 1) > UpperLimit) 
                    yield break;
                else
                    yield return (_items[i]);
            }
        }
    }
}
