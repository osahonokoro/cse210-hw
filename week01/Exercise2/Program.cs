using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your score? ");
        string input = Console.ReadLine();
        int userInput = int.Parse(input);

        //Lets ensure the user inputs a valid integer
        if (userInput < 0 || userInput > 100)
        {
            Console.WriteLine("Score must be between 0 and 100.");
            return;
        }

        string letter;
        string sign = "";
        int lastDigit = userInput % 10;

        // Determine letter grade
        if (userInput >= 90)
        {
            letter = "A";
        }
        else if (userInput >= 80)
        {
            letter = "B";
        }
        else if (userInput >= 70)
        {
            letter = "C";
        }
        else if (userInput >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Adding sign only for grades A, B, C, D
        if (letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Word of encouragement to those who failed

        if (letter == "F")
        {
            Console.WriteLine("You failed the course! You can try harder next time. Thanks.");
        }
    }
}
