using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TESTING COMPLEX CLASS

            Complex z1 = new Complex() {Re = 1, Im = -1};
            Complex z2 = new Complex(-2, 2);
            Complex z3 = new Complex(3);
            Complex z4 = Complex.MakeTrigonometricComplex(1, Math.PI / 2);

            Console.WriteLine("Созданные объекты (просмотр через toString):");
            Console.WriteLine($"z1 = {z1}");
            Console.WriteLine($"z2 = {z2}");
            Console.WriteLine($"z3 = {z3}");
            Console.WriteLine($"z4 = {z4}\n");

            Console.WriteLine("Просмотр полей через свойства-аксессоры:");
            Console.WriteLine("Re(z1) = {0:F2}  Im(z1) = {1:F2}", z1.Re, z1.Im);
            Console.WriteLine("Re(z2) = {0:F2}  Im(z2) = {1:F2}", z2.Re, z2.Im);
            Console.WriteLine("Re(z3) = {0:F2}  Im(z3) = {1:F2}", z3.Re, z3.Im);
            Console.WriteLine("Re(z4) = {0:F2}  Im(z4) = {1:F2}\n", z4.Re, z4.Im);

            Console.WriteLine("Вычислимые свойства (Модуль и Аргумент):");
            Console.WriteLine("|z1| = {0:F2}  Arg(z1) = {1:F2}", z1.Module, z1.Argument);
            Console.WriteLine("|z2| = {0:F2}  Arg(z2) = {1:F2}", z2.Module, z2.Argument);
            Console.WriteLine("|z3| = {0:F2}  Arg(z3) = {1:F2}", z3.Module, z3.Argument);
            Console.WriteLine("|z4| = {0:F2}  Arg(z4) = {1:F2}\n", z4.Module, z4.Argument);

            Console.WriteLine("Проверка арифметических операций:");
            Console.WriteLine($"z1 + z2 = {z1 + z2}");
            Console.WriteLine($"z1 * z2 = {z1 * z2}");
            Console.WriteLine($"z3 - z4 = {z3 - z4}");
            Console.WriteLine($"z2 / z4 = {z2 / z4}");
            Complex z = null;
            Console.WriteLine($"null + z3 = {z + z3} (null)\n");

            Console.WriteLine("Проверка привидения типов: \n");
            Console.WriteLine("Неявное приведение Double к Complex: Complex z5 = 3.45");
            Complex z5 = 3.45;
            Console.WriteLine("z5 = {0}  z5.GetType() = {1}\n", z5, z5.GetType());

            Console.WriteLine("Явное приведение Complex к Double");
            double d = (double)z2;
            Console.WriteLine("double d = (double)z2: d = {0}  d.GetType() = {1}\n", d, d.GetType());
            d = (double)z;
            Console.WriteLine("double d = (double)null: d = {0}  d.GetType() = {1}\n", d, d.GetType());

            Console.WriteLine("Проверка эквивалентности объектов (метод Equals):");
            Console.WriteLine($"z1.Equals(null) --> {z1.Equals(null)}");
            Console.WriteLine($"z1.Equals(100) --> {z1.Equals(100)}");
            Console.WriteLine($"z1.Equals(z2) --> {z1.Equals(z2)}");
            Console.WriteLine($"z1.Equals(new Complex(1, -1))) --> {z1.Equals(new Complex(1, -1))}\n");
            
            Console.WriteLine("Проверка эквивалентности объектов (операторы сравнения):");
            Console.WriteLine($"z2 == null --> {z2 == null}");
            Console.WriteLine($"null == z2 --> {null == z2}");
            Console.WriteLine($"z2 == 50 --> {z2 == 50}");
            Console.WriteLine($"z3 == z2 --> {z3 == z2}");
            Console.WriteLine($"z2 == new Complex(-2, 2) --> {z2 == new Complex(-2, 2)}");
            Console.WriteLine($"z4 != null --> {z4 != null}");
            Console.WriteLine($"z3 != z2 --> {z3 != z2}");
            Console.WriteLine($"z3 != new Complex(3) --> {z3 != new Complex(3)}\n");
            #endregion



            #region TESTING BODY3D CLASS

            Body3D[] figures =
            {
                new Cuboid() { Width = 1, Height = 1, Length = 1 },
                new Tetrahedron() { Side = 3 },
                new Octahedron() { Side = 3 },
                new Sphere() { Radius = 1 },
                new Cone() { Radius = 1, Height = 2 },
                new Cylinder() { Radius = 1, Height = 2 }
            };

            for (int i = 0; i < figures.Length; i++)
            {
                Console.WriteLine(figures[i]);
                figures[i].Draw();
            }
            #endregion
        }
    }
}
