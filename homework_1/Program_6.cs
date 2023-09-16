using System;

class Program_6
{
    static void Main()
    {
        Console.Write("Enter the lower number: ");
        if (int.TryParse(Console.ReadLine(), out int lowerNumber))
        {
            Console.Write("Enter the upper number: ");
            if (int.TryParse(Console.ReadLine(), out int upperNumber))
            {
                if (lowerNumber <= upperNumber)
                {
                    int divisibleBy3Count = 0, divisibleBy5Count = 0, divisibleBy9Count = 0;

                    for (int currentNum = lowerNumber; currentNum <= upperNumber; currentNum++)
                    {
                        if (currentNum % 3 == 0 && currentNum % 5 == 0 && currentNum % 9 == 0)
                        {
                            Console.WriteLine($"Divisible by 3, 5 and 9: {currentNum}");
                            divisibleBy3Count++;
                            divisibleBy5Count++;
                            divisibleBy9Count++;
                        }
                        else if (currentNum % 3 == 0 && currentNum % 5 == 0)
                        {
                            divisibleBy3Count++;
                            divisibleBy5Count++;
                        }
                        else if (currentNum % 3 == 0 && currentNum % 9 == 0)
                        {
                            divisibleBy3Count++;
                            divisibleBy9Count++;
                        }
                        else if (currentNum % 5 == 0 && currentNum % 9 == 0)
                        {
                            divisibleBy5Count++;
                            divisibleBy9Count++;
                        }
                        else if (currentNum % 3 == 0) divisibleBy3Count++;
                        else if (currentNum % 5 == 0) divisibleBy5Count++;
                        else if (currentNum % 9 == 0) divisibleBy9Count++;
                    }

                    Console.WriteLine($"Amount of numbers divisible by 3: {divisibleBy3Count}");
                    Console.WriteLine($"Amount of numbers divisible by 5: {divisibleBy5Count}");
                    Console.WriteLine($"Amount of numbers divisible by 9: {divisibleBy9Count}");
                }
                else Console.WriteLine("Lower number should be less than or equal to the upper number");
            }
            else Console.WriteLine("Incorrect upper number");
        }
        else Console.WriteLine("Incorrect lower number");
    }
}
