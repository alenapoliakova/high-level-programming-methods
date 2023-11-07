using System;

class ArrayInsertionProgram
{
    static int[] InsertElements(int[] originalArray, int[] elementsToInsert, int K)
    {
        if (K < 0 || K > originalArray.Length)
        {
            throw new ArgumentOutOfRangeException("K is out of range");
        }

        int newSize = originalArray.Length + elementsToInsert.Length;
        int[] resultArray = new int[newSize];

        for (int i = 0; i < K; i++)
        {
            resultArray[i] = originalArray[i];
        }

        for (int i = 0; i < elementsToInsert.Length; i++)
        {
            resultArray[K + i] = elementsToInsert[i];
        }

        for (int i = K; i < originalArray.Length; i++)
        {
            resultArray[i + elementsToInsert.Length] = originalArray[i];
        }

        return resultArray;
    }

    static void Main()
    {
        int[] originalArray = { 1, 2, 3, 4, 5 };
        int[] elementsToInsert = { 10, 11, 12 };
        int K = 2;

        Console.WriteLine($"Original array: {string.Join(", ", originalArray)}");
        Console.WriteLine($"Elements to insert: {string.Join(", ", elementsToInsert)}");
        Console.WriteLine($"Position K: {K}");

        int[] resultArray = InsertElements(originalArray, elementsToInsert, K);

        Console.WriteLine($"Result after insertion: {string.Join(", ", resultArray)}");
    }
}
