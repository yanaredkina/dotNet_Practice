using System;
namespace Task1
{
    public class TestMatrixMultiplication
    {
        const double GIGA = 1000000000;
        const double MILLI = 1000;


        static public void Test2DMatrix(double [,] a, double[,] b, double[,] result)
        {
            int numberOperations = 2 * a.GetLength(0) * a.GetLength(1) * b.GetLength(1);

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            MultTwoMatrix.Mult2DMatrix(a, b, result);
            sw.Stop();

            long duration = sw.ElapsedMilliseconds;
            double numberPerSeconds = numberOperations / (duration / MILLI);

            Console.WriteLine("Время вычисления (прямоугольный массив): " + duration + " миллисекунд");
            Console.WriteLine("Производительность (прямоугольный массив): " + Math.Round(numberPerSeconds / GIGA, 2) + " ГФлопс") ;
            sw.Reset();
        }


        static public void TestJaggedMatrix(double[][] a, double[][] b, double[][] result)
        {
            int numberOperations = 2 * a.Length * a[0].Length * b[0].Length;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            MultTwoMatrix.MultJagged2DMatrix(a, b, result);
            sw.Stop();

            long duration = sw.ElapsedMilliseconds;
            double numberPerSeconds = numberOperations / (duration / MILLI);

            Console.WriteLine("Время вычисления (рваный массив): " + duration + " миллисекунд");
            Console.WriteLine("Производительность (рваный массив): " + Math.Round(numberPerSeconds / GIGA, 2) + " ГФлопс");
            sw.Reset();
        }
    }
}
