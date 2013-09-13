namespace Sorting
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 5, 4, 7, 3, 6, 9, 0, 2, 8 };

            
            sort(numbers);
            //BubbleSort(numbers);
        }

        private static void BubbleSort(int[] numbers)
        {
            for (var i = 0; i < numbers.Length - 1; i++)
            {
                for (var j = 0; j < (numbers.Length - 1 - i); j++)
                {
                    var temp = numbers[j + 1];
                    if (numbers[j] > numbers[j + 1])
                    {
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
        }

        public static void sort<T>(T[] a)
    where T : IComparable<T>
        {
            sort(a, 0, a.Length);
        }

        public static void sort<T>(T[] a, int low, int high)
            where T : IComparable<T>
        {
            int N = high - low;
            if (N <= 1)
                return;

            int mid = low + N / 2;

            sort(a, low, mid);
            sort(a, mid, high);

            T[] aux = new T[N];
            int i = low, j = mid;
            for (int k = 0; k < N; k++)
            {
                if (i == mid) aux[k] = a[j++];
                else if (j == high) aux[k] = a[i++];
                else if (a[j].CompareTo(a[i]) < 0) aux[k] = a[j++];
                else aux[k] = a[i++];
            }

            for (int k = 0; k < N; k++)
            {
                a[low + k] = aux[k];
            }
        }

    }
}
