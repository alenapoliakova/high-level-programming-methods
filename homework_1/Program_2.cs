using System;

class Program_2
{
    static void Main()
    {
        Console.Write("Write number: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine($"Number divisors {number} from 2 to 10:");
            for (int i = 2; i <= 10; i++)
            {
                if (number % i == 0) Console.WriteLine($"- {i}");
            }
        }
        else Console.WriteLine("Incorrect number");
    }
}
