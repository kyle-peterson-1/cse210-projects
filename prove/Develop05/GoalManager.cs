using System;
using System.Collections.Generic;
using System.Linq;

class GoalManager
{
    private List<Goal> goals;
    private int userPoints;

    public GoalManager(int initialUserPoints)
    {
        goals = new List<Goal>();
        userPoints = initialUserPoints;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].DisplayStatus()} {goals[i].Name}");
        }
    }

    public int RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            int pointsEarned = goals[goalIndex].RecordEvent();
            return pointsEarned;
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
            return 0;
        }
    }

    public int GetGoalsCount()
    {
        return goals.Count;
    }

    public IEnumerable<string> GetGoalsAsLines()
    {
        foreach (var goal in goals)
        {
            yield return goal.GetStringRepresentation();
        }
    }

    public Goal GetGoalByName(string name)
    {
        return goals.FirstOrDefault(goal => goal.Name == name);
    }
    public void SaveToFile(string fileName)
    {
        
        List<string> lines = new List<string> { userPoints.ToString() };

        
        lines.AddRange(goals.Select(goal => goal.GetStringRepresentation()));

        File.WriteAllLines(fileName, lines);
        Console.WriteLine($"Goals saved to '{fileName}'.");
    }
}
