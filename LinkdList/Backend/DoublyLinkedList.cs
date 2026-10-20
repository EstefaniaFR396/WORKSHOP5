namespace Backend;

public class DoublyLinkedList<T>
    where T : notnull, IComparable<T>
{
    private Node<T>? head;
    private Node<T>? tail;
    private bool isDescending = false;

    public bool IsEmpty => head == null;

    // 1. Add an element in ascending order
    public void Add(T value)
    {
        // Restore ascending order before inserting.
        if (isDescending)
        {
            ReverseLinks();
            isDescending = false;
        }

        Node<T> newNode = new Node<T>(value);

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        if (value.CompareTo(head.Data) < 0)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
            return;
        }

        Node<T> current = head;

        while (current.Next != null &&
               current.Next.Data.CompareTo(value) <= 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        newNode.Previous = current;

        if (current.Next != null)
            current.Next.Previous = newNode;
        else
            tail = newNode;

        current.Next = newNode;
    }

    // 2. Display the list from head to tail
    public void DisplayForward()
    {
        if (IsEmpty)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        Node<T>? current = head;

        Console.Write("Inicio -> ");

        while (current != null)
        {
            Console.Write(current.Data);

            if (current.Next != null)
                Console.Write(" <-> ");

            current = current.Next;
        }

        Console.WriteLine(" <- Fin");
    }

    // 3. Display the list from tail to head
    public void DisplayBackward()
    {
        if (IsEmpty)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        Node<T>? current = tail;

        Console.Write("Fin -> ");

        while (current != null)
        {
            Console.Write(current.Data);

            if (current.Previous != null)
                Console.Write(" <-> ");

            current = current.Previous;
        }

        Console.WriteLine(" <- Inicio");
    }

    // Reverse the actual links
    private void ReverseLinks()
    {
        Node<T>? current = head;

        while (current != null)
        {
            Node<T>? temporary = current.Next;

            current.Next = current.Previous;
            current.Previous = temporary;

            current = temporary;
        }

        Node<T>? oldHead = head;
        head = tail;
        tail = oldHead;
    }

    // 4. Sort the list in descending order
    public void SortDescending()
    {
        if (IsEmpty || isDescending)
            return;

        ReverseLinks();
        isDescending = true;
    }

    // Get the frequency of every element
    private Dictionary<T, int> GetFrequencies()
    {
        Dictionary<T, int> frequencies = new();
        Node<T>? current = head;

        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data))
                frequencies[current.Data]++;
            else
                frequencies[current.Data] = 1;

            current = current.Next;
        }

        return frequencies;
    }

    // 5. Display all modes
    public void DisplayModes()
    {
        if (IsEmpty)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        Dictionary<T, int> frequencies = GetFrequencies();
        int maxFrequency = 0;

        foreach (int frequency in frequencies.Values)
        {
            if (frequency > maxFrequency)
                maxFrequency = frequency;
        }

        Console.WriteLine("Moda(s):");

        foreach (KeyValuePair<T, int> entry in frequencies)
        {
            if (entry.Value == maxFrequency)
            {
                Console.WriteLine(
                    $"{entry.Key} (ocurrencias: {entry.Value})");
            }
        }
    }

    // 6. Display the occurrence graph
    public void DisplayGraph()
    {
        if (IsEmpty)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        Dictionary<T, int> frequencies = GetFrequencies();

        Console.WriteLine("GRAFICO DE OCURRENCIAS");

        foreach (KeyValuePair<T, int> entry in frequencies)
        {
            Console.WriteLine(
                $"{entry.Key}: {new string('*', entry.Value)}");
        }
    }

    // 7. Check whether an element exists
    public bool Contains(T value)
    {
        Node<T>? current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(
                current.Data, value))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    // 8. Remove the first occurrence
    public bool RemoveOne(T value)
    {
        Node<T>? current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(
                current.Data, value))
            {
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;

                return true;
            }

            current = current.Next;
        }

        return false;
    }

    // 9. Remove all occurrences
    public int RemoveAll(T value)
    {
        int removedCount = 0;

        while (RemoveOne(value))
        {
            removedCount++;
        }

        return removedCount;
    }
}
