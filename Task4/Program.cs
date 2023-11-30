using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Queue Testing
            var complexes = new ComplexQueue();
            complexes.Enqueue(new myComplex(1, 1));
            complexes.Enqueue(new myComplex(2, 2));
            complexes.Enqueue(new myComplex(3, 3));
            complexes.Enqueue(new myComplex(4, 4));
            complexes.Enqueue(new myComplex(5, 5));
            complexes.Print();
            Console.WriteLine($"Элементов в очереди: {complexes.Count}");
            Console.WriteLine();

            Console.WriteLine("Забираем два первых элемента из очереди ");
            myComplex? a = complexes.Dequeue();
            myComplex? b = complexes.Dequeue();
            Console.WriteLine($"в переменные: a={a} , b={b}");
            complexes.Print();
            Console.WriteLine($"Элементов в очереди: {complexes.Count}");
            Console.WriteLine();

            Console.WriteLine("Возвращаем первый элемент очереди ");
            myComplex? c = complexes.Peek();
            Console.WriteLine($"в переменную: c={c}");
            complexes.Print();
            Console.WriteLine($"Элементов в очереди: {complexes.Count}");
            Console.WriteLine();
            #endregion




            #region Interface Testing

            var shapes = new Shape[]
            {
                new Triangle(),
                new Hexagon(),
                new Circle(),
                new Sphere()
            };


            Console.WriteLine("Анализируем фигуры из массива: \n");

            for (int i = 0; i < shapes.Length; i++)
            {
                AnalyzeShape(shapes[i]);
            }
            #endregion
            
        }

        static public void AnalyzeShape(Shape shape)
        {
            Console.Write("Метод draw() напрямую: ");
            shape.Draw();

            if (shape is IDrawable)
            {
                Console.Write("Метод draw() через интерфейс: ");
                ((IDrawable)shape).Draw();
            }

            if (shape is IPoint point)
            {
                Console.WriteLine($"Число вершин: {point.Point}");
            }

            Console.WriteLine();
        }
    }
}
