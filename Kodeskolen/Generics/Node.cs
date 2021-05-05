using System;
using System.Collections.Generic;


namespace Kodeskolen.Generics
{
    internal class Node 
    {
        public void SwapIfGreater<T>(ref T lhs, ref T rhs) where T : System.IComparable<T>
        {
            T temp;
            if (lhs.CompareTo(rhs) > 0)
            {
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        }
    }
}
