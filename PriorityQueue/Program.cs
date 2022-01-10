using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Priority_Queue
{
    class PriorityQueue<TElement, TPriority> : IEnumerable<(TElement, TPriority)> where TPriority : IComparable<TPriority>
    {
        private List<(TElement Element, TPriority Priority)> heap;
        private IComparer<TPriority> Comparer { get; }

        public int Count { get { return heap.Count; } }

        public PriorityQueue()
        {
            heap = new();
        }

        public PriorityQueue(IComparer<TPriority> comparer) : this()
        {
            this.Comparer = comparer;
        }

        public PriorityQueue(IEnumerable<(TElement, TPriority)> items)
        {
            BuildHeap(items);
        }

        public PriorityQueue(IEnumerable<(TElement, TPriority)> items, IComparer<TPriority> comparer) : this(comparer)
        {
            BuildHeap(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return heap.GetEnumerator();
        }

        public IEnumerator<(TElement, TPriority)> GetEnumerator()
        {
            return heap.GetEnumerator();
        }

        private void BuildHeap(IEnumerable<(TElement, TPriority)> items)
        {
            heap = new List<(TElement, TPriority)>(items);

            for (int i = heap.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        private int Compare(TPriority p1, TPriority p2)
        {
            return Comparer != null ? Comparer.Compare(p1, p2) : p1.CompareTo(p2);
        }

        public void Enqueue(TElement element, TPriority priority)
        {
            heap.Add((element, priority));

            var index = heap.Count - 1;

            while (index > 0)
            {
                int parentIndex = Parent(index);

                if (Compare(heap[index].Priority, heap[parentIndex].Priority) > 0)
                {
                    (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);
                    index = parentIndex;
                }
                else
                    return;
            }
        }

        public TElement Dequeue()
        {
            if (heap.Count == 0)
                throw new Exception("No Elements in the Priority Queue.");

            var max = heap[0].Element;
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            Heapify(0);

            return max;
        }

        public TElement EnqueueDequeue(TElement element, TPriority priority)
        {
            Enqueue(element, priority);
            return Dequeue();
        }

        public TElement Peek()
        {
            if (heap.Count == 0)
                throw new Exception("No Elements in the Priority Queue.");

            return heap[0].Element;
        }

        private void Heapify(int index)
        {
            var left = LeftChild(index);
            var right = RightChild(index);
            var largest = index;

            if (left < heap.Count && Compare(heap[largest].Priority, heap[left].Priority) < 0)
            {
                largest = left;
            }

            if (right < heap.Count && Compare(heap[largest].Priority, heap[right].Priority) < 0)
            {
                largest = right;
            }

            if (largest != index)
            {
                (heap[index], heap[largest]) = (heap[largest], heap[index]);
                Heapify(largest);
            }
        }

        private int Parent(int key)
        {
            return (key - 1) / 2;
        }

        private int LeftChild(int key)
        {
            return 2 * key + 1;
        }

        private int RightChild(int key)
        {
            return 2 * key + 2;
        }

        public void Print()
        {
            Console.Write("Heap: ");
            foreach (var item in heap)
            {
                Console.Write($"{item.Element} ");
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        public static void Main()
        {
            var a = new int[] { 10, 35, 20, 45, 40, 50 };
            var newA = new (int, int)[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                newA[i] = (a[i], a[i]);
            }

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(newA, Comparer<int>.Create((a, b) => b - a));

            pq.Print();
            pq.Dequeue();
            pq.Print();

            pq.Dequeue();
            pq.Print();
            pq.Dequeue();
            pq.Print();
            pq.Dequeue();
            pq.Print();
            pq.Dequeue();
            pq.Print();
            pq.Dequeue();
            pq.Print();
        }
    }

}