public struct Time 
{
    private int _seconds;

    public int Hours { get { return _seconds / 3600; } }
    public int Minutes { get { return _seconds % 3600 / 60; } }
    public int Seconds { get { return _seconds % 60; } }

    public Time(int hours, int minutes, int seconds) 
    {
        _seconds = hours * 3600 + minutes * 60 + seconds;
        if (_seconds < 0)
        {
            throw new ArgumentException("Time cannot be negative.");
        }
    }

    public Time(int seconds): this(0, 0, seconds)
    {
    }   

    public double TotalHours()
    {
        return _seconds / 3600.0;
    }

    public double TotalMinutes()
    {
        return _seconds / 60.0;
    }

    public int TotalSeconds()
    {
        return _seconds;
    }

    public static Time operator +(Time t1, Time t2)
    {
        return new Time(t1._seconds + t2._seconds);
    }

    public static Time operator -(Time t1, Time t2)
    {
        if (t1._seconds < t2._seconds)
        {
            throw new InvalidOperationException("Resulting time cannot be negative.");
        }

        return new Time(t1._seconds - t2._seconds);
    }

    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Time time1 = new Time(1, 30, 45);
        Time time2 = new Time(5000);

        Console.WriteLine($"Time 1: {time1}");
        Console.WriteLine($"Time 2: {time2}");

        Time sum = time1 + time2;
        Console.WriteLine($"Sum: {sum}");
        
        Time positiveDiff = time1 - time2;
        Console.WriteLine($"Difference: {positiveDiff}");

        try
        {
            Time negativeDiff = time2 - time1;
            Console.WriteLine($"Difference: {negativeDiff}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}