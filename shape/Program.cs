public class Shape
{
    public virtual double GetArea()
    {
        return 0;
    }

    public virtual void GetInfo()
    {
        System.Console.WriteLine($"Area: {GetArea()}");
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double GetArea()
    {
        return System.Math.PI * Radius * Radius;
    }

    public override void GetInfo()
    {
        System.Console.WriteLine($"Circle with radius {Radius}, Area: {GetArea()}");
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double GetArea()
    {
        return Width * Height;
    }

    public override void GetInfo()
    {
        System.Console.WriteLine($"Rectangle with width {Width} and height {Height}, Area: {GetArea()}");
    }
}

public class Program
{
    public static void Main()
    {
        Shape[] shapes =
        [
            new Circle { Radius = 5 },
            new Circle { Radius = 10 },
            new Rectangle { Width = 4, Height = 6 },
            new Rectangle { Width = 10, Height = 20 },
        ];

        foreach (var shape in shapes)
        {
            shape.GetInfo();
        }
    }
}