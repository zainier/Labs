public class RowCollection
{
    private readonly List<RowData> _rows = [];
    private readonly ColumnCollection _columns;

    public int Count => _rows.Count;

    internal RowCollection(ColumnCollection columns)
    {
        _columns = columns;
    }

    public RowData CreateRow()
    {
        return new RowData(_columns);
    }

    public void AddRow(RowData row)
    {
        _rows.Add(row);
    }

    public RowData? FindRow(int index)
    {
        if (index >= 0 && index < Count)
        {
            return _rows[index];
        }

        return null;
    }
}
