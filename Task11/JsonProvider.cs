using System;
using System.IO;
using System.Text.Json;

namespace Task11
{
    public class JsonProvider
    {
        private readonly string _fileName;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public JsonProvider(string fileName)
        {
            _fileName = fileName;
        }


        public void Save(Employee[] employees)
        {
            if (employees is null)
            {
                return;
            }

            try
            {
                using var stream = new FileStream(_fileName, FileMode.Create);
                JsonSerializer.Serialize(stream, employees, _options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Employee[]? Load()
        {
            try
            {
                using var stream = new FileStream(_fileName, FileMode.Open);
                return (Employee[])JsonSerializer.Deserialize(stream, typeof(Employee[]), _options)!;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}