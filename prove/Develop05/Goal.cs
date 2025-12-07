using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;
    private bool _isComplete;

    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;
    public bool IsComplete => _isComplete;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    protected void MarkComplete()
    {
        _isComplete = true;
    }

    public abstract int RecordEvent();          // Returns points gained
    public abstract string GetDetailsString();  // For listing goals
    public abstract string GetStringRepresentation(); // For saving to file
}
