class SimpleGoal : Goal
{
    public SimpleGoal(string name, int baseValue, bool completed = false) : base(name, baseValue)
    {
        this.completed = completed;
    }
    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()}";
    }
}
