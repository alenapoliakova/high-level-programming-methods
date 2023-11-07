using System;

class ArraySwapProgram
{
    static void SwapArrayHalves(int[] array)
    {
        int middle = array.Length / 2;

        for (int i = 0; i < middle; i++)
        {
            int temp = array[i];
            array[i] = array[i + middle];
            array[i + middle] = temp;
        }
    }

    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
        Console.WriteLine($"Original array: {string.Join(", ", array)}");
        SwapArrayHalves(array);
        Console.WriteLine($"Result after swapping halves: {string.Join(", ", array)}");
    }
}
