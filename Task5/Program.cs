using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets create some initial stack: (press ENTER to continue)");
            Console.ReadLine();
            var fruitStack = CreateStack<String>("apple", "orange", "banana", "lemon");
            Console.WriteLine();


            Console.WriteLine("How many elements in the stack? (press ENTER to continue)");
            Console.ReadLine();
            Console.WriteLine($"-> Current number of elements in stack is {fruitStack.Count}");
            Console.WriteLine();


            Console.WriteLine("Let's try to push elements more than the initial stack size:  (press ENTER to continue)");
            Console.ReadLine();
                fruitStack.Push("coconut");
                fruitStack.Push("mango");
            Console.WriteLine($"\n-> Current number of elements in stack is {fruitStack.Count}");
            Console.WriteLine();


            Console.WriteLine("Whats current top element? (press ENTER to continue)");
            Console.ReadLine();
            Console.WriteLine($"-> Current top element is: {fruitStack.Top()}");
            Console.WriteLine();


            Console.WriteLine("Let's pop all elemets from stack: (press ENTER to continue)");
            Console.ReadLine();
            int sz = fruitStack.Count;
            for (int i = 0; i < sz; i++)
            {
                fruitStack.Pop();
            }
            Console.WriteLine($"\n-> Current number of elements in stack is {fruitStack.Count}");
            Console.WriteLine();


            Console.WriteLine("What if we pop from empty stack? (press ENTER to continue)");
            Console.ReadLine();
            try
            {
                fruitStack.Pop();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }


            Console.WriteLine("Let's create stack with input size more than default size: (press ENTER to continue)");
            Console.ReadLine();
            var inpStack = new Stack<string>(12);
            Console.WriteLine($"-> Current number of elements in stack is {inpStack.Count}");
            Console.WriteLine();


            Console.WriteLine("What happens if we try to create stack with input size -10? (press ENTER to continue)");
            Console.ReadLine();
            try
            {
                var errorStack = new Stack<string>(-10);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }


            Console.WriteLine("Is the object that was returned from Top() the same that was storaged in stack? (press ENTER to continue)");
            Console.ReadLine();
            var pStack = CreateStack<Point2D>(new Point2D(1, 1));
            Point2D ref1 = pStack.Top();        // copy from top obj
            Point2D ref2 = pStack.Pop();        // actual obj that was in the stack
            Console.WriteLine($"\nIs references equal? -> {ReferenceEquals(ref1, ref2)}");
            Console.WriteLine();


            Console.WriteLine("--------- END of Program ---------");
        }


        static public Stack<T> CreateStack<T>(params T[] args)
            where T: ICloneable
        {
            Stack<T> result = new Stack<T>();
            for (int i = 0; i < args.Length; i++)
            {
                result.Push(args[i]);
            }
            return result;
        }
    }
}
