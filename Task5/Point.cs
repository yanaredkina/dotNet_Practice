using System;
namespace Task5
{
    public class Point2D : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2D(): this(0, 0) 
        {
        }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        object ICloneable.Clone()
        {
            return new Point2D(this.X, this.Y);
        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
    }
}
