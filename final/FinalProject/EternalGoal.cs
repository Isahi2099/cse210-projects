public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Eternal goals never complete, but always give points
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal|name|description|points
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }

    // Helper for loading from file later
    public static EternalGoal FromString(string name, string description, int points)
    {
        return new EternalGoal(name, description, points);
    }
}
