public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete() => false;

    public override string GetStatus()
    {
        return "[∞]";
    }

    public override string SaveData()
    {
        return $"Eternal|{GetName()}|{GetDescription()}|{_points}";
    }
}