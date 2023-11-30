using System;
namespace Task9
{
    public class ProgressEventArgs: EventArgs
    {
        public double Precision { get; }

        public ProgressEventArgs(double value)
        {
            Precision = value;
        }
    }
}
