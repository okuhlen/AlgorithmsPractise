namespace PractiseAlgorithms.DataStructures.BinaryTrees
{
    public class BinarySearchTree<T> : ITree<T>
    {
        private Node<T> Root;

        public bool Delete(T item)
        {
            throw new NotImplementedException();
        }

        public bool Find(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(T item)
        {
            if (Root == null)
            {
                Root = new Node<T>
                {
                    Value = item
                };
                return;
            }

            Node<T> currentNode = null;
            if (item > Root.Value)
            {

            }
            do
            {

            } while ()
        }
    }
}
