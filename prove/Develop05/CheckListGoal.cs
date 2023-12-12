class ChecklistGoal : Goal
{
    private int targetCount;
    private int completedCount;
    private int bonusValue;

    public ChecklistGoal(string name, int baseValue, int targetCount, int bonusValue, bool completed = false)
        : base(name, baseValue)
    {
        this.targetCount = targetCount;
        this.bonusValue = bonusValue;
        this.completedCount = completed ? targetCount : 0;
    }

    public override int RecordEvent()
    {
        if (!completed && completedCount < targetCount)
        {
            completedCount++;

            if (completedCount == targetCount)
            {
                completed = true;
                return bonusValue;
            }

            return base.BaseValue;
        }

        return 0;
    }

    public override string DisplayStatus()
    {
        return $"[{completedCount}/{targetCount}]";
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()},{targetCount},{bonusValue}";
    }
}
