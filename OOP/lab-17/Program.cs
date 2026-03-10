class StudentGrades
{
    private Dictionary<string, int> _grades = new Dictionary<string, int>();
    
    public int this[string name]
    {
        get
        {
            if (_grades.ContainsKey(name))
            {
                return _grades[name];
            }
            throw new KeyNotFoundException($"Студента з ім'ям '{name}' не знайдено.");
        }
        set
        {
            if (_grades.ContainsKey(name))
            {
                _grades[name] = value;
            }
            else
            {
                _grades.Add(name, value);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        StudentGrades studentGrades = new StudentGrades();

        studentGrades["Alice"] = 85;
        studentGrades["Bob"] = 92;

        Console.WriteLine($"Оцінка Alice: {studentGrades["Alice"]}");
        Console.WriteLine($"Оцінка Bob: {studentGrades["Bob"]}");

        try
        {
            Console.WriteLine($"Оцінка Charlie: {studentGrades["Charlie"]}");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}