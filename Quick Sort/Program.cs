using System;

namespace Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new[] { 2, 4, 5, 1, 3 };
            QuickSort(a, 0, a.Length - 1);

            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }
        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = Partition(array, start, end);

            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            int pivot = start;
            int i = pivot + 1;
            int j = end;

            while (i < j)
            {
                while (i <= end && array[i] <= array[pivot])
                {
                    i++;
                }

                while (array[j] > array[pivot])
                {
                    j--;
                }

                if (i < j)
                    (array[i], array[j]) = (array[j], array[i]);
            }

            (array[pivot], array[j]) = (array[j], array[pivot]);

            return j;
        }
    }
}