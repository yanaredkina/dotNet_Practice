using System;
namespace Task4
{
    public class ComplexQueue
    {
        private Node? _first = null, _last = null;

        public int Count
        {
            get
            {
                Node? tmp = _first;
                int res = 0;
                while (tmp != null)
                {
                    res++;
                    tmp = tmp.Next;
                }
                return res;
            }
        }


        public void Enqueue(myComplex c)
        {
            Node tmp = new Node(c);
            if (_first is null)
            {
                _first = tmp;
                _last = tmp;
            }
            else
            {
                _last!.Next = tmp;
                _last = _last.Next;
            }
        }

        public myComplex? Dequeue()
        {
            if (_first is null)
            {
                return null;
            }
            else
            {
                myComplex res = _first.Data;
                _first = _first.Next;

                if (_first is null)
                {
                    _last = null;
                }

                return res;
            }
        }

        public myComplex? Peek()
        {
            if (_first is null)
            {
                return null;
            }
            else
            {
                return _first.Data;
            }
        }

        public void Print()
        {
            Console.WriteLine("Содержимое очереди: ");
            Node? tmp = _first;
            while(tmp != null)
            {
                Console.WriteLine(tmp.Data);
                tmp = tmp.Next;
            }
        }


        private class Node
        {
            public Node(myComplex data)
            {
                Data = data;
            }

            public myComplex Data { get; set; }
            public Node? Next { get; set; }
        }
    }
}
