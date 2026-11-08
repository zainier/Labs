using System;
using System.IO;
using System.Text;

public class Student
{
    public int OrderNo { get; set; }
    public string StudentName { get; set; }
}

class Program
{
    private const string FilePath = "students.bin";

    public static void WriteStudent(BinaryWriter writer, Student student)
    {
        byte[] nameBytes = Encoding.UTF8.GetBytes(student.StudentName);
 
        writer.Write(student.OrderNo);
        writer.Write(nameBytes.Length);
        writer.Write(nameBytes);
    }

    public static Student ReadStudent(BinaryReader reader)
    {
        int orderNo = reader.ReadInt32();
        int nameLength = reader.ReadInt32();

        byte[] nameBytes = reader.ReadBytes(nameLength);
        string name = Encoding.UTF8.GetString(nameBytes);

        return new Student
        {
            OrderNo = orderNo,
            StudentName = name  
        };
    }

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<Student> studentsWrite = new List<Student>
        {
            new Student { OrderNo = 1, StudentName = "Артем" },
            new Student { OrderNo = 2, StudentName = "Микола" },
            new Student { OrderNo = 3, StudentName = "" },
            new Student { OrderNo = 4, StudentName = "Дмитро" },
            new Student { OrderNo = 5, StudentName = "Катерина" }
        };

        // Write the array of students to a binary file
        using (FileStream stream = new FileStream(FilePath, FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(stream))
        {
            foreach (var student in studentsWrite)
            {
                WriteStudent(writer, student);
            }
        }

        // Read the array of students from the binary file
        List<Student> studentsRead = new List<Student>();
        using (FileStream stream = new FileStream(FilePath, FileMode.Open))
        using (BinaryReader reader = new BinaryReader(stream))
        {
            while (stream.Position < stream.Length)
            {
                studentsRead.Add(ReadStudent(reader));
            }
        }

        foreach (var student in studentsRead)
        {
            Console.WriteLine($"OrderNo: {student.OrderNo}, StudentName: {student.StudentName}");
        }
    }
}

