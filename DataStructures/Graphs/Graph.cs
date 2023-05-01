namespace PractiseAlgorithms.DataStructures.Graphs;

public sealed class Graph<TKey, TValue> where TKey: struct where TValue: class
{
    private readonly Dictionary<Node<TKey, TValue>, List<Node<TKey, TValue>>> Items;

    public Graph()
    {
        Items = new Dictionary<Node<TKey, TValue>, List<Node<TKey, TValue>>>();
    }
    public void Add(TKey key, TValue keyValue, List<KeyValuePair<TKey, TValue>> neighbours)
    {
        var keyNode = new Node<TKey, TValue>
        {
            Key = key,
            Value = keyValue
        };

        if (Items.ContainsKey(keyNode))
            throw new Exception("The graph already contains an item with the given key");
        
        Items.Add(keyNode, neighbours.ConvertAll(x => new Node<TKey, TValue>() { Key = x.Key, Value = x.Value }));
    }

    /// <summary>
    /// When traversing a graph using depth-first, we use a Stack data structure to manage traversal
    /// </summary>
    /// <param name="startingNode">The node at which we begin the traversal from</param>
    public void TraverseDepthFirst(Node<TKey, TValue> startingNode)
    {
        //add the starting node to the stack. for each iteration, we take the top-most item in the stack, inspect the neighbours for a given node and add those to the stack (if any)
        var traversalStack = new Stack<Node<TKey, TValue>>();
        traversalStack.Push(startingNode);
        while (traversalStack.Any())
        {
            var currentItem = traversalStack.Pop();
            Console.WriteLine($"Current Node: {currentItem}");
            var neighbours = Items[currentItem];
            if (!neighbours.Any()) continue;
            foreach (var node in neighbours)
            {
                traversalStack.Push(node);
            }
        }
    }
    
}