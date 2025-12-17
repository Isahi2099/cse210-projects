using System;

public class Swimming : Activity
{
    private int _laps; // 1 lap = 50m

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double meters = _laps * 50;
        double kilometers = meters / 1000.0;
        return kilometers * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
