namespace PractiseAlgorithms.DataStructures.Graphs;

public sealed class Graph<TKey, TValue> where TKey: struct where TValue: class
{
    //this is an adjacency list. what about the 2d array representation?
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

    public void TraverseBreadthFirst(TKey key, TValue keyValue)
    {
        var node = new Node<TKey, TValue>
        {
            Key = key,
            Value = keyValue
        };
        var traversalQueue = new Queue<Node<TKey, TValue>>();
        traversalQueue.Enqueue(node);
        while (traversalQueue.Any())
        {
            var currentItem = traversalQueue.Dequeue();
            Console.WriteLine($"Current Node: {currentItem}");
            if (!Items.TryGetValue(currentItem, out var item)) continue;
            foreach (var neighbours in item)
            {
                traversalQueue.Enqueue(neighbours);
            }
        }
    }

    public bool HasPathDepthFirst((TKey key, TValue value) source, (TKey key, TValue value) destination)
    {
        var sourceNode = new Node<TKey, TValue> { Key = source.key, Value = source.value };
        var destinationNode = new Node<TKey, TValue> { Key = destination.key, Value = destination.value };

        if (sourceNode.Equals(destinationNode))
        {
            return true;
        }
        
        foreach (var node in Items[sourceNode])
        {
            return HasPathDepthFirst((node.Key, node.Value), (destinationNode.Key, destinationNode.Value));
        }

        return false;
    }

    public bool HasPathBreadthFirst((TKey key, TValue value) source, (TKey key, TValue value) destination)
    {
        var traversalQueue = new Queue<Node<TKey, TValue>>();
        var sourceNode = new Node<TKey, TValue> { Key = source.key, Value = source.value };
        var destinationNode = new Node<TKey, TValue> { Key = destination.key, Value = destination.value };
        
        traversalQueue.Enqueue(sourceNode);
        while (traversalQueue.Any())
        {
            var currentItem = traversalQueue.Dequeue();
            if (currentItem.Equals(destinationNode))
                return true;
            if (!Items.TryGetValue(currentItem, out var neighbours))
                continue;
            foreach (var neighbour in neighbours)
            {
                traversalQueue.Enqueue(neighbour);
            }
        }

        return false;
    }
    
}