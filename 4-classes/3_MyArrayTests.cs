using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class MyArrayTests
{
    [Test]
    public void InputData_InputValidData_ArrayContainsEnteredValues()
    {
        MyArray myArray = new MyArray(3);
        int[] testData = { 1, 2, 3 };
        string input = string.Join(Environment.NewLine, testData);

        Console.SetIn(new System.IO.StringReader(input));
        myArray.InputData();

        Assert.AreEqual(testData, myArray.array);
    }

    [Test]
    public void InputDataRandom_GenerateRandomData_ArrayContainsRandomValues()
    {
        MyArray myArray = new MyArray(3);

        myArray.InputDataRandom();

        Assert.That(myArray.array, Has.All.GreaterThanOrEqualTo(1).And.LessThanOrEqualTo(100));
    }


    [Test]
    public void FindValue_ValueExistsInArray_ReturnsCorrectIndices()
    {
        MyArray myArray = new MyArray(5);
        myArray.array = new int[] { 1, 2, 3, 2, 4 };

        List<int> indices = myArray.FindValue(2);

        Assert.AreEqual(new List<int> { 1, 3 }, indices);
    }

    [Test]
    public void DelValue_ValueExistsInArray_ValueRemoved()
    {
        MyArray myArray = new MyArray(5);
        myArray.array = new int[] { 1, 2, 3, 2, 4 };
        int searchValue = 2;

        myArray.DelValue(ref searchValue);
        myArray.Print(0, myArray.Length - 1);

        Assert.AreEqual(new int[] { 1, 3, 4 }, myArray.array);
    }

    [Test]
    public void FindMax_MaxValueInArray_ReturnsMaxValueAndIndex()
    {
        MyArray myArray = new MyArray(5);
        myArray.array = new int[] { 1, 5, 3, 2, 4 };

        int max = myArray.FindMax(out int maxIndex);

        Assert.AreEqual(5, max);
        Assert.AreEqual(1, maxIndex);
    }

    [Test]
    public void Add_AddArraysOfSameLength_CorrectSumArray()
    {
        MyArray myArray = new MyArray(3);
        myArray.array = new int[] { 1, 2, 3 };
        MyArray otherArray = new MyArray(3);
        otherArray.array = new int[] { 4, 5, 6 };

        myArray.Add(in otherArray);

        Assert.AreEqual(new int[] { 5, 7, 9 }, myArray.array);
    }

    [Test]
    public void Sort_SortArrayInDescendingOrder_SortedArrayInAscendingOrder()
    {
        MyArray myArray = new MyArray(5);
        myArray.array = new int[] { 5, 3, 1, 4, 2 };

        myArray.Sort();

        Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, myArray.array);
    }
}
