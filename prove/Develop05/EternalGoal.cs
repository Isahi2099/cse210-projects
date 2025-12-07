using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Never complete. Always gives same points.
        return Points;
    }

    public override string GetDetailsString()
    {
        // Eternal goals never get marked as [X]
        return $"[∞] {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal|name|desc|points
        return $"EternalGoal|{ShortName}|{Description}|{Points}";
    }
}
