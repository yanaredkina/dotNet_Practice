using System;

namespace Task2
{
    #region Class Body3D
    public abstract class Body3D
    {
        public abstract int Area();
        public abstract int Volume();
        public abstract void Draw();
    }
    #endregion


    #region Class SidedBody3d
    public abstract class SidedBody3d: Body3D
    {
        public abstract int SidesLength();
    }
    #endregion


    #region Class Cuboid
    public class Cuboid : SidedBody3d
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public override int Area()
        {
            return 2 * (Width * Height + Height * Length + Width * Length);
        }
        public override int Volume()
        {
            return Width * Height * Length;
        }
        public override int SidesLength()
        {
            return 4 * (Width + Height + Length);
        }

        public override string ToString()
        {
            return "Фигура: Прямоугольный параллелепипед" +
                   "\nИзмерения (ДхШхВ): " + Length + "x" + Width + "x" + Height +
                   "\nПлощадь поверхности: " + this.Area() +
                   "\nОбъем: " + this.Volume() +
                   "\nСумма длин всех ребер: " + this.SidesLength() +
                   "\n";
        }

        public override void Draw()
        {
            Console.Write(
            "   * * * * * *\n" +
            " *         * *\n" +
            "* * * * * *  *\n" +
            "*         *  *\n" +
            "*         *  *\n" +
            "*         * * \n" +
            "* * * * * *  \n\n");
        }

    }
    #endregion


    #region Class Tetrahedron
    public class Tetrahedron : SidedBody3d
    {
        public int Side { get; set; }

        public override int Area()
        {
            return Convert.ToInt32(Math.Sqrt(3) * Math.Pow(Side, 2));
        }

        public override int Volume()
        {
            return Convert.ToInt32(Math.Sqrt(2) * Math.Pow(Side, 3) / 12);
        }
        public override int SidesLength()
        {
            return 6 * Side;
        }

        public override string ToString()
        {
            return "Фигура: Тетраэдр" +
                "\nИзмерения (длина ребра): " + Side +
                "\nПлощадь поверхности: " + this.Area() +
                "\nОбъем: " + this.Volume() +
                "\nСумма длин всех ребер: " + this.SidesLength() +
                "\n";
        }

        public override void Draw()
        {
            Console.Write(
                "     *      \n" +
                "    * *     \n" +
                "   * * *    \n" +
                "  *  *  *   \n" +
                " *   *   *  \n" +
                "*    *    * \n" +
                "  *  *  *   \n" +
                "     *      \n\n");
        }
    }
    #endregion


    #region Class Octahedron
    public class Octahedron : SidedBody3d
    {
        public int Side { get; set; }

        public override int Area()
        {
            return Convert.ToInt32(Math.Sqrt(3) * Math.Pow(Side, 2) * 2);
        }
        public override int Volume()
        {
            return Convert.ToInt32(Math.Sqrt(2) * Math.Pow(Side, 3) / 3);
        }
        public override int SidesLength()
        {
            return 12 * Side;
        }

        public override string ToString()
        {
            return "Фигура: Октаэдр" +
                "\nИзмерения (длина ребра): " + Side +
                "\nПлощадь поверхности: " + this.Area() +
                "\nОбъем: " + this.Volume() +
                "\nСумма длин всех ребер: " + this.SidesLength() +
                "\n";
        }

        public override void Draw()
        {
            Console.Write(
                "     *      \n" +
                "    * *     \n" +
                "   * * *    \n" +
                "  *  *  *   \n" +
                " *   *   *  \n" +
                "* *  *  * * \n" +
                " *   *   *  \n" +
                "  *  *  *   \n" +
                "   * * *    \n" +
                "    * *     \n" +
                "     *      \n\n");
        }
    }
    #endregion


    #region Class Sphere
    public class Sphere : Body3D
    {
        public int Radius { get; set; }

        public override int Area()
        {
            return Convert.ToInt32(4 * Math.PI * Math.Pow(Radius, 2));
        }
        public override int Volume()
        {
            return Convert.ToInt32(4 * Math.PI * Math.Pow(Radius, 3) / 3);
        }

        public override string ToString()
        {
            return "Фигура: Шар" +
                "\nИзмерения (радус): " + Radius +
                "\nПлощадь поверхности: " + this.Area() +
                "\nОбъем: " + this.Volume() +
                "\n";
        }

        public override void Draw()
        {
            Console.Write(
                "       *      \n" +
                "   *       *  \n" +
                "              \n" +
                " *           *\n" +
                "              \n" +
                "   *       *  \n" +
                "       *      \n\n");
        }
    }
    #endregion


    #region Class Cone
    public class Cone : Body3D
    {
        public int Radius { get; set; }
        public int Height { get; set; }

        public override int Area()
        {
            double t = Math.Sqrt(Math.Pow(Radius, 2) + Math.Pow(Height, 2));
            return Convert.ToInt32(Math.PI * Radius * (t + Radius));
        }
        public override int Volume()
        {
            return Convert.ToInt32(Math.PI * Math.Pow(Radius, 2) * Height / 3);
        }

        public override string ToString()
        {
            return "Фигура: Конус" +
                "\nИзмерения (радус основания х высота): " + Radius + "x" + Height +
                "\nПлощадь поверхности: " + this.Area() +
                "\nОбъем: " + this.Volume() +
                "\n";
        }

        public override void Draw()
        {
            Console.Write(
                "     *      \n" +
                "    * *     \n" +
                "   *   *    \n" +
                "  *     *   \n" +
                " *       *  \n" +
                "*         * \n" +
                "   * * *   \n\n");
        }
    }
    #endregion


    #region Class Cylinder
    public class Cylinder : Body3D
    {
        public int Radius { get; set; }
        public int Height { get; set; }

        public override int Area()
        {
            return Convert.ToInt32(2 * Math.PI * Radius * (Height + Radius));
        }
        public override int Volume()
        {
            return Convert.ToInt32(Math.PI * Math.Pow(Radius, 2) * Height);
        }

        public override string ToString()
        {
            return "Фигура: Цилиндр" +
                "\nИзмерения (радус основания х высота): " + Radius + "x" + Height +
                "\nПлощадь поверхности: " + this.Area() +
                "\nОбъем: " + this.Volume() +
                "\n";
        }

        public override void Draw()
        {
            Console.Write(
                "   * * *    \n" +
                "*         * \n" +
                "*  * * *  * \n" +
                "*         * \n" +
                "*         * \n" +
                "*         * \n" +
                "*         * \n" +
                "   * * *    \n\n");
        }
    }
    #endregion
}