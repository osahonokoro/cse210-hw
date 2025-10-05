// Enhancement: Added activity counters to track how many times each activity is performed during the session.

using System;

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingCount++;
            }
            else if (choice == "4")
            {
                Console.WriteLine("\nSession Summary:");
                Console.WriteLine($"Breathing Activity: {breathingCount} times");
                Console.WriteLine($"Reflecting Activity: {reflectingCount} times");
                Console.WriteLine($"Listing Activity: {listingCount} times");
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
}
