using System;

class ArrayConsecutiveCheckerProgram
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 5, 6, 8, 9 };
        bool found = false;

        for (int i = 0; i < array.Length - 1; i++)
        {
            if (Math.Abs(array[i] - array[i + 1]) == 1)
            {
                found = true;
                break;
            }
        }

        if (found)
        {
            Console.WriteLine("The array contains two consecutive numbers with a difference of 1");
        }
        else
        {
            Console.WriteLine("The array does not contain two consecutive numbers with a difference of 1");
        }
    }
}
