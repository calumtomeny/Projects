namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 5, 4, 7, 3, 6, 9, 0, 2, 8 };

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
    }
}
