class TextBoxBase 
{
    public int Width { get; set; }
    public string Text { get; set; }

    public void Draw()
    {
        DrawTopLine();

        int spacesBeforeText = GetSpacesBeforeText();
        int spacesAfterText = GetSpacesAfterText();

        Console.Write('│');
        for (int i = 0; i < spacesBeforeText; i++)
        {
            Console.Write(' ');
        }

        Console.Write(Text);

        for (int i = 0; i < spacesAfterText; i++)
        {
            Console.Write(' ');
        }
        Console.WriteLine('│');

        DrawBottomLine();
    }

    protected virtual int GetSpacesBeforeText()
    {
        return 0;
    }

    protected virtual int GetSpacesAfterText()
    {
        return 0;
    }

     private void DrawTopLine()
    {
        Console.Write('╭');
        for (int i = 0; i < Width; i++)
        {
            Console.Write('─');
        }
        Console.WriteLine('╮');
    }

    private void DrawBottomLine()
    {
        Console.Write('╰');
        for (int i = 0; i < Width; i++)
        {
            Console.Write('─');
        }
        Console.WriteLine('╯');
    }
}

class TextBoxLeftAligned: TextBoxBase
{
    protected override int GetSpacesBeforeText()
    {
        return 0;
    }

    protected override int GetSpacesAfterText()
    {
        return Width - Text.Length;
    }
}

class TextBoxRightAligned: TextBoxBase
{
    protected override int GetSpacesBeforeText()
    {
        return Width - Text.Length;
    }

    protected override int GetSpacesAfterText()
    {
        return 0;
    }
}

class TextBoxCenterAligned: TextBoxBase
{
    protected override int GetSpacesBeforeText()
    {
        return (Width - Text.Length) / 2;
    }

    protected override int GetSpacesAfterText()
    {
        return Width - Text.Length - GetSpacesBeforeText();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Provide width:");
        int width = int.Parse(Console.ReadLine());
        Console.WriteLine("Provide text:");
        string text = Console.ReadLine();   

        TextBoxBase textBox1 = new TextBoxLeftAligned();
        textBox1.Width = width;
        textBox1.Text = text;
        textBox1.Draw();

        TextBoxBase textBox2 = new TextBoxRightAligned();
        textBox2.Width = width;
        textBox2.Text = text;
        textBox2.Draw();

        TextBoxBase textBox3 = new TextBoxCenterAligned();
        textBox3.Width = width;
        textBox3.Text = text;
        textBox3.Draw();
    }
}      