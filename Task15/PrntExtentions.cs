using System;
using System.Collections.Generic;

namespace Task15
{
    static class PrntExtentions
    {
        public static void PrintCollection<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintInt(this int number)
        {
            Console.WriteLine(number);
        }
    }


}
