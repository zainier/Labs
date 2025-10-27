using System;

class Figure
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

class Circle : Figure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Triangle : Figure
{
    public double BaseLength { get; set; }
    public double Height { get; set; }

    public Triangle(double baseLength, double height)
    {
        BaseLength = baseLength;
        Height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * BaseLength * Height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Figure[] figures =
        {
            new Rectangle(5, 10),
            new Circle(4),
            new Triangle(6, 8)
        };

        foreach (Figure figure in figures)
        {
            Console.WriteLine($"Area of {figure.GetType().Name}: {figure.CalculateArea():F2}");
        }
    }
}
