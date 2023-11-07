using System;

class GuessingGameProgram
{
    static void Main()
    {
        int targetNumber = new Random().Next(1, 51), attempts = 0, guess;
        bool isGuessed = false;
        Console.WriteLine("Try to guess number from 1 to 50");
        Console.WriteLine(targetNumber);

        do
        {
            Console.Write("Enter your guess: ");
            if (int.TryParse(Console.ReadLine(), out guess))
            {
                attempts++;
                if (guess == targetNumber)
                {
                    isGuessed = true;
                    Console.WriteLine($"You guessed the number {targetNumber} in {attempts} attempts");
                }
                else if (guess < targetNumber) Console.WriteLine("The target number is greater, try again");
                else Console.WriteLine("The target number is smaller, try again");
            }
            else Console.WriteLine("Incorrect number, attempt skipped");
        } while (!isGuessed);
    }
}
