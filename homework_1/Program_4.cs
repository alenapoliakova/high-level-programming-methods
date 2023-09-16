using System;

class Program_4
{
    static void Main()
    {
        int number = 2;
        int exponent = 0;

        while (exponent <= 20)
        {
            double result = Math.Pow(number, exponent);
            Console.WriteLine($"{number}^{exponent} = {result}");
            exponent++;
        }
    }
}
