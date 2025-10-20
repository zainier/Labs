using System;

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point()
    {
        X = 0;
        Y = 0;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Point p1 = new Point();
        Point p2 = new Point(3, 4);

        p1.X = 1;
        p1.Y = 2;

        Console.WriteLine($"Point 1: ({p1.X}, {p1.Y})");
        Console.WriteLine($"Point 2: ({p2.X}, {p2.Y})");
    }
}