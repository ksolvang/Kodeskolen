using System;
using System.Collections.Generic;
using System.Text;

namespace Kodeskolen.Lambda
{
    public class LambdaSample
    {

        public static void Run()
        {
            List<string> list = new List<string> { "Hello", "let's", "try", "this" };

            //Func<T, bool>
            var newList = list.MyWhere(x => x.Contains('l'));

            //Action<T>
            newList.MyForEach(x => Console.WriteLine(x));
        }
    }
}
