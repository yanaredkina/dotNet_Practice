using System;
using FabulousCity.DataAccess;

namespace Task13
{
    public class Producer
    {
        LimitedQueue<Person[]> limitedQueque;
        int blockSize;

        public Producer(LimitedQueue<Person[]> limqueque, int size)
        {
            limitedQueque = limqueque;
            blockSize = size;
        }

        public void Handler()
        {
            PersonProvider provider = new PersonProvider();
            Person[] persons;
            int i = 1;

            while (true)
            {
                persons = provider.GetPersons(i, blockSize);
                if (persons.Length == 0)
                {
                    limitedQueque.SetFinalFlag();
                    break;
                }
                else
                {
                    limitedQueque.Push(persons);
                }
                i += blockSize;
            }
        }
    }
}
