public class Publisher
{
    public string Name { get; set; }

    public Publisher(string name)
    {
        Name = name;
    }
}


public class Book: ICloneable
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
}