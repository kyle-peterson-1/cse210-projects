class EternalGoal : Goal
{
    public EternalGoal(string name, int baseValue, bool completed = false) : base(name, baseValue)
    {
        this.completed = completed;
    }
    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()}";
    }
    public override int RecordEvent()
    {
        if (!completed)
        {
            
            return BaseValue;
        }
        return 0;
    }
}
