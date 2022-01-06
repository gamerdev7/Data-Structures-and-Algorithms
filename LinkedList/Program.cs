using System;
using System.Collections.Generic;

namespace LinkedList
{
    class Node<T>
    {
        public T data;
        public Node<T> link;
    }


    class SingleLinkedList<T>
    {
        Node<T> head;
        public int Count { get; private set; } = 0;

        public void AddLast(T data)
        {
            Node<T> node = new Node<T>();
            node.data = data;
            node.link = null;

            if (head == null)
            {
                head = node;
                return;
            }

            Node<T> current = head;

            while (true)
            {
                if (current.link == null)
                {
                    current.link = node;
                    break;
                }
                current = current.link;
            }

            Count++;
        }

        public void ReverseList()
        {
            var first = head;
            var second = first.link;

            while (second != null)
            {
                var temp = second.link;
                second.link = first;
                first = second;
                second = temp;
            }

            head.link = null;
            head = first;
        }

        public void Print()
        {
            Node<T> current = head;
            int index = 0;

            Console.WriteLine("Printing values: ");

            if (current.link == null)
            {
                Console.WriteLine("I am null");
            }

            while (current != null)
            {
                Console.WriteLine($"Index{index} : {current.data}");
                current = current.link;
                index++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList<int> intList = new SingleLinkedList<int>();
            intList.AddLast(1);
            intList.AddLast(3);
            intList.AddLast(12);
            intList.AddLast(54);

            intList.Print();

            Console.WriteLine();
            Console.WriteLine("Reversing Linked List...");
            intList.ReverseList();

            intList.Print();
        }
    }
}
