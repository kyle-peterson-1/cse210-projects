static class GoalFactory
{
    public static Goal CreateGoal(string goalType, string goalName, int baseValue, int targetCount, int bonusValue)
    {
        switch (goalType.ToLower())
        {
            case "simple":
                return new SimpleGoal(goalName, baseValue);
            case "eternal":
                return new EternalGoal(goalName, baseValue);
            case "checklist":
                return new ChecklistGoal(goalName, baseValue, targetCount, bonusValue);
            default:
                throw new ArgumentException("Invalid goal type.");
        }
    }
}
