public class Book
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

    public Book(Book other)
    {
        Title = other.Title;
        Author = other.Author;
        Year = other.Year;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925);
        Book book2 = new Book(book1);
        Book book3 = new Book(book2);

        Console.WriteLine($"Book 1: {book1.Title}, {book1.Author}, {book1.Year}");
        Console.WriteLine($"Book 2: {book2.Title}, {book2.Author}, {book2.Year}");
        Console.WriteLine($"Book 3: {book3.Title}, {book3.Author}, {book3.Year}");

        book1.Title = "The NOT So Great Gatsby";
        Console.WriteLine(book2.Title);
    }
}