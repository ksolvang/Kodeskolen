using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodeskolen.Delegates
{
    public delegate void MyDelegate(string str);
    public delegate void MyDelegateInt(int i);

    class DelegateSample
    {
        public void DelegateMethod1(string str)
        {
            Console.WriteLine($"{nameof(DelegateMethod1)}: {str}");
        }
        public void DelegateMethod2(string str)
        {
            Console.WriteLine($"{nameof(DelegateMethod2)}: {str}");
        }

        public void DelegateMethod3(int i)
        {
            Console.WriteLine($"{nameof(DelegateMethod3)}: {i}");
        }

        public static void MethodWithCallback(MyDelegate callback)
        {
            callback("Using the delegate from another method");
        }

        public void Run()
        {
            MyDelegate handler = DelegateMethod1;

            handler("Calling the delegate");
            MethodWithCallback(handler);
        }

        #region Run2
        public void Run2()
        {
            MyDelegate handler = DelegateMethod2;
            handler += DelegateMethod1;

            handler += DelegateMethod2;

            handler("Hello world!");
        }
        #endregion

        #region Run3
        public void Run3()
        {
            //C# 1.0:
            MyDelegate del1 = new MyDelegate(DelegateMethod1);

            //C# 2.0:
            MyDelegate del2 = delegate (string str)
            {
                Console.WriteLine($"Anonymous method: {str}");
            };

            //C# 3.0
            MyDelegate del3 = str => { Console.WriteLine($"Anonymous lambda method: {str}"); };


            MethodWithCallback(del2);
        }

        #endregion

        #region Run4
        public void Run4()
        {
            //C# 1.0:
            MyDelegate del = new MyDelegate(DelegateMethod1);

            //C# 2.0:
            del += delegate (string str)
            {
                Console.WriteLine($"Anonymous method: {str}");
            };

            //C# 3.0
            del += str => { Console.WriteLine($"Anonymous lambda method: {str}"); };

            var list = new List<string>();
            list.Where(f => f == "test");

            MethodWithCallback(del);
        }
        #endregion
    }
}
