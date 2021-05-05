using System;
using System.Collections.Generic;
using System.Text;

namespace Kodeskolen.LanguageFeatures
{
    public class Version7
    {
        #region Expression bodied members
        private string _test;
        public string Test { get => _test; set => _test = value ?? "TEST"; }

        public Version7(string test) => this.Test = test;
        ~Version7() => Console.WriteLine("Dying!");
        #endregion

        #region out variables
        public void Test1(string input, int i = 10, int j = 10)
        {
            if (int.TryParse(input, out int result))
                Console.WriteLine(result);
            else
                Console.WriteLine("Could not parse input");
        }
        #endregion

        #region discards

        public void Test2(string input)
        {
            if (int.TryParse(input, out _))
                Console.WriteLine("Dont need the result");
            
            else
                Console.WriteLine("Could not parse input");

        }

        #endregion

        #region Tuples

        private class MyClass
        {
            #region deconstruct
            public string X { get; } = "Hello";
            public string Y { get; } = "World";
            public void Deconstruct(out string x, out string y)
            {
                (x, y) = (X, Y);
            }
            #endregion
        }

        public void Test3()
        {
            //Old tuples:
            Tuple<string, string> t = new Tuple<string, string>("Hello", "World");
            Console.WriteLine($"{t.Item1} {t.Item2}");

            //new tuples
            (string A, string B) t2 = ("Hello", "World");
            Console.WriteLine($"{t2.A} {t2.B}");

            //or
            var t3 = (A: "a", B: 0b1000_1000);
            Console.WriteLine($"{t3.A} {t3.B}");

            //discard and deconstruction
            var ( first, _) = t3;
            Console.WriteLine(first);

            var myclass = new MyClass();
            (string hello, string world) = myclass;

            Console.WriteLine($"{hello} {world}");

            int test = 1;
            string blah = "#";
            var tuple = (test, blah);
            Console.WriteLine(tuple.test + tuple.blah);
        }

        #endregion

        #region Pattern matching

        public void Test4()
        {
            var i = 1;
            if (i is int)
            {
                Console.WriteLine("Yup is int!");
            }

            var sum = 0;
            if (i is int count)
                sum += count;
        }

        public int Test5(IEnumerable<object> hopefullyNumbers)
        {
            int sum = 0;

            foreach (var i in hopefullyNumbers)
            {
                switch(i)
                {
                    case 0: 
                        break;
                    case IEnumerable<int> children:
                    {
                        foreach (var j in children)
                            sum += j;
                        break;
                    }
                    case int n when n > 5:
                        sum += n;
                        break;

                    case null:
                        break;
                    default:
                        break;  
                }
            }
            return sum;
        }

        #endregion

        #region Local functions
        public void Test7()
        {
            var s = "Hello" + localFunction();
            Console.WriteLine(s);

            string localFunction() => " world";
        }
        #endregion

        #region Throw expressions
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
        }
        
        #endregion






    }
}
