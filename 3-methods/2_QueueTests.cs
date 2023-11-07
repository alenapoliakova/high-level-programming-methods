using NUnit.Framework;

[TestFixture]
public class QueueTests
{
    [Test]
    public void Push_PopFront_Size_Clear_Test()
    {
        Queue queue = new Queue(5);

        queue.Push(1);
        queue.Push(2);
        queue.Push(3);

        Assert.AreEqual(1, queue.Front());
        Assert.AreEqual(3, queue.Size());

        int popped = queue.Pop();
        Assert.AreEqual(1, popped);

        Assert.AreEqual(2, queue.Front());
        Assert.AreEqual(2, queue.Size());

        queue.Clear();
        Assert.AreEqual(0, queue.Size());
    }

    [Test]
    public void Push_WhenQueueIsFull_Test()
    {
        Queue queue = new Queue(3);

        queue.Push(1);
        queue.Push(2);
        queue.Push(3);

        // Should not be able to push, as the queue is full
        queue.Push(4);

        Assert.AreEqual(1, queue.Front());
        Assert.AreEqual(3, queue.Size());
    }

    [Test]
    public void Pop_Front_Size_WhenQueueIsEmpty_Test()
    {
        Queue queue = new Queue(5);

        // Pop when the queue is empty
        queue.Pop();

        int front = queue.Front();

        // Front when the queue is empty should return -1
        Assert.AreEqual(-1, front);

        int size = queue.Size();
        Assert.AreEqual(0, size);
    }
}
