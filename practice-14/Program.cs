class Button
{
    public string Name { get; set; }

    private int clickCount = 0;

    public Button(string name)
    {
        Name = name;
    }

    public void Click()
    {
        clickCount++;
    }

    public static void ShowCounter(Button button)
    {
        Console.WriteLine($"Button \"{button.Name}\" was clicked {button.clickCount} time(s).");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Button ok = new Button("OK");
        Button cancel = new Button("Cancel");

        ok.Click();
        ok.Click();
        cancel.Click();

        Button.ShowCounter(ok);
        Button.ShowCounter(cancel);
    }
}