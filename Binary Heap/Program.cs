using System;
using System.Collections.Generic;

namespace Binary_Heap
{
    class BinaryHeap
    {
        List<int> heap;

        public BinaryHeap()
        {
            heap = new();
        }

        public BinaryHeap(int[] array)
        {
            heap = new List<int>(array);

            for (int i = heap.Count / 2 - 1; i >= 0; i--)
            {
                MaxHeapifyRecursive(i);
            }
        }

        public void Insert(int number)
        {
            heap.Add(number);

            var index = heap.Count - 1;

            while (index > 0)
            {
                int parentIndex = Parent(index);
                if (heap[index] > heap[parentIndex])
                {
                    (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);
                    index = parentIndex;
                }
                else
                    return;
            }
        }

        public int ExtractMax()
        {
            if (heap.Count == 0)
                return int.MinValue;

            int max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            MaxHeapifyRecursive(0);

            return max;
        }

        public int FindMax()
        {
            if (heap.Count == 0)
                return int.MinValue;

            return heap[0];
        }

        public void MaxHeapifyIterative(int index)
        {
            while (index < heap.Count && LeftChild(index) < heap.Count)
            {
                var leftChild = heap[LeftChild(index)];

                var rightChild = RightChild(index) < heap.Count ? heap[RightChild(index)] : int.MinValue;

                var maxChildIndex = leftChild > rightChild ? LeftChild(index) : RightChild(index);

                if (heap[index] < heap[maxChildIndex])
                {
                    (heap[index], heap[maxChildIndex]) = (heap[maxChildIndex], heap[index]);
                }

                index = maxChildIndex;
            }
        }

        public void MaxHeapifyRecursive(int index)
        {
            var left = LeftChild(index);
            var right = RightChild(index);
            var largest = index;

            if (left < heap.Count && heap[largest] < heap[left])
            {
                largest = left;
            }

            if (right < heap.Count && heap[largest] < heap[right])
            {
                largest = right;
            }

            if (largest != index)
            {
                (heap[index], heap[largest]) = (heap[largest], heap[index]);
                MaxHeapifyRecursive(largest);
            }
        }

        public int Parent(int key)
        {
            return (key - 1) / 2;
        }

        public int LeftChild(int key)
        {
            return 2 * key + 1;
        }

        public int RightChild(int key)
        {
            return 2 * key + 2;
        }

        public void Print()
        {
            Console.Write("Heap: ");
            foreach (var element in heap)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryHeap binaryHeap = new BinaryHeap(new int[] { 10, 35, 20, 45, 40, 50 });

            binaryHeap.Insert(30);
            binaryHeap.Print();

            binaryHeap.ExtractMax();
            binaryHeap.Print();

            binaryHeap.ExtractMax();
            binaryHeap.Print();
            binaryHeap.ExtractMax();
            binaryHeap.Print();
            binaryHeap.ExtractMax();
            binaryHeap.Print();
            binaryHeap.ExtractMax();
            binaryHeap.Print();
            binaryHeap.ExtractMax();
            binaryHeap.Print();
        }
    }
}
