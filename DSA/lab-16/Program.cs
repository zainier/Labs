using System;

class Program
{
    static double LeftRectangle(Func<double, double> func, double minX, double maxX, int n)
    {
        double step = (maxX - minX) / n;
        double result = 0;

        for (int i = 0; i < n; i++)
        {
            double x = minX + i * step;
            result += func(x) * step;
        }

        return result;
    }

    static double Trapezoid(Func<double, double> func, double minX, double maxX, int n)
    {
        double step = (maxX - minX) / n;
        double result = (func(minX) + func(maxX)) / 2;

        for (int i = 1; i < n; i++)
        {
            double x = minX + i * step;
            result += func(x);
        }

        return result * step;
    }

    static void Main()
    {
        Func<double, double> func = x => x * x + 2 * x + 1;

        double minX = 0;
        double maxX = 1;

        double exactValue = 7.0 / 3.0;

        int[] nValues = { 10, 100, 1000 };

        Console.WriteLine("Функція: f(x) = x^2 + 2x + 1");
        Console.WriteLine("Відрізок: [0, 1]");
        Console.WriteLine("Точне значення інтеграла: " + exactValue);
        Console.WriteLine();

        Console.WriteLine("n\tЛіві прямокутники\tПохибка\t\tМетод трапецій\t\tПохибка");

        foreach (int n in nValues)
        {
            double leftResult = LeftRectangle(func, minX, maxX, n);
            double trapezoidResult = Trapezoid(func, minX, maxX, n);

            double leftError = Math.Abs(exactValue - leftResult);
            double trapezoidError = Math.Abs(exactValue - trapezoidResult);

            Console.WriteLine(
                n + "\t" +
                leftResult.ToString("F10") + "\t\t" +
                leftError.ToString("F10") + "\t" +
                trapezoidResult.ToString("F10") + "\t\t" +
                trapezoidError.ToString("F10")
            );
        }
    }
}