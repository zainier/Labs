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
        if (encrypted.Length != original.Length)
        {
            return -1;
        }

        for (int i = 0; i < encrypted.Length; i++)
        {
            char e = encrypted[i];
            char o = original[i];

            if (e >= 'a' && e <= 'z' && o >= 'a' && o <= 'z')
            {
                int shift = (e - o + 26) % 26;

                string attempt = Decrypt(encrypted, shift);

                return attempt == original ? 1 : -1;
            }
        }

        return 0;
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

