using System;
using System.Collections.Generic;
class Queue<T>
{
    private Stack<T> enqueueStack;
    private Stack<T> dequeueStack;

    public Queue()
    {
        enqueueStack = new Stack<T>();
        dequeueStack = new Stack<T>();
    }

    public void Enqueue(T data)
    {
        var length = dequeueStack.Count;

        for (int i = 0; i < length; i++)
        {
            enqueueStack.Push(dequeueStack.Pop());
        }

        enqueueStack.Push(data);
    }

    public T Dequeque()
    {
        var length = enqueueStack.Count;

        for (int i = 0; i < length; i++)
        {
            dequeueStack.Push(enqueueStack.Pop());
        }

        return dequeueStack.Pop();
    }

    public void Print()
    {
        var i = enqueueStack.Count > dequeueStack.Count ? enqueueStack.Count - 1 : dequeueStack.Count - 1;

        if (enqueueStack.Count > dequeueStack.Count)
        {
            foreach (var item in enqueueStack)
            {
                Console.WriteLine($"{i--}: {item}");
            }

        }
        else
        {
            foreach (var item in dequeueStack)
            {
                Console.WriteLine($"{i--}: {item}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Queue<int> q = new Queue<int>();

        q.Enqueue(12);
        q.Enqueue(39);
        q.Enqueue(15);
        q.Enqueue(164);
        q.Enqueue(120);

        q.Dequeque();
        q.Dequeque();

        q.Enqueue(99);

        q.Print();
    }
}
