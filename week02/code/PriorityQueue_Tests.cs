using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 3);

        Assert.AreEqual("B", queue.Dequeue());  // highest priority
        Assert.AreEqual("C", queue.Dequeue());  // next highest
        Assert.AreEqual("A", queue.Dequeue());  // lowest
    }
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("X", 2);
        queue.Enqueue("Y", 2);

        Assert.AreEqual("X", queue.Dequeue());  // same priority, X was added first
        Assert.AreEqual("Y", queue.Dequeue());
    }

    // Add more test cases as needed below.
    [TestMethod]
    public void TestPriorityQueue_HighestPriorityReturned()
    {
        // Scenario: Enqueue multiple items with different priorities
        // Expected Result: Highest priority item is dequeued first (B has 99)
        // Defect(s) Found: None yet
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 99);
        pq.Enqueue("C", 5);

        var result = pq.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        // Scenario: Multiple items with the same priority
        // Expected Result: Items are returned in the order they were added (FIFO)
        // Defect(s) Found: None yet
        var pq = new PriorityQueue();
        pq.Enqueue("X", 10);
        pq.Enqueue("Y", 10);
        pq.Enqueue("Z", 10);

        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
    }

    [TestMethod]
    public void TestPriorityQueue_SingleItem()
    {
        // Scenario: One item
        // Expected Result: That item is returned
        // Defect(s) Found: None yet
        var pq = new PriorityQueue();
        pq.Enqueue("OnlyOne", 5);
        Assert.AreEqual("OnlyOne", pq.Dequeue());
    }

    [TestMethod]
    public void TestPriorityQueue_EmptyDequeue()
    {
        // Scenario: Dequeue on empty queue
        // Expected Result: Exception thrown
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    

    
}