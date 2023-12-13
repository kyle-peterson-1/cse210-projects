//Program 4: Polymorphism with Exercise Tracking

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        RunningActivity runningActivity = new RunningActivity("03 Nov 2022", 30, 3.0);
        CyclingActivity cyclingActivity = new CyclingActivity("03 Nov 2022", 30, 6.0);
        SwimmingActivity swimmingActivity = new SwimmingActivity("03 Nov 2022", 30, 20);

        List<Activity> activities = new List<Activity> { runningActivity, cyclingActivity, swimmingActivity };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

class Activity
{
    private readonly string date;
    protected readonly int minutes;

    public Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        return $"{date} {GetType().Name} ({minutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class RunningActivity : Activity
{
    private readonly double distance;

    public RunningActivity(string date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / minutes * 60;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
}

class CyclingActivity : Activity
{
    private readonly double speed;

    public CyclingActivity(string date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return speed * minutes / 60;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

class SwimmingActivity : Activity
{
    private readonly int laps;

    public SwimmingActivity(string date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / minutes * 60;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
}
