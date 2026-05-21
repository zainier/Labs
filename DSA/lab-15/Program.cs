using System;

class Measurement
{
    public double X { get; set; }
    public double Y { get; set; }

    public Measurement(double x, double y)
    {
        X = x;
        Y = y;
    }
}

class LinearFunction
{
    public double Slope { get; set; }
    public double Intercept { get; set; }

    public LinearFunction(double slope, double intercept)
    {
        Slope = slope;
        Intercept = intercept;
    }

    public double Calculate(double x)
    {
        return Slope * x + Intercept;
    }
}

class Program
{
    static void Main()
    {
        List<Measurement> measurements = new List<Measurement>
        {
            new Measurement(1, 2.1),
            new Measurement(2, 2.9),
            new Measurement(3, 4.2),
            new Measurement(4, 5.1),
            new Measurement(5, 5.8),
            new Measurement(6, 7.2)
        };

        LinearFunction linearFunction = BuildLinearFunction(measurements);

        Console.WriteLine("Початкові табличні дані:");
        Console.WriteLine("X\tY");

        foreach (Measurement measurement in measurements)
        {
            Console.WriteLine($"{measurement.X}\t{measurement.Y}");
        }

        Console.WriteLine();
        Console.WriteLine("Лінійна функція апроксимації:");
        Console.WriteLine($"y = {linearFunction.Slope:F4} * x + {linearFunction.Intercept:F4}");

        Console.WriteLine();
        Console.WriteLine("Таблиця апроксимованих значень:");
        Console.WriteLine("X\tY початкове\tY апроксимоване");

        foreach (Measurement measurement in measurements)
        {
            double approximatedY = linearFunction.Calculate(measurement.X);

            Console.WriteLine($"{measurement.X}\t{measurement.Y}\t\t{approximatedY:F4}");
        }

        double forecastX = 8;
        double forecastY = linearFunction.Calculate(forecastX);

        Console.WriteLine();
        Console.WriteLine("Прогнозування значення функції:");
        Console.WriteLine($"X для прогнозу = {forecastX}");
        Console.WriteLine($"Прогнозоване Y = {forecastY:F4}");
    }

    static LinearFunction BuildLinearFunction(List<Measurement> measurements)
    {
        int measurementsCount = measurements.Count;

        double sumX = 0;
        double sumY = 0;
        double sumXY = 0;
        double sumXSquare = 0;

        foreach (Measurement measurement in measurements)
        {
            sumX += measurement.X;
            sumY += measurement.Y;
            sumXY += measurement.X * measurement.Y;
            sumXSquare += measurement.X * measurement.X;
        }

        double slope = (measurementsCount * sumXY - sumX * sumY) /
                       (measurementsCount * sumXSquare - sumX * sumX);

        double intercept = (sumY - slope * sumX) / measurementsCount;

        return new LinearFunction(slope, intercept);
    }
}