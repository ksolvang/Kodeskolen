using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kodeskolen.LanguageFeatures
{

    #region default interface methods
    public interface IVersion8
    {
        public string Test();

        public string Test2() => "This works now?";
    }

    #endregion
    public class Version8 : IVersion8
    {
        #region default interface methods
        public string Test()
        {
            
            return ((IVersion8)this).Test2();
        }
        #endregion
        
        #region new form of using
        public void Test10()
        {
            //old
            using (var file = new System.IO.StreamWriter("filepath.txt"))
            {
            } //<-- file out of scope

            //new
            using var file2 = new System.IO.StreamWriter("filepath.txt");

            

        } // <-- file2 out of scope

        #endregion

        #region static inner functions
        public void Test3()
        {
            var b = "...";
            var a = innerFunction();
            var c = innerStaticFunction();


            string innerFunction() => "Hello world" + b;
            static string innerStaticFunction() => "Hello world";
        }

        #endregion

        #region async streams
        public async IAsyncEnumerable<int> Test4()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(200); // pretend we are doing something here
                yield return i;
            }
        }

        public async void Test5()
        {
            await foreach(var n in Test4())
            {
                Console.WriteLine(n);
            }

            //also mention async dispose
            //await using
        }

        #endregion

        #region null-coalescing assingment
        public void Test6()
        {
            List<List<string>> lists = new List<List<string>>();

            var list = lists.FirstOrDefault();
            list ??= new List<string>();
            list.Add("Hello");
        }
        #endregion

        #region indicies and ranges
        public void Test7()
        {
            var numbers = new int[]
            {
                1, // index 0, index from end ^6
                2, // index 1, index from end ^5
                3, // index 2, index from end ^4
                4, // index 3, index from end ^3
                5, // index 4, index from end ^2
                6  // index 5, index from end ^1
            };

            Console.WriteLine($"{numbers[0]}"); //prints 1;
            Console.WriteLine($"{numbers[^1]}"); //prints 6;

            var range = numbers[1..4];
            var theEnd = numbers[^2..^0];
            var everything = numbers[..];
            var first = numbers[..4]; //not inclusive 4
            var end = numbers[4..]; //inclusive 4

            Range num = 1..4;

            var n = numbers[num];

            //works on arrays, string, span<t>/readonlyspan<t>
        }
        #endregion

        #region Pattern matching
        #region switch
        public enum Cars
        {
            Volvo,
            Ford,
            Audi
        }
        public string Test8(Cars car)
        {
            switch (car)
            {
                case Cars.Volvo:
                    return "V40";
                case Cars.Ford:
                    return "Focus";
                case Cars.Audi:
                    return "A4";
                default:
                    return string.Empty;
            }
            
        }

        public string Test9(Cars car) => 
            car switch
        {
            Cars.Volvo => "V40",
            Cars.Ford => "Focus",
            Cars.Audi => "A4",
            _ => string.Empty
        };
        #endregion

        #region property patterns
        public class Document
        {
            public int Id { get; set; }
            public string ArchiveSystem { get; set; }
        }

        public bool Archive(Document doc) =>
            doc switch
            {
                { ArchiveSystem: "HINT" } => SendToHint(doc),
                { ArchiveSystem: "SIF"} => SendToSif(doc),
                _ => throw new NotImplementedException(),
            };

        private bool SendToHint(Document doc) => true;
        private bool SendToSif(Document doc) => true;

        #endregion

        #region positional patterns / tuple patterns
        public class Address
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }

            public void Deconstruct(out string country, out string city, out string street)
            {
                (country, city, street) = (Country, City, Street);
            }
        }

        public static decimal ComputeSalesTax(Address address, decimal price) =>
            address switch
            {
                var (country, _, _) when country == "Norway" => price * 0.25M,
                var (country, _, _) when country == "Italy" => price * 0.22M,
                _ => 0.0M
            };
        #endregion
        #endregion

        #region nullable reference types


        #endregion
    }
}
