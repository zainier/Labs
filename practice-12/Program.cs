class Animal
{
    public string Name { get; }

    public string Says { get;}

    public Animal(string name, string says)
    {
        Name = name;
        Says = says;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"{Name} says {Says}");
    }
}

class Dog : Animal
{
    public Dog() : base("Dog", "Woof")
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal animal = new Dog();
        animal.PrintInfo();
    }
}