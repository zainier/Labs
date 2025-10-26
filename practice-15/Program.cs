using System;

class Math
{
    public static double ToPower(double number, int power)
    {
        return System.Math.Pow(number, power);
    }

    public static double ToPower(double number)
    {
        return System.Math.Pow(number, 2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        double num = 3;

        Console.WriteLine($"3 to the power of 3 = {Math.ToPower(num, 3)}");
        Console.WriteLine($"Square of 3 = {Math.ToPower(num)}");
    }
}

