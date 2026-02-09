public class Book: ICloneable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925);
        Book book2 = (Book)book1.Clone();

        book1.Title = "The Great Gatsby (Updated Edition)";
        book1.Author = "F. Scott Fitzgerald (Updated Edition)";
        book1.Year = 2020;

        Console.WriteLine("Book 2:");
        Console.WriteLine($"Title: {book2.Title}, Author: {book2.Author}, Year: {book2.Year}");
    }
}