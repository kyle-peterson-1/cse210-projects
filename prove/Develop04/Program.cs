// Program.cs
using System;

class Program
{
    static void Main()
    {
        // Create instances of activities
        MindfulnessActivity[] activities = {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };

        // Display menu
        Console.WriteLine("Choose an activity:");
        for (int i = 0; i < activities.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].GetActivityName()}");
        }

        // Get user input
        int choice;
        do
        {
            Console.Write("Enter the number of the activity: ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > activities.Length);

        // Perform the selected activity
        activities[choice - 1].StartActivity();
    }
}
