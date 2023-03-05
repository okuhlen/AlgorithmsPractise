namespace PractiseAlgorithms.DataStructures.BinaryTrees
{
    public class BinarySearchTree<T> : ITree<T> where T : IComparable<T>
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

            T currentItem = Root.Value;

            if (item.CompareTo(currentItem) > 0 && Root.Left is null)
            {
                Root.Left = new Node<T> { Value = item };
                return;
            }

            if (item.CompareTo(currentItem) < 0 && Root.Right is null)
            {
                Root.Right = new Node<T> { Value = item };
                return;
            }

            do
            {
                //recursively go through the tree somehow

            } while (currentItem is null);
        }
    }
}
