public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _name;

    // Polymorphism: each goal type records progress differently
    public abstract int RecordEvent();

    // Polymorphism: each goal type has different completion rules
    public abstract bool IsComplete();

    // Shows checkbox + name + description (child classes can override if needed)
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }

    // Used for saving to a file (each child class will output its own format)
    public abstract string GetStringRepresentation();
}
