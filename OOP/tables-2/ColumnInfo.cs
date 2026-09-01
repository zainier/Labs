public class ColumnInfo
{
    public string Name { get; }
    public Type DataType { get; }
    public int Width { get; }
    public AlignmentTypes Alignment { get; }

    internal ColumnInfo(string name, Type dataType, int width, AlignmentTypes alignment)
    {
        Name = name;
        DataType = dataType;
        Width = width;
        Alignment = alignment;
    }
}
