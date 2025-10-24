class MathOperation
{
    public virtual float Calculate(float a, float b)
    {
        return 0;
    }
}

class SumOperation : MathOperation
{
    public override float Calculate(float a, float b)
    {
        return a + b;
    }
}

class MultiplyOperation : MathOperation
{
    public override float Calculate(float a, float b)
    {
        return a * b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MathOperation sumOp = new SumOperation();
        MathOperation mulOp = new MultiplyOperation();

        float sumResult = sumOp.Calculate(5, 10);
        float mulResult = mulOp.Calculate(5, 10);

        Console.WriteLine($"Sum: {sumResult}");
        Console.WriteLine($"Multiplication: {mulResult}");
    }
}