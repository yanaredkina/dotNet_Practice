using System;
using System.IO;

namespace Task8_2
{
    class Program
    {
        public static string? DirName { get; set; }
        public static string? LogFile { get; set; }

        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    throw new ArgumentException("ERROR: incorrect number of arguments: need two");
                }

                DirName = args[0];
                LogFile = args[1];

                Console.WriteLine("Starting...(press any key to exit)");
                Console.WriteLine("\n");

                using (FileSystemWatcher dirWatcher = new FileSystemWatcher(DirName, "*.cs"))
                {
                    string startingLine = $"{"Date, Time:",-20}\t{"Name:",-20}\t{"Change Type:",-10}\n{"-----------------------------------------------------------"}";

                    Console.WriteLine(startingLine);
                    using (StreamWriter logsWriter = new StreamWriter(LogFile!, true))
                    {
                        logsWriter.WriteLine(startingLine);
                    }

                    dirWatcher.InternalBufferSize = 65536; // 64KB
                    dirWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite;

                    dirWatcher.Changed += OnChanged;
                    dirWatcher.Created += OnCreated;
                    dirWatcher.Deleted += OnDeleted;
                    dirWatcher.Renamed += OnRenamed;
                    dirWatcher.Error += OnError;

                    dirWatcher.EnableRaisingEvents = true;
                    Console.ReadKey();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.Message}");
            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            DateTime dt = File.GetLastWriteTime(e.FullPath);
            string res = $"{dt,-20:dd MMM yyyy, HH:mm}\t{e.Name,-20}\t{e.ChangeType.ToString().ToUpper(),-10}";
            Console.WriteLine(res);

            using (StreamWriter logsWriter = new StreamWriter(LogFile!, true))
            {
                logsWriter.WriteLine(res);
            }
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            DateTime dt = File.GetCreationTime(e.FullPath);
            string res = $"{dt, -20:dd MMM yyyy, HH:mm}\t{e.Name, -20}\t{e.ChangeType.ToString().ToUpper(), -10}";
            Console.WriteLine(res);

            using (StreamWriter logsWriter = new StreamWriter(LogFile!, true))
            {
                logsWriter.WriteLine(res);
            }
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            DateTime dt = DateTime.Now;
            string res = $"{dt,-20:dd MMM yyyy, HH:mm}\t{e.Name,-20}\t{e.ChangeType.ToString().ToUpper(),-10}";
            Console.WriteLine(res);

            using (StreamWriter logsWriter = new StreamWriter(LogFile!, true))
            {
                logsWriter.WriteLine(res);
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            string res = $"{dt,-20:dd MMM yyyy, HH:mm}\t{e.Name,-20}\t{e.ChangeType.ToString().ToUpper(),-10}";
            Console.WriteLine(res);

            using (StreamWriter logsWriter = new StreamWriter(LogFile!, true))
            {
                logsWriter.WriteLine(res);
            }
        }

        private static void OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"The process failed: {e.GetException().Message}");
        }
    }
}