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

        Console.WriteLine("Початкова система рівнянь:");
        DisplaySystem(coefficients, freeTerms, variablesCount);

        Console.WriteLine();
        Console.Write("Введіть номер першого рядка для перестановки: ");
        int firstRow = int.Parse(Console.ReadLine()) - 1;

        Console.Write("Введіть номер другого рядка для перестановки: ");
        int secondRow = int.Parse(Console.ReadLine()) - 1;

        SwapRows(coefficients, freeTerms, firstRow, secondRow, variablesCount);

        Console.WriteLine();
        Console.Write("Введіть номер першого стовпця для перестановки: ");
        int firstColumn = int.Parse(Console.ReadLine()) - 1;

        Console.Write("Введіть номер другого стовпця для перестановки: ");
        int secondColumn = int.Parse(Console.ReadLine()) - 1;

        SwapColumns(coefficients, firstColumn, secondColumn, variablesCount);

        Console.WriteLine();
        Console.WriteLine("Система рівнянь після перестановок:");
        DisplaySystem(coefficients, freeTerms, variablesCount);
    }

    static void SwapRows(
        double[,] coefficients,
        double[] freeTerms,
        int firstRow,
        int secondRow,
        int variablesCount
    )
    {
        for (int variableIndex = 0; variableIndex < variablesCount; variableIndex++)
        {
            double temporaryCoefficient = coefficients[firstRow, variableIndex];

            coefficients[firstRow, variableIndex] = coefficients[secondRow, variableIndex];
            coefficients[secondRow, variableIndex] = temporaryCoefficient;
        }

        double temporaryFreeTerm = freeTerms[firstRow];

        freeTerms[firstRow] = freeTerms[secondRow];
        freeTerms[secondRow] = temporaryFreeTerm;
    }

    static void SwapColumns(
        double[,] coefficients,
        int firstColumn,
        int secondColumn,
        int variablesCount
    )
    {
        for (int equationIndex = 0; equationIndex < variablesCount; equationIndex++)
        {
            double temporaryCoefficient = coefficients[equationIndex, firstColumn];

            coefficients[equationIndex, firstColumn] = coefficients[equationIndex, secondColumn];
            coefficients[equationIndex, secondColumn] = temporaryCoefficient;
        }
    }

    static void DisplaySystem(double[,] coefficients, double[] freeTerms, int variablesCount)
    {
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