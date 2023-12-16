using System;

class TriangleTypeCheckerProgram
{
    static void Main()
    {
        Console.Write("Enter the length of the first side of the triangle: ");
        if (double.TryParse(Console.ReadLine(), out double side1))
        {
            Console.Write("Enter the length of the second side of the triangle: ");
            if (double.TryParse(Console.ReadLine(), out double side2))
            {
                Console.Write("Enter the length of the third side of the triangle: ");
                if (double.TryParse(Console.ReadLine(), out double side3))
                {
                    if (IsTriangle(side1, side2, side3))
                    {
                        string triangleType = DetermineTriangleType(side1, side2, side3);
                        Console.WriteLine($"This is a {triangleType} triangle");
                    }
                    else Console.WriteLine("This triangle is not possible");
                }
                else Console.WriteLine("Incorrect third side");
            }
            else Console.WriteLine("Incorrect second side");
        }
        else Console.WriteLine("Incorrect first side");
    }

    static bool IsTriangle(double a, double b, double c)
    {
        // Check for the triangle inequality to determine if a triangle is possible
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    static string DetermineTriangleType(double a, double b, double c)
    {
        if (a == b && b == c) return "equilateral";
        else if (a == b || a == c || b == c) return "isosceles";
        else if (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a) return "right-angled";
        return "scalene";
    }
}
