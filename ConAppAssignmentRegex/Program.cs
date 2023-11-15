using System;
using System.Text.RegularExpressions;

class TextProcessingProgram
{
    static void Main()
    {
        string userText = GetUserInput();
        int wordCount = CountWords(userText);
        string[] emailAddresses = ValidateEmails(userText);
        string[] mobileNumbers = ExtractMobileNumbers(userText);

        Console.Write("Enter custom regex pattern: ");
        string customRegexPattern = Console.ReadLine();
        string[] customRegexResults = CustomRegexSearch(userText, customRegexPattern);

        DisplayResults(wordCount, emailAddresses, mobileNumbers, customRegexResults);
    }

    static string GetUserInput()
    {
        Console.Write("Enter a piece of text or paragraph: ");
        return Console.ReadLine();
    }

    static int CountWords(string text)
    {
        string[] words = Regex.Split(text, @"\b\w+\b");
        return words.Length - 1;
    }

    static string[] ValidateEmails(string text)
    {
        MatchCollection matches = Regex.Matches(text, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
        string[] emails = new string[matches.Count];

        for (int i = 0; i < matches.Count; i++)
        {
            emails[i] = matches[i].Value;
        }

        return emails;
    }

    static string[] ExtractMobileNumbers(string text)
    {
        MatchCollection matches = Regex.Matches(text, @"\b\d{10}\b");
        string[] numbers = new string[matches.Count];

        for (int i = 0; i < matches.Count; i++)
        {
            numbers[i] = matches[i].Value;
        }

        return numbers;
    }

    static string[] CustomRegexSearch(string text, string pattern)
    {
        MatchCollection matches = Regex.Matches(text, pattern);
        string[] results = new string[matches.Count];

        for (int i = 0; i < matches.Count; i++)
        {
            results[i] = matches[i].Value;
        }

        return results;
    }

    static void DisplayResults(int wordCount, string[] emailAddresses, string[] mobileNumbers, string[] customRegexResults)
    {
        Console.WriteLine($"Word Count: {wordCount}");
        Console.WriteLine($"Email Addresses: {string.Join(", ", emailAddresses)}");
        Console.WriteLine($"Mobile Numbers: {string.Join(", ", mobileNumbers)}");
        Console.WriteLine($"Custom Regex Search Results: {string.Join(", ", customRegexResults)}");
    }
}
