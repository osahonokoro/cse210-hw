using System;
using System.Collections.Generic;
using System.IO;

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
                Console.WriteLine($"Skipped invalid entry format: {line}");
            }
        }

        Console.WriteLine($"✅ Loaded {loadedCount} entries from '{filename}'.");
    }

}
