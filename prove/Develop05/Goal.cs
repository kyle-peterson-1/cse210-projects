using System;
using System.Collections.Generic;
using System.IO;

class Goal
{
    private string name;
    private int baseValue;
    protected bool completed;

    public string Name { get => name; set => name = value; }
    public int BaseValue { get => baseValue; set => baseValue = value; }
    public bool Completed { get => completed; }

    public Goal(string name, int baseValue)
    {
        Name = name;
        BaseValue = baseValue;
        completed = false;
    }

    public virtual int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return BaseValue;
        }
        return 0;
    }

    public virtual string DisplayStatus()
    {
        return $"[{(completed ? 'X' : ' ')}]";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}:{Name},{BaseValue},{completed}";
    }

    public static Goal CreateGoalFromString(string data)
    {
        try
        {
            string[] parts = data.Split(':');

            if (parts.Length < 2)
            {
                throw new ArgumentException("Invalid data format - Missing parts");
            }

            string typeName = parts[0];
            string[] values = parts[1].Split(',');

            if (values.Length < 3)
            {
                throw new ArgumentException("Invalid data format - Missing values");
            }

            string name = values[0];
            int baseValue = int.Parse(values[1]);
            bool completed = bool.Parse(values[2]);

            switch (typeName)
            {
                case nameof(SimpleGoal):
                    return new SimpleGoal(name, baseValue, completed);
                case nameof(EternalGoal):
                    return new EternalGoal(name, baseValue, completed);
                case nameof(ChecklistGoal):
                    if (values.Length >= 5) // Ensure at least 5 elements for ChecklistGoal
                    {
                        int targetCount = int.Parse(values[3]);
                        int bonusValue = int.Parse(values[4]);
                        return new ChecklistGoal(name, baseValue, targetCount, bonusValue, completed);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid data format for ChecklistGoal - Insufficient values");
                    }
                default:
                    throw new ArgumentException("Invalid goal type");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating goal from string: {ex.Message}\nData: {data}");
            throw;
        }
    }
}
