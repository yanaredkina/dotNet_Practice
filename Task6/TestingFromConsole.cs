using System;
using System.Collections.Generic;

namespace Task6
{
    public class TestingFromConsole
    {
        public static void Start(ref EngRusDict dict)
        {
            do
            {
                Console.WriteLine("\nChoose operation: add translation (press 'A') or get translate (press 'T')");
                var inputKey = Console.ReadKey().Key;
                if (inputKey == ConsoleKey.A)
                {
                    Console.WriteLine("\nEnter the word to add:");
                    string? word = Console.ReadLine();

                    Console.WriteLine("Enter the translations (if there are several words, enter them separated by ','):");
                    string? translation = Console.ReadLine();

                    if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(translation))
                    {
                        Console.WriteLine("ERROR: input word or translation cannot be empty");
                    }
                    else
                    {
                        try
                        {
                            string[] array = translation!.Split(',');
                            dict.Add(word, new List<string>(array));
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }

                else if (inputKey == ConsoleKey.T)
                {
                    Console.WriteLine("\nEnter the word to translate:");
                    string? input = Console.ReadLine();
                    try
                    {
                        Program.PrintTranslationList(dict.GetTranslations(input));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                else
                {
                    Console.WriteLine("\nIncorrect key operation");
                }

                Console.WriteLine("\nWant to start again? (press 'Y' for yes)");
            }

            while (Console.ReadKey().Key == ConsoleKey.Y);

        }
    }
}
