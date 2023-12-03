// MindfulnessActivity.cs
using System;
using System.Threading;

class MindfulnessActivity
{
    private string activityName;
    private string activityDescription;

    public MindfulnessActivity(string name, string description)
    {
        activityName = name;
        activityDescription = description;
    }

    public string GetActivityName() => activityName;
    protected string ActivityDescription => activityDescription;

    public void StartActivity()
    {
        DisplayStartingMessage();
        Thread.Sleep(3000);
        PerformActivity();
        DisplayFinishingMessage();
    }

    protected virtual void PerformActivity()
    {
        // Base class implementation (to be overridden by subclasses)
    }

    private void DisplayStartingMessage()
    {
        Console.WriteLine($"--- {activityName} ---");
        Console.WriteLine(activityDescription);
        Console.WriteLine("Get ready to begin...");
    }

    private void DisplayFinishingMessage()
    {
        Console.WriteLine($"Good job! You have completed {activityName}.");
        Thread.Sleep(3000);
    }
}
