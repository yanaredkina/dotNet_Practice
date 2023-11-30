using System;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inverseFunc = new InverseFunction();
                inverseFunc.Progress += (sender, e) => Console.WriteLine($"Current precision: {e.Precision:0.000000}");

                Console.WriteLine("TASK: find x in 0.5 = sin(x) на отрезке [0.1, 1.3] с точностью 0,0001");
                Console.WriteLine("START CALCULATING...");
                double x1 = inverseFunc.Find(0.1, 1.3, Math.Sin, 0.5, 0.0001);
                Console.WriteLine("ANSWER: calculated x = {0}\n", x1);

                Console.WriteLine("TASK: find x in 8 = x^2 + sin(x-2) на отрезке [2.5, 3.5] с точностью 0,0001");
                Console.WriteLine("START CALCULATING...");
                double x2 = inverseFunc.Find(2.5, 3.5, x => x * x + Math.Sin(x - 2), 8, 0.0001);
                Console.WriteLine("ANSWER: calculated x = {0}\n", x2);

                Console.WriteLine("TASK: find x in 0.9 = 1 / x на отрезке [1, 3] с точностью 0,00001");
                Console.WriteLine("START CALCULATING...");
                double x3 = inverseFunc.Find(1, 3, x => 1 / x, 0.9, 0.00001);
                Console.WriteLine("ANSWER: calculated x = {0}\n", x3);
            }

            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
