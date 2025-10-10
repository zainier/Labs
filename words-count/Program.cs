using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int wordCount = 0;
        bool inWord = false;

        foreach (char c in input)
        {
            if (!char.IsWhiteSpace(c))
            {
                if (!inWord)
                {
                    wordCount++;
                    inWord = true;
                }
            }
            else
            {
                inWord = false;
            }
        }

        Console.WriteLine("Number of words: " + wordCount);
    }
}
