class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the input string:");
        string input = Console.ReadLine().Replace(" ", "");

        Console.WriteLine("Enter the row key:");
        string rowKey = Console.ReadLine();

        Console.WriteLine("Enter the column key:");
        string colKey = Console.ReadLine();

        int rows = rowKey.Length;
        int cols = colKey.Length;

        char[,] matrix = new char[rows, cols];  

        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = input[index++];
            }
        }

        char[,] colPermutedMatrix = new char[rows, cols];
        for (int j = 0; j < cols; j++)
        {
            int colIndex = colKey.IndexOf((j + 1).ToString());
            for (int i = 0; i < rows; i++)
            {
                colPermutedMatrix[i, j] = matrix[i, colIndex];      
            }        
        }

        char[,] finalMatrix = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            int rowIndex = rowKey.IndexOf((i + 1).ToString());
            for (int j = 0; j < cols; j++)
            {
                finalMatrix[i, j] = colPermutedMatrix[rowIndex, j];      
            }        
        }

        Console.WriteLine("Final permuted matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(finalMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }   
    }
}