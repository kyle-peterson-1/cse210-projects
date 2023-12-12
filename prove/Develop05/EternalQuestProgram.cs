using System;
using System.Collections.Generic;
using System.IO;

class EternalQuestProgram
{
    private GoalManager goalManager;
    private int userPoints;

    public EternalQuestProgram()
    {
        userPoints = 0;
        goalManager = new GoalManager(userPoints);
    }

    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            if (lines.Length > 0 && int.TryParse(lines[0], out int loadedUserPoints))
            {
                userPoints = loadedUserPoints;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                Goal loadedGoal = Goal.CreateGoalFromString(lines[i]);

                Goal existingGoal = goalManager.GetGoalByName(loadedGoal.Name);
                if (existingGoal != null)
                {
                    Console.WriteLine($"A goal with the name '{loadedGoal.Name}' already exists.");

                    
                    Console.Write("Do you want to overwrite it? (y/n): ");
                    string overwriteInput = Console.ReadLine();
                    if (overwriteInput.ToLower() != "y")
                    {
                        continue; 
                    }
                }

                goalManager.AddGoal(loadedGoal);
            }
        }
    }

    public void SaveToFile(string fileName)
    {
        
        List<string> lines = new List<string> { userPoints.ToString() };

        
        lines.AddRange(goalManager.GetGoalsAsLines());

        File.WriteAllLines(fileName, lines);
        Console.WriteLine($"Goals saved to '{fileName}'.");
    }

    public void Run()
    {
        while (true)
        {
            DisplayMenu();

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveList();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Quit();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine($"you have {userPoints} points.");
        
        Console.WriteLine("\nEternal Quest Menu:");
        Console.WriteLine("1. Create a new goal");
        Console.WriteLine("2. List goals");
        Console.WriteLine("3. Save list");
        Console.WriteLine("4. Load goals");
        Console.WriteLine("5. Record event");
        Console.WriteLine("6. Quit");
        
    }

    private void CreateNewGoal()
    {
        Console.Write("Enter goal type (simple, eternal, checklist): ");
        string goalType = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string goalName = Console.ReadLine();

        Console.Write("Enter base value: ");
        int baseValue = int.Parse(Console.ReadLine());

        int targetCount = 0;
        int bonusValue = 0;

        if (goalType.ToLower() == "checklist")
        {
            Console.Write("Enter target count: ");
            targetCount = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus value: ");
            bonusValue = int.Parse(Console.ReadLine());
        }

        Goal newGoal = GoalFactory.CreateGoal(goalType, goalName, baseValue, targetCount, bonusValue);
        goalManager.AddGoal(newGoal);

        Console.WriteLine($"New goal created: {goalType} - {goalName}");
    }

    private void ListGoals()
    {
        goalManager.DisplayGoals();
    }

    private void SaveList()
    {
        Console.Write("Enter file name to save: ");
        string fileName = Console.ReadLine();

        goalManager.SaveToFile(fileName);
    }

    private void LoadGoals()
    {
        Console.Write("Enter file name to load: ");
        string fileName = Console.ReadLine();

        LoadFromFile(fileName);
    }

    private void RecordEvent()
    {
        Console.Write("Enter the goal number to record an event: ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex))
        {
            int pointsEarned = goalManager.RecordEvent(goalIndex - 1);
            userPoints += pointsEarned;

            Console.WriteLine($"Event recorded! Earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid goal index.");
        }
    }

    private void Quit()
    {
        Console.WriteLine("Goodbye!");
    }
}

class Program
{
    static void Main()
    {
        EternalQuestProgram program = new EternalQuestProgram();
        program.Run();
    }
}
