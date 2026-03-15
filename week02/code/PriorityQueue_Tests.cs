using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // ======== ANSWER ======== // (by Jéssica Seniw)
    // Scenario: Adding a single item and then dequeuing it
    // Expected Result: The item is returned by Dequeue and the queue becomes empty afterwards
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);

        // Dequeue should return the item
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);

        // Queue should now be empty; Dequeue should throw
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // ======== ANSWER ======== // (by Jéssica Seniw)
    // Scenario: Dequeuing from a queue with multiple items of different priorities
    // Expected Result: Items are dequeued in order of highest priority first
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        // Highest priority is B
        var result1 = priorityQueue.Dequeue();
        Assert.AreEqual("B", result1);

        // Next highest is C
        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("C", result2);

        // Next is A
        var result3 = priorityQueue.Dequeue();
        Assert.AreEqual("A", result3);

        // Queue now empty
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}