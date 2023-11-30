using System;
using System.IO;
using FabulousCity.DataAccess;

namespace Task13
{
    public class Consumer
    {
        LimitedQueue<Person[]> limitedQueque;

        public Consumer(LimitedQueue<Person[]> limqueque)
        {
            limitedQueque = limqueque;
        }


        public void Handler()
        {
            Person[] persons;

            using (StreamWriter swr = new StreamWriter("result.txt"))
            {
                while (true)
                {
                    persons = limitedQueque.Pop();
                    if (persons == null)
                    {
                        break;
                    }
                    foreach (var item in persons)
                    {
                        swr.WriteLine(item.ToString());
                    }
                }

            }
        }
    }
}
