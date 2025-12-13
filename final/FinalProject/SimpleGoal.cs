public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            // already completed, no points
            return 0;
        }

        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal|name|description|points|isComplete
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }

    // Helper for loading from file later
    public static SimpleGoal FromString(string name, string description, int points, bool isComplete)
    {
        return new SimpleGoal(name, description, points, isComplete);
    }
}
