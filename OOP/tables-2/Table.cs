public class Table
{
    public ColumnCollection Columns { get; }
    public RowCollection Rows { get; }

    public Table()
    {
        Columns = new ColumnCollection();
        Rows = new RowCollection(Columns);
    }
}
