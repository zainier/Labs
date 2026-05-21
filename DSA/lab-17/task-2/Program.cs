using System;
using System.Text;

class EulerSolver
{
    public static double[] Solve(
        double[] initialState,
        double step,
        Func<double[], double[]> stateChange,
        Func<double[], bool> shouldContinue)
    {
        double[] currentState = (double[])initialState.Clone();

        while (shouldContinue(currentState))
        {
            double[] changes = stateChange(currentState);
            double[] nextState = new double[currentState.Length];

            for (int i = 0; i < currentState.Length; i++)
            {
                nextState[i] = currentState[i] + step * changes[i];
            }

            currentState = nextState;
        }

        return currentState;
    }
}

class TeaResult
{
    public double Time { get; set; }
    public double FinalTemperature { get; set; }

    public TeaResult(double time, double finalTemperature)
    {
        Time = time;
        FinalTemperature = finalTemperature;
    }
}

class Program
{
    const double ComfortableTemperature = 57.8;
    const double CoolingCoefficient = 0.05;

    static double environmentTemperature;

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Введіть початкову температуру окропу: ");
        double initialTemperature = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть температуру навколишнього середовища: ");
        environmentTemperature = Convert.ToDouble(Console.ReadLine());

        double step = 0.1;

        TeaResult result = CalculateCoolingTime(initialTemperature, step);

        Console.WriteLine();
        Console.WriteLine("Комфортна температура пиття: " + ComfortableTemperature + " °C");
        Console.WriteLine("Час очікування: " + result.Time.ToString("F2") + " хв");
        Console.WriteLine("Остання обчислена температура: " + result.FinalTemperature.ToString("F2") + " °C");
    }

    static TeaResult CalculateCoolingTime(double initialTemperature, double step)
    {
        double[] initialState = {
            0,
            initialTemperature
        };

        double[] finalState = EulerSolver.Solve(
            initialState,
            step,
            GetTeaTemperatureChange,
            state => state[1] > ComfortableTemperature
        );

        double time = finalState[0];
        double finalTemperature = finalState[1];

        return new TeaResult(time, finalTemperature);
    }

    static double[] GetTeaTemperatureChange(double[] state)
    {
        double temperature = state[1];

        return new double[] {
            1,
            -CoolingCoefficient * (temperature - environmentTemperature)
        };
    }
}