using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, Dequeue returns highest priority value first, then FIFO for same priority
    // Expected Result: "B", "A", "C"
    // Defect(s) Found: 
    // When I run this test, it works correct. The dequeue give me "B" first (because it has highest priority), then "A" and "C" (they have same priority, so it is FIFO). I do not find problem in this test.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 1);
        Assert.AreEqual("B", pq.Dequeue()); // Highest priority
        Assert.AreEqual("A", pq.Dequeue()); // Next in FIFO order for same priority
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items with the same highest priority, Dequeue returns them in FIFO order
    // Expected Result: "X", "Y", "Z"
    // Defect(s) Found: 
    // This test also works good. All items have same priority, so dequeue return them in the order I add them. No
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 5);
        pq.Enqueue("Y", 5);
        pq.Enqueue("Z", 5);
        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
    }

    // Add more test cases as needed below.
}