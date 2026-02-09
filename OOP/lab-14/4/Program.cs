public class Publisher
{
    public string Name { get; set; }

    public Publisher(string name)
    {
        Name = name;
    }
}

public class Book : ICloneable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public Publisher Publisher { get; set; }

    public Book(string title, string author, int year, Publisher publisher)
    {
        Title = title;
        Author = author;
        Year = year;
        Publisher = publisher;
    }

    public object Clone()
    {
        return new Book(Title, Author, Year, new Publisher(Publisher.Name));
    }

    public object ShallowClone()
    {
        return this.MemberwiseClone();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Publisher commonPub = new Publisher("Original Publisher");
        Book originalBook = new Book("C# Guide", "John Doe", 2024, commonPub);

        Book shallowBook = (Book)originalBook.ShallowClone();
        Book deepBook = (Book)originalBook.Clone();

        originalBook.Publisher.Name = "NEW PUBLISHER NAME";

        Console.WriteLine($"Original Publisher: {originalBook.Publisher.Name}");
        Console.WriteLine($"Shallow Copy Publisher: {shallowBook.Publisher.Name}");
        Console.WriteLine($"Deep Copy Publisher: {deepBook.Publisher.Name}");
    }
}