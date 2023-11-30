using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Task11
{
    class Program
    {
        private static readonly string JsonFileName = Path.Combine(Environment.CurrentDirectory, "EmployeesRegister.json");

        static void Main(string[] args)
        {
            var provider = new JsonProvider(JsonFileName);

            if (!File.Exists(JsonFileName))
            {
                Console.WriteLine("JSON SERIALIZATION DEMONSTRATION\n");
                Demo(provider, JsonFileName);
            }


            Console.WriteLine("\nLETS GET STARTED IN CONSOLE!\n");
            Console.WriteLine("Select operation: SEARCH (press 'S') or ADD (press 'A') ");
            var inputKey = Console.ReadKey().Key;

            if (inputKey == ConsoleKey.S)
            {
                Console.WriteLine();
                Console.WriteLine("Please fill search form: ");
                Console.Write("Employee First Name: ");
                string firstname = Console.ReadLine() ?? string.Empty;
                Console.Write("Employee Last Name: ");
                string lastname = Console.ReadLine() ?? string.Empty;
                Console.Write("Employee Middle Name :");
                string middlename = Console.ReadLine() ?? string.Empty;
                Console.Write("Employee Phone: ");
                string phone = Console.ReadLine() ?? string.Empty;
                Console.Write("Employee Address: ");
                string address = Console.ReadLine() ?? string.Empty;

                var query = new Employee(firstname, lastname, middlename, phone, address);

                Employee[]? restored = provider.Load();
                if (restored is not null)
                {
                    List<Employee> results = Search(restored, query);
                    if (results.Count < 1)
                    {
                        Console.WriteLine("\nNothing found");
                    } else
                    {
                        Console.WriteLine("\nSearch results:");
                        Print(results);
                    }
                }
            }


            else if (inputKey == ConsoleKey.A)
            {
                List<Employee> inputList = new List<Employee>();

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Please fill add form: ");
                    Console.Write("Employee First Name: ");
                    string firstname = Console.ReadLine() ?? string.Empty;
                    Console.Write("Employee Last Name: ");
                    string lastname = Console.ReadLine() ?? string.Empty;
                    Console.Write("Employee Middle Name: ");
                    string middlename = Console.ReadLine() ?? string.Empty;
                    Console.Write("Employee Phone: ");
                    string phone = Console.ReadLine() ?? string.Empty;
                    Console.Write("Employee Address: ");
                    string address = Console.ReadLine() ?? string.Empty;

                    var employee = new Employee(firstname, lastname, middlename, phone, address);
                    inputList.Add(employee);

                    Console.WriteLine("\nWant to add another person? (press 'Y' for yes, any key for no)");
                }

                while (Console.ReadKey().Key == ConsoleKey.Y);
                Console.WriteLine();


                if (!File.Exists(JsonFileName))
                {
                    provider.Save(inputList.ToArray());
                }
                else
                {
                    Employee[]? restored = provider.Load();
                    if (restored is not null)
                    {
                        Employee[] newrecords = inputList.ToArray();
                        Employee[] alldata = new Employee[restored.Length + newrecords.Length];
                        restored.CopyTo(alldata, 0);
                        newrecords.CopyTo(alldata, restored.Length);
                        provider.Save(alldata);
                    }
                }

                Console.WriteLine("New Employee entry added");
            }


            else
            {
                Console.WriteLine("\nIncorrect key operation");
            }

        }


        public static List<Employee> Search(Employee[] restored, Employee query)
        {
            List<Employee> result = new List<Employee>();

            foreach (var item in restored)
            {
                if (!string.IsNullOrEmpty(query.FirstName) && query.FirstName != item.FirstName)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(query.LastName) && query.LastName != item.LastName)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(query.MiddleName) && query.MiddleName != item.MiddleName)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(query.Phone) && query.Phone != item.Phone)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(query.Address) && query.Address != item.Address)
                {
                    continue;
                }

                result.Add(item);
            }

            return result;
        }


        public static void Demo(JsonProvider provider, string fileName)
        {
            Employee[] employees =
            {   new Employee("Igor", "Ivanov", "Dmitrievich", "34645745523", "Moscow"),
                new Employee("Anna", "Smirnova", "Vladimirovna", "78233453452", "Moscow"),
                new Employee("Ivan", "Ivanov", "Petrovich", "029693294", "Moscow"),
            };

            Console.WriteLine("Initial list of Employees:");
            Print(employees);

            Console.WriteLine("Start serializing in file: {0}", fileName);
            provider.Save(employees);

            Console.WriteLine("Reading file:\n");
            Console.WriteLine(File.ReadAllText(fileName));

            Console.WriteLine("\nStart deserializing...\n");
            Employee[] restored = (Employee[])provider.Load()!;

            Console.WriteLine("Restored data:\n");
            Print(restored);
        }


        public static void Print(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
