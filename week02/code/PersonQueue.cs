/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person);
    }

    public Person Dequeue()
    {
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
    
    // Extra helper: access by index (needed for PriorityQueue)
    public Person Peek(int index)
    {
        return _queue[index];
    }

    // Extra helper: remove at specific index (needed for PriorityQueue)
    public Person RemoveAt(int index)
    {
        var person = _queue[index];
        _queue.RemoveAt(index);
        return person;
    }
}

