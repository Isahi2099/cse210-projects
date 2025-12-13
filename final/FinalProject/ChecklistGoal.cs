public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int bonusPoints, int targetCount, int amountCompleted = 0)
        : base(name, description, points)
    {
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        // If already complete, no more points
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;

        // Award normal points every time
        int earned = _points;

        // If it JUST became complete, add bonus
        if (_amountCompleted >= _targetCount)
        {
            earned += _bonusPoints;
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetCount;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Currently completed: {_amountCompleted}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal|name|description|points|bonus|target|completed
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonusPoints}|{_targetCount}|{_amountCompleted}";
    }

    // Helper for loading from file later
    public static ChecklistGoal FromString(string name, string description, int points, int bonus, int target, int completed)
    {
        return new ChecklistGoal(name, description, points, bonus, target, completed);
    }
}
