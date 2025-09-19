// This program exceeds core requirements by:
// - Auto-filling the date for journal entries
// - Randomly selecting prompts from a list
// - Reporting how many entries were loaded from file

using System;
using System.Collections.Generic;

class Program
{
    static List<string> promptList = new List<string>
    {
        "What made you smile today?",
        "Describe a moment you felt proud.",
        "What’s something you’re grateful for?",
        "What challenged you today?",
        "Write about someone who inspires you.",
        "What’s a goal you’re working toward?",
        "How did you take care of yourself today?",
        "What’s a memory that makes you laugh?",
        "What’s something new you learned?",
        "What’s a dream you want to pursue?"
    };

    static string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(promptList.Count);
        return promptList[index];
    }
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("📓 Welcome to the Journal App!");

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    Console.WriteLine($"Date auto-filled: {date}");

                    string prompt = GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");

                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added.");
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save journal: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("Enter filename to load journal: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
