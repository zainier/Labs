class Car
{
    private string keyCode;

    public string Model { get; set; }

    public void SpeedUp()
    {
        Console.WriteLine("Speeding up");
    }

    public void SpeedDown()
    {
        Console.WriteLine("Slowing down");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car myCar = new Car();
        myCar.Model = "Toyota";

        Console.WriteLine($"Car model: {myCar.Model}");
        myCar.SpeedUp();
        myCar.SpeedDown();
    }
}
