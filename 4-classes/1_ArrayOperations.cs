using System;

public class ArrayOperations
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    public static void Main()
    {
        Console.Write("Enter the number of rows in the array: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Incorrect input. Please enter a positive integer.");
            return;
        }

        int[][] array = new int[n][];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter values for row {i + 1}: ");
            string[] inputValues = Console.ReadLine().Split(' ');

            array[i] = new int[inputValues.Length];
            for (int j = 0; j < inputValues.Length; j++)
            {
                if (int.TryParse(inputValues[j], out int value))
                {
                    array[i][j] = value;
                }
                else
                {
                    array[i][j] = 0;
                }
            }
        }

        Console.WriteLine("\nResults:");
        for (int i = 0; i < n; i++)
        {
            int min = FindMin(in array[i]);
            int max = FindMax(in array[i]);
            int sum = CalculateSum(in array[i]);

            Console.WriteLine($"Row {i + 1}: Min Value - {min}, Max Value - {max}, Sum of Values - {sum}");
        }
    }

    /// <summary>
    /// Finds the minimum value in a given row.
    /// </summary>
    /// <param name="row">The input row.</param>
    /// <returns>The minimum value in the row.</returns>
    public static int FindMin(in int[] row)
    {
        int min = int.MaxValue;
        foreach (int value in row)
        {
            if (value < min)
            {
                min = value;
            }
        }
        return min;
    }

    /// <summary>
    /// Finds the maximum value in a given row.
    /// </summary>
    /// <param name="row">The input row.</param>
    /// <returns>The maximum value in the row.</returns>
    public static int FindMax(in int[] row)
    {
        int max = int.MinValue;
        foreach (int value in row)
        {
            if (value > max)
            {
                max = value;
            }
        }
        return max;
    }

    /// <summary>
    /// Calculates the sum of values in a given row.
    /// </summary>
    /// <param name="row">The input row.</param>
    /// <returns>The sum of values in the row.</returns>
    public static int CalculateSum(in int[] row)
    {
        int sum = 0;
        foreach (int value in row)
        {
            sum += value;
        }
        return sum;
    }
}
