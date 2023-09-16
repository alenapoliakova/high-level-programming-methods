using System;

class Program_5
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            int evenCnt = 0, oddCnt = 0;
            for (int num = 1; num <= number; num++)
            {
                if (num % 2 == 0) evenCnt++;
                else oddCnt++;
            }
            Console.WriteLine($"Even numbers amount: {evenCnt}\nOdd numbers amount: {oddCnt}");
        }
        else Console.WriteLine("Incorrect number");
    }
}
