namespace SieveOfEratosthenes
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            long n;

            // Get user input while the user enters an invalid int
            while (!long.TryParse(Console.ReadLine(), out n))
            {
            }

            var numbers = new bool[n];

            //Set all values in the array to true 
            for (var i = 2; i < numbers.Length; i++)
            {
                numbers[i] = true;
            }

            for (var i = 2; i < Math.Sqrt(n); i++)
            {
                if (!numbers[i])
                {
                    continue;
                }

                for (var j = 2; i * j < numbers.Length; j++)
                {
                    numbers[(i * j)] = false;
                }
            }

            //Write out all the prime numbers to console. 
            //If the value of an item in the array is true then the index of that item is a prime number
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
