using System;
using static System.Math;

namespace Task9
{
    public class InverseFunction
    {
        public event EventHandler<ProgressEventArgs>? Progress;

        enum Monotone
        {
            INCREASING,
            DECREASING
        }

        // it's assumed by task that function f is monotone
        public double Find(double a, double b, Func<double, double> f,  double y, double eps)
        {
            // checking input interval [a, b]
            if (a >= b)
            {
                throw new ArgumentException("Error: incorrect interval, must be [a, b]");
            }

            // checking input eps
            if (eps <= 0)
            {
                throw new ArgumentException("Error: incorrect precision value, must be eps > 0");

            }

            // checking whether the target value lies on the boundaries (a or b)
            double precision;
            if ((precision = Abs(y - f(a))) < eps)
            {
                Progress?.Invoke(this, new ProgressEventArgs (precision));
                return a;
            }

            if ((precision = Abs(y - f(b))) < eps)
            {
                Progress?.Invoke(this, new ProgressEventArgs(precision));
                return b;
            }

            // determination of the monotone type of the function
            Monotone monotone = (f(a) < f(b)) ? Monotone.INCREASING : Monotone.DECREASING;

            // checking if 'y' lies within the boundaries
            if (monotone == Monotone.INCREASING && (y < f(a) || y > f(b)))
            {
                throw new ArgumentException("Error: incorrect y value, must be f(a) <= y <= f(b)");
            }

            if (monotone == Monotone.DECREASING && (y > f(a) || y < f(b)))
            {
                throw new ArgumentException("Error: incorrect y value, must be f(b) <= y <= f(a)");
            }

            // start calculation
            double leftBound = a;
            double rightBound = b;
            double x = (leftBound + rightBound) / 2;

            while ((precision = Abs(y - f(x))) > eps)
            {
                Progress?.Invoke(this, new ProgressEventArgs(precision)); // intermediate precision
                if (monotone == Monotone.INCREASING)
                {
                    if (f(x) > y)
                    {
                        rightBound = x;
                    }
                    else
                    {
                        leftBound = x;
                    }

                }
                else // (monotone == Monotone.DECREASING)
                {
                    if (f(x) > y)
                    {
                        leftBound = x;
                    }
                    else
                    {
                        rightBound = x;
                    }
                }

                x = (leftBound + rightBound) / 2;
            }

            Progress?.Invoke(this, new ProgressEventArgs(precision)); // final precision
            return x;
        }
    }
}
