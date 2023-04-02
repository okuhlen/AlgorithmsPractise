namespace PractiseAlgorithms.DataStructures.Graph;

public sealed class DirectionalGraph<T> : GraphBase, IGraph<T> where T : class
{
    public DirectionalGraph(int numVerticies, bool directed): base(numVerticies, directed)
    {
    }

    public void AddEdge(T objectA, T objectB)
    {
        throw new NotImplementedException();
    }

    public void AddItem(T item)
    {
        throw new NotImplementedException();
    }

    public void Display()
    {
        throw new NotImplementedException();
    }

    public int GetEdgeWeight()
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfVerticies()
    {
        throw new NotImplementedException();
    }

    public void RemoveEdge(T objectA, T objectB)
    {
        throw new NotImplementedException();
    }

    public void RemoveItem(T item)
    {
        throw new NotImplementedException();
    }
}
