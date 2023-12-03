// BreathingActivity.cs
using System;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Start breathing...");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(1000);
        }
    }
}
