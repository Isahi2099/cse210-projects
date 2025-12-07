using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Only give points the first time it is completed
        if (!IsComplete)
        {
            MarkComplete();
            return Points;
        }
        else
        {
            Console.WriteLine("This goal is already complete.");
            return 0;
        }
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete ? "[X]" : "[ ]";
        return $"{checkbox} {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal|name|desc|points|isComplete
        return $"SimpleGoal|{ShortName}|{Description}|{Points}|{IsComplete}";
    }
}
