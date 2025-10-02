using System;

class Program
{
    static void Main(string[] args)
    {


        // Sample test entry
        Entry testEntry = new Entry("2025-09-18", "what was the best part of your day?", "   Talking to my friend.   ");
        Console.WriteLine("\nSample Entry:");
        Console.WriteLine(testEntry.ToString());
    }
}

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public string Date
    {
        get { return _date; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _date = value;
            else
                _date = "Unknown Date";
        }
    }

    public string Prompt
    {
        get { return _prompt; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _prompt = char.ToUpper(value[0]) + value.Substring(1);
            else
                _prompt = "No prompt provided.";
        }
    }

    public string Response
    {
        get { return _response; }
        set
        {
            _response = string.IsNullOrWhiteSpace(value) ? "No response given." : value.Trim();
        }
    }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"[{Date}] Prompt: {Prompt}\nResponse: {Response}";
    }
}
