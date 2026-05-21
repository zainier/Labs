using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Введіть кількість змінних: ");
        int variablesCount = int.Parse(Console.ReadLine());

        double[,] coefficients = new double[variablesCount, variablesCount];
        double[] freeTerms = new double[variablesCount];

        Console.WriteLine();

        for (int equationIndex = 0; equationIndex < variablesCount; equationIndex++)
        {
            Console.WriteLine("Рівняння " + ToSubscript(equationIndex + 1));

            for (int variableIndex = 0; variableIndex < variablesCount; variableIndex++)
            {
                Console.Write(
                    "Введіть коефіцієнт a" +
                    ToSubscript(equationIndex + 1) +
                    ToSubscript(variableIndex + 1) +
                    ": "
                );

                coefficients[equationIndex, variableIndex] = double.Parse(Console.ReadLine());
            }

            Console.Write("Введіть вільний член b" + ToSubscript(equationIndex + 1) + ": ");
            freeTerms[equationIndex] = double.Parse(Console.ReadLine());

            Console.WriteLine();
        }

        Console.WriteLine("Система лінійних алгебраїчних рівнянь:");
        Console.WriteLine();

        for (int equationIndex = 0; equationIndex < variablesCount; equationIndex++)
        {
            for (int variableIndex = 0; variableIndex < variablesCount; variableIndex++)
            {
                double currentCoefficient = coefficients[equationIndex, variableIndex];

                if (variableIndex > 0)
                {
                    if (currentCoefficient >= 0)
                    {
                        Console.Write(" + ");
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }
                else if (currentCoefficient < 0)
                {
                    Console.Write("-");
                }

                Console.Write(Math.Abs(currentCoefficient) + "x" + ToSubscript(variableIndex + 1));
            }

            Console.WriteLine(" = " + freeTerms[equationIndex]);
        }
    }

    static string ToSubscript(int number)
    {
        string[] digits = { "₀", "₁", "₂", "₃", "₄", "₅", "₆", "₇", "₈", "₉" };

        string result = "";

        foreach (char digit in number.ToString())
        {
            result += digits[digit - '0'];
        }

        return result;
    }
}