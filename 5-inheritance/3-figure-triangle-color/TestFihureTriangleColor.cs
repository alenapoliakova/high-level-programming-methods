using NUnit.Framework;

[TestFixture]
public class FigureTests
{
    [Test]
    public void Figure_Print_ShouldReturnCorrectString()
    {
        Figure figure = new Triangle("Triangle", 3, 4, 5);

        string result = CaptureConsoleOutput(() => figure.Print());

        Assert.AreEqual("Figure: Triangle\r\nTriangle sides: 3, 4, 5\r\n", result);
    }

    [Test]
    public void Triangle_Area_ShouldReturnCorrectValue()
    {
        Triangle triangle = new Triangle("Triangle", 3, 4, 5);

        double result = triangle.Area();

        Assert.AreEqual(6, result, 0.001);
    }

    [Test]
    public void TriangleColor_Print_ShouldReturnCorrectString()
    {
        TriangleColor coloredTriangle = new TriangleColor("Triangle", 3, 4, 5, "Red");

        string result = CaptureConsoleOutput(() => coloredTriangle.Print());

        Assert.AreEqual("Figure: Triangle\r\nTriangle sides: 3, 4, 5\r\nTriangle background color: Red\r\n", result);
    }

    [Test]
    public void TriangleColor_Area_ShouldReturnCorrectValue()
    {
        TriangleColor coloredTriangle = new TriangleColor("Triangle", 3, 4, 5, "Red");

        double result = coloredTriangle.Area();

        Assert.AreEqual(6, result, 0.001);
    }

    private string CaptureConsoleOutput(Action action)
    {
        using (System.IO.StringWriter sw = new System.IO.StringWriter())
        {
            System.Console.SetOut(sw);
            action.Invoke();
            return sw.ToString();
        }
    }
}
