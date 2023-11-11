using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int givenNumber;
        do
        {
            Console.WriteLine("Please enter a number (enter 0 to quit): ");

            string responce = Console.ReadLine();
            givenNumber = int.Parse(responce);

            if (givenNumber != 0)
            {
                numbers.Add(givenNumber);
            }
        }   while (givenNumber != 0);

        // Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        //calculate the average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is {average}");

        //find the max 
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}