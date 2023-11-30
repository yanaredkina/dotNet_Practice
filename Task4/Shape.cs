using System;
namespace Task4
{
    #region Class Shape
    public abstract class Shape
    {
        public virtual void Draw() 
        {
            Console.WriteLine("Shape");
        }
    }
    #endregion


    #region Class Triangle
    public class Triangle : Shape, IPoint, IDrawable
    {
        public override void Draw()
        {
            Console.WriteLine("Triangle");
        }

        public int Point
        {
            get { return 3; }
        }

    }

    #endregion


    #region Class Hexagon
    public class Hexagon : Shape, IPoint
    {
        public override void Draw()
        {
            Console.WriteLine("Hexagon");
        }

        public int Point
        {
            get { return 6; }
        }
    }

    #endregion


    #region Class Circle
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }
    }
    #endregion


    #region Class Sphere
    public class Sphere : Shape, IDrawable
    {
        public override void Draw()
        {
            Console.WriteLine("Base's Sphere");
        }

        void IDrawable.Draw()
        {
            Console.WriteLine("Interface's Sphere");
        }
    }
    #endregion
}