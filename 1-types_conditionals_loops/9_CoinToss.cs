using System;

class CoinTossProgram
{
    static void Main()
    {
        Random random = new Random();
        int headsCnt = 0, tailsCnt = 0;

        for (int i = 0; i < 100; i++)
        {
            // 0 or 1 (head or tail)
            int result = random.Next(2);
            if (result == 0) headsCnt++;
            else tailsCnt++;
        }

        Console.WriteLine($"Heads count: {headsCnt}");
        Console.WriteLine($"Tails count: {tailsCnt}");
    }
}
