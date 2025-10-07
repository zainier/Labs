using System;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point() : this(0, 0) { }
}

public class Segment
{
    public Point A { get; set; }
    public Point B { get; set; }

    public Segment(Point a, Point b)
    {
        A = a;
        B = b;
    }

    public double Length => Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
    public int TopY => Math.Max(A.Y, B.Y);
    public int BottomY => Math.Min(A.Y, B.Y);
}

public class SegmentList
{
    public Segment[] Segments { get; set; }

    public SegmentList(Segment[] segments)
    {
        Segments = segments;
    }

    public Segment FindHighest()
    {     
        Segment highest = Segments[0];

        for (int i = 1; i < Segments.Length; i++)
        {
            var s = Segments[i];
            if (s.TopY > highest.TopY || (s.TopY == highest.TopY && s.BottomY > highest.BottomY))
            {
                highest = s;
            }
        }

        return highest;
    }

    public Segment FindShortest()
    {            
        Segment shortest = Segments[0];

        for (int i = 1; i < Segments.Length; i++)
        {
            if (Segments[i].Length < shortest.Length)
            {
                shortest = Segments[i];
            }
        }

        return shortest;
    }
}

public class Program
{
    public static void Main()
    {
        Point a1 = new Point(0, 0);
        Point b1 = new Point(3, 4);

        Point a2 = new Point(1, 5);
        Point b2 = new Point(4, 9);

        Point a3 = new Point(2, 2);
        Point b3 = new Point(2, 3);

        Segment s1 = new Segment(a1, b1);
        Segment s2 = new Segment(a2, b2);
        Segment s3 = new Segment(a3, b3);

        SegmentList list = new SegmentList(new Segment[] { s1, s2, s3 });

        Segment highest = list.FindHighest();
        Segment shortest = list.FindShortest();

        Console.WriteLine("Highest segment:");
        Console.WriteLine($"A({highest.A.X},{highest.A.Y}), B({highest.B.X},{highest.B.Y})");

        Console.WriteLine("\nShortest segment:");
        Console.WriteLine($"A({shortest.A.X},{shortest.A.Y}), B({shortest.B.X},{shortest.B.Y})");
    }
}
