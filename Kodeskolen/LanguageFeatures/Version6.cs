using System;
using System.Collections.Generic;
using System.Text;
//using static
using static System.Console;

namespace Kodeskolen.LanguageFeatures
{
    public class Version6
    {

        #region using static
        public void Test()
        {
            //using static
            WriteLine("Test");
        }
        #endregion

        #region auto property

        public Version6()
        {
            Name = "Kristian";
        }

        public string Name { get; set; } = "Kristian";
        public int Age { get; } = 34;

        #endregion

        #region dictionary init

        public void Test2()
        {
            Dictionary<string, string> dictOld = new Dictionary<string, string>()
            {
                { "Test", "test" },
                { "Test", "test" }
            };

            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                ["Test"] = "test",
                ["Test"] = "test"
            };
        }
        #endregion

        #region nameof and string interpolation

        public void Test4()
        {
            var test = "hello";
            WriteLine($"Variable {nameof(test)} contains {test}");
        }
        #endregion

        #region expression bodied methods
        public void Test5()
        {
            WriteLine("Hello!");
        }

        public void Test6() => WriteLine("Hello!");

        #endregion

        #region null-conditional operator
        public string Test7(A a)
        {
            //a.Test.Test = "Hello";
            WriteLine($"{a?.Test?.Test ?? "No data"}");

            if (Name == null)
            {
                return "Test";
            }
            else
            {
                return Name;
            }
        }

        public string Test8 => Name ?? "Test";
        #endregion

        #region Exception filters
        public void Test9()
        {
            int blah = 0;
            try
            {
                throw new Exception("Something failed!");
            }
            catch(Exception e) when (blah == 0)
            {
                WriteLine(e.Message);
            }
            catch (Exception)
            {
                WriteLine("other exceptions");
            }
        }
        #endregion

    }

    #region Test things
    public class A
    {
        public B Test { get; set; }
    }

    public class B
    {
        public string Test { get; set; }
    }

    #endregion
}
