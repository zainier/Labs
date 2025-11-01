using System;

public class LinkedItem
{
    public int Value { get; set; }
    public LinkedItem Next { get; set; }

    public LinkedItem(int value)
    {
        Value = value;
    }
}

public class LinkedList
{
    public LinkedItem Head { get; private set; }

    public void Add(int value)
    {
        LinkedItem newItem = new LinkedItem(value);

        if (Head == null)
        {
            Head = newItem;
            return;
        }

        LinkedItem current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newItem;
    }

    public void AddFirst(int value)
    {
        LinkedItem newItem = new LinkedItem(value);
        newItem.Next = Head;
        Head = newItem;
    }

    public bool Contains(int value)
    {
        LinkedItem current = Head;
        while (current != null)
        {
            if (current.Value == value)
            {
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public int MaxValue()
    {
        if (Head == null)
        {
            throw new InvalidOperationException("The list is empty.");
        }

        int max = Head.Value;
        LinkedItem current = Head.Next;
        while (current != null)
        {
            if (current.Value > max)
            {
                max = current.Value;
            }
            current = current.Next;
        }

        return max;
    }

    public int Count
    {
        get
        {
            int count = 0;
            LinkedItem current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            
            return count;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        LinkedList list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.AddFirst(5);

        Console.WriteLine("List contains 20: " + list.Contains(20));
        Console.WriteLine("List contains 15: " + list.Contains(15));
        Console.WriteLine("Max value in the list: " + list.MaxValue());
        Console.WriteLine("Total items in the list: " + list.Count);
    }
}