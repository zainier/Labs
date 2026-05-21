using System;

class RootResult
{
    public double Root { get; set; }
    public int Iterations { get; set; }
    public double Error { get; set; }
}

class RootFinder
{
    private const int MaxIterations = 1000;

    public double Function(double x)
    {
        return Math.Pow(x, 3) - x - 2;
    }

    public double Derivative(double x)
    {
        return 3 * Math.Pow(x, 2) - 1;
    }

    public RootResult SecantMethod(double a, double b, double epsilon)
    {
        double x0 = a;
        double x1 = b;
        double x2 = x1;

        int iterations = 0;

        while (iterations < MaxIterations)
        {
            x2 = x1 - Function(x1) * (x1 - x0) / (Function(x1) - Function(x0));
            iterations++;

            if (Math.Abs(x2 - x1) < epsilon)
            {
                break;
            }

            x0 = x1;
            x1 = x2;
        }

        return new RootResult
        {
            Root = x2,
            Iterations = iterations,
            Error = Math.Abs(Function(x2))
        };
    }

    public RootResult NewtonMethod(double startX, double epsilon)
    {
        double x = startX;
        int iterations = 0;

        while (iterations < MaxIterations)
        {
            double nextX = x - Function(x) / Derivative(x);
            iterations++;

            if (Math.Abs(nextX - x) < epsilon)
            {
                x = nextX;
                break;
            }

            x = nextX;
        }

        return new RootResult
        {
            Root = x,
            Iterations = iterations,
            Error = Math.Abs(Function(x))
        };
    }
}

class Program
{
    static void Main()
    {
        RootFinder rootFinder = new RootFinder();

        double a = 1;
        double b = 2;
        double epsilon = 0.000001;

        Console.WriteLine("Функція: f(x) = x^3 - x - 2");
        Console.WriteLine($"Проміжок: [{a}; {b}]");
        Console.WriteLine($"Точність: {epsilon}");
        Console.WriteLine();

        if (rootFinder.Function(a) * rootFinder.Function(b) > 0)
        {
            Console.WriteLine("На заданому проміжку немає гарантованого кореня.");
            return;
        }

        RootResult secantResult = rootFinder.SecantMethod(a, b, epsilon);
        RootResult newtonResult = rootFinder.NewtonMethod(b, epsilon);

        Console.WriteLine("Метод хорд:");
        Console.WriteLine($"Корінь: {secantResult.Root}");
        Console.WriteLine($"Кількість ітерацій: {secantResult.Iterations}");
        Console.WriteLine($"Похибка: {secantResult.Error}");
        Console.WriteLine();

        Console.WriteLine("Метод дотичних:");
        Console.WriteLine($"Корінь: {newtonResult.Root}");
        Console.WriteLine($"Кількість ітерацій: {newtonResult.Iterations}");
        Console.WriteLine($"Похибка: {newtonResult.Error}");
        Console.WriteLine();

        Console.WriteLine("Порівняння:");

        if (newtonResult.Iterations < secantResult.Iterations)
        {
            Console.WriteLine("Метод дотичних виконав менше ітерацій.");
        }
        else if (secantResult.Iterations < newtonResult.Iterations)
        {
            Console.WriteLine("Метод хорд виконав менше ітерацій.");
        }
        else
        {
            Console.WriteLine("Обидва методи виконали однакову кількість ітерацій.");
        }

        Console.WriteLine();
        Console.WriteLine("Пояснення:");
        Console.WriteLine("Метод дотичних зазвичай швидший, тому що використовує похідну функції.");
        Console.WriteLine("Метод хорд не використовує похідну, тому може потребувати більше ітерацій.");
    }
}