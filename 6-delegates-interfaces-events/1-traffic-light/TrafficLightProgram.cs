using System;
using System.Threading;

/// <summary>
/// Interface for a traffic light signal.
/// </summary>
public interface ITrafficLightSignal
{
    /// <summary>
    /// Event triggered when the signal changes.
    /// </summary>
    event Action OnSignalChanged;

    /// <summary>
    /// Starts the traffic light signal, simulating its operation.
    /// </summary>
    void Start();
}

/// <summary>
/// Implementation of a traffic light signal.
/// </summary>
public class TrafficLightSignal : ITrafficLightSignal
{
    /// <summary>
    /// Event triggered when the signal changes.
    /// </summary>
    public event Action OnSignalChanged;

    private int duration; // Duration of the signal in seconds

    /// <summary>
    /// Initializes a new instance of the TrafficLightSignal class with the specified duration.
    /// </summary>
    /// <param name="duration">The duration of the signal in seconds.</param>
    public TrafficLightSignal(int duration)
    {
        this.duration = duration;
    }

    /// <summary>
    /// Starts the traffic light signal, simulating its operation.
    /// </summary>
    public void Start()
    {
        Console.WriteLine($"Signal turned on: {GetSignalName()}");
        Thread.Sleep(duration * 1000);

        // The signal has changed, invoke the event
        OnSignalChanged?.Invoke();
    }

    private string GetSignalName()
    {
        return duration == 20 ? "Red" : (duration == 5 ? "Yellow" : "Green");
    }
}

/// <summary>
/// Class representing a traffic light with multiple signals.
/// </summary>
public class TrafficLight
{
    public ITrafficLightSignal[] signals;
    private int currentIndex;

    /// <summary>
    /// Initializes a new instance of the TrafficLight class.
    /// </summary>
    public TrafficLight()
    {
        signals = new ITrafficLightSignal[]
        {
            new TrafficLightSignal(20), // Red
            new TrafficLightSignal(5),  // Yellow
            new TrafficLightSignal(15)  // Green
        };

        // Subscribe to the signal change event
        for (int i = 0; i < signals.Length - 1; i++)
        {
            signals[i].OnSignalChanged += ChangeSignal;
        }

        // Link the last signal to the first to cyclically switch between signals
        signals[signals.Length - 1].OnSignalChanged += ChangeSignal;
    }

    /// <summary>
    /// Starts the traffic light, initiating the signal cycle.
    /// </summary>
    public void Start()
    {
        currentIndex = 0;
        signals[currentIndex].Start();
    }

    private void ChangeSignal()
    {
        currentIndex = (currentIndex + 1) % signals.Length;
        signals[currentIndex].Start();
    }
}

/// <summary>
/// Main program class.
/// </summary>
public class TrafficLightProgram
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
        TrafficLight trafficLight = new TrafficLight();
        trafficLight.Start();
    }
}
