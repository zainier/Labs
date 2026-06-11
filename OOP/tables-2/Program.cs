Table table = new();

table.Columns.AddColumn("Id", typeof(int), 5, AlignmentTypes.Right);
table.Columns.AddColumn("Name", typeof(string), 20, AlignmentTypes.Left);
table.Columns.AddColumn("AverageGrade", typeof(double), 12, AlignmentTypes.Center);

RowData firstRow = table.Rows.CreateRow();
firstRow.SetValue("Id", 1);
firstRow.SetValue("Name", "Olena");
firstRow.SetValue("AverageGrade", 92.5);
table.Rows.AddRow(firstRow);

RowData secondRow = table.Rows.CreateRow();
secondRow.SetValue("Id", 2);
secondRow.SetValue("Name", "Andrii");
secondRow.SetValue("AverageGrade", 88.0);
table.Rows.AddRow(secondRow);

Console.WriteLine($"Columns: {table.Columns.Count}");
Console.WriteLine($"Rows: {table.Rows.Count}");
Console.WriteLine($"Name column index: {table.Columns.FindColumnIndex("Name")}");
Console.WriteLine($"First student's name: {table.Rows.FindRow(0)?.GetValue("Name")}");
