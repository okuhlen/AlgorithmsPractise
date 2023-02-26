namespace PractiseAlgorithms.DataStructures.SinglyLinkedList;
public sealed class SinglyLinkedList<T>
{
    public Node<T> Head { get; set; }
    public int Count { get; set; }
    public void AddFirst(T node)
    {
        if (Head is null)
        {
            Head = new Node<T>
            {
                Value = node
            };

            Count++;
        }
        else
        {
            throw new NotSupportedException("An item already exists at the start of the list. Please consider using InsertAt method");
        }
    }

    public void Add(T item)
    {
        if (Head is null)
        {
            AddFirst(item);
        }
        else
        {
            var listNode = Head;
            while (listNode is not null)
            {
                if (listNode.Next is null)
                {
                    listNode.Next = new Node<T>
                    {
                        Value = item,
                        Next = null
                    };
                    Count++;
                    break;
                }
                else
                {
                    listNode = listNode.Next;
                }
            }

        }
    }

    public T? Find(T item)
    {
        if (Head is null)
            throw new Exception("The LinkedList is empty. Please try add items to the list");

        var currentNode = Head;

        while (currentNode is not null)
        {
            if (currentNode.Value!.Equals(item))
            {
                return currentNode.Value;
            }
            else
            {
                currentNode = currentNode.Next;
            }
        }

        return default;
    }

    public void PrintAllItems()
    {
        var currentNode = Head;
        while (currentNode is not null)
        {
            Console.WriteLine($"Current Node: {currentNode.Value}");
            currentNode = currentNode.Next;
        }
    }

    public void Delete(T item)
    {

    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentItem = Head;
        if (Head is null)
            throw new Exception("No items have been added to the LinkedList as of yet");

        while (currentItem is not null)
        {
            yield return currentItem.Value;
            currentItem = currentItem.Next;
        }
    }

    public void InsertAtStart(T item)
    {
        var temp = Head;
        Head = new Node<T>
        {
            Value = item,
            Next = new Node<T>
            {
                Value = temp.Value,
                Next = temp.Next
            }
        };
    }


}
