using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;

    public override double GetDistance()
    {
        return GetSpeed() * (GetMinutes() / 60.0);
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
