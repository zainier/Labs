using System.Diagnostics;

public class ChainingHashTable
{
    private List<string>[] _table;

    public ChainingHashTable(int size)
    {
        _table = new List<string>[size];
        for (int i = 0; i < size; i++)
        {
            _table[i] = new List<string>();
        }
    }

    public bool Add(string value)
    {
        int index = GetHash(value);
        if (_table[index].Contains(value))
        {
            return false;
        }
        _table[index].Add(value);
        return true;
    }

    public bool Contains(string value)
    {
        int index = GetHash(value);
        return _table[index].Contains(value);
    }

    private int GetHash(string value)
    {
        int hash = 0;
        foreach (char c in value)
        {
            hash += c;
        }
        return hash % _table.Length;
    }
}

public class LinearProbingHashTable
{
    private string[] _table;

    public LinearProbingHashTable(int size)
    {
        _table = new string[size];
        for (int i = 0; i < size; i++)
        {
            _table[i] = null;
        }
    }

    public bool Add(string value)
    {
        int index = GetHash(value);
        int originalIndex = index;
        while (_table[index] != null)
        {
            if (_table[index] == value)
            {
                return false; 
            }
            index = (index + 1) % _table.Length;
            if (index == originalIndex)
            {
                return false;               
            }
        }
        _table[index] = value;
        return true; 
    }

    public bool Contains(string value)
    {
        int index = GetHash(value);
        int originalIndex = index;
        while (_table[index] != null)
        {
            if (_table[index] == value)
            {
                return true;
            }
            index = (index + 1) % _table.Length;
            if (index == originalIndex)
            {
                break; 
            }
        }

        return false;
    }


    private int GetHash(string value)
    {
        int hash = 0;
        foreach (char c in value)
        {
            hash += c;
        }
        return hash % _table.Length;
    }
}

public class Program
{
   public static void Main(string[] args)
    {
        int tableSize = 25;
        int numberOfItems = 20; 
        
        var chainingTable = new ChainingHashTable(tableSize);
        var probingTable = new LinearProbingHashTable(tableSize);
        
        string[] testData = new string[numberOfItems];
        Random rand = new Random();
        for (int i = 0; i < numberOfItems; i++)
        {
            testData[i] = "Key_" + rand.Next(100, 999);
        }

        Console.WriteLine($"--- Efficiency Analysis ({numberOfItems} keys, size {tableSize}) ---");
        Console.WriteLine($"{"Method",-20} | {"Add Time (ms)",-15} | {"Search Time (ms)",-15}");
        Console.WriteLine(new string('-', 55));

        Stopwatch sw = new Stopwatch();

        // Measure Chaining
        sw.Start();
        foreach (var key in testData) chainingTable.Add(key);
        sw.Stop();
        double addChainingMs = sw.Elapsed.TotalMilliseconds;

        sw.Restart();
        foreach (var key in testData) chainingTable.Contains(key);
        sw.Stop();
        double searchChainingMs = sw.Elapsed.TotalMilliseconds;
        
        Console.WriteLine($"{"Chaining",-20} | {addChainingMs,-15:F5} | {searchChainingMs,-15:F5}");

        // Measure Linear Probing
        sw.Restart();
        foreach (var key in testData) probingTable.Add(key);
        sw.Stop();
        double addProbingMs = sw.Elapsed.TotalMilliseconds;

        sw.Restart();
        foreach (var key in testData) probingTable.Contains(key);
        sw.Stop();
        double searchProbingMs = sw.Elapsed.TotalMilliseconds;

        Console.WriteLine($"{"Linear Probing",-20} | {addProbingMs,-15:F5} | {searchProbingMs,-15:F5}");
        
        Console.WriteLine("\nAnalysis Complete.");
    }
}
