using System.Diagnostics;

class Graph
{
    private Dictionary<int, List<int>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();
    }

    public void AddVertex(int vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new List<int>();
        }
    }

    public void AddEdge(int source, int destination)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            AddVertex(source);
        }

        if (!adjacencyList.ContainsKey(destination))
        {
            AddVertex(destination);
        }

        adjacencyList[source].Add(destination);
        adjacencyList[destination].Add(source);
    }

    public List<int> BFS(int start, int target)
    {
        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        var parent = new Dictionary<int, int>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == target)
            {
                return BuildPath(parent, target);
            }

            foreach (int neighbor in adjacencyList[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    parent[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return new List<int>();
    }

    private List<int> BuildPath(Dictionary<int, int> parent, int target)
    {
        var path = new List<int>();
        int current = target;

        while (parent.ContainsKey(current))
        {
            path.Add(current);
            current = parent[current];
        }

        path.Add(current);
        path.Reverse();
        
        return path;
    }
}

class Program
{
    static void Main()
    {
        RunTest(100, 300);
        RunTest(1000, 5000);
        RunTest(10000, 50000);
        RunTest(100000, 500000);
    }

    static void RunTest(int verticesCount, int edgesCount)
    {
        Graph graph = new Graph();
        Random rand = new Random(42);

        for (int i = 0; i < verticesCount; i++)
        {
            graph.AddVertex(i);
        }

        for (int i = 0; i < edgesCount; i++)
        {
            int source = rand.Next(0, verticesCount);
            int destination = rand.Next(0, verticesCount);
            graph.AddEdge(source, destination);
        }

        int startNode = 0;
        int targetNode = verticesCount - 1;

        Stopwatch stopwatch = Stopwatch.StartNew();
        List<int> path = graph.BFS(startNode, targetNode);
        stopwatch.Stop();

        Console.WriteLine($"Вершини: {verticesCount}, Ребра: {edgesCount}");
        Console.WriteLine($"Час виконання BFS: {stopwatch.Elapsed.TotalMilliseconds} мс, Довжина шляху: {path.Count}");
        Console.WriteLine(new string('-', 40));
    }
}