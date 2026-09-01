public class ColumnCollection
{
    private readonly List<ColumnInfo> _columns = [];

    public int Count => _columns.Count;

    public ColumnInfo AddColumn(
        string name,
        Type dataType,
        int width,
        AlignmentTypes alignment)
    {
        ColumnInfo column = new(name, dataType, width, alignment);
        _columns.Add(column);

        return column;
    }

    public ColumnInfo? FindColumn(string name)
    {
        return _columns.Find(column => column.Name == name);
    }

    public int FindColumnIndex(string name)
    {
        return _columns.FindIndex(column => column.Name == name);
    }

    public ColumnInfo? FindColumn(int index)
    {
        if (index >= 0 && index < Count)
        {
            return _columns[index];
        }

        return null;
    }
}
