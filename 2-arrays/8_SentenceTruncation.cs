using System;

public class SentenceTruncation
{
    public static string TruncateSentence(string str, int wordCount)
    {
        string[] words = str.Split(' ');
        if (wordCount > words.Length) return str;
        return string.Join(" ", words, 0, wordCount);
    }

    static void Main()
    {
        string input = "Today is a good day";
        string output = TruncateSentence(input, 2);
        Console.WriteLine($"{input}.split()[:2] = {output}");
    }
}
