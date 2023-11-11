using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percenate: ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        //figure out what the letter grade using if-elde if-else statements
        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Display the letter grade
        Console.WriteLine($"Your letter grade is: {letter}");

        //Check if the user passed the couse
        if (percent >= 70)
        {
            Console.WriteLine("Congradulations! Your passed the course.");
        }
        else
        {
            Console.WriteLine("You'll do better next time!");
        }
    }
}