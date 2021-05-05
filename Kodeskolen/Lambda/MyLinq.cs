using System;
using System.Collections.Generic;

namespace Kodeskolen.Lambda
{
    static class MyLinq
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> data, Func<T, bool> predicate)
        {
            foreach (T value in data)
            {
                if (predicate(value)) yield return value;
            }
        }

        public static void MyForEach<T>(this IEnumerable<T> data, Action<T> action)
        {
            foreach(T value in data)
            {
                action(value);
            }
        }

        public static string EnumName(this Enum e)
        {
            return Enum.GetName(e.GetType(), e);
        }
    }

    enum TestEnum
    {
        Hello
    }
}
