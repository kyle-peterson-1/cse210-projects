using System;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration)
    {
    }

    protected override void PerformActivity()
    {
        Countdown();
        base.PerformActivity();
    }

    private void Countdown()
    {
        Console.WriteLine("Get ready for deep breathing...");
        Thread.Sleep(1000);

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdownAnimation(5);

            if (DateTime.Now >= endTime)
                break;

            Console.WriteLine("Breathe out...");
            ShowCountdownAnimation(5);
        }
    }

    private void ShowCountdownAnimation(int countdownSeconds)
    {
        for (int i = countdownSeconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
