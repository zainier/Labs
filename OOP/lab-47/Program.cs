const int Size = 20;

int[] numbers = new int[Size];
Random random = new Random();

for (int i = 0; i < Size; i++)
{
    numbers[i] = random.Next(1, 13);
}

Thread[] threads = new Thread[Size];

for (int i = 0; i < Size; i++)
{
    int num = numbers[i];

    threads[i] = new Thread(() =>
    {
        long numF = Factorial(num);
        Console.WriteLine($"факторіал числа: {num}! = {numF}");
    });

    threads[i].Start();
}

foreach (Thread thread in threads)
{
    thread.Join();
}

Console.WriteLine("Розрахунок закінчено.");

static long Factorial(int n)
{
    long result = 1;
    for (int i = 2; i <= n; i++)
    {
        result *= i;
    }
    return result;
}
