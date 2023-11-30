using System;

namespace Task8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    CSVAnalyzer.Start(args[i]);
                }

                catch (ArgumentException e) // exception from filename
                {
                    Console.WriteLine("Incorrect input:");
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)         // exception from StreamReader
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}