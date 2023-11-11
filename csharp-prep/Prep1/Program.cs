using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        // Promt the user for their first name.
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Promt the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        //Display the name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}