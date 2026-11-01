using System;
using System.IO;
using System.Text;

namespace Lab53
{
    internal static class Program
    {
        private const string FilePath = "numbers.txt";

        private const string NumberFormat = "D8";

        private static readonly int LineLength =
            8 + Environment.NewLine.Length;

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            WriteFirstNumber();
            ReadFirstNumber();
            AppendNumbers();
            PrintFile("Крок 4. Вміст файла:");
            ReplaceSecondNumber();
        }

        private static void WriteFirstNumber()
        {
            int first = 1;

            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                writer.WriteLine(first.ToString(NumberFormat));
            }

            Console.WriteLine("Крок 1. Створено файл \"" + FilePath
                + "\", записано число " + first
                + " у форматі D8: " + first.ToString(NumberFormat) + ".");
        }

        private static void ReadFirstNumber()
        {
            int value;

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line = reader.ReadLine();
                value = int.Parse(line);
            }

            Console.WriteLine("Крок 2. Прочитано перше число з файла: "
                + value + " (тип int).");
        }

        private static void AppendNumbers()
        {
            int second = 42;
            int third = 777;

            using (StreamWriter writer =
                new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(second.ToString(NumberFormat));
                writer.WriteLine(third.ToString(NumberFormat));
            }

            Console.WriteLine("Крок 3. Дописано у кінець файла числа "
                + second + " (" + second.ToString(NumberFormat) + ") і "
                + third + " (" + third.ToString(NumberFormat) + ").");
        }

        private static void ReplaceSecondNumber()
        {
            int newSecond = 555;
            int index = 1;

            using (FileStream stream =
                new FileStream(FilePath, FileMode.Open, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                stream.Position = index * LineLength;
                writer.Write(newSecond.ToString(NumberFormat));
            }

            Console.WriteLine("Крок 5. Друге число замінено на "
                + newSecond + " (" + newSecond.ToString(NumberFormat)
                + ") безпосередньо у файлі.");
            PrintFile("Новий вміст файла:");
        }

        private static void PrintFile(string header)
        {
            Console.WriteLine(header);

            using (StreamReader reader = new StreamReader(FilePath))
            {
                int number = 1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine("  " + number + ": " + line);
                    number++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
