public class RowData
{
    private readonly ColumnCollection _columns;
    private readonly object?[] _values;

    internal RowData(ColumnCollection columns)
    {
        _columns = columns;
        _values = new object?[columns.Count];
    }

    public void SetValue(string columnName, object? value)
    {
        int columnIndex = _columns.FindColumnIndex(columnName);
        _values[columnIndex] = value;
    }

    public object? GetValue(string columnName)
    {
        int columnIndex = _columns.FindColumnIndex(columnName);
        return _values[columnIndex];
    }
}
