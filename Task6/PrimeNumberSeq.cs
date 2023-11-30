using System;
using System.Collections.Generic;

namespace Task6
{
    public class PrimeNumberSeq
    {
        public static IEnumerable<int> GetSequence()
        {
            while(true)
            {
                for (int i = 1; i < int.MaxValue; i++)
                {
                    if (IsPrime(i))
                    {
                        yield return i;
                    }
                }
            }
        }

        private static bool IsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }

            for (int i = 2; i <= (int)Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
