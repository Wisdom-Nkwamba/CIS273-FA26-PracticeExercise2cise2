namespace PracticeExercise2;

public class LinkedListNode<T>
{
   public T Data {get; set; }
   public LinkedListNode<T> Next {get; set;}

   public LinkedListNode(T data=default,  LinkedListNode<T> next=null)

    {
        Data = data;
        Next = next;

    }

    public override string ToString()
    {
        return Data==null? "null": Data.ToString();
    }
}


public class LinkedList<T> : IList<T>
{
   
   private LinkedListNode<T>? Head {get;set;}
   private LinkedListNode<T>? Tail {get;set;}

   public LinkedList()
    {
        Head = null;
        Tail = null;
    }

    // TODO
    /// <summary>
    /// Returns first element in list, null if empty.
    /// </summary>
    public T? First => IsEmpty ? default : Head.Data;

    // TODO
    /// <summary>
    /// Returns last element in list, null if empty.
    /// </summary>
    public T? Last => IsEmpty ? default : Tail.Data;

    // TODO
    /// <summary>
    /// Returns true if list is has no elements; false otherwise.
    /// </summary>
    public bool IsEmpty => Head is null;

    /// <summary>
    /// Number of elements in list.
    /// </summary>
    public int Length
    {
        get;
        private set;
    }

    // TODO 
    /// <summary>
    /// Adds given item to end of list.
    /// </summary>
    /// <param name="item">item to add to the list</param>
    public void Append(T item)
    {
        var newNode = new LinkedListNode<T>(item);
        if(IsEmpty)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;

        }



        Length++;
    }

    /// <summary>
    /// Remove all elements from list
    /// </summary>
    public void Clear()
    {
        Head = null;
        Tail = null;
        Length=0;

    }

    /// <summary>
    /// Checks if the list contains the given value.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>true if item is in list; false otherwise</returns>
    public bool Contains(T item)
    {
        var currentNode = Head;

        while ( currentNode != null)
        {
            if(currentNode.Data.Equals(item))
            {
                return true;
            }
            currentNode = currentNode.Next;
        }


        return false;
    }

    // TODO
    /// <summary>
    /// Find index of first element with matching value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Index of first element with value; -1 if element is not found</returns>
    public int FirstIndexOf(T item)
    {
        var currentNode = Head;
    int currentIndex = 0;

    while (currentNode != null)
    {
        if (currentNode.Data.Equals(item))
        {
            return currentIndex;
        }

        currentNode = currentNode.Next;
        currentIndex++;
    }

    return -1;
    }

    /// <summary>
    /// Return the element at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns>The element at the given index.</returns>
    public T Get(int index)
    {
    if (index < 0 || index >= Length)
    {
        throw new IndexOutOfRangeException();
    }

    var currentNode = Head;
    int currentIndex = 0;

    while (currentIndex < index)
    {
        currentNode = currentNode.Next;
        currentIndex++;
    }

    return currentNode.Data;
}

    // TODO
    /// <summary>
    /// Insert new value after first instance of existing value.
    /// If existingValue is not in list, then add new value to end of list.
    /// </summary>
    /// <param name="newValue"></param>
    /// <param name="existingValue"></param>
    public void InsertAfter(T newItem, T existingItem)
    {
         var existingNode = GetNode(existingItem);

    if (existingNode == null)
    {
        Append(newItem);
        return;
    }

    var newNode = new LinkedListNode<T>(newItem);

    newNode.Next = existingNode.Next;
    existingNode.Next = newNode;

    if (existingNode == Tail)
    {
        Tail = newNode;
    }

    Length++;
    }

    // TODO
    /// <summary>
    /// Insert value at given index 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="index"></param>
    public void InsertAt(T item, int index)
    {
        if (index < 0 || index > Length)
    {
        throw new IndexOutOfRangeException();
    }

    if (index == 0)
    {
        Prepend(item);
        return;
    }

    if (index == Length)
    {
        Append(item);
        return;
    }

    var previousNode = Head;

    for (int i = 0; i < index - 1; i++)
    {
        previousNode = previousNode.Next;
    }

    var newNode = new LinkedListNode<T>(item);

    newNode.Next = previousNode.Next;
    previousNode.Next = newNode;

    Length++;
    }

    // TODO
    /// <summary>
    /// Add value to beginning of list
    /// </summary>
    /// <param name="value"></param>
    public void Prepend(T item)
    {
        var newNode = new LinkedListNode<T>(item);
        if(IsEmpty)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }
        Length++;
    }

    // TODO
    /// <summary>
    /// Remove first item with given value
    /// </summary>
    /// <param name="value">value of item to be removed</param>
    public void Remove(T item)
    {
       if(IsEmpty)
       return;

       if(Head.Data.Equals(item))
        {
            
        }

        var currentNode = Head;
        while (currentNode != null)
        {
        var successorNode = currentNode.Next;

        if (successorNode.Data.Equals(item))
        {
            currentNode.Next = successorNode.Next;

            if (successorNode == Tail)
            {
                Tail = currentNode;
            }

            Length--;
            return;
        }

        currentNode = currentNode.Next;
    }
    }

    // TODO
    /// <summary>
    /// Removed item at specififed index.
    /// </summary>
    /// <param name="index"></param>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Length)
    {
        throw new IndexOutOfRangeException();
    }

    if (index == 0)
    {
        Remove(Head.Data);
        return;
    }

    var previousNode = Head;

    for (int i = 0; i < index - 1; i++)
    {
        previousNode = previousNode.Next;
    }

    var nodeToRemove = previousNode.Next;

    previousNode.Next = nodeToRemove.Next;

    if (nodeToRemove == Tail)
    {
        Tail = previousNode;
    }

    Length--;
    }

    // TODO
    /// <summary>
    /// Return a new copy of list in reverse order
    /// </summary>
    /// <returns></returns>
    public IList<T> Reverse()
    {
        var reversedList = new LinkedList<T>();

    var currentNode = Head;

    while (currentNode != null)
    {
        reversedList.Prepend(currentNode.Data);

        currentNode = currentNode.Next;
    }

    return reversedList;
    }

    private LinkedListNode<T> GetNode(T item)
    {
            var currentNode = Head;

    while (currentNode != null)
    {
        if (currentNode.Data.Equals(item))
        {
            return currentNode;
        }

        currentNode = currentNode.Next;
    }

    return null;

    }
    

    public override string ToString()
    {
        string str = "[ ";
        var currentNode = Head;
        while (currentNode != null)
        {
            str += currentNode.Data.ToString();

            if (currentNode != Tail)
            {
                str += ", ";
            }
            currentNode = currentNode.Next;
        }
        str += "]";
        return str;
    }
}
