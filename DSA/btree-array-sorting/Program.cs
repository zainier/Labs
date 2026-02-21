public class BinaryNode
{
    public int Value;
    public int Count;
    public BinaryNode? Left;
    public BinaryNode? Right;

    public BinaryNode(int value)
    {
        Value = value;
        Count = 1;
    }
}

public class BinaryTree
{
    public BinaryNode? Root;

    public void Add(int value)
    {
        Root = AddRecursive(Root, value);
    }

    private BinaryNode AddRecursive(BinaryNode? root, int value)
    {
        if (root == null)
        {
            return new BinaryNode(value);
        }

        if (value == root.Value)
        {
            root.Count++;
        }
        else if (value < root.Value)
        {
            root.Left = AddRecursive(root.Left, value);
        }
        else
        {
            root.Right = AddRecursive(root.Right, value);
        }
        return root;
    }

    public void TraverseAscending(BinaryNode? node)
    {
        if (node == null)
        {
            return;
        }

        TraverseAscending(node.Left);
        
        for (int i = 0; i < node.Count; i++)
        {
            Console.Write(node.Value + " ");
        }

        TraverseAscending(node.Right);
    }

    public void TraverseDescending(BinaryNode? node)
    {
        if (node == null) return;

        TraverseDescending(node.Right);
        
        for (int i = 0; i < node.Count; i++)
        {
            Console.Write(node.Value + " ");
        }

        TraverseDescending(node.Left);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        BinaryTree tree = new BinaryTree();
        int[] array = new int[100];

        Console.WriteLine("Початковий масив:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(1, 11);
            Console.Write(array[i] + " ");
            
            tree.Add(array[i]);
        }

        Console.WriteLine("\n\n--- Сортування за допомогою дерева ---");

        Console.WriteLine("\nМасив за зростанням:");
        tree.TraverseAscending(tree.Root);

        Console.WriteLine("\n\nМасив за спаданням:");
        tree.TraverseDescending(tree.Root);
        
        Console.WriteLine();
    }
}