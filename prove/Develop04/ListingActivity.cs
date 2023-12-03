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

    private int itemCount;

    public ListingActivity(int duration) : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration)
    {
        itemCount = 0;
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Start listing items...");

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        Random random = new Random();

        while (DateTime.Now < endTime)
        {
            string prompt = listingPrompts[random.Next(listingPrompts.Length)];
            Console.WriteLine(prompt);

            Console.Write("Enter an item: ");
            string userItem = Console.ReadLine();

            if (!string.IsNullOrEmpty(userItem))
            {
                Console.WriteLine($"You listed: {userItem}");
                itemCount++;
            }

            Thread.Sleep(1000);
        }

        Console.WriteLine($"You came up with {itemCount} items!");
    }
}
