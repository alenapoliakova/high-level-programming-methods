using NUnit.Framework;

[TestFixture]
public class BracketCheckerTests
{
    [TestCase("()", true)]
    [TestCase("(a + b) * (c - d)", true)]
    [TestCase(")", false)]
    [TestCase("(", false)]
    [TestCase("((())", false)]
    [TestCase("())(", false)]
    [TestCase("()()()()", true)]
    [TestCase("(())", true)]
    [TestCase("(a + b) * (c - d)", true)]
    [TestCase("()(", false)]
    [TestCase("(())(", false)]
    [TestCase("())(", false)]

    public void AreBracketsPlacedCorrectly_Test(string expression, bool expectedResult)
    {
        BracketChecker bracketChecker = new BracketChecker(expression.Length);
        bool result = bracketChecker.AreBracketsPlacedCorrectly(expression);
        Assert.AreEqual(expectedResult, result);
    }
}
