using System;

namespace Fibonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int nthNumber;

            while (!int.TryParse(Console.ReadLine(), out nthNumber))
            {
            }

            Console.WriteLine(Fibonacci(nthNumber));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}