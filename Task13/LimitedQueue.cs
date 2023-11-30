using System;
using System.Threading;

namespace Task13
{
    public class LimitedQueue<T> : IDisposable
        where T : class
    {
        private ConcurrentQueue<T> cq;
        private Semaphore readingSem;
        private Semaphore writingSem;
        private int limit;
        private int finalFlag;
        private object lockObject;

        public LimitedQueue() : this(100)
        {
        }

        public LimitedQueue(int size)
        {
            cq = new ConcurrentQueue<T>(size);
            readingSem = new Semaphore(0, size);
            writingSem = new Semaphore(size, size);
            limit = size;
            finalFlag = 0;
            lockObject = new object();
        }

        public int Flag
        {
            get
            {
                lock (lockObject)
                { return finalFlag; }
            }
            set {
                lock (lockObject)
                { finalFlag = value; }
            }
        }

        public int Count()
        {
            return cq.Count();
        }

        public void SetFinalFlag()
        {
            Flag = 1;
            readingSem.Release();
        }

        public void Push(T item)
        {
            writingSem.WaitOne();
            cq.Enqueue(item);
            int i = readingSem.Release();
        }

        public T Pop()
        {
            readingSem.WaitOne();

            if (cq.Count() == 0 && Flag == 1)
            {
                return null;
            }

            T item;
            item = cq.Dequeue();
            int i = writingSem.Release();
            return item;
        }

        public void Dispose()
        {
            readingSem.Close();
            writingSem.Close();
        }
    }
}
