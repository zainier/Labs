using System;

class IntValue
{
    public int Value { get; set; }

    public IntValue(int value)
    {
        Value = value;
    }

    public static IntValue operator ++(IntValue intValue)
    {
        return new IntValue(intValue.Value + 1);
    }
}

class Program
{
    static void Main(string[] args)
    {

        IntValue num = new IntValue(10);
        Console.WriteLine($"Initial value: {num.Value}");

        IntValue newNum1 = ++num;
        Console.WriteLine($"Value after prefix increment: {newNum1.Value}");
        Console.WriteLine($"Original variable after prefix increment: {num.Value}");

        Console.WriteLine();

        IntValue newNum2 = num++;
        Console.WriteLine($"Value after postfix increment: {newNum2.Value}");
        Console.WriteLine($"Original variable after postfix increment: {num.Value}");
    }
}
