using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.",
        0)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountDown(4);
            Console.WriteLine("Now breathe out...");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}
