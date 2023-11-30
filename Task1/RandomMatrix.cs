using System;
namespace Task1
{
    public class RandomMatrix
    {
        static public double[,] Create2DMatrix(int rows, int cols)
        {
            double[,] result = new double[rows, cols];
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = rnd.NextDouble();
                }
            }

            return result;
        }

        static public double[][] CreateJagged2DMatrix(int rows, int cols)
        {
            double[][] result = new double[rows][];
            Random rnd = new Random();

            for (int r = 0; r < rows; r++)
            {
                result[r] = new double[cols];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i][j] = rnd.NextDouble();
                }
            }

            return result;
        }
    }
}
