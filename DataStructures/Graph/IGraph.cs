namespace PractiseAlgorithms.DataStructures.Graph;

public interface IGraph<T> where T : class
{
    void AddItem(T item);
    void RemoveItem(T item);
    void AddEdge(T objectA, T objectB);
    void RemoveEdge(T objectA, T objectB);
    void Display();

    int GetEdgeWeight();
    int GetNumberOfVerticies();
    List<T> GetAdjacentVerticies(T @object);

}
