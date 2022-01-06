using System;
using System.Collections.Generic;

namespace Stack_using_Linked_List
{
    class Stack<T>
    {
        LinkedList<T> stack;
        public int Count { get; private set; }

        public Stack()
        {
            stack = new LinkedList<T>();
        }

        public void Push(T data)
        {
            stack.AddLast(data);
            Count++;
        }

        public LinkedListNode<T> Pop()
        {
            var p = stack.Last;
            stack.RemoveLast();
            Count--;
            return p;
        }

        public void Print()
        {
            var i = 0;
            Console.WriteLine($"Count: {stack.Count}");

            foreach (var item in stack)
            {
                Console.WriteLine($"{i++} : {item}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> intStack = new Stack<int>();

            intStack.Push(10);
            intStack.Push(40);
            intStack.Push(50);
            intStack.Push(70);
            intStack.Pop();

            intStack.Print();
        }
    }
}
