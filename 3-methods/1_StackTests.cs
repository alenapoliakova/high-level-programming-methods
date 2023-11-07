using NUnit.Framework;

[TestFixture]
public class StackTests
{
    [Test]
    public void TestPushAndPop()
    {
        Stack stack = new Stack(5);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.AreEqual(3, stack.Pop());
        Assert.AreEqual(2, stack.Pop());
        Assert.AreEqual(1, stack.Pop());

        // Stack is empty
        Assert.AreEqual(-1, stack.Pop());
    }

    [Test]
    public void TestPeek()
    {
        Stack stack = new Stack(5);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.AreEqual(3, stack.Peek());
        stack.Pop();
        Assert.AreEqual(2, stack.Peek());
        stack.Pop();
        Assert.AreEqual(1, stack.Peek());
        stack.Pop();

        // Stack is empty
        Assert.AreEqual(-1, stack.Peek());
    }

    [Test]
    public void TestSize()
    {
        Stack stack = new Stack(5);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.AreEqual(3, stack.Size());
        stack.Pop();
        Assert.AreEqual(2, stack.Size());
        stack.Pop();
        Assert.AreEqual(1, stack.Size());
        stack.Pop();
        Assert.AreEqual(0, stack.Size());
    }

    [Test]
    public void TestClear()
    {
        Stack stack = new Stack(5);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        stack.Clear();
        Assert.AreEqual(0, stack.Size());

        // Stack is empty
        Assert.AreEqual(-1, stack.Pop());
    }
}
