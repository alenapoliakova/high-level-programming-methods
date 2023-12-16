using System;

/// <summary>
/// Represents a task with properties such as title, description, and completion status.
/// </summary>
public class Task
{
    /// <summary>
    /// Gets or sets the title of the task.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the description of the task.
    /// </summary>
    public string Description { get; set; }

    private bool isCompleted;

    /// <summary>
    /// Gets or sets a value indicating whether the task is completed.
    /// </summary>
    public bool IsCompleted
    {
        get { return isCompleted; }
        set
        {
            if (isCompleted != value)
            {
                isCompleted = value;
                OnTaskStatusChanged(this);
            }
        }
    }

    /// <summary>
    /// Delegate for handling the event when the task status changes.
    /// </summary>
    public delegate void TaskStatusChangedHandler(Task task);

    /// <summary>
    /// Event that is triggered when the task status changes.
    /// </summary>
    public event TaskStatusChangedHandler TaskStatusChanged;

    /// <summary>
    /// Raises the TaskStatusChanged event.
    /// </summary>
    /// <param name="task">The task whose status has changed.</param>
    protected virtual void OnTaskStatusChanged(Task task)
    {
        TaskStatusChanged?.Invoke(task);
    }
}

/// <summary>
/// Manages tasks, including methods for creating, updating, and deleting tasks.
/// </summary>
public class TaskManager
{
    /// <summary>
    /// Completes the specified task by setting its status to "completed" and triggering the event.
    /// </summary>
    /// <param name="task">The task to be completed.</param>
    public void CompleteTask(Task task)
    {
        task.IsCompleted = true;
    }
}

/// <summary>
/// Represents an observer that reacts to task status changes.
/// </summary>
public class TaskObserver
{
    /// <summary>
    /// Notifies that the specified task has been completed.
    /// </summary>
    /// <param name="task">The task that has been completed.</param>
    public void TaskCompletedNotification(Task task)
    {
        Console.WriteLine($"Task '{task.Title}' is completed!");
    }
}

class TaskManagerProgram
{
    static void Main()
    {
        // Create instances of TaskManager and TaskObserver
        TaskManager taskManager = new TaskManager();
        TaskObserver taskObserver = new TaskObserver();

        // Create tasks
        Task task1 = new Task { Title = "Task 1", Description = "Description, Task 1" };
        Task task2 = new Task { Title = "Task 2", Description = "Description, Task 2" };

        // Subscribe the TaskObserver to the TaskStatusChanged event for each task
        task1.TaskStatusChanged += taskObserver.TaskCompletedNotification;
        task2.TaskStatusChanged += taskObserver.TaskCompletedNotification;

        // Add tasks to the TaskManager
        taskManager.CompleteTask(task1);
        taskManager.CompleteTask(task2);

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}
