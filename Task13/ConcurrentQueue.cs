using System;
using System.Collections.Generic;

namespace Task13
{
    public class ConcurrentQueue<T>
    {
        private Queue<T> queque;
        private object lockObject;

        public ConcurrentQueue() : this(100)
        {
        }

        public ConcurrentQueue(int size)
        {
            queque = new Queue<T>(size);
            lockObject = new object();
        }

        public int Count()
        {
            int res;
            lock (lockObject)
            {
                res = queque.Count;
            }
            return res;
        }

        public void Enqueue(T item)
        {
            lock (lockObject)
            {
                queque.Enqueue(item);
            }
        }

        public T Dequeue()
        {
            T item;
            lock (lockObject)
            {
                item = queque.Dequeue();
            }
            return item;
        }
    }
}
