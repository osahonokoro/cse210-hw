using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base(
        "Reflecting",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.",
        0)
    {
        _prompts = new List<string>
        {
            "Think of a time when you overcame a challenge.",
            "Recall a moment when you helped someone in need.",
            "Reflect on a time when you achieved a personal goal."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "What did you learn about yourself?",
            "How did this experience make you stronger?",
            "What would you do differently next time?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        DisplayPrompt(prompt);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            DisplayQuestions(question);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        int index = rand.Next(_questions.Count);
        return _questions[index];
    }

    private void DisplayPrompt(string prompt)
    {
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
        ShowSpinner(3);
    }

    private void DisplayQuestions(string question)
    {
        Console.Write($"> {question} ");
        ShowSpinner(5);
        Console.WriteLine();
    }
}
