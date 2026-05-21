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

class BallResult
{
    public double InitialVelocity { get; set; }
    public double FlightTime { get; set; }
    public double FinalHeight { get; set; }
    public double FinalVelocity { get; set; }

    public BallResult(double initialVelocity, double flightTime, double finalHeight, double finalVelocity)
    {
        InitialVelocity = initialVelocity;
        FlightTime = flightTime;
        FinalHeight = finalHeight;
        FinalVelocity = finalVelocity;
    }
}

class Program
{
    const double Gravity = 9.81;

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        double initialHeight = 0;
        double step = 0.01;

        double[] initialVelocities = { 10, 20, 30 };

        foreach (double initialVelocity in initialVelocities)
        {
            BallResult result = SimulateBallMovement(initialHeight, initialVelocity, step);

            Console.WriteLine("Початкова швидкість: " + result.InitialVelocity + " м/с");
            Console.WriteLine("Час польоту: " + result.FlightTime.ToString("F2") + " с");
            Console.WriteLine("Остання висота: " + result.FinalHeight.ToString("F4") + " м");
            Console.WriteLine("Швидкість при поверненні: " + result.FinalVelocity.ToString("F4") + " м/с");
            Console.WriteLine();
        }
    }

    static BallResult SimulateBallMovement(double initialHeight, double initialVelocity, double step)
    {
        double[] initialState = {
            0,
            initialHeight,
            initialVelocity
        };

        double[] finalState = EulerSolver.Solve(
            initialState,
            step,
            GetBallStateChange,
            state => state[1] >= 0
        );

        double flightTime = finalState[0];
        double finalHeight = finalState[1];
        double finalVelocity = finalState[2];

        return new BallResult(initialVelocity, flightTime, finalHeight, finalVelocity);
    }

    static double[] GetBallStateChange(double[] state)
    {
        double velocity = state[2];

        return new double[] {
            1,
            velocity,
            -Gravity
        };
    }
}