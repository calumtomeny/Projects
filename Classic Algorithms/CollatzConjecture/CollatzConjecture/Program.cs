namespace CollatzConjecture
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int steps = 0;

            while (!int.TryParse(Console.ReadLine(), out n))
            {
            }

            while (n != 1)
            {
                // Half Or Tripple Plus One
                if (n % 2 == 0)
                {
                    n = n / 2;
                }
                else
                {
                    n = (n * 3) + 1;
                }

                steps++;
            }

            // Print the number of steps to get from n to one.
            Console.WriteLine(steps);
        }
    }
}
