namespace PractiseAlgorithms.DataStructures.BinaryTrees
{
    public interface ITree<T>
    {
        void Insert(T item);

        bool Delete(T item);

        bool Find(T item);
    }
}
