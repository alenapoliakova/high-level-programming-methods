using NUnit.Framework;
using System;

[TestFixture]
public class BookTests
{
    [Test]
    public void Book_Print_ShouldPrintCorrectly()
    {
        Book book = new Book("The Book", "John Doe", 29.99);

        string printedInfo = TestHelpers.CaptureConsoleOutput(() => book.Print());

        StringAssert.Contains("Title: The Book, Author: John Doe, Cost: 29,99 ₽", printedInfo);
    }
}

[TestFixture]
public class BookGenreTests
{
    [Test]
    public void BookGenre_Print_ShouldPrintCorrectly()
    {
        BookGenre bookGenre = new BookGenre("The Genre Book", "Jane Doe", 19.99, "Mystery");

        string printedInfo = TestHelpers.CaptureConsoleOutput(() => bookGenre.Print());

        StringAssert.Contains("Title: The Genre Book, Author: Jane Doe, Cost: 19,99 ₽", printedInfo);
        StringAssert.Contains("Genre: Mystery", printedInfo);
    }
}

[TestFixture]
public class BookGenrePublTests
{
    [Test]
    public void BookGenrePubl_Print_ShouldPrintCorrectly()
    {
        BookGenrePubl bookGenrePubl = new BookGenrePubl("The Publ Book", "Jim Doe", 39.99, "Science Fiction", "XYZ Publishers");
        
        string printedInfo = TestHelpers.CaptureConsoleOutput(() => bookGenrePubl.Print());

        StringAssert.Contains("Title: The Publ Book, Author: Jim Doe, Cost: 39,99 ₽", printedInfo);
        StringAssert.Contains("Genre: Science Fiction", printedInfo);
        StringAssert.Contains("Publisher: XYZ Publishers", printedInfo);
    }
}

public static class TestHelpers
{
    public static string CaptureConsoleOutput(Action action)
    {
        using (System.IO.StringWriter sw = new System.IO.StringWriter())
        {
            System.Console.SetOut(sw);
            action.Invoke();
            return sw.ToString().Trim();
        }
    }
}
