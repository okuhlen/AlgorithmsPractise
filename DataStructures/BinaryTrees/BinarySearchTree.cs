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

        //the key to this is recursion??
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

            var currentItem = Root;
            do
            {
                if (item.CompareTo(currentItem.Value) > 0)
                {
                    if (currentItem.Right is null)
                    {
                        currentItem.Right = new Node<T>
                        {
                            Value = item
                        };

                        return;
                    }

                    currentItem = currentItem.Right;
                }

                else if (item.CompareTo(currentItem.Value) < 0)
                {
                    if (currentItem.Left is null)
                    {
                        currentItem.Left = new Node<T>
                        {
                            Value = item
                        };

                        return;
                    }

                    currentItem = currentItem.Left;
                }

                else
                {
                    throw new Exception("No duplicate items are allowed to be inserted");
                }

            } while (currentItem is not null);
        }
    }
}
