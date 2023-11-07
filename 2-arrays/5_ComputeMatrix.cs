class ComputeMatrix
{
    static int[] computeMatrix(int[] matrix1, int[] matrix2, int matrixSize)
    {
        int[] matrix3 = new int[matrixSize * matrixSize];

        for (int i = 0; i < matrixSize; i++)
        {
            // Column
            for (int j = 0; j < matrixSize; j++)
            {
                // Row
                for (int k = 0; k < matrixSize; k++)
                {
                    matrix3[i * matrixSize + j] += matrix1[i * matrixSize + k] * matrix2[k * matrixSize + j];
                }
            }
        }
        return matrix3;
    }

    static void Main()
    {
        int matrixSize = 10;
        int[] array1 = new int[matrixSize * matrixSize];
        int[] array2 = new int[matrixSize * matrixSize];

        for (int i = 0; i < matrixSize * matrixSize; i++) {
            Random rnd = new Random();
            array1[i] = rnd.Next(0, 30);
            array2[i] = rnd.Next(0, 30);
        }
        int[] array3 = computeMatrix(array1, array2, matrixSize);
        Console.WriteLine($"[{string.Join(", ", array1)}]\n* [{string.Join(", ", array2)}]\n= [{string.Join(", ", array3)}]");
    }
}
