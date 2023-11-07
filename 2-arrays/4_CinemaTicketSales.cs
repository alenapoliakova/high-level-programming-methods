using System;

class CinemaTicketSalesProgram
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split();
        int rowCount = int.Parse(dimensions[0]);
        int seatsPerRow = int.Parse(dimensions[1]);

        int[][] theater = new int[rowCount][];
        int foundRow = 0;
        bool found = false;

        // Заполняем двумерный массив информацией о проданных билетах
        for (int idx = 0; idx < rowCount; idx++)
        {
            theater[idx] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        }

        int requiredSeats = int.Parse(Console.ReadLine());

        for (int idx = 0; idx < rowCount; idx++)
        {
            int consecutiveAvailableSeats = 0;

            for (int idx2 = 0; idx2 < seatsPerRow; idx2++)
            {
                if (theater[idx][idx2] == 0)
                {
                    consecutiveAvailableSeats++;

                    if (consecutiveAvailableSeats == requiredSeats)
                    {
                        foundRow = idx + 1;
                        found = true;
                        break;
                    }
                }
                else
                {
                    consecutiveAvailableSeats = 0;
                }
            }

            if (found)
                break;
        }

        Console.WriteLine(foundRow);
    }
}
