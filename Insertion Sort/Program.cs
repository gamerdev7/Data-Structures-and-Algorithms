using System;

namespace Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new[] { 2, 4, 5, 1, 3 };
            InsertionSort(a);

            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var temp = array[i];
                int j = i - 1;

                while (j >= 0 && temp < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = temp;
            }
        }
    }
}