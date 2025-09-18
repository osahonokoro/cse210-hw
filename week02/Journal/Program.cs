using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

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
public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
            return;
        }

        Console.WriteLine("----- Journal Entries -----");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
            Console.WriteLine("---------------------------");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                string safeResponse = entry.Response.Replace("\n", " ").Replace("\r", " ");
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{safeResponse}");
            }
        }

        Console.WriteLine($"Journal saved to '{filename}'.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        int loadedCount = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[0], parts[1], parts[2]);
                _entries.Add(entry);
                loadedCount++;
            }
            else
            {
                Console.WriteLine($"⚠️ Skipped invalid entry format: {line}");
            }
        }

        Console.WriteLine($"✅ Loaded {loadedCount} entries from '{filename}'.");
    }

}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        Console.WriteLine("📓 Welcome to the Journal App!");

        // Load entries
        Console.Write("Enter filename to load journal (e.g., journal.txt): ");
        string loadFilename = Console.ReadLine();
        journal.LoadFromFile(loadFilename);

        // Display loaded entries
        journal.DisplayEntries();

        // Add a new entry
        Console.Write("Would you like to add a new entry? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        if (response == "yes")
        {
            Console.Write("Enter today's date (Using the format: yyyy-mm-dd e.g., 2025-09-18): ");
            string date = Console.ReadLine();

            Console.Write("Enter your journal prompt: ");
            string prompt = Console.ReadLine();

            Console.Write("Enter your response: ");
            string entryText = Console.ReadLine();

            Entry newEntry = new Entry(date, prompt, entryText);
            journal.AddEntry(newEntry);
        }

        // Save updated journal
        Console.Write("Enter filename to save journal: ");
        string saveFilename = Console.ReadLine();
        journal.SaveToFile(saveFilename);

        Console.WriteLine("✅ Journal saved. Goodbye!");
    }
}