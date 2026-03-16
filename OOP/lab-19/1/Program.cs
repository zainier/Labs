class Shape
{
    public void ShowArea()
    {
       Console.WriteLine($"Area of the shape: {CalcArea()}");
    }

    protected virtual double CalcArea()
    {
       return 0;
    }
}

class Circle : Shape
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    protected override double CalcArea()
    {
        return Math.PI * radius * radius;
    }
}

class Rectangle : Shape
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    protected override double CalcArea()
    {
        return width * height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(4, 6);

        circle.ShowArea();
        rectangle.ShowArea();
    }
}