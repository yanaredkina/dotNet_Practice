using System;
using System.Collections.Generic;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {

            #region TESTING EngRusDict class
            Console.WriteLine("-------------- Testing English-Russian Dictionary --------------\n");
            Console.WriteLine("Сreating initial dictionary:\n");

            EngRusDict newDict = new EngRusDict();
            newDict.Add("home", new List<string>() { "дом", "родина", "жилье" });
            newDict.Add("study", new List<string>() { "обучение", "исследование", "анализ", "кабинет" });
            newDict.Add("маршрут", new List<string>() { "route", "path", "direction", "trail" });
            Console.WriteLine();


            Console.WriteLine("Translation request for 'HOME':");
            PrintTranslationList(newDict.GetTranslations("HOME"));
            Console.WriteLine();

            Console.WriteLine("Translation request for 'dinner':");
            PrintTranslationList(newDict.GetTranslations("dinner"));
            Console.WriteLine();


            Console.WriteLine("Current dictionary statistic:");
            Console.WriteLine($"Number of english words: {newDict.GetStat().eng}");
            Console.WriteLine($"Number of russian words: {newDict.GetStat().rus}");
            Console.WriteLine();

            Console.WriteLine("Adding new translation for duplicate word 'study' (already in dict):");
            newDict.Add("study", "изучение");
            Console.WriteLine();

            Console.WriteLine("New dictionary statistic:");
            Console.WriteLine($"Number of english words: {newDict.GetStat().eng} (hasn't changed?)");
            Console.WriteLine($"Number of russian words: {newDict.GetStat().rus} (has been changed?)");
            Console.WriteLine();


            Console.WriteLine("Adding duplicate translations for 'маршрут':");
            Console.WriteLine($"Current number of translations for word is {newDict.GetStatOfElem("маршрут")}");
            newDict.Add("маршрут", "path");
            Console.WriteLine($"New number of translations for word is {newDict.GetStatOfElem("маршрут")} (hasn't changed?)");
            Console.WriteLine();


            Console.WriteLine("Lets test some exceptions\n");
            Console.WriteLine("Adding pair: 'work' -> {'работа', '', '45м344а', 'cat'}: \n");
            try
            {
                newDict.Add("work", new List<string>() { "работа", "", "45м344а", "cat" });
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"Total number of translations for 'work' is {newDict.GetStatOfElem("work")}");
            Console.WriteLine();


            Console.WriteLine("Start testing English-Russian dictionary from console? (press 'Y' for yes)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                TestingFromConsole.Start(ref newDict);
            }
            Console.WriteLine("\n------------------------- End testing -------------------------\n");
            #endregion



            Console.WriteLine("Press Enter to continue next part");
            Console.ReadLine();



            #region TESTING PrimeNumberSeq class
            Console.WriteLine("------------ Testing Prime Number Infinite Sequence ------------\n");
            Console.WriteLine("Enter n - the number of the first elements of the sequence:");

            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Wrong input! Try again!");
            }

            Console.WriteLine($"First {n} prime numbers:");
            foreach (var item in PrimeNumberSeq.GetSequence())
            {
                if (n < 1)
                {
                    break;
                }
                Console.Write($"{item} ");
                n--;
            }

            Console.WriteLine("\n------------------------- End testing -------------------------\n");
            #endregion
        }


        #region static method
        public static void PrintTranslationList(List<string>? list)
        {
            if (list is not null)
            {
                Console.Write("Translation: ");
                foreach (var item in list)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
