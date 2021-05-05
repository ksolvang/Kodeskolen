using Kodeskolen.Delegates;
using Kodeskolen.Generics;
using Kodeskolen.Iterators;
using Kodeskolen.Lambda;
using Kodeskolen.LanguageFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Kodeskolen
{
    class Program
    {
        static void Main(string[] args)
        {
            //var version8 = new Version8();

            //version8.Test7();

            var a = new Version8.Address
            {
                Country = "Norway"
            };

            var b = new Version8.Address
            {
                Country = "Italy"
            };

            var test = Version8.ComputeSalesTax(b, 100);
            Console.WriteLine(test);
            //LambdaSample.Run();

            //TestEnum testEnum = TestEnum.Hello;
            //Console.WriteLine(testEnum.ToString());


            //var delegateSample = new DelegateSample();

            //delegateSample.Run4();

            //Console.WriteLine("Run2:");
            //delegateSample.Run2();

            //Console.WriteLine("Run3:");
            //delegateSample.Run3();

            //Console.WriteLine("Run4:");
            //delegateSample.Run4();

            //var p = new Program();
            //var list = new MyOtherList<int>();
            //var list2 = new MyOtherList<int>();

            //list.Add(1);
            //list2.Add(2);

            //var node = new Node();
            //node.SwapIfGreater(ref list, ref list2);

            //for (int i = 0; i < new List<string>().Count; i++)
            //{
            //}

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}


        }
    }
}
