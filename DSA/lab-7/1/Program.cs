public class HashTable
{
    private string[] _table;

    public HashTable(int size)
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
        if (_table[index] == null)
        {
            _table[index] = value;
            return true;
        }
        return false;
    }

    public bool Contains(string value)
    {
        int index = GetHash(value);
        return _table[index] == value;
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