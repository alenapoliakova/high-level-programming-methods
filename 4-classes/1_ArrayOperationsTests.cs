using NUnit.Framework;
using System;
using System.IO;

[TestFixture]
public class ArrayOperationsTests
{
    private StringWriter _consoleOutput;

    [SetUp]
    public void Setup()
    {
        _consoleOutput = new StringWriter();
        Console.SetOut(_consoleOutput);
    }

    [TearDown]
    public void Cleanup()
    {
        _consoleOutput.Dispose();
    }

    [Test]
    public void Test_FindMin()
    {
        int[] row = { 5, 2, 8, 1, 9 };
        int result = ArrayOperations.FindMin(row);
        Assert.AreEqual(1, result);
    }

    [Test]
    public void Test_FindMax()
    {
        int[] row = { 5, 2, 8, 1, 9 };
        int result = ArrayOperations.FindMax(row);
        Assert.AreEqual(9, result);
    }

    [Test]
    public void Test_CalculateSum()
    {
        int[] row = { 5, 2, 8, 1, 9 };
        int result = ArrayOperations.CalculateSum(row);
        Assert.AreEqual(25, result);
    }

    [Test]
    public void Test_MainWithInvalidInput()
    {
        string input = "invalid\n3 5 7\n";
        using (StringReader stringReader = new StringReader(input))
        {
            Console.SetIn(stringReader);

            ArrayOperations.Main();

            string expectedOutput = "Enter the number of rows in the array: Incorrect input. Please enter a positive integer.\r\n";
            Assert.AreEqual(expectedOutput, _consoleOutput.ToString());
        }
    }
}
