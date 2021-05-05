using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Kodeskolen.Iterators
{
    class MyOtherList<T> : IEnumerable<T>, IComparable<MyOtherList<T>>
    {
        private readonly List<T> _items = new List<T>();
        public MyOtherList()
        {
            UpperLimit = 3;
        }

        public IEnumerator<T> GetEnumerator()
        {
            try
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    try
                    {
                        if ((i + 1) > UpperLimit)
                            yield break;
                        else
                            yield return (_items[i]);
                    }
                    finally
                    {
                        Console.WriteLine("When does this get called2?");
                    }

                }
            }
            finally
            {
                Console.WriteLine("When does this get called?");
            }
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

        public int CompareTo(MyOtherList<T> other)
        {
            throw new NotImplementedException();
        }
    }
}
