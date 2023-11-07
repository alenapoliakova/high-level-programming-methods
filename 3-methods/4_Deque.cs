using System;


public class DoublyNode<T>
{
    public DoublyNode(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public DoublyNode<T> Previous { get; set; }
    public DoublyNode<T> Next { get; set; }
}


public class Deque<T>
{
    private DoublyNode<T> front; // Pointer to the front of the deque
    private DoublyNode<T> rear;  // Pointer to the rear of the deque
    private int count;           // Number of elements in the deque

    /// <summary>
    /// Initializes a new instance of the Deque class
    /// </summary>
    public Deque()
    {
        front = null;
        rear = null;
        count = 0;
    }

    /// <summary>
    /// Find the specified item in the double-ended queue
    /// </summary>
    /// <param name="item">The item to find</param>
    /// <returns>A list of positions where the item was found</returns>
    public List<int> Find(T item)
    {
        List<int> positions = new List<int>();
        DoublyNode<T> current = front;
        int position = 0;

        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                positions.Add(position);
            }
            current = current.Next;
            position++;
        }

        return positions;
    }

    /// <summary>
    /// Adds an item to the front of the deque
    /// </summary>
    /// <param name="item">The item to add to the front</param>
    public void AddFront(T item)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(item);

        if (front == null)
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            newNode.Next = front;
            front.Previous = newNode;
            front = newNode;
        }

        count++;
    }

    /// <summary>
    /// Adds an item to the rear of the deque
    /// </summary>
    /// <param name="item">The item to add to the rear</param>
    public void AddRear(T item)
    {
        DoublyNode<T> newNode = new DoublyNode<T>(item);

        if (rear == null)
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            newNode.Previous = rear;
            rear.Next = newNode;
            rear = newNode;
        }

        count++;
    }

    /// <summary>
    /// Removes the specified item from the deque
    /// </summary>
    /// <param name="item">The item to remove</param>
    public void Remove(T item)
    {
        DoublyNode<T> current = front;

        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                if (current == front)
                {
                    front = current.Next;
                    if (front != null)
                    {
                        front.Previous = null;
                    }
                }
                else if (current == rear)
                {
                    rear = current.Previous;
                    if (rear != null)
                    {
                        rear.Next = null;
                    }
                }
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }

                count--;
                return;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// Removes an item from the front of the deque
    /// </summary>
    public void RemoveFront()
    {
        if (front == null)
        {
            return;
        }

        front = front.Next;
        if (front != null)
        {
            front.Previous = null;
        }

        count--;
    }

    /// <summary>
    /// Removes an item from the rear of the deque
    /// </summary>
    public void RemoveRear()
    {
        if (rear == null)
        {
            return;
        }

        rear = rear.Previous;
        if (rear != null)
        {
            rear.Next = null;
        }

        count--;
    }

    /// <summary>
    /// Prints the elements in the deque
    /// </summary>
    public void Print()
    {
        DoublyNode<T> current = front;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Gets the number of elements in the deque
    /// </summary>
    public int Count
    {
        get { return count; }
    }
}


public class DequeProgram
{
    static void Main()
    {
        Deque<int> deque = new Deque<int>();
        Console.WriteLine("find <item> - Find indexes by item value");
        Console.WriteLine("add_front <item> - Add an item to the front of the deque");
        Console.WriteLine("add_rear <item> - Add an item to the rear of the deque");
        Console.WriteLine("remove <item> - Remove the specified item from the deque");
        Console.WriteLine("remove_front - Remove an item from the front of the deque");
        Console.WriteLine("remove_rear - Remove an item from the rear of the deque");
        Console.WriteLine("print - Print the elements in the deque");
        Console.WriteLine("count - Get the number of elements in the deque");
        Console.WriteLine("exit - Finish the program");

        while (true)
        {
            Console.Write("Enter a command: ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            string command = parts[0].ToLower();

            switch (command)
            {
                case "find":
                    int itemToFind = int.Parse(parts[1]);
                    List<int> positions = deque.Find(itemToFind);
                    if (positions.Count > 0)
                    {
                        Console.WriteLine($"Value {itemToFind} found at positions: {string.Join(", ", positions)}");
                    }
                    else
                    {
                        Console.WriteLine($"Value {itemToFind} not found in the deque");
                    }
                    break;
                case "add_front":
                    int itemToAddFront = int.Parse(parts[1]);
                    deque.AddFront(itemToAddFront);
                    break;
                case "add_rear":
                    int itemToAddRear = int.Parse(parts[1]);
                    deque.AddRear(itemToAddRear);
                    break;
                case "remove":
                    int itemToRemove = int.Parse(parts[1]);
                    deque.Remove(itemToRemove);
                    break;
                case "remove_front":
                    deque.RemoveFront();
                    break;
                case "remove_rear":
                    deque.RemoveRear();
                    break;
                case "print":
                    deque.Print();
                    break;
                case "count":
                    int dequeCount = deque.Count;
                    Console.WriteLine(dequeCount);
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
