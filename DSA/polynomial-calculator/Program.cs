class Program
    {
        static void Main(string[] args)
        {
            // Запит степеня многочлена
            Console.Write("Введіть степінь многочлена: ");
            int degree = int.Parse(Console.ReadLine());

            double[] coefficients = new double[degree + 1];

            // Запит коефіцієнтів
            for (int i = 0; i <= degree; i++)
            {
                int currentPower = degree - i;
                Console.Write($"Введіть коефіцієнт для x^{currentPower}: ");
                coefficients[i] = double.Parse(Console.ReadLine());
            }

            // Виведення сформованого многочлена
            Console.Write("\nСформований многочлен: ");
            for (int i = 0; i <= degree; i++)
            {
                int currentPower = degree - i;
                Console.Write($"{coefficients[i]}*x^{currentPower}");
                
                if (i < degree)
                {
                    Console.Write(" + ");
                }
            }
            Console.WriteLine();

            // Запит значення X
            Console.Write("\nВведіть довільне значення X для обрахунку: ");
            double x = double.Parse(Console.ReadLine());

            // Стандартний (прямий) обрахунок
            double standardResult = 0;
            for (int i = 0; i <= degree; i++)
            {
                standardResult += coefficients[i] * Math.Pow(x, degree - i);
            }
            Console.WriteLine($"\nРезультат (стандартний обрахунок): {standardResult}");

            // Обрахунок за схемою Горнера
            double hornerResult = coefficients[0];
            for (int i = 1; i <= degree; i++)
            {
                hornerResult = hornerResult * x + coefficients[i];
            }
            Console.WriteLine($"Результат (схема Горнера): {hornerResult}");
        }
    }