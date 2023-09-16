using System;

class Program_1
{
    static void Main()
    {
        Console.Write("Write fist number: ");
        if (double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.Write("Write second number: ");
            if (double.TryParse(Console.ReadLine(), out double num2))
            {
                double max = Math.Max(num1, num2);
                Console.WriteLine($"Max({num1}, {num2}) = {max}");
            }
            else Console.WriteLine("Incorrect second number");
        }
        else Console.WriteLine("Incorrect first number");
    }
}
