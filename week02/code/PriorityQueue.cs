// ======== Test Results: ======== //  (by Jéssica Seniw)
// Enqueue adds to the back - PASSED
// Dequeue returns highest priority item - PASSED
// Dequeue returns first item on tie (FIFO) - PASSED
// Dequeue throws exception when empty - PASSED

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // ======== Find the index of the item with the highest priority to remove ======== //  (by Jéssica Seniw)
        var highPriorityIndex = 0;

        // ======== Before: for (int index = 1; index < _queue.Count - 1; index++) ======== //  (by Jéssica Seniw)
        // Issue: the last element of the list was ignored, potentially skipping the highest priority item
        // Fixed:
        for (int index = 1; index < _queue.Count; index++)
        {
            // ======== Before: if (_queue[index].Priority >= _queue[highPriorityIndex].Priority) ======== //  (by Jéssica Seniw)
            // Issue: using >= caused the last item to be chosen in case of a tie (FIFO broken)
            // Fixed: use > to maintain FIFO for items with the same highest priority
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = index;
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;

        // ======== Before: the item was not removed from the queue ======== //  (by Jéssica Seniw)
        // Fixed:
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}