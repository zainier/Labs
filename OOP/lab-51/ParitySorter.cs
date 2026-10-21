namespace lab_51;

public class ParitySorter
{
    private const int ArraySize = 1000;
    private const int ThreadCount = 3;

    private readonly int[] fullArray = new int[ArraySize];

    private readonly List<int> evenList = new List<int>();
    private readonly List<int> oddList = new List<int>();

    private int currentIndex;

    // окремі об'єкти блокування для кожного спільного ресурсу
    private readonly object lockIndex = new object();
    private readonly object lockEven = new object();
    private readonly object lockOdd = new object();

    public void Run()
    {
        FillArray();

        var threads = new Thread[ThreadCount];
        for (int i = 0; i < ThreadCount; i++)
        {
            threads[i] = new Thread(Distribute) { Name = $"Worker {i + 1}" };
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        PrintResults();
    }

    private void FillArray()
    {
        var rnd = new Random();
        for (int i = 0; i < fullArray.Length; i++)
        {
            fullArray[i] = rnd.Next(1, 11); // 1..10
        }
    }

    private void Distribute()
    {
        while (true)
        {
            int index;

            // спільний лічильник — беремо наступний індекс під блокуванням
            lock (lockIndex)
            {
                index = currentIndex;
                currentIndex++;
            }

            if (index >= fullArray.Length)
            {
                return;
            }

            int value = fullArray[index];

            if (value % 2 == 0)
            {
                lock (lockEven)
                {
                    evenList.Add(value);
                }
            }
            else
            {
                lock (lockOdd)
                {
                    oddList.Add(value);
                }
            }
        }
    }

    private void PrintResults()
    {
        Console.WriteLine($"Усього елементів у масиві: {fullArray.Length}");
        Console.WriteLine($"Парних: {evenList.Count}, непарних: {oddList.Count}, " +
                          $"разом: {evenList.Count + oddList.Count}");
        Console.WriteLine();

        Console.WriteLine("Парні елементи (evenList):");
        Console.WriteLine(string.Join(", ", evenList));
        Console.WriteLine();

        Console.WriteLine("Непарні елементи (oddList):");
        Console.WriteLine(string.Join(", ", oddList));
    }
}
