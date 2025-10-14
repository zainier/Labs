public class Program
{
    public static void Main(string[] args)
    {
        var numbersHelper = new NumberHelper();

        // TryParseInt
        Console.Write("Please provide an integer number: ");
        bool isNumber = numbersHelper.TryParseInt(Console.ReadLine(), out int number);
        Console.WriteLine($"Is number: {isNumber}, Value: {number}");

        // Banker's Rounding
        float decimalNumber;
        do
        {
            Console.Write("Please provide a float number to round: ");
        } while (!float.TryParse(Console.ReadLine(), out decimalNumber));

        int rounded = numbersHelper.BankersRounding(decimalNumber);
        Console.WriteLine($"Rounded value: {rounded}");
    }
}

    public class NumberHelper
    {
        public bool TryParseInt(string input, out int value)
        {
            value = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char character = input[i];
                int digit = -1;

                switch (character)
                {
                    case '0':
                        digit = 0;
                        break;
                    case '1':
                        digit = 1;
                        break;
                    case '2':
                        digit = 2;
                        break;
                    case '3':
                        digit = 3;
                        break;
                    case '4':
                        digit = 4;
                        break;
                    case '5':
                        digit = 5;
                        break;
                    case '6':
                        digit = 6;
                        break;
                    case '7':
                        digit = 7;
                        break;
                    case '8':
                        digit = 8;
                        break;
                    case '9':
                        digit = 9;
                        break;
                    default:
                        return false;
                }

                value = value * 10 + digit;
            }

            return true;
        }

        public int BankersRounding(float num)
        {
            int wholePart = (int)num;
            float decimalPart = Math.Abs(num - wholePart);

            if (decimalPart > 0.5)
            {
                return wholePart + 1;
            }

            if (decimalPart < 0.5)
            {
                return wholePart;
            }

            if (wholePart % 2 == 0)
            {
                return wholePart;
            }

            return num < 0 ? wholePart - 1 : wholePart + 1;
        }
    }
