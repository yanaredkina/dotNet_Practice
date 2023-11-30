using System;
using System.IO;
using System.Reflection;
using System.Numerics;

namespace Task10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string assemblyPath = Path.Combine(Environment.CurrentDirectory, "Task9.dll");

                if (File.Exists(assemblyPath))
                {
                    PrintAssemblies();
                    Assembly assembly = Assembly.LoadFrom(assemblyPath);

                    // static method without dynamic
                    AssemblyCall(assembly);
                    Console.WriteLine();

                    // non-static method using dynamic
                    Program pr = new Program();
                    pr.AssemblyCallwithDynamic(assembly);
                    Console.WriteLine();

                    PrintAssemblies();
                }
                else
                {
                    Console.WriteLine("В каталоге программы отсутствует сборка с поиском обратной функции");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public static void PrintAssemblies()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Console.WriteLine($"Кол-во загруженных сборок = {assemblies.Length}:");
            for (int i = 0; i < assemblies.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {assemblies[i].FullName}");
            }
            Console.WriteLine();
        }


        public static void AssemblyCall(Assembly assembly)
        {
            Console.WriteLine("Start calculation via reflection without dynamic...");
            Type type = assembly.GetType("Task9.InverseFunction");
            object invFunc = Activator.CreateInstance(type)!;

            // Here make subscribtion to event (instead this: myVar.myEvent += new Delegate(MyHandler) )
            EventInfo ei = type.GetEvent("Progress");
            Type eventType = ei.EventHandlerType;
            var obj = new ReflectionProgressEventArgs() { AssemblyProp = assembly };
            MethodInfo miHandler = obj.GetType().GetMethod("Handler");
            Delegate d = Delegate.CreateDelegate(eventType, obj, miHandler);
            ei.AddEventHandler(invFunc, d);

            // call for class method
            MethodInfo find = type.GetMethod("Find");
            Delegate del = Delegate.CreateDelegate(typeof(Func<double, double>), typeof(Math).GetMethod("Sin"));
            object res = find.Invoke(invFunc, new object[] { 0.1, 1.3, del, 0.5, 0.0001 });
            Console.WriteLine($"Computing result for inverse function: {res}");
        }


        public void AssemblyCallwithDynamic(Assembly assembly)
        {
            Console.WriteLine("Start calculation via reflection with dynamic...");
            Type type = assembly.GetType("Task9.InverseFunction");
            dynamic invFunc = Activator.CreateInstance(type)!;

            // Here make subscribtion to event
            Type eventType = type.GetEvent("Progress").EventHandlerType;
            var obj = new ReflectionProgressEventArgs() { AssemblyProp = assembly };
            MethodInfo miHandler = obj.GetType().GetMethod("Handler");
            dynamic d = Delegate.CreateDelegate(eventType, obj, miHandler);
            invFunc.Progress += d;

            // call for class method
            dynamic del = Delegate.CreateDelegate(typeof(Func<double, double>), typeof(Math).GetMethod("Sin"));
            dynamic res = invFunc.Find(0.1, 1.3, del, 0.5, 0.0001);
            Console.WriteLine($"Computing result for inverse function: {res}");
        }


        public class ReflectionProgressEventArgs
        {
            public Assembly AssemblyProp { get; set; }

            public void Handler(Object sender, EventArgs e)
            {
                Type argstype = AssemblyProp.GetType("Task9.ProgressEventArgs");
                object p = argstype.GetProperty("Precision").GetValue(e);
                Console.WriteLine($"Current precision: {p:0.000000}");
            }
        }
    }
}
