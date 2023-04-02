namespace PractiseAlgorithms.DataStructures.Graph;

public abstract class GraphBase
{
    protected readonly int NumVerticies;
    protected readonly bool IsDirected;

    public GraphBase(int numVerticies, bool isDirected)
    {
        NumVerticies = numVerticies;
        IsDirected = isDirected;
    }
}
