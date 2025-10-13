using System;
using System.Text;

public class CaesarCipher
{
    public static string Encrypt(string text, int shift)
    {
        StringBuilder result = new StringBuilder();

        foreach (char character in text)
        {
            if (character >= 'a' && character <= 'z')
            {
                char encryptedChar = (char)((((character - 'a') + shift) % 26) + 'a');
                result.Append(encryptedChar);
            }
            else
            {
                result.Append(character);
            }

        }

        return result.ToString();
    }

    public static int BruteForce(string encrypted, string original)
    {
        int iterations = 0;

        for (int shift = 1; shift < 26; shift++)
        {
            iterations++;

            if (Decrypt(encrypted, shift) == original)
            {
                return iterations;
            }
        }

        return -1;
    }

    public static string Decrypt(string text, int shift)
    {
        return Encrypt(text, 26 - shift);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter text to encrypt:");
        string text = Console.ReadLine()?.ToLower() ?? "";

        Random random = new Random();
        int shift = random.Next(1, 26);

        string encryptedText = CaesarCipher.Encrypt(text, shift);

        Console.WriteLine($"Random shift value: {shift}");
        Console.WriteLine($"Encrypted text: {encryptedText}");

        int iterations = CaesarCipher.BruteForce(encryptedText, text);
        Console.WriteLine($"Number of iterations: {iterations}");
    }
}

