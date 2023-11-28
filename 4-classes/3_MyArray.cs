using System;
using System.Collections.Generic;

/// <summary>
/// Represents a one-dimensional array of integers with various operations.
/// </summary>
public class MyArray
{
    /// <summary>
    /// Gets or sets the array of integers.
    /// </summary>
    public int[] array;

    /// <summary>
    /// Initializes a new instance of the <see cref="MyArray"/> class with the specified size.
    /// </summary>
    /// <param name="size">The size of the array.</param>
    public MyArray(int size)
    {
        array = new int[size];
    }

    /// <summary>
    /// Gets the length of the array.
    /// </summary>
    public int Length
    {
        get { return array.Length; }
    }

    /// <summary>
    /// Allows the user to input data for the array.
    /// </summary>
    public void InputData()
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"Enter element at index {i}: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                array[i] = value;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                i--;
            }
        }
    }

    /// <summary>
    /// Fills the array with random values.
    /// </summary>
    public void InputDataRandom()
    {
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100);
        }
    }

    /// <summary>
    /// Prints the elements of the array in the specified range of indices.
    /// </summary>
    /// <param name="startIndex">The starting index.</param>
    /// <param name="endIndex">The ending index.</param>
    public void Print(int startIndex, int endIndex)
    {
        if (startIndex < 0 || startIndex >= array.Length || endIndex < 0 || endIndex >= array.Length || startIndex > endIndex)
        {
            Console.WriteLine("Invalid indices.");
            return;
        }

        Console.Write("Array elements in the specified range: ");
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Finds the indices of the specified value in the array.
    /// </summary>
    /// <param name="searchValue">The value to search for.</param>
    /// <returns>A list of indices where the value is found.</returns>
    public List<int> FindValue(int searchValue)
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == searchValue)
            {
                indices.Add(i);
            }
        }
        return indices;
    }

    /// <summary>
    /// Deletes all occurrences of the specified value from the array.
    /// </summary>
    /// <param name="searchValue">The value to delete.</param>
    public void DelValue(ref int searchValue)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == searchValue)
            {
                for (int j = i; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                Array.Resize(ref array, array.Length - 1);
                i--; // Check the same index again, as it now contains a new value
            }
        }
    }

    /// <summary>
    /// Finds the maximum value in the array and returns its value and index.
    /// </summary>
    /// <param name="maxIndex">The index of the maximum value.</param>
    /// <returns>The maximum value in the array.</returns>
    public int FindMax(out int maxIndex)
    {
        int max = array[0];
        maxIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                maxIndex = i;
            }
        }

        return max;
    }

    /// <summary>
    /// Adds the corresponding elements of another array to this array.
    /// </summary>
    /// <param name="otherArray">The array to add.</param>
    public void Add(in MyArray otherArray)
    {
        if (array.Length != otherArray.array.Length)
        {
            Console.WriteLine("Arrays must be of the same length for addition.");
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            array[i] += otherArray.array[i];
        }
    }

    /// <summary>
    /// Sorts the elements of the array in ascending order.
    /// </summary>
    public void Sort()
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Example usage
        MyArray myArray = new MyArray(5);

        myArray.InputData();
        myArray.Print(0, myArray.Length - 1);

        MyArray randomArray = new MyArray(5);
        randomArray.InputDataRandom();
        randomArray.Print(0, randomArray.Length - 1);

        int searchValue = 5;
        List<int> indices = myArray.FindValue(searchValue);
        Console.WriteLine($"Indices of {searchValue}: {string.Join(", ", indices)}");

        myArray.DelValue(ref searchValue);
        myArray.Print(0, myArray.Length - 1);

        int maxIndex;
        int max = myArray.FindMax(out maxIndex);
        Console.WriteLine($"Max value: {max}, Index: {maxIndex}");

        MyArray arrayToAdd = new MyArray(5);
        arrayToAdd.InputData();
        myArray.Add(in arrayToAdd);
        myArray.Print(0, myArray.Length - 1);

        myArray.Sort();
        myArray.Print(0, myArray.Length - 1);
    }
}
