using System;

public class AmdahlLaw
{
    public static void Main(string[] args)
    {
        for (int p = 5; p <= 100; p += 5)
        {
            Console.Write($"\t{p}%");
        }
        Console.WriteLine();

        for (int n = 1; n <= 10; n++)
        {
            Console.Write($"{n}");

            for (int p = 5; p <= 100; p += 5)
            {
                double pFrac = p / 100.0;
                double speedup = 1 / ((1 - pFrac) + pFrac / n);
                Console.Write($"\t{speedup.ToString("F2")}");
            }

            Console.WriteLine();
        }
    }
}