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

public class HashTableTest
{
    public static void Main(string[] args)
    {
        LinearProbingHashTable hashTable = new LinearProbingHashTable(10);

        // Test adding elements
        Console.WriteLine(hashTable.Add("apple"));  // True
        Console.WriteLine(hashTable.Add("banana")); // True
        Console.WriteLine(hashTable.Add("apple"));  // False (duplicate)   

        // Test contains method
        Console.WriteLine(hashTable.Contains("apple"));  // True
        Console.WriteLine(hashTable.Contains("banana")); // True
        Console.WriteLine(hashTable.Contains("cherry")); // False
    }
}