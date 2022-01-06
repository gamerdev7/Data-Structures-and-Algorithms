using System;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new[] { 2, 4, 5, 1, 3 };
            SelectionSort(a);

            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                var temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }
    }
}
