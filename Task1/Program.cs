using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // ВВОД ПАРАМЕТРОВ - РАЗМЕРЫ 2-Х МАТРИЦ

            Console.WriteLine("Введите размеры матрицы A (nxm):");
            int n = Int32.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("Ошибка! Введено отрицательное значение");
                return;
            }

            int m = Int32.Parse(Console.ReadLine());
            if (m <= 0)
            {
                Console.WriteLine("Ошибка! Введено отрицательное значение");
                return;
            }


            Console.WriteLine("Введите размеры матрицы B (kxl):");
            int k = Int32.Parse(Console.ReadLine());

            if (k <= 0)
            {
                Console.WriteLine("Ошибка! Введено отрицательное значение");
                return;
            }


            if (k != m)
            {
                Console.WriteLine("Ошибка! Число строк матрицы В должно совпадать с числом столбцов матрицы А");
                return;
            }

            int l = Int32.Parse(Console.ReadLine());
            if (l <= 0)
            {
                Console.WriteLine("Ошибка! Введено отрицательное значение");
                return;
            }


            // СОЗДАНИЕ МАТРИЦ: 2D ARRAY

            double[,] a1 = RandomMatrix.Create2DMatrix(n, m);
            double[,] b1 = RandomMatrix.Create2DMatrix(k, l);
            double[,] result1 = new double[n, l];


            // СОЗДАНИЕ МАТРИЦ: JAGGED ARRAY

            double[][] a2 = RandomMatrix.CreateJagged2DMatrix(n, m);
            double[][] b2 = RandomMatrix.CreateJagged2DMatrix(k, l);
            double[][] result2 = new double[n][];

            for (int i = 0; i < n; i++)
            {
                result2[i] = new double[l];
            }


            // ТЕСТИРОВАНИЕ

            // 1 эксперимент с прямоугольными матрицами
            TestMatrixMultiplication.Test2DMatrix(a1, b1, result1);


            // 2 эксперимент с рваными матрицами
            TestMatrixMultiplication.TestJaggedMatrix(a2, b2, result2);

            // РЕЗУЛЬТАТ: производительность операции умножения рваных матриц выше, чем умножения прямоугольных матриц
        }
    }
}
