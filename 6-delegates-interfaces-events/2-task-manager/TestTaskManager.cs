using NUnit.Framework;
using System;

[TestFixture]
public class TaskManagerTests
{
    [Test]
    public void CompleteTask_StatusChanged_EventRaised()
    {
        TaskManager taskManager = new TaskManager();
        TaskObserver taskObserver = new TaskObserver();
        Task task = new Task { Title = "Test Task", Description = "Test Description" };

        bool eventRaised = false;

        task.TaskStatusChanged += (t) => { eventRaised = true; };

        taskManager.CompleteTask(task);

        Assert.IsTrue(task.IsCompleted);
        Assert.IsTrue(eventRaised);
    }
}

[TestFixture]
public class TaskObserverTests
{
    [Test]
    public void TaskCompletedNotification_CorrectMessageDisplayed()
    {
        TaskObserver taskObserver = new TaskObserver();
        Task task = new Task { Title = "Test Task", Description = "Test Description" };

        using (var consoleOutput = new ConsoleOutput())
        {
            taskObserver.TaskCompletedNotification(task);

            Assert.AreEqual($"Task '{task.Title}' is completed!" + Environment.NewLine, consoleOutput.GetOuput());
        }
    }
}

public class ConsoleOutput : IDisposable
{
    private readonly StringWriter stringWriter;
    private readonly TextWriter originalOutput;

    public ConsoleOutput()
    {
        stringWriter = new StringWriter();
        originalOutput = Console.Out;
        Console.SetOut(stringWriter);
    }

    public string GetOuput()
    {
        return stringWriter.ToString();
    }

    public void Dispose()
    {
        stringWriter.Dispose();
        Console.SetOut(originalOutput);
    }
}
