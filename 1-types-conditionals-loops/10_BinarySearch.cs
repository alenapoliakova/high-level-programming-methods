/*
Algorithm (binary search):
1. Set the minimum range value (min) to 1 and the maximum range value (max) to 100.
2. Set the attempts counter to 0.
3. While min <= max:
a. Calculate the midpoint of the range (mid) as (min + max) / 2.
b. Increase the attempt counter by 1 (attempts = attempts + 1).
c. Suggest the mid number as a computer attempt.
d. If the mid number is equal to the hidden number, then the computer guessed the number, end the game.
e. If the mid number is greater than the desired number, set max to mid - 1.
f. If the mid number is less than the desired number, set min to mid + 1.
4. The game ends if min > max (the range is exhausted) and the computer has not guessed the number.
5. Output the number of attempts that it took the computer to guess.
 */
using System;

class BinarySearchProgram
{
    static void Main()
    {
        int minValue = 1, maxValue = 100, attempts = 0, targetNumber=0;
        Console.WriteLine("Think of a number between 1 and 100, I will try to guess it");

        while (minValue <= maxValue)
        {
            int middle = (minValue + maxValue) / 2;
            attempts++;

            Console.WriteLine($"Is your number {middle}? (yes/no)");
            string response = Console.ReadLine().ToLower();

            if (response == "yes")
            {
                targetNumber = middle;
                break;
            }
            else if (response == "no")
            {
                Console.WriteLine($"Is your number greater than {middle}? (yes/no)");
                string greaterResponse = Console.ReadLine().ToLower();

                if (greaterResponse == "yes") minValue = middle + 1;
                else if (greaterResponse == "no") maxValue = middle - 1;
                else Console.WriteLine("You entered invalid response, skipped");
            }
            else Console.WriteLine("You entered invalid response, skipped");
        }

        Console.WriteLine($"I guessed your number {targetNumber} in {attempts} attempts!");
    }
}
