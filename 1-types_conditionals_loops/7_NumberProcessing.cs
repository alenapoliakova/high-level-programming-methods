using System;

class NumberProcessingProgram
{
    static void Main()
    {
        double sum = 0, maxNumber = double.MinValue, amount = 10;
        for (int idx = 1; idx <= amount; idx++)
        {
            Console.Write($"Enter number {idx}: ");
            if (double.TryParse(Console.ReadLine(), out double number))
            {
                sum += number;
                if (number > maxNumber) maxNumber = number;
            }
            else Console.WriteLine($"Incorrect number {idx}, skipped");
        }
        Console.WriteLine($"Max={maxNumber} average={sum / amount}");
    }
}
