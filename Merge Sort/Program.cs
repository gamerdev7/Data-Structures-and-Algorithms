using System;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new[] { 2, 4, 5, 1, 3 };
            MergeSort(a, 0, a.Length - 1);

            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }
        }

        public static void MergeSort(int[] array, int start, int end)
        {
            if (start == end)
            {
                return;
            }

            int mid = (start + end) / 2;

            MergeSort(array, start, mid);
            MergeSort(array, mid + 1, end);

            Merge(array, new int[array.Length], start, end);
        }

        private static void Merge(int[] array, int[] temp, int start, int end)
        {
            int i = start;
            int mid = (start + end) / 2;
            int j = mid + 1;
            int k = start;


            while (i <= mid && j <= end)
            {
                if (array[i] < array[j])
                {
                    temp[k] = array[i];
                    i++;
                }
                else
                {
                    temp[k] = array[j];
                    j++;
                }

                k++;
            }

            while (i <= mid)
            {
                temp[k] = array[i];
                i++;
                k++;
            }

            while (j <= end)
            {
                temp[k] = array[j];
                j++;
                k++;
            }

            for (k = start; k <= end; k++)
            {
                array[k] = temp[k];
            }
        }
    }
}