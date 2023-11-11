using System;

class Program
{
    static void Main(string[] args)
    {
        //Create a random number
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        int guess = -1;

        while (guess != number)
        {
            Console.WriteLine("I am thinking of a number between 1 and 100. I want you to guess the number I am thinking.");
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (number > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (number < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("thats it!");
                Console.WriteLine("Good job!");
            }
        }
    }

}