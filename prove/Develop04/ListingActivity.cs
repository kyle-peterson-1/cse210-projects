// ListingActivity.cs
using System;
using System.Threading;

class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Start listing...");
        Random random = new Random();
        string prompt = listingPrompts[random.Next(listingPrompts.Length)];

        Console.WriteLine(prompt);
        Thread.Sleep(3000);

        Console.WriteLine("Start listing items...");

        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"Item {i}: ");
            string item = Console.ReadLine();
        }

        Console.WriteLine("You listed 5 items.");
    }
}
