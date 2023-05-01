namespace PractiseAlgorithms.DataStructures.Graphs;

public sealed class Node<TKey, TValue> : IEquatable<Node<TKey, TValue>> where TKey: struct where TValue: class
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
    
    public bool Equals(Node<TKey, TValue>? other)
    {
        if (other is null)
            return false;
        
        return Key.GetHashCode() == other.Key.GetHashCode();
    }

    public override int GetHashCode()
    {
        return Key.GetHashCode();
    }

    /// <summary>
    /// Return the string representation of the value attached to this particular node. 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Value.ToString()!;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Node<TKey, TValue>);
    }
}