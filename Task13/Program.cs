using System;
using FabulousCity.DataAccess;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Task13
{
    class Program
    {
        public const int quequeSize = 10;
        public const int quequeElemSize = 10_000;
        public const int blockSize = 100_000;

        static void Main(string[] args)
        {
            // single-threaded processing
            Stopwatch sw = Stopwatch.StartNew();
            SingleThreadProcess();
            sw.Stop();
            long duration = sw.ElapsedMilliseconds;
            Console.WriteLine($"single-threaded performance time: {duration} ms");
            // Time with 100 data blocksize: ~210 827 ms
            // Time with 1_000 data blocksize: ~94 037 ms
            // Time with 10_000 data blocksize: ~76 632 ms
            // Time with 100_000 data blocksize:  ~68 874 ms
            // Results: with large block much faster (because there is buffering in streamwriter)


            // two-threaded processing
            sw = Stopwatch.StartNew();
            TwoThreadProcess();
            sw.Stop();
            duration = sw.ElapsedMilliseconds;
            Console.WriteLine($"two-threaded performance time: {duration} ms");
            // n/m, n = queque size, m=block size per element in queque:
            // Time with 10/10_000: ~47 446 ms
            // Time with 100/1_000: ~59 978 ms
            // Time with 1_000/100: ~155 069 ms
            // Results: small queue + large data block is more efficient (because there are fewer synchronization operations + buffering)
        }

        static public void SingleThreadProcess()
        {
            PersonProvider provider = new PersonProvider();
            Person[] persons;
            int i = 1;

            using (StreamWriter swr = new StreamWriter("result.txt"))
            {
                while (true)
                {
                    persons = provider.GetPersons(i, blockSize);
                    if (persons.Length == 0)
                    {
                        break;
                    }
                    else
                    {
                        foreach (var item in persons)
                        {
                            swr.WriteLine(item.ToString());
                        }
                    }
                    i += blockSize;
                }
            }

        }

        static public void TwoThreadProcess()
        {
            var limqueque = new LimitedQueue<Person[]>(quequeSize);
            var producer = new Producer(limqueque, quequeElemSize);
            var consumer = new Consumer(limqueque);

            Thread pr = new Thread(() => producer.Handler());
            pr.Start();
            Thread cn = new Thread(() => consumer.Handler());
            cn.Start();

            pr.Join();
            cn.Join();
        }
    }
}
