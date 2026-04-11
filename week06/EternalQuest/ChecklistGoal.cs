public class ChecklistGoal : Goal
{
    private int _target;
    private int _current;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _current = 0;
    }

    public override int RecordEvent()
    {
        _current++;
        if (_current == _target)
        {
            return _points + _bonus;
        }
        return _points;
    }

    public override bool IsComplete() => _current >= _target;

    public override string GetStatus()
    {
        return $"[{_current}/{_target}]";
    }

    public override string SaveData()
    {
        return $"Checklist|{GetName()}|{GetDescription()}|{_points}|{_target}|{_bonus}|{_current}";
    }
}