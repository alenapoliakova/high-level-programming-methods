using System;
using System.Diagnostics;
using System.Drawing;

public class Queue
{
    private int[] items; // Array to store queue elements
    private int front;   // Index of the front of the queue
    private int last;    // Index of the last of the queue
    private int size;    // Current size of the queue

    /// <summary>
    /// Constructor creates a new queue object with the specified capacity
    /// </summary>
    /// <param name="capacity">The capacity of the queue</param>
    public Queue(int capacity)
    {
        items = new int[capacity];
        front = 0;
        last = -1;
        size = 0;
    }

    /// <summary>
    /// Adds an element to the end of the queue
    /// </summary>
    /// <param name="item">The item to be added</param>
    public void Push(int item)
    {
        if (size == items.Length)
        {
            Console.WriteLine("error");
            return;
        }

        last = (last + 1) % items.Length;
        items[last] = item;
        size++;
        Console.WriteLine("ok");
    }

    /// <summary>
    /// Removes an element from the front of the queue
    /// </summary>
    public int Pop()
    {
        if (size == 0)
        {
            Console.WriteLine("error");
            return -1;
        }
        int removedItem = items[front];
        front = (front + 1) % items.Length;
        size--;
        return removedItem;
    }

    /// <summary>
    /// Returns the value of the element at the front of the queue without removing it
    /// </summary>
    public int Front()
    {
        if (size == 0)
        {
            Console.WriteLine("error");
            return -1;
        }
        return items[front];
    }

    /// <summary>
    /// Returns the current size of the queue
    /// </summary>
    /// <returns>The size of the queue</returns>
    public int Size()
    {
        return size;
    }

    /// <summary>
    /// Clears the queue
    /// </summary>
    public void Clear()
    {
        front = 0;
        last = -1;
        size = 0;
        Console.WriteLine("ok");
    }
}

class QueueProgram
{
    static void Main()
    {
        int capacity = 100;
        Queue queue = new Queue(capacity);
        Console.WriteLine("Commands:\npush <number> - push number to the end of queue\npop - pop the first queue element");
        Console.WriteLine("front - write the first queue element\nsize - write queue size\nclear - clear elements\nexit - finish program\n");

        while (true)
        {
            Console.Write("Enter a command: ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            string command = parts[0].ToLower();

            switch (command)
            {
                case "push":
                    int n = int.Parse(parts[1]);
                    queue.Push(n);
                    break;
                case "pop":
                    int popItem = queue.Pop();
                    Console.WriteLine(popItem);
                    break;
                case "front":
                    int frontItem = queue.Front();
                    Console.WriteLine(frontItem);
                    break;
                case "size":
                    int size = queue.Size();
                    Console.WriteLine(size);
                    break;
                case "clear":
                    queue.Clear();
                    break;
                case "exit":
                    Console.WriteLine("Exit");
                    return;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
