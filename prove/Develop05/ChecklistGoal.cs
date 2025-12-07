using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public int TargetCount => _targetCount;
    public int CurrentCount => _currentCount;
    public int BonusPoints => _bonusPoints;

    public ChecklistGoal(string shortName, string description, int points, int targetCount, int bonusPoints)
        : base(shortName, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;

        if (_currentCount < _targetCount)
        {
            return Points;
        }
        else if (_currentCount == _targetCount)
        {
            // Mark as complete and give bonus
            typeof(Goal)
                .GetMethod("MarkComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(this, null);

            return Points + _bonusPoints;
        }
        else
        {
            // Already completed previously
            Console.WriteLine("This checklist goal is already fully completed.");
            return 0;
        }
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete ? "[X]" : "[ ]";
        return $"{checkbox} {ShortName} ({Description}) -- Currently completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal|name|desc|points|bonus|target|current|isComplete
        return $"ChecklistGoal|{ShortName}|{Description}|{Points}|{_bonusPoints}|{_targetCount}|{_currentCount}|{IsComplete}";
    }
}
