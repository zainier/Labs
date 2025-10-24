class IntValue
{
    public int Value { get; set; }

    public IntValue(int value)
    {
        Value = value;
    }

    public static IntValue operator +(IntValue a, IntValue b)
    {
        return new IntValue(a.Value + b.Value);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IntValue a = new IntValue(5);
        IntValue b = new IntValue(10);
        IntValue c = a + b;
        System.Console.WriteLine(c.Value);
    }
}