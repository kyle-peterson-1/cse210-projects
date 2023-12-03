using System;
using System.Threading;

class MindfulnessActivity
{
    private string activityName;
    private string activityDescription;
    protected int duration;

    public MindfulnessActivity(string name, string description, int userDuration)
    {
        activityName = name;
        activityDescription = description;
        duration = userDuration;
    }

    public string GetActivityName() => activityName;
    protected string ActivityDescription => activityDescription;

    public void StartActivity()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayFinishingMessage();
    }

    protected virtual void PerformActivity()
    {
        RunForSpecifiedDuration();
    }

    private void RunForSpecifiedDuration()
    {
        Console.WriteLine("Activity is running...");
        Thread.Sleep(duration * 1000); 
    }

    private void DisplayStartingMessage()
    {
        Console.WriteLine($"--- {activityName} ---");
        Console.WriteLine(activityDescription);
        Console.WriteLine($"Get ready to begin for {duration} seconds...");
        PauseWithAnimation();
    }

    private void DisplayFinishingMessage()
    {
        Console.WriteLine($"Good job! You have completed {activityName}.");
        Console.WriteLine($"You spent {duration} seconds on {activityName}.");
        PauseWithAnimation();
    }

    protected void PauseWithAnimation()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }
}
