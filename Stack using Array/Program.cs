using System;
using System.Collections.Generic;

namespace Stack_using_Array
{
    class Stack<T>
    {
        T[] stack;
        public int Top { get; private set; } = -1;

        public Stack(int capacity)
        {
            stack = new T[capacity];
        }

        public void Push(T data)
        {
            stack[++Top] = data;
        }

        public T Pop()
        {
            return stack[Top--];
        }

        public void Print()
        {
            Console.WriteLine($"Count: {Top + 1}");

            for (int i = 0; i <= Top; i++)
            {
                Console.WriteLine($"{i} : {stack[i]}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> intStack = new Stack<int>(10);

            intStack.Push(10);
            intStack.Push(480);
            intStack.Push(0);
            intStack.Push(120);
            intStack.Push(70);

            intStack.Pop();
            intStack.Pop();

            intStack.Print();
        }
    }
}