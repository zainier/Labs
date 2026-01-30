public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Group { get; set; }

    public Student(): this("Artem", "Zainier", "IT-32")
    {
    }

    public Student(string firstName): this(firstName, "Zainier", "IT-32")
    {
    }

    public Student(string firstName, string lastName, string group)
    {
        FirstName = firstName;
        LastName = lastName;
        Group = group;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Student: {FirstName} {LastName}, Group: {Group}");
    }
}

public class TestStudent
{
    public static void Main(string[] args)
    {
        Student student1 = new Student();
        student1.DisplayInfo();

        Student student2 = new Student("Kamil");
        student2.DisplayInfo();

        Student student3 = new Student("Kamil", "Nowak", "CS-101");
        student3.DisplayInfo();
    }
}
