using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            
            int choice;
            do
            {
                Console.Write("Enter the number of the activity (or enter 4 to quit): ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4);

            if (choice == 4)
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            Console.Write($"Enter the duration of the selected activity in seconds: ");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.Write("Invalid input. Please enter a positive integer for the duration: ");
            }

            MindfulnessActivity selectedActivity;
            switch (choice)
            {
                case 1:
                    selectedActivity = new BreathingActivity(duration);
                    break;
                case 2:
                    selectedActivity = new ReflectionActivity(duration);
                    break;
                case 3:
                    selectedActivity = new ListingActivity(duration);
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    throw new InvalidOperationException("Invalid choice.");
            }

            selectedActivity.StartActivity();
        }
    }
}
