using System;

namespace NullableReferencetypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int? i = null;

            Test? test = new Test("test");
            if (test == null)
            {
                Console.WriteLine("Hello World!");
            }
            
        }
    }
}
