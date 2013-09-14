using System;

namespace ReverseAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string toReverse = Console.ReadLine();
            string reversedString = null;

            for (int i = toReverse.Length - 1; i >= 0; i--)
            {
                reversedString += toReverse[i];
            }

            Console.WriteLine(reversedString);
        }
    }
}
