using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Sample scripture
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, " +
            "that whoever believes in him should not perish but have eternal life.");

        do
        {
            Console.Clear();
            scripture.Display(); // Display the scripture
            Console.WriteLine("\nPress Enter to continue or type 'quit' to end.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(2); // Hide 2 random words

        } while (!scripture.AllWordsHidden());
    }
}

// class for the scriptures 
class Scripture
{
    private Reference reference;  
    private List<Word> words;             
    private List<int> hiddenWordIndices;  

    // initialize the scripture
    public Scripture(string referenceText, string scriptureText)
    {
        reference = new Reference(referenceText);
        words = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
        hiddenWordIndices = new List<int>();
    }

    // hide words from the scripture.
    public void Display()
    {
        Console.WriteLine($"{reference.GetDisplayText()}\n");

        for (int i = 0; i < words.Count; i++)
        {
            if (hiddenWordIndices.Contains(i))
                Console.Write("____ "); // Display an underscore for hidden words
            else
                Console.Write($"{words[i].GetDisplayText()} ");
        }

        Console.WriteLine();
    }

    // Hide a specified number of random words in the scripture
    public void HideRandomWords(int count)
    {
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = random.Next(words.Count);
            } while (hiddenWordIndices.Contains(randomIndex));

            hiddenWordIndices.Add(randomIndex);
        }
    }

    // Check if all words in the scripture are hidden
    public bool AllWordsHidden()
    {
        return hiddenWordIndices.Count == words.Count;
    }
}

// Class representing the reference of the scripture
class Reference
{
    private string book;       
    private int chapter;        
    private int startVerse;    
    private int endVerse;      

    public Reference(string book)
    {
        this.book = book;
        this.chapter = 1;
        this.startVerse = 1;
        this.endVerse = 1;
    }

    // Get the display text for the reference
    public string GetDisplayText()
    {
        return $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}

class Word
{
    private string text;

    public Word(string text)
    {
        this.text = text;
    }

    public string GetDisplayText()
    {
        return text;
    }
}