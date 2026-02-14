
public class TreeNode 
{
    public int Value;
    public List<TreeNode> Children;

    public TreeNode(int value) 
    {
        Value = value;
        Children = new List<TreeNode>();
    }

    public void AddChild(TreeNode child) 
    {
        Children.Add(child);
    }

    public void RemoveChild(int value) 
    {
        TreeNode? toRemove = null;
        foreach (TreeNode child in Children) 
        {
            if (child.Value == value) 
            {
                toRemove = child;
                break;
            }
        }
        if (toRemove != null) 
        {   
            Children.Remove(toRemove);
        }
    }

    public void DepthFirstTraversal(TreeNode? node) 
    {
        if (node == null) 
        {
            return;
        }
        Console.Write(node.Value + " ");
        foreach (TreeNode child in node.Children) 
        {
            DepthFirstTraversal(child);
        }
    }
}

public class BinaryNode
{
    public int Value;
    public BinaryNode? Left;
    public BinaryNode? Right;

    public BinaryNode(int value)
    {
        Value = value;
    }
}

public class BinaryTree
{
    public BinaryNode? Root;

    public void Add(int value)
    {
        Root = AddRecursive(Root, value);
    }

    private BinaryNode? AddRecursive(BinaryNode? root, int value)
    {
        if (root == null) 
        {
            return new BinaryNode(value);
        }

        if (value < root.Value) 
        {
            root.Left = AddRecursive(root.Left, value);
        }
        else if (value > root.Value) 
        {
            root.Right = AddRecursive(root.Right, value);
        }
        return root;
    }

    public bool Search(int value)
    {
        BinaryNode? current = Root;
        while (current != null)
        {
            if (current.Value == value) 
            {
                return true;
            }
            if (value < current.Value) 
            {
                current = current.Left;
            }
            else 
            {
                current = current.Right;
            }
        }
        return false;
    }

    public void Delete(int value)
    {
        Root = DeleteRecursive(Root, value);
    }

    private BinaryNode? DeleteRecursive(BinaryNode? root, int value)
    {
        if (root == null) 
        {
            return null;
        }

        if (value < root.Value)
        {
            root.Left = DeleteRecursive(root.Left, value);
        }
        else if (value > root.Value)
        {
            root.Right = DeleteRecursive(root.Right, value);
        }
        else
        {
            if (root.Left == null) 
            {
                return root.Right;
            }
            if (root.Right == null) 
            {
                return root.Left;
            }

            root.Value = MinValue(root.Right);
            root.Right = DeleteRecursive(root.Right, root.Value);
        }
        return root;
    }

    private int MinValue(BinaryNode node)
    {
        int minv = node.Value;
        while (node.Left != null)
        {
            minv = node.Left.Value;
            node = node.Left;
        }
        return minv;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        BinaryTree bst = new BinaryTree();
        TreeNode generalTree = new TreeNode(50);

        Console.WriteLine("Додавання 10 випадкових елементів:");
        for (int i = 0; i < 10; i++)
        {
            int val = rnd.Next(1, 100);
            Console.Write(val + " ");
            bst.Add(val);
            generalTree.AddChild(new TreeNode(val));
        }

        Console.WriteLine("\n\nОбхід бінарного дерева:");
        PrintInOrder(bst.Root);

        Console.WriteLine("\n\nОбхід загального дерева (DFS):");
        generalTree.DepthFirstTraversal(generalTree);

        Console.WriteLine("\n\n--- Аналіз ефективності ---");
        Console.WriteLine("1. Обхід (DFS/In-order): O(n). Ми відвідуємо кожен вузол один раз.");
        Console.WriteLine("2. Пошук у BST: O(log n). Завдяки ієрархії ми відсікаємо частину дерева.");
        Console.WriteLine("3. Видалення у BST: O(log n). Вимагає пошуку вузла та його заміни.");
    }

    public static void PrintInOrder(BinaryNode? node)
    {
        if (node != null)
        {
            PrintInOrder(node.Left);
            Console.Write(node.Value + " ");
            PrintInOrder(node.Right);
        }
    }
}