using System;

/// <summary>
/// Represents a stack data structure
/// </summary>
public class Stack
{
    private int[] items;  // Field to store stack elements
    private int top;      // Field to keep track of the top element's index

    /// <summary>
    /// Initializes a new instance of the Stack class with the specified capacity
    /// </summary>
    /// <param name="capacity">The maximum capacity of the stack</param>
    public Stack(int capacity)
    {
        items = new int[capacity];
        top = -1;
    }

    /// <summary>
    /// Pushes an item onto the stack
    /// </summary>
    /// <param name="item">The item to be pushed onto the stack</param>
    public void Push(int item)
    {
        if (top == items.Length - 1)
        {
            Console.WriteLine("Stack is full, can't push");
            return;
        }

        items[++top] = item;
        Console.WriteLine("ok");
    }

    /// <summary>
    /// Pops and returns the top item from the stack
    /// </summary>
    /// <returns>The popped item, or -1 if the stack is empty</returns>
    public int Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is empty, can't pop");
            return -1;
        }

        int popped = items[top--];
        return popped;
    }

    /// <summary>
    /// Returns the top item from the stack without removing it
    /// </summary>
    /// <returns>The top item, or -1 if the stack is empty</returns>
    public int Peek()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is empty, can't peek");
            return -1;
        }

        return items[top];
    }

    /// <summary>
    /// Returns the current size of the stack
    /// </summary>
    /// <returns>The size of the stack</returns>
    public int Size()
    {
        return top + 1;
    }

    /// <summary>
    /// Clears the stack
    /// </summary>
    public void Clear()
    {
        top = -1;
        Console.WriteLine("ok");
    }
}


class StackProgram
{
    static void Main()
    {
        int capacity = 100;
        Stack stack = new Stack(capacity);
        Console.WriteLine("Commands:\npush <number> - push number to the end of stack\npop - pop last stack element");
        Console.WriteLine("back - write last stack element\nsize - write stack size\nclear - clear elements\nexit - finish program\n");

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
                    stack.Push(n);
                    break;
                case "pop":
                    int popped = stack.Pop();
                    Console.WriteLine(popped);
                    break;
                case "back":
                    int top = stack.Peek();
                    Console.WriteLine(top);
                    break;
                case "size":
                    int size = stack.Size();
                    Console.WriteLine(size);
                    break;
                case "clear":
                    stack.Clear();
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
