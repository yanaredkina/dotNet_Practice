using System;

namespace Task5
{
    public class Stack<T>
        where T: ICloneable
    {
        private T[] _body;  // array for data storage
        private int _size;  // overall size of array
        private int _top;   // actual filled size of array


        public Stack()
        {
            _body = new T[5];
            _size = 5;
            _top = 0;
            Console.WriteLine($"-> Stack of '{typeof(T)}' type has been created (default size 5)");
        }


        public Stack(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException("-> ERROR: input stack size < 1");
            }

            _body = new T[size];
            _size = size;
            _top = 0;
            Console.WriteLine($"-> Stack of '{typeof(T)}' type has been created (size {_size})");
        }


        public int Count
        {
            get
            {
                return _top;
            }
        }


        public void Push(T item)
        {
            if (_size == _top)
            {
                Array.Resize(ref _body, _size * 2);
                _size *= 2;
                Console.WriteLine($"-> Stack size has been changed (new size is {_size})");
            }

            _body[_top] = (T)item.Clone();
            _top++;
            Console.WriteLine($"-> Element '{item}' was pushed to the stack"); 
        }


        // Замеч. (не исправляла): При возвращении данных в Pop хорошо бы было зачищать ячейку массива,
        // чтобы не держать ссылку на объект и позволить его удалить сборщику мусора при необходимости.

        public T Pop()
        {
            if (_top == 0)
            {
                throw new InvalidOperationException("-> ERROR: stack is empty");
            }

            _top--;
            Console.WriteLine($"-> Element '{_body[_top]}' was poped from the stack");
            return _body[_top];
        }


        public T Top()
        {
            if (_top == 0)
            {
                throw new InvalidOperationException("-> ERROR: stack is empty");
            }
            return (T)_body[_top - 1].Clone();
        }
    }
}
