namespace PractiseAlgorithms;

public static class AdjacencyList
{
    /// <summary>
    /// For graphs, apparently an adjacency list is used to illustrate the graph.
    /// Each key represents the node itself, while the values (lists) contains a list of neighbours relative to the node.
    /// Must take not of whether the graph is a directed or undirected graph.
    /// </summary>
    public static readonly Dictionary<string, List<string>> DirectedGraph = new()
    {
        {"a", new List<string>() { "b", "d" }},
        {"b", new List<string>() { "c" }},
        {"c", new List<string>() { "d" }},
        {"d", new List<string>() { "e" }},
        {"e", new List<string>() {  }}
    };
}