namespace PractiseAlgorithms.DataStructures.BinaryTrees;
public sealed class Node<T>
{
    public T Value { get; set; }
    
    public Node<T> Left { get; set; }

    public Node<T> Right { get; set; }

    public override string ToString()
    {
        return Value?.ToString() ?? $"{GetHashCode()}";
    }
}
