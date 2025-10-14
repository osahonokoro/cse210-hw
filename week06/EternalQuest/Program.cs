// This program exceeds core requirements by:
// - Supporting multiple goal types with polymorphism
// - Saving and loading goals with serialization
// - Displaying progress and score in game format
// - Using visual indicators like [X], [∞], and checklist progress
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nYour current score: {score}");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goals);
                    break;
                case "2":
                    ListGoals(goals);
                    break;
                case "3":
                    score += RecordEvent(goals);
                    break;
                case "4":
                    SaveGoals(goals, score);
                    break;
                case "5":
                    (goals, score) = LoadGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Your choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("How many times to complete? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points on completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void ListGoals(List<Goal> goals)
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].GetName()} - {goals[i].GetDescription()}");
        }
    }

    static int RecordEvent(List<Goal> goals)
    {
        ListGoals(goals);
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent();
            Console.WriteLine($"You earned {earned} points!");
            return earned;
        }
        else
        {
            Console.WriteLine("Invalid selection.");
            return 0;
        }
    }

    static void SaveGoals(List<Goal> goals, int score)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    static (List<Goal>, int) LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        List<Goal> loadedGoals = new List<Goal>();
        int loadedScore = 0;

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            loadedScore = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] data = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        var sg = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                        sg.SetComplete(bool.Parse(data[3]));
                        loadedGoals.Add(sg);
                        break;
                    case "EternalGoal":
                        loadedGoals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        var cg = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[5]));
                        cg.SetCurrentCount(int.Parse(data[4]));
                        loadedGoals.Add(cg);
                        break;
                }
            }

            Console.WriteLine("Goals loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }

        return (loadedGoals, loadedScore);
    }
}
