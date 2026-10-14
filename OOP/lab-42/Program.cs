while (true)
{
    Console.Write("Введіть число: ");
    string? input = Console.ReadLine();

    try
    {
        int number = Int32.Parse(input!);
        Console.WriteLine($"Введено число: {number}");
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("Введене значення не є числом.");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Введене значення виходить за межі допустимого діапазону.");
    }
    catch (Exception)
    {
        Console.WriteLine("Не вдалося перетворити значення. Спробуйте ще раз.");
    }
}
