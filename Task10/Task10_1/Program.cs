using System;
using System.IO;
using System.Reflection;
using System.Numerics;

namespace Task10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string assemblyPath = Path.Combine(Environment.CurrentDirectory, "Task2.dll");
                if (File.Exists(assemblyPath))
                {
                    Assembly assembly = Assembly.LoadFrom(assemblyPath);
                    Type type = assembly.GetType("Task2.Complex");

                    // calculate via reflection : z = (x+y)^2 / 27 (without dynamic)
                    object x = Activator.CreateInstance(type, 2, 3)!;                       // x = 2 + 3i
                    MethodInfo mTrigComp = type.GetMethod("MakeTrigonometricComplex");
                    object y = mTrigComp.Invoke(null, new object[] { 14, Math.PI / 4 });    // y = 14(cos(pi/4) + i sin(pi/4))
                    object const27 = Activator.CreateInstance(type, 27, 0)!;                // 27

                    MethodInfo add = type.GetMethod("op_Addition");
                    MethodInfo mult = type.GetMethod("op_Multiply");
                    MethodInfo div = type.GetMethod("op_Division");

                    object z1 = add.Invoke(null, new object[] { x, y });        // (x + y)
                    object z2 = mult.Invoke(null, new object[] { z1, z1 });     // (x + y)^2
                    object z = div.Invoke(null, new object[] { z2, const27 });  // (x + y)^2 / 27

                    PropertyInfo module = type.GetProperty("Module");
                    PropertyInfo argument = type.GetProperty("Argument");
                    object modZ = module.GetValue(z);
                    object argZ = argument.GetValue(z);

                    Console.WriteLine("Computing result of z (without dynamic):");
                    Console.WriteLine($"z = {z}");
                    Console.WriteLine($"z = {modZ:0.0000}(cos({argZ:0.0000}) + isin({argZ:0.0000}))");
                    Console.WriteLine();


                    // calculate via reflection : c = (a^2+b^2)^2 / 3b (with dynamic)
                    dynamic a = Activator.CreateInstance(type, 4, 1)!;                      // a = 4 + i
                    dynamic b = mTrigComp.Invoke(null, new object[] { 2, Math.PI / 3 });    // b = 2(cos(pi/3) + i sin(pi/3))
                    dynamic const3 = Activator.CreateInstance(type, 3, 0)!;                 // 3
                    dynamic c = (a * a + b * b) * (a * a + b * b) / (const3 * b);

                    Console.WriteLine("Computing result of c (with dynamic):");
                    Console.WriteLine($"c = {c}");
                    Console.WriteLine($"c = {c.Module:0.0000}(cos({c.Argument:0.0000}) + isin({c.Argument:0.0000}))");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("В каталоге программы отсутствует сборка с комлексными числами");

                    // calculate d = 34 + e^f (using System.Numerics.Complex)
                    Complex e = new Complex(1, 2);                                  // e = 1 + 2i
                    Complex f = Complex.FromPolarCoordinates(3, Math.PI / 8);       // f = 3(cos(pi/8) + i sin(pi/8))
                    Complex d = 34 + Complex.Pow(e, f);                             

                    Console.WriteLine("Computing result of d:");
                    Console.WriteLine($"d = {d}");
                    Console.WriteLine($"d = {d.Magnitude:0.0000}(cos({d.Phase:0.0000}) + isin({d.Phase:0.0000}))");
                    Console.WriteLine();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
