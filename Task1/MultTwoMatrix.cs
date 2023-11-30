using System;
namespace Task1
{
    public class MultTwoMatrix
    {
        static public void Mult2DMatrix(double[,] a, double[,] b, double[,] result)
        {
            int rows = a.GetLength(0);
            int cols = b.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }

                }

            }
        }

        static public void MultJagged2DMatrix(double[][] a, double[][] b, double[][] result)
        {
            int rows = a.Length;
            int cols = b[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < a[0].Length; k++)
                    {
                        result[i][j] += a[i][k] * b[k][j];
                    }

                }

            }
        }
    }
}
