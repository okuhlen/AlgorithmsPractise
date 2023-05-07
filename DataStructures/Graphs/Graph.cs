namespace PractiseAlgorithms.DataStructures.Graphs;

public sealed class Graph<TKey, TValue> where TKey: struct where TValue: class
{
    //this is an adjacency list (a list of nodes, and their neighbours). what about the 2d array representation?
    private readonly Dictionary<Node<TKey, TValue>, List<Node<TKey, TValue>>> Items;

    public Graph()
    {
        Items = new Dictionary<Node<TKey, TValue>, List<Node<TKey, TValue>>>();
    }

    private Graph(Dictionary<Node<TKey, TValue>, List<Node<TKey, TValue>>> items)
    {
        Items = items;
    }

    /// <summary>
    /// We can create our graph from a list of edges. An edge is defined by the connection (line) between 2 nodes.
    /// The list here is simply a collection of nodes which are connected to each other (pairings)
    /// </summary>
    /// <param name="edgesList">list of connected nodes</param>
    /// <returns>A new graph instance</returns>
    public static Graph<TKey, TValue> FromEdgesListBiDirectional(List<List<Node<TKey, TValue>>> edgesList)
    {
        var graph = new Dictionary<Node<TKey, TValue>, List<Node<TKey, TValue>>>();

        foreach (var edge in edgesList)
        {
            if (!graph.TryGetValue(edge.First(), out var node))
            {
                graph.Add(edge.First(), new List<Node<TKey, TValue>>()
                {
                    edge.Last()
                });
            }
            else
            {
                graph[edge.First()].Add(edge.Last());
            }

            if (!graph.TryGetValue(edge.Last(), out var lastNode))
            {
                graph.Add(edge.Last(), new List<Node<TKey, TValue>>()
                {
                    edge.First()
                });
            }
            else
            {
                graph[edge.Last()].Add(edge.First());
            }
        }
        
        return new Graph<TKey, TValue>(graph);
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
        
        Items.Add(keyNode, neighbours.ConvertAll(x => new Node<TKey, TValue> { Key = x.Key, Value = x.Value }));
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

    //it is assumed that at this point, we will have an adjacency list to work from. 
    //we know that each node is represented as a key, and the items represent the neighbours.
    //therefore, we can use the keys to get a list of all nodes
    //NB: VERY IMPORTANT INTERVIEW QUESTION!! PRACTISE TOMORROW MORNING!! 
    public int GetNumberOfConnectedComponents()
    {
        var count = 0;
        var visitedNodes = new List<Node<TKey, TValue>>();
        var stack = new Stack<Node<TKey, TValue>>();

        foreach (var node in Items.Keys)
        {
            //if the node has already been visited, move onto the next known node
            if (visitedNodes.Contains(node))
                continue;

            //if the given node has no neighbours, we can conclude we have visited that component in its entirety
            if (!Items[node].Any())
            {
                count++;
                visitedNodes.Add(node);
                continue;
            }
            
            //add the current node to the stack, so we can look at the node's neighbours
            stack.Push(node);
            while (stack.Any())
            {
                var currentItem = stack.Pop();
                var neighbours = Items[currentItem];

                if (neighbours.Any())
                {
                    foreach (var neighbour in neighbours)
                    {
                        stack.Push(neighbour);
                        visitedNodes.Add(neighbour);
                    }
                }
            }
            count++; //meaning that all possible neighbours for this node have been visited.
        }

        return count;

    }
    
}