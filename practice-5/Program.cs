class Car
{
    public int Speed { get; private set; }

    public void SpeedUp()
    {
        Speed += 3;
    }

    public void SlowDown()
    {
        Speed = Speed - 10 < 0 ? 0 : Speed - 10;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car myCar = new Car();
        Random random = new Random();

        int times = random.Next(5, 10);
        for (int i = 0; i < times; i++)
        {
            myCar.SpeedUp();
            Console.WriteLine("SpeedUp() called, current speed: " + myCar.Speed);
        }

        myCar.SlowDown();
        Console.WriteLine("SlowDown() called, current speed: " + myCar.Speed);
    }
}