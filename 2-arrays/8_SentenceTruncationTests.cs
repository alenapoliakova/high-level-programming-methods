using NUnit.Framework;

[TestFixture]
public class SentenceTruncationTests
{
    [Test]
    public void TruncateSentence_ReturnsOriginalString_WhenWordCountIsGreaterThanWordLength()
    {
        string str = "Today is a good day";
        Assert.AreEqual(str, SentenceTruncation.TruncateSentence(str, 5));
    }

    [Test]
    public void TruncateSentence_TruncatesString_WhenWordCountIsLessThanWordLength()
    {
        string input = "Today is a good day";
        Assert.AreEqual("Today is", SentenceTruncation.TruncateSentence(input, 2));
    }

    [Test]
    public void TruncateSentence_ReturnsEmptyString_WhenInputIsEmpty()
    {
        Assert.AreEqual("", SentenceTruncation.TruncateSentence("", 3));
    }
}
