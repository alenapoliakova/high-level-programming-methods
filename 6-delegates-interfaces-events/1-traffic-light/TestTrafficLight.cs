using NUnit.Framework;
using System;
using System.Threading;

[TestFixture]
public class TrafficLightTests
{
    [Test]
    public void TrafficLight_CyclesThroughSignals()
    {
        TrafficLight trafficLight = new TrafficLight();

        // Mock the Console output
        using (ConsoleOutput output = new ConsoleOutput())
        {
            trafficLight.Start();
            string consoleOutput = output.GetOuput();

            // Check if each signal is printed at least once
            Assert.IsTrue(consoleOutput.Contains("Signal turned on: Red"));
            Assert.IsTrue(consoleOutput.Contains("Signal turned on: Yellow"));
            Assert.IsTrue(consoleOutput.Contains("Signal turned on: Green"));
        }
    }

    [Test]
    public void TrafficLight_SignalChangedEventIsRaised()
    {
        TrafficLight trafficLight = new TrafficLight();
        bool eventRaised = false;

        trafficLight.Start();

        // Hook up an event handler to the first signal
        ((TrafficLightSignal)trafficLight.signals[0]).OnSignalChanged += () => eventRaised = true;

        // Sleep to allow the first signal to complete
        Thread.Sleep(20000); // 20 seconds for the Red signal

        Assert.IsTrue(eventRaised, "OnSignalChanged event was not raised.");
    }

    [Test]
    public void TrafficLightSignal_SimulatesSignalOperation()
    {
        TrafficLightSignal signal = new TrafficLightSignal(5); // Yellow signal (5 seconds)
        bool eventRaised = false;

        // Hook up an event handler to the signal
        signal.OnSignalChanged += () => eventRaised = true;

        signal.Start();

        // Sleep to allow the signal to complete
        Thread.Sleep(6000); // 6 seconds for the Yellow signal

        Assert.IsTrue(eventRaised, "OnSignalChanged event was not raised.");
    }
}

public class ConsoleOutput : IDisposable
{
    private readonly System.IO.StringWriter stringWriter;
    private readonly System.IO.TextWriter originalOutput;

    public ConsoleOutput()
    {
        stringWriter = new System.IO.StringWriter();
        originalOutput = Console.Out;
        Console.SetOut(stringWriter);
    }

    public string GetOuput()
    {
        return stringWriter.ToString();
    }

    public void Dispose()
    {
        Console.SetOut(originalOutput);
        stringWriter.Dispose();
    }
}
