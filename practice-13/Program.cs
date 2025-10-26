using System;

class Expression
{
    public string Value { get; }

    public Expression(string value)
    {
        Value = value;
    }
}

class LongExpression : Expression
{
    public int Length { get; }
    
    public LongExpression(string value) : base(value)
    {
        Length = value.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LongExpression longExpr = new LongExpression("x + y - z");
        Console.WriteLine($"Expression: {longExpr.Value}");
        Console.WriteLine($"Length: {longExpr.Length}");
    }
}