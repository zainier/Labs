using System;

class IntValue
{
    public int Value { get; set; }

    public IntValue(int value)
    {
        Value = value;
    }

    public static bool operator >(IntValue a, IntValue b)
    {
        return a.Value > b.Value;
    }

    public static bool operator <(IntValue a, IntValue b)
    {
        return a.Value < b.Value;
    }
}

class Program
{
    static void Main(string[] args)
    {
        IntValue a = new IntValue(5);
        IntValue b = new IntValue(10);

        Console.WriteLine(a > b ? "a is greater than b" : "b is greater than a");
    }
}