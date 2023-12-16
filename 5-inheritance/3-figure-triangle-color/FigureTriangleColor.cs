using System;

/// <summary>
/// Abstract class representing a geometric figure.
/// </summary>
public abstract class Figure
{
    private string name;

    /// <summary>
    /// Constructor with one parameter, initializing the name of the figure.
    /// </summary>
    /// <param name="name">The name of the figure.</param>
    public Figure(string name)
    {
        this.name = name;
    }

    /// <summary>
    /// Property for accessing the name of the figure.
    /// </summary>
    public string Name
    {
        get { return name; }
    }

    /// <summary>
    /// Abstract property for obtaining the area of the figure.
    /// </summary>
    public abstract double Area2 { get; }

    /// <summary>
    /// Abstract method for obtaining the area of the figure.
    /// </summary>
    public abstract double Area();

    /// <summary>
    /// Virtual method for displaying information about the figure.
    /// </summary>
    public virtual void Print()
    {
        Console.WriteLine($"Figure: {Name}");
    }
}

/// <summary>
/// Class representing a triangle, inheriting from Figure.
/// </summary>
public class Triangle : Figure
{
    private double a, b, c;

    /// <summary>
    /// Constructor with four parameters, initializing the name and sides of the triangle.
    /// </summary>
    public Triangle(string name, double a, double b, double c) : base(name)
    {
        SetABC(a, b, c);
    }

    /// <summary>
    /// Method for setting the values of the triangle sides.
    /// </summary>
    public void SetABC(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    /// <summary>
    /// Method for getting the values of the triangle sides.
    /// </summary>
    public (double a, double b, double c) GetABC()
    {
        return (a, b, c);
    }

    /// <summary>
    /// Property for determining the area of the triangle based on its sides.
    /// </summary>
    public override double Area2
    {
        get
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }

    /// <summary>
    /// Method for getting the area of the triangle.
    /// </summary>
    public override double Area()
    {
        return Area2;
    }

    /// <summary>
    /// Virtual method for displaying information about the triangle.
    /// </summary>
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Triangle sides: {a}, {b}, {c}");
    }
}

/// <summary>
/// Class representing a colored triangle, inheriting from Triangle.
/// </summary>
public class TriangleColor : Triangle
{
    private string color;

    /// <summary>
    /// Constructor with five parameters, calling the base class constructor and initializing the color.
    /// </summary>
    public TriangleColor(string name, double a, double b, double c, string color) : base(name, a, b, c)
    {
        this.color = color;
    }

    /// <summary>
    /// Property for accessing the color of the triangle.
    /// </summary>
    public string Color
    {
        get { return color; }
    }

    /// <summary>
    /// Property calling the base class property to calculate the area of the triangle.
    /// </summary>
    public override double Area2
    {
        get { return base.Area2; }
    }

    /// <summary>
    /// Method for getting the area of the triangle.
    /// </summary>
    public override double Area()
    {
        return Area2;
    }

    /// <summary>
    /// Virtual method for displaying information about the colored triangle.
    /// </summary>
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Triangle background color: {color}");
    }
}

/// <summary>
/// Class containing the entry point for the program.
/// </summary>
public class Program
{
    /// <summary>
    /// Entry point for the program.
    /// </summary>
    static void Main()
    {
        TriangleColor coloredTriangle = new TriangleColor("Triangle", 3, 4, 5, "Red");
        coloredTriangle.Print();
        Console.WriteLine($"Triangle area: {coloredTriangle.Area()}");
    }
}
