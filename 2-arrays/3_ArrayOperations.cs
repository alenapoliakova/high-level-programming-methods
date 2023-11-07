using System;

class ArrayOperationsProgram
{
    static Random random = new Random();

    static int[] InitializeArray(int size)
    {
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 101);
        }
        return array;
    }

    static int[] AddArrays(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length)
        {
            throw new ArgumentException("Arrays must have the same length");
        }

        int[] result = new int[array1.Length];
        for (int i = 0; i < array1.Length; i++)
        {
            result[i] = array1[i] + array2[i];
        }
        return result;
    }

    static int[] MultiplyArrayByNumber(int[] array, int number)
    {
        int[] result = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = array[i] * number;
        }
        return result;
    }

    static int[] FindCommonValues(int[] array1, int[] array2)
    {
        int[] commonValues = new int[Math.Min(array1.Length, array2.Length)];
        int count = 0;

        foreach (int value1 in array1)
        {
            foreach (int value2 in array2)
            {
                if (value1 == value2)
                {
                    commonValues[count] = value1;
                    count++;
                    break;
                }
            }
        }

        Array.Resize(ref commonValues, count);
        return commonValues;
    }

    static void PrintArray(int[] array)
    {
        Console.WriteLine($"Array: {string.Join(", ", array)}");
    }

    static int[] SortArrayDescending(int[] array)
    {
        Array.Sort(array);
        Array.Reverse(array);
        return array;
    }

    static (int, int, double) FindMinMaxAverage(int[] array)
    {
        if (array.Length == 0)
        {
            return (0, 0, 0);
        }

        int min = array[0];
        int max = array[0];
        int sum = 0;

        foreach (int value in array)
        {
            if (value < min)
                min = value;
            if (value > max)
                max = value;
            sum += value;
        }

        double average = (double)sum / array.Length;

        return (min, max, average);
    }

    static void Main()
    {
        Console.Write("Enter the array size: ");
        int size = int.Parse(Console.ReadLine());

        int[] array1 = InitializeArray(size);
        int[] array2 = InitializeArray(size);

        Console.WriteLine("Original arrays:");
        PrintArray(array1);
        PrintArray(array2);

        int[] sumArray = AddArrays(array1, array2);
        Console.WriteLine("Sum of arrays:");
        PrintArray(sumArray);

        int number = 5;
        int[] multipliedArray = MultiplyArrayByNumber(array1, number);
        Console.WriteLine($"Array multiplied by {number}:");
        PrintArray(multipliedArray);

        int[] commonValues = FindCommonValues(array1, array2);
        Console.WriteLine("Common values in arrays:");
        PrintArray(commonValues);

        int[] sortedArray = SortArrayDescending(array1);
        Console.WriteLine("Array sorted in descending order:");
        PrintArray(sortedArray);

        (int min, int max, double average) = FindMinMaxAverage(array1);
        Console.WriteLine($"Minimum value: {min}");
        Console.WriteLine($"Maximum value: {max}");
        Console.WriteLine($"Average value: {average}");
    }
}
