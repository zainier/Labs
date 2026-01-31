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

public class HashTableTest
{
    public static void Main(string[] args)
    {
        ChainingHashTable hashTable = new ChainingHashTable(10);

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
