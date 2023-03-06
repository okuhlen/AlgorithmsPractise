namespace PractiseAlgorithms.DataStructures.BinaryTrees;
public class BinarySearchTree<T> : ITree<T> where T : IComparable<T>
{
    private Node<T> Root;

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
    public bool Delete(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        if (Root is null)
            throw new NullReferenceException("No items in the BST!");

        if (Root.Value.Equals(item))
        {

        }

        var currentNode = Root;
        do
        {

        } while (currentNode is not null);

        throw new NotImplementedException("Still thinking...");
    }

    //is the key recursion?
    public T Find(T item)
    {
        if (Root is null)
            throw new NullReferenceException("No items present in the Binary Search Tree");

        var currentNode = Root;
        do
        {
            if (currentNode.Value.Equals(item))
            {
                return currentNode.Value;
            }
            else if (item.CompareTo(currentNode.Value) > 0)
            {
                currentNode = currentNode.Right;
            } 
            else if (item.CompareTo(currentNode.Value) < 0)
            {
                currentNode = currentNode.Left;
            }
        } while (currentNode != null);

        throw new Exception("Could not find the item in the collection");
    }

    //the key to this is recursion??
    

    public void Traverse(TreeTraversalMode traversalMode)
    {
        switch (traversalMode)
        {
            case TreeTraversalMode.PreOrderTraversal:
                TraverseForPreOrderTraversal();
                break;
            default:
                throw new NotSupportedException($"The selected traversal mode is not supported: {nameof(traversalMode)}");
        }
    }

    private void TraverseForPreOrderTraversal()
    {
        var node = Root;
        if (node is not null)
        {
            PreOrderTraversal(node.Left);
            Console.WriteLine(node.ToString());
            PreOrderTraversal(node.Right);
        }
    }

    private void PreOrderTraversal(Node<T> node)
    {
        Console.WriteLine(node.ToString());
    }
}
