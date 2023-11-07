using System;

class ArrayReplacementProgram
{
    static void Main()
    {
        int[] array = { 1, 0, 2, 0, 0, 3, 4, 0, 5 };
        Console.WriteLine($"Array before replacement: {string.Join(", ", array)}");

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == 0 && i >= 2)
            {
                array[i] = array[i - 1] + array[i - 2];
            }
            else if (array[i] == 0)
            {
                array[i] = array[i - 1];
            }
        }

        Console.WriteLine($"Array after replacement: {string.Join(", ", array)}");
    }
}
